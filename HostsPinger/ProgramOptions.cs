using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HostsPinger
{
	public class ProgramOptions : DevExpress.XtraEditors.XtraForm
    {
		private IContainer components;

		private CheckedListBox _clColumns;

		private Label label1;

		private Button _btnCancel;

		private Button _btnOK;

		private CheckBox _cbStartWithWindows;

		private CheckBox _cbShowErrorMessages;

		private CheckBox _cbClearTimes;

		private CheckBox _cbStartPinging;

		public bool ClearTimeStatistics => _cbClearTimes.Checked;

		public CheckedListBox SelectedColumns => _clColumns;

		public bool ShowErrorMessages => _cbShowErrorMessages.Checked;

		public bool StartPingingOnProgramStart => _cbStartPinging.Checked;

		public bool StartWithWindows => _cbStartWithWindows.Checked;

		public ProgramOptions()
		{
			InitializeComponent();
			_cbStartWithWindows.Checked = Options.Instance.StartWithWindows;
			_cbShowErrorMessages.Checked = Options.Instance.ShowErrorMessages;
			_cbStartPinging.Checked = Options.Instance.StartPingingOnProgramStart;
			_cbClearTimes.Checked = Options.Instance.ClearTimeStatistics;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			_clColumns = new System.Windows.Forms.CheckedListBox();
			label1 = new System.Windows.Forms.Label();
			_btnCancel = new System.Windows.Forms.Button();
			_btnOK = new System.Windows.Forms.Button();
			_cbStartWithWindows = new System.Windows.Forms.CheckBox();
			_cbShowErrorMessages = new System.Windows.Forms.CheckBox();
			_cbClearTimes = new System.Windows.Forms.CheckBox();
			_cbStartPinging = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			_clColumns.CheckOnClick = true;
			_clColumns.FormattingEnabled = true;
			System.Windows.Forms.CheckedListBox.ObjectCollection items = _clColumns.Items;
			object[] items2 = new object[24]
			{
				"IP Address",
				"Name",
				"Description",
				"Status",
				"Sent Packets",
				"Received Packets",
				"Received Packets %",
				"Lost Packets",
				"Lost Packets %",
				"Last Packet Lost",
				"Received Packets (Recent)",
				"Received Packets % (Recent)",
				"Lost Packets (Recent)",
				"Lost Packets % (Recent)",
				"Current Response Time",
				"Avarge Response Time",
				"Current Status Duration",
				"Alive Status Duration",
				"Dead Status Duration",
				"DNS Error Status Duration",
				"Unknown Status Duration",
				"Host Availability",
				"Total Test Duration",
				"Current Test Duration"
			};
			items.AddRange(items2);
			_clColumns.Location = new System.Drawing.Point(12, 25);
			_clColumns.Name = "_clColumns";
			_clColumns.Size = new System.Drawing.Size(210, 364);
			_clColumns.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(87, 13);
			label1.TabIndex = 7;
			label1.Text = "Display Columns:";
			_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_btnCancel.Location = new System.Drawing.Point(344, 366);
			_btnCancel.Name = "_btnCancel";
			_btnCancel.Size = new System.Drawing.Size(75, 23);
			_btnCancel.TabIndex = 6;
			_btnCancel.Text = "Cancel";
			_btnCancel.UseVisualStyleBackColor = true;
			_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			_btnOK.Location = new System.Drawing.Point(255, 366);
			_btnOK.Name = "_btnOK";
			_btnOK.Size = new System.Drawing.Size(75, 23);
			_btnOK.TabIndex = 5;
			_btnOK.Text = "OK";
			_btnOK.UseVisualStyleBackColor = true;
			_cbStartWithWindows.AutoSize = true;
			_cbStartWithWindows.Location = new System.Drawing.Point(229, 25);
			_cbStartWithWindows.Name = "_cbStartWithWindows";
			_cbStartWithWindows.Size = new System.Drawing.Size(117, 17);
			_cbStartWithWindows.TabIndex = 1;
			_cbStartWithWindows.Text = "Start with Windows";
			_cbStartWithWindows.UseVisualStyleBackColor = true;
			_cbShowErrorMessages.AutoSize = true;
			_cbShowErrorMessages.Location = new System.Drawing.Point(229, 49);
			_cbShowErrorMessages.Name = "_cbShowErrorMessages";
			_cbShowErrorMessages.Size = new System.Drawing.Size(129, 17);
			_cbShowErrorMessages.TabIndex = 2;
			_cbShowErrorMessages.Text = "Show Error Messages";
			_cbShowErrorMessages.UseVisualStyleBackColor = true;
			_cbClearTimes.AutoSize = true;
			_cbClearTimes.Location = new System.Drawing.Point(229, 73);
			_cbClearTimes.Name = "_cbClearTimes";
			_cbClearTimes.Size = new System.Drawing.Size(133, 17);
			_cbClearTimes.TabIndex = 3;
			_cbClearTimes.Text = "Clear Times By Default";
			_cbClearTimes.UseVisualStyleBackColor = true;
			_cbStartPinging.AutoSize = true;
			_cbStartPinging.Location = new System.Drawing.Point(229, 97);
			_cbStartPinging.Name = "_cbStartPinging";
			_cbStartPinging.Size = new System.Drawing.Size(190, 17);
			_cbStartPinging.TabIndex = 4;
			_cbStartPinging.Text = "Start Pinging When Program Starts";
			_cbStartPinging.UseVisualStyleBackColor = true;
			base.AcceptButton = _btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = _btnCancel;
			base.ClientSize = new System.Drawing.Size(431, 405);
			base.Controls.Add(_cbStartPinging);
			base.Controls.Add(_cbClearTimes);
			base.Controls.Add(_cbShowErrorMessages);
			base.Controls.Add(_cbStartWithWindows);
			base.Controls.Add(_btnOK);
			base.Controls.Add(_btnCancel);
			base.Controls.Add(label1);
			base.Controls.Add(_clColumns);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ProgramOptions";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Program Options";
			ResumeLayout(performLayout: false);
			PerformLayout();
		}
	}
}
