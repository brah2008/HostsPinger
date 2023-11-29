using HostsPinger;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using System.Xml;

public class HostPinger
{
	private class OnHostStatusChangeParams
	{
		public HostStatus _oldState;

		public HostStatus _newState;

		public OnHostStatusChangeParams(HostStatus oldStatus, HostStatus newStatus)
		{
			_oldState = oldStatus;
			_newState = newStatus;
		}
	}

	public const int NUMBER_OF_STATUSES = 4;

	public readonly string XML_ELEMENT_NAME_HOST = "host";

	private static int _nextID = 0;

	private int _id;

	public readonly string XML_ELEMENT_NAME_HOST_IP = "ip";

	private IPAddress _hostIP;

	public readonly string XML_ELEMENT_NAME_HOST_NAME = "name";

	private string _hostName = string.Empty;

	public readonly string XML_ELEMENT_NAME_HOST_DESCRIPTION = "description";

	private string _hostDescription = string.Empty;

	private HostStatus _status = HostStatus.Unknown;

	private int _continousPacketLost;

	private int _sentPackets;

	private int _recivedPackets;

	private int _lostPackets;

	private bool _lastPacketLost;

	private long _currentResponseTime;

	private long _totalResponseTime;

	private DateTime _statusReachedAt = DateTime.Now;

	private TimeSpan[] _statusDurations = new TimeSpan[4];

	private DateTime _startTime = DateTime.Now;

	private TimeSpan _totalTestDuration;

	public readonly string XML_ELEMENT_NAME_TTL = "ttl";

	public static readonly int DEFAULT_TTL = 32;

	private int _ttl = DEFAULT_TTL;

	public readonly string XML_ELEMENT_NAME_FRAGMENT = "dontfragment";

	public static readonly bool DEFALUT_FRAGMENT = false;

	private bool _dontFragment;

	public readonly string XML_ELEMENT_NAME_BUFFER_SIZE = "buffersize";

	public static readonly int DEFAULT_BUFFER_SIZE = 32;

	private int _bufferSize = DEFAULT_BUFFER_SIZE;

	public readonly string XML_ELEMENT_NAME_TIMEOUT = "timeout";

	public static readonly int DEFAULT_TIMEOUT = 2000;

	private int _timeout = DEFAULT_TIMEOUT;

	public readonly string XML_ELEMENT_NAME_PING_INTERVAL = "interval";

	public static readonly int DEFAULT_PING_INTERVAL = 1000;

	private int _pingInterval = DEFAULT_PING_INTERVAL;

	public readonly string XML_ELEMENT_NAME_DNS_QUERY_INTERVAL = "dnsinterval";

	public static readonly int DEFAULT_DNS_QUERY_INTERVAL = 60000;

	private int _dnsQueryInterval = DEFAULT_DNS_QUERY_INTERVAL;

	public readonly string XML_ELEMENT_NAME_PINGS_BEFORE_DEAD = "pingsbeforedead";

	public static readonly int DEFALUT_PINGS_BEFORE_DEAD = 10;

	private int _pingsBeforeDead = DEFALUT_PINGS_BEFORE_DEAD;

	public readonly string XML_ELEMENT_NAME_RECENT_HISTORY_DEPTH = "recenthistorydepth";

	private byte[] _buffer = new byte[DEFAULT_BUFFER_SIZE];

	private System.Timers.Timer _timer = new System.Timers.Timer();

	private Ping _pinger = new Ping();

	private PingOptions _pingerOptions = new PingOptions(DEFAULT_TTL, DEFALUT_FRAGMENT);

	private PingResultsBuffer _recentHistory = new PingResultsBuffer();

	private object _syncObject = new object();

	private IPingLogger _logger;

	private bool _isRunning;

	private bool _activePing;

	public int ID => _id;

