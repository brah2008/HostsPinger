using System;
using System.IO;

namespace HostsPinger
{
	internal class DefaultLogger : IPingLogger
	{
		private static readonly string LOG_ROW_FORMAT;

		private StreamWriter _fileWriter;

		private static object _syncInstance;

		private static DefaultLogger _instance;

		public static DefaultLogger Instance
		{
			get
			{
				lock (_syncInstance)
				{
					if (_instance == null)
					{
						_instance = new DefaultLogger();
					}
					return _instance;
				}
			}
		}

		static DefaultLogger()
		{
			LOG_ROW_FORMAT = "{0,-21}| ({1,-15}) {2,-30} | {3}";
			_syncInstance = new object();
		}

		public DefaultLogger()
		{
			_fileWriter = new StreamWriter(File.Open("pinger.log", FileMode.Append, FileAccess.Write, FileShare.Read));
		}

		public void Log(HostPinger host, string message)
		{
			PingForm.NotifyMessage(host, message);
			lock (this)
			{
				StreamWriter fileWriter = _fileWriter;
				string lOG_ROW_FORMAT = LOG_ROW_FORMAT;
				object[] arg = new object[4]
				{
					DateTime.Now,
					host.HostIP,
					host.HostName,
					message
				};
				fileWriter.WriteLine(lOG_ROW_FORMAT, arg);
				_fileWriter.Flush();
			}
		}

		public void LogStart(HostPinger host)
		{
			Log(host, "Pinging started");
		}

		public void LogStatusChange(HostPinger host, HostStatus oldStatus, HostStatus newStatus)
		{
			switch (newStatus)
			{
			case HostStatus.Dead:
				Log(host, "Host died!");
				break;
			case HostStatus.Alive:
				Log(host, "Host is now alive!");
				break;
			case HostStatus.DnsError:
				Log(host, "Host name couldn't be resolved (DNS error)!");
				break;
			}
		}

		public void LogStop(HostPinger host)
		{
			Log(host, "Pinging stopped");
		}
	}
}
