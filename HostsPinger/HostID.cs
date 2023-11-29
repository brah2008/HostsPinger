using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HostsPinger
{
	public class HostID : DevExpress.XtraEditors.XtraForm
    {
		private IContainer components;

		private Label label1;

		private TextBox _txtHostID;

		private Button _btnClose;

		private Button _btnCopy;

		public HostID()
		{
			InitializeComponent();
		}

		private void _btnCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(_txtHostID.Text);
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
			label1 = new System.Windows.Forms.Label();
			_txtHostID = new System.Windows.Forms.TextBox();
			_btnClose = new System.Windows.Forms.Button();
			_btnCopy = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 13);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(46, 13);
			label1.TabIndex = 0;
			label1.Text = "&Host ID:";
			_txtHostID.Location = new System.Drawing.Point(13, 30);
			_txtHostID.Name = "_txtHostID";
			_txtHostID.ReadOnly = true;
			_txtHostID.Size = new System.Drawing.Size(259, 20);
			_txtHostID.TabIndex = 1;
			_btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			_btnClose.Location = new System.Drawing.Point(197, 56);
			_btnClose.Name = "_btnClose";
			_btnClose.Size = new System.Drawing.Size(75, 23);
			_btnClose.TabIndex = 3;
			_btnClose.Text = "&Close";
			_btnClose.UseVisualStyleBackColor = true;
			_btnCopy.Location = new System.Drawing.Point(116, 56);
			_btnCopy.Name = "_btnCopy";
			_btnCopy.Size = new System.Drawing.Size(75, 23);
			_btnCopy.TabIndex = 2;
			_btnCopy.Text = "Co&py";
			_btnCopy.UseVisualStyleBackColor = true;
			_btnCopy.Click += new System.EventHandler(_btnCopy_Click);
			base.AcceptButton = _btnClose;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(284, 91);
			base.Controls.Add(_btnCopy);
			base.Controls.Add(_btnClose);
			base.Controls.Add(_txtHostID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "HostID";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Host ID";
			ResumeLayout(performLayout: false);
			PerformLayout();
		}

		public void SetHostID(string id)
		{
			_txtHostID.Text = id;
		}
	}
}