	public IPAddress HostIP
	{
		get
		{
			lock (_syncObject)
			{
				return (_hostIP != null) ? _hostIP : new IPAddress(0L);
			}
		}
		set
		{
			lock (_syncObject)
			{
				_hostIP = value;
				if (_status == HostStatus.DnsError)
				{
					Status = HostStatus.Unknown;
				}
			}
		}
	}

	public string HostName
	{
		get
		{
			lock (_syncObject)
			{
				return _hostName;
			}
		}
		set
		{
			lock (_syncObject)
			{
				_hostName = value;
			}
		}
	}

	public string HostDescription
	{
		get
		{
			lock (_syncObject)
			{
				return _hostDescription;
			}
		}
		set
		{
			lock (_syncObject)
			{
				_hostDescription = value;
			}
		}
	}

	public HostStatus Status
	{
		get
		{
			lock (_syncObject)
			{
				return _isRunning ? _status : HostStatus.Unknown;
			}
		}
		private set
		{
			if (_status != value || _status == HostStatus.Unknown)
			{
				DateTime now = DateTime.Now;
				TimeSpan timeSpan = now - _statusReachedAt;
				if (_isRunning)
				{
					_statusDurations[(int)_status] += timeSpan;
				}
				_statusReachedAt = now;
				HostStatus status = _status;
				_status = value;
				ThreadPool.QueueUserWorkItem(RaiseOnStatusChange, new OnHostStatusChangeParams(status, _status));
			}
		}
	}

	public int SentPackets
	{
		get
		{
			lock (_syncObject)
			{
				return _sentPackets;
			}
		}
	}

	public int RecivedPackets
	{
		get
		{
			lock (_syncObject)
			{
				return _recivedPackets;
			}
		}
	}

	public float RecivedPacketsPercent
	{
		get
		{
			lock (_syncObject)
			{
				return (float)_recivedPackets / (float)_sentPackets * 100f;
			}
		}
	}

	public int LostPackets
	{
		get
		{
			lock (_syncObject)
			{
				return _lostPackets;
			}
		}
	}

	public float LostPacketsPercent
	{
		get
		{
			lock (_syncObject)
			{
				return (float)_lostPackets / (float)_sentPackets * 100f;
			}
		}
	}

	public bool LastPacketLost
	{
		get
		{
			lock (_syncObject)
			{
				return _lastPacketLost;
			}
		}
	}

	public int RecentlyRecivedPackets
	{
		get
		{
			lock (_syncObject)
			{
				return _recentHistory.RecivedCount;
			}
		}
	}

	public float RecentlyRecivedPacketsPercent
	{
		get
		{
			lock (_syncObject)
			{
				return _recentHistory.RecivedCountPercent;
			}
		}
	}

	public int RecentlyLostPackets
	{
		get
		{
			lock (_syncObject)
			{
				return _recentHistory.LostCount;
			}
		}
	}

	public float RecentlyLostPacketsPercent
	{
		get
		{
			lock (_syncObject)
			{
				return _recentHistory.LostCountPercent;
			}
		}
	}

	public long CurrentResponseTime
	{
		get
		{
			lock (_syncObject)
			{
				return _currentResponseTime;
			}
		}
	}

	public float AvargeResponseTime
	{
		get
		{
			lock (_syncObject)
			{
				return (_recivedPackets != 0) ? ((float)_totalResponseTime / (float)_recivedPackets) : 0f;
			}
		}
	}

	public TimeSpan CurrentStatusDuration
	{
		get
		{
			lock (_syncObject)
			{
				return DateTime.Now.Subtract(_statusReachedAt);
			}
		}
	}

	public float HostAvailability
	{
		get
		{
			lock (_syncObject)
			{
				long num = _totalTestDuration.Ticks;
				long num2 = _statusDurations[1].Ticks;
				if (_isRunning)
				{
					DateTime now = DateTime.Now;
					num += now.Subtract(_startTime).Ticks;
					if (_status == HostStatus.Alive)
					{
						num2 += (now - _statusReachedAt).Ticks;
					}
				}
				return (float)((double)num2 / (double)num * 100.0);
			}
		}
	}

