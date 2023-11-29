using HostsPinger;
using Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

public class Registration : DevExpress.XtraEditors.XtraForm
{
	private string _proxyAddress = string.Empty;

	private int _proxyPort = 8080;

	private bool _useProxy;

	private RegistrationProcess _registrationProcessDlg = new RegistrationProcess();

	private IContainer components;

	private PictureBox pictureBox1;

	private Button _btnCancel;

	private Button _btnOK;

	private GroupBox _grpLicenceKey;

	private GroupBox _grpLicenceFile;

	private RadioButton _rbLicenceKey;

	private Label label1;

	private Button _btnBrowse;

	private TextBox _txtLicenceFile;

	private RadioButton _rbLicenceFile;

	private TextBox _txtLicenceKey;

	private Label label2;

	private Label label3;

	private Label label5;

	private Label label4;

	private LinkLabel _lnkRegistration;

	private Label label6;

	private LinkLabel _lnkDownload;

	private OpenFileDialog _dlgOpenFile;

	private Button _btnProxy;

	private Button _btnHostID;

	public string ProxyAddress => _proxyAddress;

	public int ProxyPort => _proxyPort;

	public bool UseProxy => _useProxy;

	public Registration()
	{
		InitializeComponent();
		GroupBox grpLicenceFile = _grpLicenceFile;
		bool flag2 = _rbLicenceFile.Checked = false;
		bool flag4 = grpLicenceFile.Enabled = flag2;
		GroupBox grpLicenceKey = _grpLicenceKey;
		flag2 = (_rbLicenceKey.Checked = false);
		bool flag7 = grpLicenceKey.Enabled = flag2;
	}

	private void _rbLicenceKey_CheckedChanged(object sender, EventArgs e)
	{
		_grpLicenceFile.Enabled = _rbLicenceFile.Checked;
		_grpLicenceKey.Enabled = _rbLicenceKey.Checked;
	}

	private void _rbLicenceFile_CheckedChanged(object sender, EventArgs e)
	{
		_grpLicenceFile.Enabled = _rbLicenceFile.Checked;
		_grpLicenceKey.Enabled = _rbLicenceKey.Checked;
	}

	private void _btnBrowse_Click(object sender, EventArgs e)
	{
	}

