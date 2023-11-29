namespace HostsPinger
{
	internal class ColumnWidth
	{
		private bool _visible = true;

		private int _width = 100;

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				_visible = value;
			}
		}

		public int Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		public ColumnWidth(bool visible, int width)
		{
			_visible = visible;
			_width = width;
		}

		public ColumnWidth()
		{
		}
	}
}