	public TimeSpan CurrentTestDuration
	{
		get
		{
			lock (_syncObject)
			{
				return _isRunning ? DateTime.Now.Subtract(_startTime) : new TimeSpan(0L);
			}
		}
	}

	public TimeSpan TotalTestDuration
	{
		get
		{
			lock (_syncObject)
			{
				return _isRunning ? (_totalTestDuration + DateTime.Now.Subtract(_startTime)) : _totalTestDuration;
			}
		}
	}

	public int TTL
	{
		get
		{
			lock (_syncObject)
			{
				return _ttl;
			}
		}
		set
		{
			lock (_syncObject)
			{
				if (value > 0 && value != _ttl)
				{
					_ttl = value;
					_pingerOptions.Ttl = value;
				}
			}
		}
	}

	public bool DontFragment
	{
		get
		{
			lock (_syncObject)
			{
				return _dontFragment;
			}
		}
		set
		{
			lock (_syncObject)
			{
				if (value != _dontFragment)
				{
					_dontFragment = value;
					_pingerOptions.DontFragment = value;
				}
			}
		}
	}

	public int BufferSize
	{
		get
		{
			lock (_syncObject)
			{
				return _bufferSize;
			}
		}
		set
		{
			lock (_syncObject)
			{
				if (value > 0)
				{
					_bufferSize = value;
					_buffer = new byte[value];
				}
			}
		}
	}

	public int Timeout
	{
		get
		{
			lock (_syncObject)
			{
				return _timeout;
			}
		}
		set
		{
			lock (_syncObject)
			{
				_timeout = value;
			}
		}
	}

	public int PingInterval
	{
		get
		{
			lock (_syncObject)
			{
				return _pingInterval;
			}
		}
		set
		{
			lock (_syncObject)
			{
				_pingInterval = value;
			}
		}
	}

	public int DnsQueryInterval
	{
		get
		{
			lock (_syncObject)
			{
				return _dnsQueryInterval;
			}
		}
		set
		{
			lock (_syncObject)
			{
				_dnsQueryInterval = value;
			}
		}
	}

	public int PingsBeforeDead
	{
		get
		{
			lock (_syncObject)
			{
				return _pingsBeforeDead;
			}
		}
		set
		{
			lock (_syncObject)
			{
				_pingsBeforeDead = value;
			}
		}
	}

	public int RecentHisoryDepth
	{
		get
		{
			lock (_syncObject)
			{
				return _recentHistory.BufferSize;
			}
		}
		set
		{
			lock (_syncObject)
			{
				_recentHistory.BufferSize = value;
			}
		}
	}

	public IPingLogger Logger
	{
		get
		{
			lock (_syncObject)
			{
				return _logger;
			}
		}
		set
		{
			lock (_syncObject)
			{
				_logger = value;
			}
		}
	}

	public bool IsRunning
	{
		get
		{
			lock (_syncObject)
			{
				return _isRunning;
			}
		}
		set
		{
			if (value)
			{
				Start();
			}
			else
			{
				Stop();
			}
		}
	}

	public event OnPingDelegate OnPing;

	public event OnHostStatusChangeDelegate OnStatusChange;

	public event OnHostPingerCommandDelegate OnStartPinging;

	public event OnHostPingerCommandDelegate OnStopPinging;

	private void AssignID()
	{
		_id = Interlocked.Increment(ref _nextID);
	}

	public TimeSpan GetStatusDuration(HostStatus status)
	{
		lock (_syncObject)
		{
			TimeSpan timeSpan = _statusDurations[(int)status];
			if (_status == status && _isRunning)
			{
				timeSpan += DateTime.Now - _statusReachedAt;
			}
			return timeSpan;
		}
	}

	private void IncLost()
	{
		_sentPackets++;
		_lostPackets++;
		_lastPacketLost = true;
		_recentHistory.AddPingResult(recived: false);
		if (++_continousPacketLost > _pingsBeforeDead && _status != 0)
		{
			Status = HostStatus.Dead;
		}
	}

