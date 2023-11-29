using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace HostsPinger
{
	public class ProxyOptions : DevExpress.XtraEditors.XtraForm
    {
		private bool _cancel;

		private IContainer components;

		private TextBox _txtProxyAddress;

		private TextBox _txtProxyPort;

		private Label _lblProxyAddress;

		private Label _lblProxyPort;

		private CheckBox _chkUseProxy;

		private Button _btnCancel;

		private Button _btnOK;

		public string ProxyAddress
		{
			get
			{
				return _txtProxyAddress.Text;
			}
			set
			{
				_txtProxyAddress.Text = value;
			}
		}

		public int ProxyPort
		{
            get
			{
                int result;
                int.TryParse(_txtProxyPort.Text, out  result);
				return result;
			}
			set
			{
				_txtProxyPort.Text = value.ToString();
			}
		}

		public bool UseProxy
		{
			get
			{
				return _chkUseProxy.Checked;
			}
			set
			{
				_chkUseProxy.Checked = value;
			}
		}

		public ProxyOptions()
		{
			InitializeComponent();
		}

		private void _btnCancel_Click(object sender, EventArgs e)
		{
			_cancel = true;
		}

		private void _chkUseProxy_CheckedChanged(object sender, EventArgs e)
		{
			Label lblProxyAddress = _lblProxyAddress;
			Label lblProxyPort = _lblProxyPort;
			TextBox txtProxyAddress = _txtProxyAddress;
			TextBox txtProxyPort = _txtProxyPort;
			bool flag = txtProxyPort.Enabled = _chkUseProxy.Checked;
			bool flag3 = txtProxyAddress.Enabled = flag;
			bool enabled = lblProxyPort.Enabled = flag3;
			lblProxyAddress.Enabled = enabled;
		}

		private void _txtProxyPort_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
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
			_txtProxyAddress = new System.Windows.Forms.TextBox();
			_txtProxyPort = new System.Windows.Forms.TextBox();
			_lblProxyAddress = new System.Windows.Forms.Label();
			_lblProxyPort = new System.Windows.Forms.Label();
			_chkUseProxy = new System.Windows.Forms.CheckBox();
			_btnCancel = new System.Windows.Forms.Button();
			_btnOK = new System.Windows.Forms.Button();
			SuspendLayout();
			_txtProxyAddress.Enabled = false;
			_txtProxyAddress.Location = new System.Drawing.Point(94, 12);
			_txtProxyAddress.Name = "_txtProxyAddress";
			_txtProxyAddress.Size = new System.Drawing.Size(179, 20);
			_txtProxyAddress.TabIndex = 1;
			_txtProxyPort.Enabled = false;
			_txtProxyPort.Location = new System.Drawing.Point(94, 39);
			_txtProxyPort.MaxLength = 5;
			_txtProxyPort.Name = "_txtProxyPort";
			_txtProxyPort.Size = new System.Drawing.Size(179, 20);
			_txtProxyPort.TabIndex = 3;
			_txtProxyPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_txtProxyPort_KeyPress);
			_lblProxyAddress.AutoSize = true;
			_lblProxyAddress.Enabled = false;
			_lblProxyAddress.Location = new System.Drawing.Point(12, 16);
			_lblProxyAddress.Name = "_lblProxyAddress";
			_lblProxyAddress.Size = new System.Drawing.Size(76, 13);
			_lblProxyAddress.TabIndex = 0;
			_lblProxyAddress.Text = "Proxy &address:";
			_lblProxyPort.AutoSize = true;
			_lblProxyPort.Enabled = false;
			_lblProxyPort.Location = new System.Drawing.Point(12, 43);
			_lblProxyPort.Name = "_lblProxyPort";
			_lblProxyPort.Size = new System.Drawing.Size(57, 13);
			_lblProxyPort.TabIndex = 2;
			_lblProxyPort.Text = "Proxy &port:";
			_chkUseProxy.AutoSize = true;
			_chkUseProxy.Location = new System.Drawing.Point(94, 66);
			_chkUseProxy.Name = "_chkUseProxy";
			_chkUseProxy.Size = new System.Drawing.Size(105, 17);
			_chkUseProxy.TabIndex = 4;
			_chkUseProxy.Text = "&Use proxy server";
			_chkUseProxy.UseVisualStyleBackColor = true;
			_chkUseProxy.CheckedChanged += new System.EventHandler(_chkUseProxy_CheckedChanged);
			_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_btnCancel.Location = new System.Drawing.Point(198, 99);
			_btnCancel.Name = "_btnCancel";
			_btnCancel.Size = new System.Drawing.Size(75, 23);
			_btnCancel.TabIndex = 6;
			_btnCancel.Text = "&Cancel";
			_btnCancel.UseVisualStyleBackColor = true;
			_btnCancel.Click += new System.EventHandler(_btnCancel_Click);
			_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			_btnOK.Location = new System.Drawing.Point(117, 99);
			_btnOK.Name = "_btnOK";
			_btnOK.Size = new System.Drawing.Size(75, 23);
			_btnOK.TabIndex = 5;
			_btnOK.Text = "&OK";
			_btnOK.UseVisualStyleBackColor = true;
			base.AcceptButton = _btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = _btnCancel;
			base.ClientSize = new System.Drawing.Size(285, 134);
			base.Controls.Add(_btnOK);
			base.Controls.Add(_btnCancel);
			base.Controls.Add(_chkUseProxy);
			base.Controls.Add(_lblProxyPort);
			base.Controls.Add(_lblProxyAddress);
			base.Controls.Add(_txtProxyPort);
			base.Controls.Add(_txtProxyAddress);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ProxyOptions";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Proxy Options";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ProxyOptions_FormClosing);
			ResumeLayout(performLayout: false);
			PerformLayout();
		}

		private void ProxyOptions_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_cancel || !_chkUseProxy.Checked || (e.CloseReason != CloseReason.UserClosing && e.CloseReason != 0))
			{
				return;
			}
            IPAddress _;
            if (!Uri.CheckSchemeName(_txtProxyAddress.Text) && !IPAddress.TryParse(_txtProxyAddress.Text, out  _))
			{
				MessageBox.Show(this, "Wrong proxy address format", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
            int result;
            int.TryParse(_txtProxyPort.Text, out  result);
			if (result <= 0 || result > 65535)
			{
				MessageBox.Show(this, "Wrong proxy port", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
			}
		}
	}
}
