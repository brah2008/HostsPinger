using System.Collections.Generic;

namespace HostsPinger
{
	public class PingResultsBuffer
	{
		private class Entry
		{
			public bool _recived;

			public int _count;

			public Entry(bool recived, int count)
			{
				_recived = recived;
				_count = count;
			}
		}

		private List<Entry> _buffer = new List<Entry>();

		private object _syncObject = new object();

		public static readonly int DEFAULT_BUFFER_SIZE;

		private int _bufferSize = DEFAULT_BUFFER_SIZE;

		private int _currentSize;

		private int _lostCount;

		private int _recivedCount;

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
					if (value < 0)
					{
						value = 0;
					}
					if (value <= _bufferSize)
					{
						int num = _currentSize - value;
						while (num > 0)
						{
							Entry entry = _buffer[0];
							if (entry._count > num)
							{
								entry._count -= num;
								DecCount(entry._recived, num);
								num = 0;
							}
							else
							{
								_buffer.RemoveAt(0);
								DecCount(entry._recived, entry._count);
								num -= entry._count;
							}
						}
						if (_currentSize > value)
						{
							_currentSize = value;
						}
						_bufferSize = value;
					}
					else
					{
						_bufferSize = value;
					}
				}
			}
		}

		public int CurrentSize
		{
			get
			{
				lock (_syncObject)
				{
					return _currentSize;
				}
			}
		}

		public int LostCount
		{
			get
			{
				lock (_syncObject)
				{
					return _lostCount;
				}
			}
		}

		public float LostCountPercent
		{
			get
			{
				lock (_syncObject)
				{
					return (float)_lostCount / (float)_currentSize * 100f;
				}
			}
		}

		public int RecivedCount
		{
			get
			{
				lock (_syncObject)
				{
					return _recivedCount;
				}
			}
		}

		public float RecivedCountPercent
		{
			get
			{
				lock (_syncObject)
				{
					return (float)_recivedCount / (float)_currentSize * 100f;
				}
			}
		}

		static PingResultsBuffer()
		{
			DEFAULT_BUFFER_SIZE = 100;
		}

		public PingResultsBuffer(int size)
		{
			_bufferSize = size;
		}

		public PingResultsBuffer()
		{
		}

		public void AddPingResult(bool recived)
		{
			if (_bufferSize >= 1)
			{
				lock (_syncObject)
				{
					if (_currentSize >= _bufferSize)
					{
						Entry entry = _buffer[0];
						entry._count--;
						DecCount(entry._recived, 1);
						if (entry._count == 0)
						{
							_buffer.RemoveAt(0);
						}
						goto IL_00d4;
					}
					if (_currentSize != 0)
					{
						_currentSize++;
						goto IL_00d4;
					}
					_buffer.Add(new Entry(recived, 1));
					IncCount(recived);
					_currentSize++;
					goto end_IL_0022;
					IL_00d4:
					Entry entry2 = _buffer[_buffer.Count - 1];
					if (entry2._recived != recived)
					{
						_buffer.Add(new Entry(recived, 1));
					}
					else
					{
						entry2._count++;
					}
					IncCount(recived);
					end_IL_0022:;
				}
			}
		}

		public void Clear()
		{
			lock (_syncObject)
			{
				_currentSize = 0;
				_lostCount = 0;
				_recivedCount = 0;
				_buffer.Clear();
			}
		}

		private void DecCount(bool recived, int count)
		{
			if (recived)
			{
				_recivedCount -= count;
			}
			else
			{
				_lostCount -= count;
			}
		}

		private void IncCount(bool recived)
		{
			if (recived)
			{
				_recivedCount++;
			}
			else
			{
				_lostCount++;
			}
		}
	}
}
