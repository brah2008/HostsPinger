using Microsoft.Win32;
using System;
using System.IO;

namespace HostsPinger
{
	internal class Options
	{
		public static readonly string RKN_WINDOWS_RUN;

		public static readonly string RKN_NETPINGER;

		public static readonly string RVN_STAR_WITH_WINDOWS;

		public static readonly string RVN_SHOW_ERROR_MESSAGES;

		public static readonly string RVN_CLEAR_TIMES;

		public static readonly string RVN_START_PINGING;

		public static readonly string RVN_WINDOW_WIDTH;

		public static readonly string RVN_WINDOW_HEIGHT;

		public static readonly string RVN_WINDOW_POS_X;

		public static readonly string RVN_WINDOW_POS_Y;

		public static readonly string RVN_COLUMNS_WIDTHS;

		private static object _syncInstance;

		private static Options _instance;

		private bool _startWithWindows;

		private bool _showErrorMessages;

		private bool _clearTimeStatistics;

		private bool _startPingingOnProgramStart;

		private int _windowsWidth;

		private int _windowsHeight;

		private int _windowPositionX;

		private int _windowPositionY;

		public static readonly int NUMBER_OF_COLUMNS;

		private ColumnWidth[] _columns = new ColumnWidth[NUMBER_OF_COLUMNS];

		private bool _useDefaultColumnsWidths;

		private RegistryKey _key;

		public bool ClearTimeStatistics
		{
			get
			{
				return _clearTimeStatistics;
			}
			set
			{
				if (value != _clearTimeStatistics)
				{
					WriteBoolToRegistry(RVN_CLEAR_TIMES, value);
					_clearTimeStatistics = value;
				}
			}
		}

		public static Options Instance
		{
			get
			{
				lock (_syncInstance)
				{
					if (_instance == null)
					{
						_instance = new Options();
					}
				}
				return _instance;
			}
		}

		public bool ShowErrorMessages
		{
			get
			{
				return _showErrorMessages;
			}
			set
			{
				if (value != _showErrorMessages)
				{
					WriteBoolToRegistry(RVN_SHOW_ERROR_MESSAGES, value);
					_showErrorMessages = value;
				}
			}
		}

		public bool StartPingingOnProgramStart
		{
			get
			{
				return _startPingingOnProgramStart;
			}
			set
			{
				if (_startPingingOnProgramStart != value)
				{
					WriteBoolToRegistry(RVN_START_PINGING, value);
					_startPingingOnProgramStart = value;
				}
			}
		}

		public bool StartWithWindows
		{
			get
			{
				return _startWithWindows;
			}
			set
			{
				if (value != _startWithWindows)
				{
					RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(RKN_WINDOWS_RUN, writable: true);
					if (!value)
					{
						registryKey.DeleteValue(RVN_STAR_WITH_WINDOWS);
					}
					else
					{
						string value2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName);
						registryKey.SetValue(RVN_STAR_WITH_WINDOWS, value2, RegistryValueKind.String);
					}
					registryKey.Close();
					_startWithWindows = value;
				}
			}
		}

		public bool UseDefaultColumnsWidths => _useDefaultColumnsWidths;

		public bool UseDefaultPosition
		{
			get
			{
				if (_windowPositionX == -1)
				{
					return true;
				}
				return _windowPositionY == -1;
			}
		}

		public bool UseDefaultSize
		{
			get
			{
				if (_windowsHeight == -1)
				{
					return true;
				}
				return _windowsWidth == -1;
			}
		}

		public int WindowPositionX
		{
			get
			{
				return _windowPositionX;
			}
			set
			{
				if (value != _windowPositionX)
				{
					WriteIntToRegistry(RVN_WINDOW_POS_X, value);
					_windowPositionX = value;
				}
			}
		}

		public int WindowPositionY
		{
			get
			{
				return _windowPositionY;
			}
			set
			{
				if (value != _windowPositionY)
				{
					WriteIntToRegistry(RVN_WINDOW_POS_Y, value);
					_windowPositionY = value;
				}
			}
		}

		public int WindowsHeight
		{
			get
			{
				return _windowsHeight;
			}
			set
			{
				if (value != _windowsHeight)
				{
					WriteIntToRegistry(RVN_WINDOW_HEIGHT, value);
					_windowsHeight = value;
				}
			}
		}

		public int WindowsWidth
		{
			get
			{
				return _windowsWidth;
			}
			set
			{
				if (value != _windowsWidth)
				{
					WriteIntToRegistry(RVN_WINDOW_WIDTH, value);
					_windowsWidth = value;
				}
			}
		}