	private void IncRecived(long time)
	{
		_sentPackets++;
		_recivedPackets++;
		_lastPacketLost = false;
		_recentHistory.AddPingResult(recived: true);
		_totalResponseTime += time;
		_currentResponseTime = time;
		_continousPacketLost = 0;
		if (_status != HostStatus.Alive)
		{
			Status = HostStatus.Alive;
		}
	}

	public void ClearStatistics(bool clearTimes)
	{
		lock (_syncObject)
		{
			_sentPackets = 0;
			_recivedPackets = 0;
			_lostPackets = 0;
			_currentResponseTime = 0L;
			_totalResponseTime = 0L;
			_continousPacketLost = 0;
			_lastPacketLost = false;
			_recentHistory.Clear();
			if (clearTimes)
			{
				_statusReachedAt = DateTime.Now;
				_startTime = DateTime.Now;
				for (int num = _statusDurations.Length - 1; num >= 0; num--)
				{
					_statusDurations[num] = new TimeSpan(0L);
				}
			}
		}
	}

	private void RaiseOnPing()
	{
		if (this.OnPing != null)
		{
			this.OnPing(this);
		}
	}

	private void RaiseOnStatusChange(object param)
	{
		OnHostStatusChangeParams onHostStatusChangeParams = (OnHostStatusChangeParams)param;
		if (_logger != null)
		{
			_logger.LogStatusChange(this, onHostStatusChangeParams._oldState, onHostStatusChangeParams._newState);
		}
		if (this.OnStatusChange != null)
		{
			this.OnStatusChange(this, onHostStatusChangeParams._oldState, onHostStatusChangeParams._newState);
		}
	}

	private void RaiseOnStartPinging()
	{
		if (_logger != null)
		{
			_logger.LogStart(this);
		}
		if (this.OnStartPinging != null)
		{
			this.OnStartPinging(this);
		}
	}

	private void RaiseOnStopPinging()
	{
		if (_logger != null)
		{
			_logger.LogStop(this);
		}
		if (this.OnStopPinging != null)
		{
			this.OnStopPinging(this);
		}
	}

	public HostPinger()
	{
		AssignID();
		_hostIP = new IPAddress(new byte[4]
		{
			127,
			0,
			0,
			1
		});
		_hostName = "localhost";
	}

	public HostPinger(XmlNode xmlNode)
	{
		AssignID();
		if (xmlNode[XML_ELEMENT_NAME_HOST_NAME] != null)
		{
			HostName = xmlNode[XML_ELEMENT_NAME_HOST_NAME].InnerText;
		}
		else
		{
			HostName = "No Name";
		}
		if (xmlNode[XML_ELEMENT_NAME_HOST_IP] != null)
		{
			HostIP = IPAddress.Parse(xmlNode[XML_ELEMENT_NAME_HOST_IP].InnerText);
		}
		else
		{
			try
			{
				_hostIP = GetHostIpByName(_hostName);
			}
			catch
			{
				Status = HostStatus.DnsError;
			}
		}
		if (xmlNode[XML_ELEMENT_NAME_HOST_DESCRIPTION] != null)
		{
			HostDescription = xmlNode[XML_ELEMENT_NAME_HOST_DESCRIPTION].InnerText;
		}
		if (xmlNode[XML_ELEMENT_NAME_TIMEOUT] != null)
		{
			Timeout = int.Parse(xmlNode[XML_ELEMENT_NAME_TIMEOUT].InnerText);
		}
		if (xmlNode[XML_ELEMENT_NAME_PING_INTERVAL] != null)
		{
			PingInterval = int.Parse(xmlNode[XML_ELEMENT_NAME_PING_INTERVAL].InnerText);
		}
		if (xmlNode[XML_ELEMENT_NAME_DNS_QUERY_INTERVAL] != null)
		{
			DnsQueryInterval = int.Parse(xmlNode[XML_ELEMENT_NAME_DNS_QUERY_INTERVAL].InnerText);
		}
		if (xmlNode[XML_ELEMENT_NAME_PINGS_BEFORE_DEAD] != null)
		{
			PingsBeforeDead = int.Parse(xmlNode[XML_ELEMENT_NAME_PINGS_BEFORE_DEAD].InnerText);
		}
		if (xmlNode[XML_ELEMENT_NAME_BUFFER_SIZE] != null)
		{
			BufferSize = int.Parse(xmlNode[XML_ELEMENT_NAME_BUFFER_SIZE].InnerText);
		}
		if (xmlNode[XML_ELEMENT_NAME_RECENT_HISTORY_DEPTH] != null)
		{
			RecentHisoryDepth = int.Parse(xmlNode[XML_ELEMENT_NAME_RECENT_HISTORY_DEPTH].InnerText);
		}
		if (xmlNode[XML_ELEMENT_NAME_TTL] != null)
		{
			TTL = int.Parse(xmlNode[XML_ELEMENT_NAME_TTL].InnerText);
		}
		if (xmlNode[XML_ELEMENT_NAME_FRAGMENT] != null)
		{
			DontFragment = bool.Parse(xmlNode[XML_ELEMENT_NAME_FRAGMENT].InnerText);
		}
		InitTimer();
	}

