using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace HostsPinger
{
	public class HostOptions : DevExpress.XtraEditors.XtraForm
    {
		private IContainer components;

		private Label label1;

		private NumericUpDown _spTtl;

		private CheckBox _chkbDontFragent;

		private NumericUpDown _spBufferSize;

		private Label label2;

		private NumericUpDown _spPingsBeforeDeath;

		private NumericUpDown _spInterval;

		private NumericUpDown _spTimeout;

		private Label label3;

		private Label label4;

		private Label label5;

		private Button _btnCancel;

		private Button _btnOk;

		private TextBox _tbHostName;

		private Label label6;

		private Button _btnResolve;

		private Label label7;

		private TextBox _tbHostIp;

		private NumericUpDown _spDnsInterval;

		private Label label8;

		private NumericUpDown _spRecentDepth;

		private Label label9;

		private TextBox _tbDescription;

		private Label label10;

		private HostPinger _host;

		public HostPinger Host => _host;

		public HostOptions()
		{
			InitializeComponent();
		}

		private void _btnResolve_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(Resolve);
			thread.Start(_tbHostName.Text);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void HostOptions_Load(object sender, EventArgs e)
		{
			if (_host == null)
			{
				_spTimeout.Value = HostPinger.DEFAULT_TIMEOUT;
				_spInterval.Value = HostPinger.DEFAULT_PING_INTERVAL;
				_spDnsInterval.Value = HostPinger.DEFAULT_DNS_QUERY_INTERVAL;
				_spRecentDepth.Value = PingResultsBuffer.DEFAULT_BUFFER_SIZE;
				_spPingsBeforeDeath.Value = HostPinger.DEFALUT_PINGS_BEFORE_DEAD;
				_spBufferSize.Value = HostPinger.DEFAULT_BUFFER_SIZE;
				_spTtl.Value = HostPinger.DEFAULT_TTL;
				_chkbDontFragent.Checked = HostPinger.DEFALUT_FRAGMENT;
			}
			else
			{
				_tbHostName.Text = _host.HostName;
				_tbHostIp.Text = _host.HostIP.ToString();
				_tbDescription.Text = _host.HostDescription;
				_tbHostName.Enabled = false;
				_tbHostIp.Enabled = false;
				_spTimeout.Value = _host.Timeout;
				_spInterval.Value = _host.PingInterval;
				_spDnsInterval.Value = _host.DnsQueryInterval;
				_spPingsBeforeDeath.Value = _host.PingsBeforeDead;
				_spRecentDepth.Value = _host.RecentHisoryDepth;
				_spBufferSize.Value = _host.BufferSize;
				_spTtl.Value = _host.TTL;
				_chkbDontFragent.Checked = _host.DontFragment;
			}
		}

		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			_spTtl = new System.Windows.Forms.NumericUpDown();
			_chkbDontFragent = new System.Windows.Forms.CheckBox();
			_spBufferSize = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			_spPingsBeforeDeath = new System.Windows.Forms.NumericUpDown();
			_spInterval = new System.Windows.Forms.NumericUpDown();
			_spTimeout = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			_btnCancel = new System.Windows.Forms.Button();
			_btnOk = new System.Windows.Forms.Button();
			_tbHostName = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			_btnResolve = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			_tbHostIp = new System.Windows.Forms.TextBox();
			_spDnsInterval = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			_spRecentDepth = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			_tbDescription = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)_spTtl).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spBufferSize).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spPingsBeforeDeath).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spInterval).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spTimeout).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spDnsInterval).BeginInit();
			((System.ComponentModel.ISupportInitialize)_spRecentDepth).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(92, 286);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(30, 13);
			label1.TabIndex = 23;
			label1.Text = "TTL:";
			_spTtl.Location = new System.Drawing.Point(133, 282);
			System.Windows.Forms.NumericUpDown spTtl = _spTtl;
			int[] bits = new int[4]
			{
				256,
				0,
				0,
				0
			};
			spTtl.Maximum = new decimal(bits);
			System.Windows.Forms.NumericUpDown spTtl2 = _spTtl;
			int[] bits2 = new int[4]
			{
				1,
				0,
				0,
				0
			};
			spTtl2.Minimum = new decimal(bits2);
			_spTtl.Name = "_spTtl";
			_spTtl.Size = new System.Drawing.Size(98, 20);
			_spTtl.TabIndex = 10;
			System.Windows.Forms.NumericUpDown spTtl3 = _spTtl;
			int[] bits3 = new int[4]
			{
				127,
				0,
				0,
				0
			};
			spTtl3.Value = new decimal(bits3);
			_chkbDontFragent.AutoSize = true;
			_chkbDontFragent.Location = new System.Drawing.Point(133, 308);
			_chkbDontFragent.Name = "_chkbDontFragent";
			_chkbDontFragent.Size = new System.Drawing.Size(98, 17);
			_chkbDontFragent.TabIndex = 11;
			_chkbDontFragent.Text = "Don't Fragment";
			_chkbDontFragent.UseVisualStyleBackColor = true;
			_spBufferSize.Location = new System.Drawing.Point(133, 256);
			System.Windows.Forms.NumericUpDown spBufferSize = _spBufferSize;
			int[] bits4 = new int[4]
			{
				65536,
				0,
				0,
				0
			};
			spBufferSize.Maximum = new decimal(bits4);
			System.Windows.Forms.NumericUpDown spBufferSize2 = _spBufferSize;
			int[] bits5 = new int[4]
			{
				1,
				0,
				0,
				0
			};
			spBufferSize2.Minimum = new decimal(bits5);
			_spBufferSize.Name = "_spBufferSize";
			_spBufferSize.Size = new System.Drawing.Size(98, 20);
			_spBufferSize.TabIndex = 9;
			System.Windows.Forms.NumericUpDown spBufferSize3 = _spBufferSize;
			int[] bits6 = new int[4]
			{
				32,
				0,
				0,
				0
			};
			spBufferSize3.Value = new decimal(bits6);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(61, 260);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(61, 13);
			label2.TabIndex = 22;
			label2.Text = "Buffer Size:";
			_spPingsBeforeDeath.Location = new System.Drawing.Point(133, 230);
			System.Windows.Forms.NumericUpDown spPingsBeforeDeath = _spPingsBeforeDeath;
			int[] bits7 = new int[4]
			{
				1000,
				0,
				0,
				0
			};
			spPingsBeforeDeath.Maximum = new decimal(bits7);
			System.Windows.Forms.NumericUpDown spPingsBeforeDeath2 = _spPingsBeforeDeath;
			int[] bits8 = new int[4]
			{
				1,
				0,
				0,
				0
			};
			spPingsBeforeDeath2.Minimum = new decimal(bits8);
			_spPingsBeforeDeath.Name = "_spPingsBeforeDeath";
			_spPingsBeforeDeath.Size = new System.Drawing.Size(98, 20);
			_spPingsBeforeDeath.TabIndex = 8;
			System.Windows.Forms.NumericUpDown spPingsBeforeDeath3 = _spPingsBeforeDeath;
			int[] bits9 = new int[4]
			{
				10,
				0,
				0,
				0
			};
			spPingsBeforeDeath3.Value = new decimal(bits9);
			System.Windows.Forms.NumericUpDown spInterval = _spInterval;
			int[] bits10 = new int[4]
			{
				100,
				0,
				0,
				0
			};
			spInterval.Increment = new decimal(bits10);
			_spInterval.Location = new System.Drawing.Point(133, 152);
			System.Windows.Forms.NumericUpDown spInterval2 = _spInterval;
			int[] bits11 = new int[4]
			{
				100000,
				0,
				0,
				0
			};
			spInterval2.Maximum = new decimal(bits11);
			System.Windows.Forms.NumericUpDown spInterval3 = _spInterval;
			int[] bits12 = new int[4]
			{
				100,
				0,
				0,
				0
			};
			spInterval3.Minimum = new decimal(bits12);
			_spInterval.Name = "_spInterval";
			_spInterval.Size = new System.Drawing.Size(98, 20);
			_spInterval.TabIndex = 5;
			System.Windows.Forms.NumericUpDown spInterval4 = _spInterval;
			int[] bits13 = new int[4]
			{
				1000,
				0,
				0,
				0
			};
			spInterval4.Value = new decimal(bits13);
			System.Windows.Forms.NumericUpDown spTimeout = _spTimeout;
			int[] bits14 = new int[4]
			{
				100,
				0,
				0,
				0
			};
			spTimeout.Increment = new decimal(bits14);
			_spTimeout.Location = new System.Drawing.Point(133, 126);
			System.Windows.Forms.NumericUpDown spTimeout2 = _spTimeout;
			int[] bits15 = new int[4]
			{
				100000,
				0,
				0,
				0
			};
			spTimeout2.Maximum = new decimal(bits15);
			System.Windows.Forms.NumericUpDown spTimeout3 = _spTimeout;
			int[] bits16 = new int[4]
			{
				10,
				0,
				0,
				0
			};
			spTimeout3.Minimum = new decimal(bits16);
			_spTimeout.Name = "_spTimeout";
			_spTimeout.Size = new System.Drawing.Size(98, 20);
			_spTimeout.TabIndex = 4;
			System.Windows.Forms.NumericUpDown spTimeout4 = _spTimeout;
			int[] bits17 = new int[4]
			{
				5000,
				0,
				0,
				0
			};
			spTimeout4.Value = new decimal(bits17);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(20, 234);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(102, 13);
			label3.TabIndex = 21;
			label3.Text = "Pings Before Death:";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(77, 156);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(45, 13);
			label4.TabIndex = 18;
			label4.Text = "Interval:";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(74, 130);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(48, 13);
			label5.TabIndex = 17;
			label5.Text = "Timeout:";
			_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_btnCancel.Location = new System.Drawing.Point(156, 331);
			_btnCancel.Name = "_btnCancel";
			_btnCancel.Size = new System.Drawing.Size(75, 23);
			_btnCancel.TabIndex = 13;
			_btnCancel.Text = "Cancel";
			_btnCancel.UseVisualStyleBackColor = true;
			_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			_btnOk.Location = new System.Drawing.Point(75, 331);
			_btnOk.Name = "_btnOk";
			_btnOk.Size = new System.Drawing.Size(75, 23);
			_btnOk.TabIndex = 12;
			_btnOk.Text = "OK";
			_btnOk.UseVisualStyleBackColor = true;
			_tbHostName.Location = new System.Drawing.Point(133, 12);
			_tbHostName.Name = "_tbHostName";
			_tbHostName.Size = new System.Drawing.Size(98, 20);
			_tbHostName.TabIndex = 0;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(59, 16);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(63, 13);
			label6.TabIndex = 14;
			label6.Text = "Host Name:";
			_btnResolve.Location = new System.Drawing.Point(156, 38);
			_btnResolve.Name = "_btnResolve";
			_btnResolve.Size = new System.Drawing.Size(75, 23);
			_btnResolve.TabIndex = 1;
			_btnResolve.Text = "Resolve";
			_btnResolve.UseVisualStyleBackColor = true;
			_btnResolve.Click += new System.EventHandler(_btnResolve_Click);
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(77, 78);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(45, 13);
			label7.TabIndex = 15;
			label7.Text = "Host IP:";
			_tbHostIp.Location = new System.Drawing.Point(133, 74);
			_tbHostIp.Name = "_tbHostIp";
			_tbHostIp.Size = new System.Drawing.Size(98, 20);
			_tbHostIp.TabIndex = 2;
			System.Windows.Forms.NumericUpDown spDnsInterval = _spDnsInterval;
			int[] bits18 = new int[4]
			{
				10000,
				0,
				0,
				0
			};
			spDnsInterval.Increment = new decimal(bits18);
			_spDnsInterval.Location = new System.Drawing.Point(133, 178);
			System.Windows.Forms.NumericUpDown spDnsInterval2 = _spDnsInterval;
			int[] bits19 = new int[4]
			{
				600000,
				0,
				0,
				0
			};
			spDnsInterval2.Maximum = new decimal(bits19);
			System.Windows.Forms.NumericUpDown spDnsInterval3 = _spDnsInterval;
			int[] bits20 = new int[4]
			{
				10000,
				0,
				0,
				0
			};
			spDnsInterval3.Minimum = new decimal(bits20);
			_spDnsInterval.Name = "_spDnsInterval";
			_spDnsInterval.Size = new System.Drawing.Size(98, 20);
			_spDnsInterval.TabIndex = 6;
			System.Windows.Forms.NumericUpDown spDnsInterval4 = _spDnsInterval;
			int[] bits21 = new int[4]
			{
				60000,
				0,
				0,
				0
			};
			spDnsInterval4.Value = new decimal(bits21);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(20, 182);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(102, 13);
			label8.TabIndex = 19;
			label8.Text = "DNS Query Interval:";
			System.Windows.Forms.NumericUpDown spRecentDepth = _spRecentDepth;
			int[] bits22 = new int[4]
			{
				10,
				0,
				0,
				0
			};
			spRecentDepth.Increment = new decimal(bits22);
			_spRecentDepth.Location = new System.Drawing.Point(133, 204);
			System.Windows.Forms.NumericUpDown spRecentDepth2 = _spRecentDepth;
			int[] bits23 = new int[4]
			{
				10000,
				0,
				0,
				0
			};
			spRecentDepth2.Maximum = new decimal(bits23);
			System.Windows.Forms.NumericUpDown spRecentDepth3 = _spRecentDepth;
			int[] bits24 = new int[4]
			{
				10,
				0,
				0,
				0
			};
			spRecentDepth3.Minimum = new decimal(bits24);
			_spRecentDepth.Name = "_spRecentDepth";
			_spRecentDepth.Size = new System.Drawing.Size(98, 20);
			_spRecentDepth.TabIndex = 7;
			System.Windows.Forms.NumericUpDown spRecentDepth4 = _spRecentDepth;
			int[] bits25 = new int[4]
			{
				100,
				0,
				0,
				0
			};
			spRecentDepth4.Value = new decimal(bits25);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(10, 208);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(112, 13);
			label9.TabIndex = 20;
			label9.Text = "Recent History Depth:";
			_tbDescription.Location = new System.Drawing.Point(133, 100);
			_tbDescription.Name = "_tbDescription";
			_tbDescription.Size = new System.Drawing.Size(98, 20);
			_tbDescription.TabIndex = 3;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(59, 104);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(63, 13);
			label10.TabIndex = 16;
			label10.Text = "Description:";
			base.AcceptButton = _btnOk;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = _btnCancel;
			base.ClientSize = new System.Drawing.Size(254, 373);
			base.Controls.Add(label10);
			base.Controls.Add(_tbDescription);
			base.Controls.Add(label9);
			base.Controls.Add(_spRecentDepth);
			base.Controls.Add(label8);
			base.Controls.Add(_spDnsInterval);
			base.Controls.Add(_tbHostIp);
			base.Controls.Add(label7);
			base.Controls.Add(_btnResolve);
			base.Controls.Add(label6);
			base.Controls.Add(_tbHostName);
			base.Controls.Add(_btnOk);
			base.Controls.Add(_btnCancel);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(_spTimeout);
			base.Controls.Add(_spInterval);
			base.Controls.Add(_spPingsBeforeDeath);
			base.Controls.Add(label2);
			base.Controls.Add(_spBufferSize);
			base.Controls.Add(_chkbDontFragent);
			base.Controls.Add(_spTtl);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "HostOptions";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Host Options";
			base.Load += new System.EventHandler(HostOptions_Load);
			((System.ComponentModel.ISupportInitialize)_spTtl).EndInit();
			((System.ComponentModel.ISupportInitialize)_spBufferSize).EndInit();
			((System.ComponentModel.ISupportInitialize)_spPingsBeforeDeath).EndInit();
			((System.ComponentModel.ISupportInitialize)_spInterval).EndInit();
			((System.ComponentModel.ISupportInitialize)_spTimeout).EndInit();
			((System.ComponentModel.ISupportInitialize)_spDnsInterval).EndInit();
			((System.ComponentModel.ISupportInitialize)_spRecentDepth).EndInit();
			ResumeLayout(performLayout: false);
			PerformLayout();
		}

		private void Resolve(object name)
		{
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry((string)name);
				UpdateIPAddress(hostEntry.AddressList[0]);
			}
			catch (Exception ex)
			{
				ShowError(ex.Message);
			}
		}

		public DialogResult ShowDialog(IWin32Window owner, HostPinger host)
		{
			_host = host;
			DialogResult dialogResult = ShowDialog(owner);
			DialogResult result;
			if (dialogResult == DialogResult.OK)
			{
				if (_host == null)
				{
					bool flag = string.IsNullOrEmpty(_tbHostName.Text);
					bool flag2 = string.IsNullOrEmpty(_tbHostIp.Text);
					try
					{
						if (!flag && flag2)
						{
							_host = new HostPinger(_tbHostName.Text);
						}
						else if (flag && !flag2)
						{
							_host = new HostPinger(IPAddress.Parse(_tbHostIp.Text));
						}
						else if (!flag && !flag2)
						{
							_host = new HostPinger(_tbHostName.Text, IPAddress.Parse(_tbHostIp.Text));
						}
						if (_host != null)
						{
							_host.Logger = DefaultLogger.Instance;
						}
					}
					catch
					{
						_host = null;
						result = DialogResult.Cancel;
						goto IL_0117;
					}
				}
				_host.HostDescription = _tbDescription.Text;
				_host.Timeout = (int)_spTimeout.Value;
				_host.PingInterval = (int)_spInterval.Value;
				_host.DnsQueryInterval = (int)_spDnsInterval.Value;
				_host.PingsBeforeDead = (int)_spPingsBeforeDeath.Value;
				_host.RecentHisoryDepth = (int)_spRecentDepth.Value;
				_host.BufferSize = (int)_spBufferSize.Value;
				_host.TTL = (int)_spTtl.Value;
				_host.DontFragment = _chkbDontFragent.Checked;
			}
			return dialogResult;
			IL_0117:
			return result;
		}

		private void ShowError(string error)
		{
			if (!base.InvokeRequired)
			{
				MessageBox.Show(error, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			ShowErrorDelegate method = ShowError;
			object[] args = new object[1]
			{
				error
			};
			Invoke(method, args);
		}

		private void UpdateIPAddress(IPAddress address)
		{
			if (!base.InvokeRequired)
			{
				_tbHostIp.Text = address.ToString();
				return;
			}
			UpdateIPAddressDelegate method = UpdateIPAddress;
			object[] args = new object[1]
			{
				address
			};
			Invoke(method, args);
		}
	}
}