		static Options()
		{
			RKN_WINDOWS_RUN = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
			RKN_NETPINGER = "Software\\Gitsoft\\HostsPinger";
			RVN_STAR_WITH_WINDOWS = "netpinger.exe";
			RVN_SHOW_ERROR_MESSAGES = "ShowErrorMessages";
			RVN_CLEAR_TIMES = "ClearTimes";
			RVN_START_PINGING = "StartPinging";
			RVN_WINDOW_WIDTH = "WindowWidth";
			RVN_WINDOW_HEIGHT = "WindowHeight";
			RVN_WINDOW_POS_X = "WindowPosX";
			RVN_WINDOW_POS_Y = "WindowPosY";
			RVN_COLUMNS_WIDTHS = "ColumnsWidths";
			_syncInstance = new object();
			NUMBER_OF_COLUMNS = 24;
		}

		public Options()
		{
			for (int num = NUMBER_OF_COLUMNS - 1; num >= 0; num--)
			{
				_columns[num] = new ColumnWidth();
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(RKN_WINDOWS_RUN);
			_startWithWindows = (registryKey.GetValue(RVN_STAR_WITH_WINDOWS) != null);
			registryKey.Close();
			_key = Registry.CurrentUser.OpenSubKey(RKN_NETPINGER, writable: true);
			if (_key == null)
			{
				_key = Registry.CurrentUser.CreateSubKey(RKN_NETPINGER);
			}
			_showErrorMessages = ReadBoolFromRegistry(RVN_SHOW_ERROR_MESSAGES);
			_clearTimeStatistics = ReadBoolFromRegistry(RVN_CLEAR_TIMES);
			_startPingingOnProgramStart = ReadBoolFromRegistry(RVN_START_PINGING);
			ReadIntFromRegistry(out _windowsWidth, RVN_WINDOW_WIDTH, -1);
			ReadIntFromRegistry(out _windowsHeight, RVN_WINDOW_HEIGHT, -1);
			ReadIntFromRegistry(out _windowPositionX, RVN_WINDOW_POS_X, -1);
			ReadIntFromRegistry(out _windowPositionY, RVN_WINDOW_POS_Y, -1);
			ReadColumnsWidthsFromRegistry();
		}

		~Options()
		{
			_key.Close();
		}

		public int GetColumnWidth(int column)
		{
			if (!_columns[column].Visible)
			{
				return 0;
			}
			return _columns[column].Width;
		}

		public bool GetComlumnVisability(int column)
		{
			return _columns[column].Visible;
		}

		public int GetSavedColumnWidth(int column)
		{
			return _columns[column].Width;
		}

		private bool ReadBoolFromRegistry(string valueName)
		{
			object value = _key.GetValue(valueName);
			if (value == null)
			{
				return false;
			}
			return (int)value != 0;
		}

		private void ReadColumnsWidthsFromRegistry()
		{
			object value = _key.GetValue(RVN_COLUMNS_WIDTHS);
			if (value == null)
			{
				_useDefaultColumnsWidths = true;
				return;
			}
			byte[] array = (byte[])value;
			int num = 0;
			int num2 = 0;
			while (num < array.Length)
			{
				int num3 = num;
				num = num3 + 1;
				_columns[num2].Visible = (array[num3] != 0);
				_columns[num2].Width = BitConverter.ToInt32(array, num);
				num += 4;
				num2++;
			}
		}

		private void ReadIntFromRegistry(out int value, string valueName, int defaultValue)
		{
			object value2 = _key.GetValue(valueName);
			value = ((value2 != null) ? ((int)value2) : defaultValue);
		}

		public void SetColumnVisability(int column, bool visible)
		{
			if (_columns[column].Visible != visible)
			{
				_columns[column].Visible = visible;
				WriteColumnsWidthsToRegistry();
			}
		}

		public void SetColumnWidth(int column, int width)
		{
			if (_columns[column].Width != width)
			{
				if (width >= 1)
				{
					_columns[column].Visible = true;
					_columns[column].Width = width;
				}
				else
				{
					_columns[column].Visible = false;
				}
				WriteColumnsWidthsToRegistry();
			}
		}

		private void WriteBoolToRegistry(string valueName, bool value)
		{
			WriteIntToRegistry(valueName, value ? 1 : 0);
		}

		private void WriteColumnsWidthsToRegistry()
		{
			byte[] array = new byte[NUMBER_OF_COLUMNS * 5];
			int num = 0;
			ColumnWidth[] columns = _columns;
			foreach (ColumnWidth columnWidth in columns)
			{
				byte[] array2 = array;
				int num2 = num;
				num = num2 + 1;
				array2[num2] = (byte)(columnWidth.Visible ? 1 : 0);
				BitConverter.GetBytes(columnWidth.Width).CopyTo(array, num);
				num += 4;
			}
			_key.SetValue(RVN_COLUMNS_WIDTHS, array, RegistryValueKind.Binary);
		}

		private void WriteIntToRegistry(string valueName, int value)
		{
			_key.SetValue(valueName, value, RegistryValueKind.DWord);
		}
	}
}