	public HostPinger(string hostName)
	{
		AssignID();
		_hostName = hostName;
		try
		{
			_hostIP = GetHostIpByName(_hostName);
		}
		catch
		{
			Status = HostStatus.DnsError;
		}
		InitTimer();
	}

	public HostPinger(IPAddress address)
	{
		AssignID();
		_hostName = "No Name";
		_hostIP = address;
		InitTimer();
	}

	public HostPinger(string hostName, IPAddress address)
	{
		AssignID();
		_hostName = hostName;
		_hostIP = address;
		InitTimer();
	}

	private IPAddress GetHostIpByName(string name)
	{
		IPHostEntry hostEntry;
		try
		{
			hostEntry = Dns.GetHostEntry(_hostName);
		}
		catch (Exception innerException)
		{
			throw new Exception("Error connecting DNS for " + _hostName + " host", innerException);
		}
		if (hostEntry != null)
		{
			return hostEntry.AddressList[0];
		}
		throw new Exception("Cannot resolve host \"" + _hostName + "\" IP by its name.");
	}

	public void Save(XmlWriter writer)
	{
		writer.WriteStartElement(XML_ELEMENT_NAME_HOST);
		lock (_syncObject)
		{
			writer.WriteElementString(XML_ELEMENT_NAME_HOST_NAME, _hostName);
			if (_hostIP != null)
			{
				writer.WriteElementString(XML_ELEMENT_NAME_HOST_IP, _hostIP.ToString());
			}
			writer.WriteElementString(XML_ELEMENT_NAME_HOST_DESCRIPTION, _hostDescription);
			writer.WriteElementString(XML_ELEMENT_NAME_TIMEOUT, _timeout.ToString());
			writer.WriteElementString(XML_ELEMENT_NAME_PING_INTERVAL, _pingInterval.ToString());
			writer.WriteElementString(XML_ELEMENT_NAME_DNS_QUERY_INTERVAL, _dnsQueryInterval.ToString());
			writer.WriteElementString(XML_ELEMENT_NAME_PINGS_BEFORE_DEAD, _pingsBeforeDead.ToString());
			writer.WriteElementString(XML_ELEMENT_NAME_RECENT_HISTORY_DEPTH, _recentHistory.BufferSize.ToString());
			writer.WriteElementString(XML_ELEMENT_NAME_BUFFER_SIZE, _bufferSize.ToString());
			writer.WriteElementString(XML_ELEMENT_NAME_TTL, _ttl.ToString());
			writer.WriteElementString(XML_ELEMENT_NAME_FRAGMENT, _dontFragment.ToString());
		}
		writer.WriteEndElement();
	}

	private void InitTimer()
	{
		_timer.AutoReset = false;
		_timer.Elapsed += _timer_Elapsed;
	}