	private void _lnkRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start(_lnkRegistration.Text);
		}
		catch
		{
			MessageBox.Show("Cannot start web browser!");
		}
	}

	private void _lnkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start(_lnkDownload.Text);
		}
		catch
		{
			MessageBox.Show("Cannot start web browser!");
		}
	}

	private void _btnProxy_Click(object sender, EventArgs e)
	{
		ProxyOptions proxyOptions = new ProxyOptions();
		proxyOptions.ProxyAddress = _proxyAddress;
		proxyOptions.ProxyPort = _proxyPort;
		proxyOptions.UseProxy = _useProxy;
		if (proxyOptions.ShowDialog(this) == DialogResult.OK)
		{
			_proxyAddress = proxyOptions.ProxyAddress;
			_proxyPort = proxyOptions.ProxyPort;
			_useProxy = proxyOptions.UseProxy;
		}
	}

	private void _btnHostID_Click(object sender, EventArgs e)
	{
	}

	private void _txtLicenceKey_KeyPress(object sender, KeyPressEventArgs e)
	{
		if ((e.KeyChar < 'a' || e.KeyChar > 'z') && (e.KeyChar < 'A' || e.KeyChar > 'Z') && (e.KeyChar < '0' || e.KeyChar > '9') && !char.IsControl(e.KeyChar))
		{
			e.Handled = true;
		}
	}

	private void _btnOK_Click(object sender, EventArgs e)
	{
	}

	private void ProcessRegistration(object licenceKey)
	{
	}

	private void ProcessLicenceFile(object licenceFile)
	{
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
		_btnCancel = new System.Windows.Forms.Button();
		_btnOK = new System.Windows.Forms.Button();
		_grpLicenceKey = new System.Windows.Forms.GroupBox();
		label2 = new System.Windows.Forms.Label();
		_txtLicenceKey = new System.Windows.Forms.TextBox();
		_grpLicenceFile = new System.Windows.Forms.GroupBox();
		label6 = new System.Windows.Forms.Label();
		_lnkDownload = new System.Windows.Forms.LinkLabel();
		label5 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		_lnkRegistration = new System.Windows.Forms.LinkLabel();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		_btnBrowse = new System.Windows.Forms.Button();
		_txtLicenceFile = new System.Windows.Forms.TextBox();
		_rbLicenceKey = new System.Windows.Forms.RadioButton();
		_rbLicenceFile = new System.Windows.Forms.RadioButton();
		_dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
		_btnProxy = new System.Windows.Forms.Button();
		_btnHostID = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		_grpLicenceKey.SuspendLayout();
		_grpLicenceFile.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		_btnCancel.Location = new System.Drawing.Point(657, 262);
		_btnCancel.Name = "_btnCancel";
		_btnCancel.Size = new System.Drawing.Size(75, 23);
		_btnCancel.TabIndex = 7;
		_btnCancel.Text = "&Cancel";
		_btnCancel.UseVisualStyleBackColor = true;
		_btnOK.Location = new System.Drawing.Point(576, 262);
		_btnOK.Name = "_btnOK";
		_btnOK.Size = new System.Drawing.Size(75, 23);
		_btnOK.TabIndex = 6;
		_btnOK.Text = "&OK";
		_btnOK.UseVisualStyleBackColor = true;
		_btnOK.Click += new System.EventHandler(_btnOK_Click);
		_grpLicenceKey.Controls.Add(label2);
		_grpLicenceKey.Controls.Add(_txtLicenceKey);
		_grpLicenceKey.Location = new System.Drawing.Point(275, 13);
		_grpLicenceKey.Name = "_grpLicenceKey";
		_grpLicenceKey.Size = new System.Drawing.Size(457, 83);
		_grpLicenceKey.TabIndex = 1;
		_grpLicenceKey.TabStop = false;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(6, 17);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(68, 13);
		label2.TabIndex = 0;
		label2.Text = "&Licence key:";
		_txtLicenceKey.Location = new System.Drawing.Point(9, 44);
		_txtLicenceKey.Name = "_txtLicenceKey";
		_txtLicenceKey.Size = new System.Drawing.Size(442, 20);
		_txtLicenceKey.TabIndex = 1;
		_txtLicenceKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_txtLicenceKey_KeyPress);
		_grpLicenceFile.Controls.Add(label6);
		_grpLicenceFile.Controls.Add(_lnkDownload);
		_grpLicenceFile.Controls.Add(label5);
		_grpLicenceFile.Controls.Add(label4);
		_grpLicenceFile.Controls.Add(_lnkRegistration);
		_grpLicenceFile.Controls.Add(label3);
		_grpLicenceFile.Controls.Add(label1);
		_grpLicenceFile.Controls.Add(_btnBrowse);
		_grpLicenceFile.Controls.Add(_txtLicenceFile);
		_grpLicenceFile.Location = new System.Drawing.Point(275, 102);
		_grpLicenceFile.Name = "_grpLicenceFile";
		_grpLicenceFile.Size = new System.Drawing.Size(457, 154);
		_grpLicenceFile.TabIndex = 3;
		_grpLicenceFile.TabStop = false;
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(225, 122);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(129, 13);
		label6.TabIndex = 5;
		label6.Text = "- Product Download Page";
		_lnkDownload.AutoSize = true;
		_lnkDownload.Location = new System.Drawing.Point(12, 122);
		_lnkDownload.Name = "_lnkDownload";
		_lnkDownload.Size = new System.Drawing.Size(217, 13);
		_lnkDownload.TabIndex = 4;
		_lnkDownload.TabStop = true;
		_lnkDownload.Text = "http://www.GitSoft.com/Download.aspx";
		_lnkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(_lnkDownload_LinkClicked);
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(9, 105);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(371, 13);
		label5.TabIndex = 7;
		label5.Text = "If you reinstalled already registred product, your licence key file is available at:";
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(270, 88);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(137, 13);
		label4.TabIndex = 6;
		label4.Text = "- Product Registration Page";
		_lnkRegistration.AutoSize = true;
		_lnkRegistration.Location = new System.Drawing.Point(12, 88);
		_lnkRegistration.Name = "_lnkRegistration";
		_lnkRegistration.Size = new System.Drawing.Size(262, 13);
		_lnkRegistration.TabIndex = 3;
		_lnkRegistration.TabStop = true;
		_lnkRegistration.Text = "http://www.GitSoft.com/ProductRegistration.aspx";
		_lnkRegistration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(_lnkRegistration_LinkClicked);
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(9, 71);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(423, 13);
		label3.TabIndex = 8;
		label3.Text = "If Internet connection is not available at this computer, you can obtain licence key file at:";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(6, 17);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(108, 13);
		label1.TabIndex = 0;
		label1.Text = "Licence key file &path:";
		_btnBrowse.Location = new System.Drawing.Point(376, 43);
		_btnBrowse.Name = "_btnBrowse";
		_btnBrowse.Size = new System.Drawing.Size(75, 23);
		_btnBrowse.TabIndex = 2;
		_btnBrowse.Text = "&Browse...";
		_btnBrowse.UseVisualStyleBackColor = true;
		_btnBrowse.Click += new System.EventHandler(_btnBrowse_Click);
		_txtLicenceFile.Location = new System.Drawing.Point(9, 44);
		_txtLicenceFile.Name = "_txtLicenceFile";
		_txtLicenceFile.Size = new System.Drawing.Size(361, 20);
		_txtLicenceFile.TabIndex = 1;
		_rbLicenceKey.AutoSize = true;
		_rbLicenceKey.Location = new System.Drawing.Point(282, 10);
		_rbLicenceKey.Name = "_rbLicenceKey";
		_rbLicenceKey.Size = new System.Drawing.Size(107, 17);
		_rbLicenceKey.TabIndex = 0;
		_rbLicenceKey.TabStop = true;
		_rbLicenceKey.Text = "Enter licence &key";
		_rbLicenceKey.UseVisualStyleBackColor = true;
		_rbLicenceKey.CheckedChanged += new System.EventHandler(_rbLicenceKey_CheckedChanged);
		_rbLicenceFile.AutoSize = true;
		_rbLicenceFile.Location = new System.Drawing.Point(282, 99);
		_rbLicenceFile.Name = "_rbLicenceFile";
		_rbLicenceFile.Size = new System.Drawing.Size(97, 17);
		_rbLicenceFile.TabIndex = 2;
		_rbLicenceFile.TabStop = true;
		_rbLicenceFile.Text = "Use licence &file";
		_rbLicenceFile.UseVisualStyleBackColor = true;
		_rbLicenceFile.CheckedChanged += new System.EventHandler(_rbLicenceFile_CheckedChanged);
		_dlgOpenFile.Filter = "Licence Files (*.lic)|*.lic|All Files (*.*)|*.*";
		_dlgOpenFile.Title = "Select Licence File";
		_btnProxy.Location = new System.Drawing.Point(275, 262);
		_btnProxy.Name = "_btnProxy";
		_btnProxy.Size = new System.Drawing.Size(106, 23);
		_btnProxy.TabIndex = 4;
		_btnProxy.Text = "&Proxy Options...";
		_btnProxy.UseVisualStyleBackColor = true;
		_btnProxy.Click += new System.EventHandler(_btnProxy_Click);
		_btnHostID.Location = new System.Drawing.Point(387, 262);
		_btnHostID.Name = "_btnHostID";
		_btnHostID.Size = new System.Drawing.Size(75, 23);
		_btnHostID.TabIndex = 5;
		_btnHostID.Text = "&Host ID...";
		_btnHostID.UseVisualStyleBackColor = true;
		_btnHostID.Click += new System.EventHandler(_btnHostID_Click);
		pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		pictureBox1.Image = Properties.Resources.keys;
		pictureBox1.Location = new System.Drawing.Point(12, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(256, 256);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.CancelButton = _btnCancel;
		base.ClientSize = new System.Drawing.Size(744, 297);
		base.Controls.Add(_btnHostID);
		base.Controls.Add(_btnProxy);
		base.Controls.Add(_rbLicenceKey);
		base.Controls.Add(_rbLicenceFile);
		base.Controls.Add(_grpLicenceFile);
		base.Controls.Add(_grpLicenceKey);
		base.Controls.Add(_btnOK);
		base.Controls.Add(_btnCancel);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Registration";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Registration";
		_grpLicenceKey.ResumeLayout(performLayout: false);
		_grpLicenceKey.PerformLayout();
		_grpLicenceFile.ResumeLayout(performLayout: false);
		_grpLicenceFile.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
