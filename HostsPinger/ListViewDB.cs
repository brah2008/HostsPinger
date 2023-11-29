using System.Windows.Forms;

namespace HostsPinger
{
	public class ListViewDB : ListView
	{
		public ListViewDB()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		}
	}
}