	private void _timer_Elapsed(object sender, ElapsedEventArgs e)
	{
		Pinger();
	}

	public void Start()
	{
		bool flag = false;
		Monitor.Enter(_syncObject);
		if (!_isRunning)
		{
			_startTime = DateTime.Now;
			if (_status != HostStatus.DnsError)
			{
				Status = HostStatus.Unknown;
			}
			flag = (_isRunning = true);
			if (!_activePing)
			{
				_activePing = true;
				_timer.Interval = _pingInterval;
				_timer.Start();
			}
		}
		Monitor.Exit(_syncObject);
		if (flag)
		{
			RaiseOnStartPinging();
		}
	}

	public void Stop()
	{
		bool flag = false;
		lock (_syncObject)
		{
			if (_isRunning)
			{
				_continousPacketLost = 0;
				if (_status != HostStatus.DnsError)
				{
					Status = HostStatus.Unknown;
				}
				_totalTestDuration += DateTime.Now - _startTime;
				_isRunning = false;
				flag = true;
			}
		}
		if (flag)
		{
			RaiseOnStopPinging();
		}
	}

	private void Pinger()
	{
		bool flag;
		lock (_syncObject)
		{
			flag = (_status != HostStatus.DnsError);
		}
		if (!flag)
		{
			try
			{
				IPAddress hostIpByName = GetHostIpByName(HostName);
				lock (_syncObject)
				{
					if (_status == HostStatus.DnsError && _isRunning)
					{
						_hostIP = hostIpByName;
						Status = HostStatus.Unknown;
					}
				}
			}
			catch
			{
				lock (_syncObject)
				{
					if (_isRunning)
					{
						_activePing = true;
						_timer.Interval = _dnsQueryInterval;
						_timer.Start();
					}
					else
					{
						_activePing = false;
					}
				}
				RaiseOnPing();
				return;
			}
		}
		IPAddress hostIP;
		int timeout;
		byte[] buffer;
		PingOptions pingerOptions;
		lock (_syncObject)
		{
			hostIP = _hostIP;
			timeout = _timeout;
			buffer = _buffer;
			pingerOptions = _pingerOptions;
		}
		PingReply pingReply = _pinger.Send(hostIP, timeout, buffer, pingerOptions);
		lock (_syncObject)
		{
			flag = false;
			if (_isRunning)
			{
				if (hostIP == _hostIP)
				{
					switch (pingReply.Status)
					{
					case IPStatus.BadOption:
					case IPStatus.PacketTooBig:
					case IPStatus.BadRoute:
					case IPStatus.ParameterProblem:
					case IPStatus.BadDestination:
					case IPStatus.BadHeader:
					case IPStatus.UnrecognizedNextHeader:
						IncLost();
						break;
					case IPStatus.Unknown:
					case IPStatus.NoResources:
					case IPStatus.HardwareError:
					case IPStatus.SourceQuench:
					case IPStatus.IcmpError:
					case IPStatus.DestinationScopeMismatch:
						IncLost();
						break;
					case IPStatus.DestinationNetworkUnreachable:
					case IPStatus.DestinationHostUnreachable:
					case IPStatus.DestinationProtocolUnreachable:
					case IPStatus.DestinationPortUnreachable:
					case IPStatus.DestinationUnreachable:
						IncLost();
						break;
					case IPStatus.TimedOut:
					case IPStatus.TtlExpired:
					case IPStatus.TtlReassemblyTimeExceeded:
					case IPStatus.TimeExceeded:
						IncLost();
						break;
					case IPStatus.Success:
						IncRecived(pingReply.RoundtripTime);
						break;
					default:
						IncLost();
						break;
					}
					flag = true;
				}
				_activePing = true;
				_timer.Interval = _pingInterval;
				_timer.Start();
			}
			else
			{
				_activePing = false;
			}
		}
		if (flag)
		{
			RaiseOnPing();
		}
	}
}
