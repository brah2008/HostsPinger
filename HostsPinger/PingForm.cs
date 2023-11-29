using HostsPinger;
using HostsPinger.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace HostsPinger
{
    public class PingForm : DevExpress.XtraEditors.XtraForm
    {
        private Hashtable _table = new Hashtable();

        private StreamReader SR;

        private List<HostPinger> _hosts = new List<HostPinger>();

		private HostPinger _selectedPinger;

		private bool _hostListChanged;

		private FormWindowState _oldState;

		private IContainer components;

		private ColumnHeader _colHostName;

		private ColumnHeader _colIpAddr;

		private ColumnHeader _colStatus;

		private ColumnHeader _colPacketSent;

		private ColumnHeader _colPacketLost;

		private ColumnHeader _colPacketLostPercent;

		private ColumnHeader _colCurrentResponseTime;

		private ColumnHeader _colAvargeResponseTime;

		private ColumnHeader _colStatusDuration;

		private ColumnHeader _colTestDuration;

		private ContextMenuStrip _notifyIconMenu;

		private ToolStripMenuItem _nimRestore;

		private ToolStripMenuItem _nimMaximize;

		private ToolStripMenuItem _nimMinimize;

		private ToolStripMenuItem _nimStartAll;

		private ToolStripMenuItem _nimStopAll;

		private ToolStripMenuItem _nimExit;

		private ToolStripSeparator toolStripMenuItem1;

		private ColumnHeader _colRecPacketReceived;

		private ColumnHeader _colRecPacketLost;

		private ColumnHeader _colRecPacketLostPercent;

		private ColumnHeader _colHostDescription;

		private ColumnHeader _colPacketReceived;

		private ColumnHeader _colPacketReceivedPercent;

		private ColumnHeader _colLastPacketLost;

		private ColumnHeader _colRecPacketReceivedPercent;

		private ColumnHeader _colDeadStatus;

		private ColumnHeader _colAliveStatus;

		private ColumnHeader _colDnsErrorStatus;

		private ColumnHeader _colUnknownStatus;

		private ColumnHeader _colAvailability;

		private ColumnHeader _colCurTestDuration;

		private ListViewDB _lvHosts;

		private ToolStripButton _tbStartAll;

		private ToolStripButton _tbStopAll;

		private ToolStripButton _tbClearAllStatistics;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton _tbStartHost;

		private ToolStripButton _tbStopHost;

		private ToolStripButton _tbClearStatistics;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripButton _tbAddNewHost;

		private ToolStripButton _tbHostOptions;

		private ToolStripButton _tbRemoveHost;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripButton _tbOptions;

		private ToolStripButton _tbAbout;

		private ToolStripMenuItem aDDNewHostToolStripMenuItem;

		private ToolStripMenuItem hostOptionsToolStripMenuItem;

		private ToolStripMenuItem clearStatisticsToolStripMenuItem;

		private ToolStripMenuItem startPingToolStripMenuItem;

		private ColumnHeader IP;

		private ColumnHeader HOSTN;

		private ColumnHeader HOSTD;

		private ColumnHeader STATUS;

		private ColumnHeader SENT;

		private ColumnHeader RECEIV;

		private ColumnHeader LOST;

		private ColumnHeader LAST;

		private ColumnHeader RESEIVREC;

		private ColumnHeader RESEIVRECC;

		private ColumnHeader LOSTT;

		private ColumnHeader LOSTTT;

		private ColumnHeader CURRENT;

		private ColumnHeader AVIRAGE;

		private ColumnHeader STATUSDUR;

		private ColumnHeader ACTIVE;

		private ColumnHeader DEAD;

		private ColumnHeader DnsErr;

		private ColumnHeader UNKSTAUS;

		private ColumnHeader HOSTAV;

		private ColumnHeader TESTDU;

		private ColumnHeader CURRENTTES;

		private ToolStripMenuItem toolStripMenuItem3;

		private ToolStripSeparator removeHostToolStripMenuItem;

		private ToolStripMenuItem stopAllToolStripMenuItem;

		private ToolStripButton __tbStartAll;

		private ToolStripButton __tbStopAll;

		private ToolStripButton __tbClearAllStatistics;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton __tbStartHost;

		private ToolStripButton __tbStopHost;

		private ToolStripButton __tbClearStatistics;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripButton __tbAddNewHost;

		private ToolStripButton __tbHostOptions;

		private ToolStripButton __tbRemoveHost;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripButton __tbSave;

		private ToolStripButton __tbOptions;

		private ToolStripButton __tbAbout;

		private ToolStrip _toolbar;
        private DevExpress.XtraBars.FormAssistant formAssistant1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem tbStartAll;
        private DevExpress.XtraBars.BarButtonItem tbStopAll;
        private DevExpress.XtraBars.BarButtonItem tbClearAllStatistics;
        private DevExpress.XtraBars.BarButtonItem tbStartHost;
        private DevExpress.XtraBars.BarButtonItem tbStopHost;
        private DevExpress.XtraBars.BarButtonItem tbClearStatistics;
        private DevExpress.XtraBars.BarButtonItem tbAddNewHost;
        private DevExpress.XtraBars.BarButtonItem tbHostOptions;
        private DevExpress.XtraBars.BarButtonItem nAnnulerCalcul;
        private DevExpress.XtraBars.BarButtonItem nFactureAvoir;
        private DevExpress.XtraBars.BarButtonItem nCNASATS;
        private DevExpress.XtraBars.BarButtonItem nCNASMouvement;
        private DevExpress.XtraBars.BarButtonItem nCNASDeclaration;
        private DevExpress.XtraBars.BarButtonItem nRubrique;
        private DevExpress.XtraBars.BarButtonItem nVenteauComptoire;
        private DevExpress.XtraBars.BarButtonItem nBultinPaie;
        private DevExpress.XtraBars.BarButtonItem nDeclaration;
        private DevExpress.XtraBars.BarButtonItem nImpGenrale;
        private DevExpress.XtraBars.BarButtonItem nSaisiePresence;
        private DevExpress.XtraBars.BarButtonItem nB20AA;
        private DevExpress.XtraBars.BarButtonItem barButtonItem25;
        private DevExpress.XtraBars.BarButtonItem nClassification;
        private DevExpress.XtraBars.BarButtonItem nPOSTE;
        private DevExpress.XtraBars.BarButtonItem nSTRUCTURE;
        private DevExpress.XtraBars.BarButtonItem barButtonItem31;
        private DevExpress.XtraBars.BarButtonItem barButtonItem32;
        private DevExpress.XtraBars.BarButtonItem barButtonItem33;
        private DevExpress.XtraBars.BarButtonItem nLocalisation;
        private DevExpress.XtraBars.BarButtonItem barButtonItem35;
        private DevExpress.XtraBars.BarButtonItem barButtonItem36;
        private DevExpress.XtraBars.BarButtonItem nMODEPAIEMENT;
        private DevExpress.XtraBars.BarButtonItem nTables;
        private DevExpress.XtraBars.BarButtonItem nBANQUE;
        private DevExpress.XtraBars.BarButtonItem nAgenceBancaire;
        private DevExpress.XtraBars.BarButtonItem barButtonItem41;
        private DevExpress.XtraBars.BarButtonItem nRevaloriserCMP;
        private DevExpress.XtraBars.BarButtonItem nEcart;
        private DevExpress.XtraBars.BarButtonItem nReglementClient;
        private DevExpress.XtraBars.BarButtonItem barButtonItem45;
        private DevExpress.XtraBars.BarButtonItem barButtonItem46;
        private DevExpress.XtraBars.BarButtonItem barButtonItem47;
        private DevExpress.XtraBars.BarButtonItem nStatistique;
        private DevExpress.XtraBars.BarButtonItem barButtonItem49;
        private DevExpress.XtraBars.BarButtonItem nAgenda;
        private DevExpress.XtraBars.BarButtonItem ntableauDeBord;
        private DevExpress.XtraBars.BarButtonItem nInitialiser;
        private DevExpress.XtraBars.BarButtonItem mnReseaux1;
        private DevExpress.XtraBars.BarButtonItem nTransfererCompta1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem55;
        private DevExpress.XtraBars.BarButtonItem nRequetteLibre;
        private DevExpress.XtraBars.BarButtonItem nEnregistrement;
        private DevExpress.XtraBars.BarButtonItem naide;
        private DevExpress.XtraBars.BarButtonItem tbAbout;
        private DevExpress.XtraBars.BarButtonItem nEtatG50;
        private DevExpress.XtraBars.BarButtonItem barButtonItem61;
        private DevExpress.XtraBars.BarButtonItem nTransfererCompta;
        private DevExpress.XtraBars.BarButtonItem nUsers1;
        private DevExpress.XtraBars.BarListItem barListItem1;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem2;
        private DevExpress.XtraBars.BarButtonItem tbRemoveHost;
        private DevExpress.XtraBars.BarButtonItem nCalculerETArchiver;
        private DevExpress.XtraBars.BarButtonItem nAvanaces;
        private DevExpress.XtraBars.BarButtonItem nGenererFacture;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraBars.BarButtonItem nUsers;
        private DevExpress.XtraBars.BarButtonItem nJournal;
        private DevExpress.XtraBars.BarButtonItem nPersonel;
        private DevExpress.XtraBars.BarButtonItem nPaieinverse;
        private DevExpress.XtraBars.BarButtonItem nPret;
        private DevExpress.XtraBars.BarButtonItem mConge;
        private DevExpress.XtraBars.BarButtonItem bbOrdreMission;
        private DevExpress.XtraBars.BarButtonItem nContrat_Click;
        private DevExpress.XtraBars.BarButtonItem nSaisiVaraibles;
        private DevExpress.XtraBars.BarButtonItem tbSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem tbOptions;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private NotifyIcon _notifyIcon;
        private ToolStripButton _tbSave;

		public PingForm()
		{
			InitializeComponent();
			LoadSettings();
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load("hosts.cfg");
				foreach (XmlNode childNode in xmlDocument.ChildNodes[xmlDocument.ChildNodes.Count - 1].ChildNodes)
				{
					ThreadPool.QueueUserWorkItem(AddLoadedHost, childNode);
				}
				base.WindowState = FormWindowState.Minimized;
				base.Visible = false;
			}
			catch
			{
				if (Options.Instance.ShowErrorMessages)
				{
					MessageBox.Show("Error ocurred while loading the config file.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		private void _btnStart_Click(object sender, EventArgs e)
		{
			lock (_hosts)
			{
				foreach (HostPinger host in _hosts)
				{
					host.Start();
				}
			}
		}

		private void _btnStop_Click(object sender, EventArgs e)
		{
			lock (_hosts)
			{
				foreach (HostPinger host in _hosts)
				{
					host.Stop();
				}
			}
		}

		private void _lvHosts_DoubleClick(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
			{
				_tbHostOptions_Click(sender, e);
			}
		}

		private void _lvHosts_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			ContextMenu contextMenu = new ContextMenu();
			contextMenu.MenuItems.Add(new MenuItem("Add new host...", _tbAddNewHost_Click));
			if (_selectedPinger != null)
			{
				contextMenu.MenuItems.Add(new MenuItem("Host options...", _tbHostOptions_Click));
				contextMenu.MenuItems.Add(new MenuItem("Clear statistics", _tbClearStatistics_Click));
				if (!_selectedPinger.IsRunning)
				{
					contextMenu.MenuItems.Add(new MenuItem("Start ping", _tbStartHost_Click));
					contextMenu.MenuItems.Add(new MenuItem("Remove host", _tbRemoveHost_Click));
				}
				else
				{
					contextMenu.MenuItems.Add(new MenuItem("Stop ping", _tbStopHost_Click));
				}
			}
			contextMenu.Show(this, e.Location);
		}

		private void _lvHosts_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_lvHosts.SelectedItems == null || _lvHosts.SelectedItems.Count <= 0)
			{
				_selectedPinger = null;
			}
			else
			{
				_selectedPinger = (HostPinger)_lvHosts.SelectedItems[0].Tag;
			}
			_tbStartHost.Enabled = (_selectedPinger != null && !_selectedPinger.IsRunning);
			_tbRemoveHost.Enabled = (_selectedPinger != null && !_selectedPinger.IsRunning);
			_tbStopHost.Enabled = (_selectedPinger != null && _selectedPinger.IsRunning);
			_tbClearStatistics.Enabled = (_selectedPinger != null);
			_tbHostOptions.Enabled = (_selectedPinger != null);
		}

		private void _nimExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void _nimMaximize_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Maximized;
			base.Visible = true;
		}

		private void _nimMinimize_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void _nimRestore_Click(object sender, EventArgs e)
		{
			if (base.WindowState == FormWindowState.Maximized)
			{
				base.WindowState = FormWindowState.Normal;
				return;
			}
			base.Visible = true;
			base.WindowState = _oldState;
		}

		private void _notifyIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && base.WindowState != FormWindowState.Minimized)
			{
				Activate();
			}
		}

		private void _notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (base.WindowState != FormWindowState.Minimized)
			{
				base.WindowState = FormWindowState.Minimized;
				base.Visible = false;
			}
			else
			{
				base.Visible = true;
				base.WindowState = _oldState;
			}
		}

		private void _tbAbout_Click(object sender, EventArgs e)
		{
			new AboutForm().ShowDialog(this);
		}

		private void _tbAddNewHost_Click(object sender, EventArgs e)
		{
			HostOptions hostOptions = new HostOptions();
			if (hostOptions.ShowDialog(this, null) != DialogResult.OK)
			{
				return;
			}
			bool flag = false;
			lock (_hosts)
			{
				foreach (HostPinger host in _hosts)
				{
					if (host.HostIP != null && host.HostIP == hostOptions.Host.HostIP)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				MessageBox.Show("Host already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			hostOptions.Host.Logger = DefaultLogger.Instance;
			hostOptions.Host.OnPing += OnHostPing;
			hostOptions.Host.OnStopPinging += hp_OnStopPinging;
			hostOptions.Host.OnStartPinging += hp_OnStartPinging;
			lock (_hosts)
			{
				_hosts.Add(hostOptions.Host);
			}
			_hostListChanged = true;
			if (MessageBox.Show("Start pinging of the host?", "Start", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				hostOptions.Host.Start();
			}
		}

		private void _tbClearAllStatistics_Click(object sender, EventArgs e)
		{
			bool flag = false;
			if (!Options.Instance.ClearTimeStatistics)
			{
				DialogResult dialogResult = MessageBox.Show("Clear time statistics as well?", "Time Statistics", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Cancel)
				{
					return;
				}
				flag = (dialogResult == DialogResult.Yes);
			}
			else
			{
				flag = true;
			}
			lock (_hosts)
			{
				foreach (HostPinger host in _hosts)
				{
					host.ClearStatistics(flag);
				}
			}
		}

		private void _tbClearStatistics_Click(object sender, EventArgs e)
		{
			if (_selectedPinger == null)
			{
				return;
			}
			bool flag = false;
			if (!Options.Instance.ClearTimeStatistics)
			{
				DialogResult dialogResult = MessageBox.Show("Clear time statistics as well?", "Time Statistics", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Cancel)
				{
					return;
				}
				flag = (dialogResult == DialogResult.Yes);
			}
			else
			{
				flag = true;
			}
			_selectedPinger.ClearStatistics(flag);
		}

		private void _tbHostOptions_Click(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
			{
				new HostOptions().ShowDialog(this, _selectedPinger);
			}
		}

		private void _tbOptions_Click(object sender, EventArgs e)
		{
			ProgramOptions programOptions = new ProgramOptions();
			for (int num = Options.NUMBER_OF_COLUMNS - 1; num >= 0; num--)
			{
				programOptions.SelectedColumns.SetItemChecked(num, Options.Instance.GetComlumnVisability(num));
			}
			if (programOptions.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			for (int num2 = Options.NUMBER_OF_COLUMNS - 1; num2 >= 0; num2--)
			{
				bool comlumnVisability = Options.Instance.GetComlumnVisability(num2);
				Options.Instance.SetColumnVisability(num2, programOptions.SelectedColumns.GetItemChecked(num2));
				if (!comlumnVisability)
				{
					_lvHosts.Columns[num2].Width = Options.Instance.GetColumnWidth(num2);
				}
				if (!Options.Instance.GetComlumnVisability(num2))
				{
					_lvHosts.Columns[num2].Width = 0;
				}
			}
			Options.Instance.StartWithWindows = programOptions.StartWithWindows;
			Options.Instance.StartPingingOnProgramStart = programOptions.StartPingingOnProgramStart;
			Options.Instance.ShowErrorMessages = programOptions.ShowErrorMessages;
			Options.Instance.ClearTimeStatistics = programOptions.ClearTimeStatistics;
		}

		private void _tbRemoveHost_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Remove host from list?", "Remove host", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No && _selectedPinger != null && !_selectedPinger.IsRunning)
			{
				lock (_table)
				{
					lock (_hosts)
					{
						_hosts.Remove(_selectedPinger);
					}
					_selectedPinger.OnPing -= OnHostPing;
					_selectedPinger.OnStopPinging -= hp_OnStopPinging;
					_selectedPinger.OnStartPinging -= hp_OnStartPinging;
					ListViewItem item = (ListViewItem)_table[_selectedPinger.ID];
					_table.Remove(_selectedPinger.ID);
					_lvHosts.Items.Remove(item);
					_hostListChanged = true;
				}
			}
		}

		private void _tbSave_Click(object sender, EventArgs e)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				CloseOutput = true,
				Indent = true
			};
			try
			{
				XmlWriter xmlWriter = XmlWriter.Create("hosts.cfg", settings);
				try
				{
					xmlWriter.WriteStartElement("pinger");
					lock (_hosts)
					{
						foreach (HostPinger host in _hosts)
						{
							host.Save(xmlWriter);
						}
					}
					xmlWriter.WriteEndElement();
					_hostListChanged = false;
				}
				finally
				{
					xmlWriter.Close();
				}
			}
			catch
			{
				MessageBox.Show("An error ocurred while saving host list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void _tbStartAll_Click(object sender, EventArgs e)
		{
			lock (_hosts)
			{
				foreach (HostPinger host in _hosts)
				{
					host.Start();
				}
			}
		}

		private void _tbStartHost_Click(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
			{
				_selectedPinger.Start();
			}
		}

		private void _tbStopAll_Click(object sender, EventArgs e)
		{
			lock (_hosts)
			{
				foreach (HostPinger host in _hosts)
				{
					host.Stop();
				}
			}
		}

		private void _tbStopHost_Click(object sender, EventArgs e)
		{
			if (_selectedPinger != null)
			{
				_selectedPinger.Stop();
			}
		}

		private void AddLoadedHost(object hostNode)
		{
			try
			{
				HostPinger hostPinger = new HostPinger((XmlNode)hostNode)
				{
					Logger = DefaultLogger.Instance
				};
				hostPinger.OnPing += OnHostPing;
				hostPinger.OnStopPinging += hp_OnStopPinging;
				hostPinger.OnStartPinging += hp_OnStartPinging;
				_hosts.Add(hostPinger);
				if (Options.Instance.StartPingingOnProgramStart)
				{
					hostPinger.Start();
				}
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				if (Options.Instance.ShowErrorMessages)
				{
					MessageBox.Show(ex2.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
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

		private string DurationToString(TimeSpan duration)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (duration.Days > 0)
			{
				stringBuilder.Append(duration.Days);
				stringBuilder.Append((duration.Days > 1) ? " days " : " day ");
			}
			stringBuilder.AppendFormat("{0:d2} : {1:d2} : {2:d2}", duration.Hours, duration.Minutes, duration.Seconds);
			return stringBuilder.ToString();
		}

		private void hp_OnStartPinging(HostPinger host)
		{
			if (base.InvokeRequired)
			{
				OnPingDelegate method = OnHostPing;
				object[] args = new object[1]
				{
					host
				};
				Invoke(method, args);
			}
			else
			{
				lock (_table)
				{
					if ((ListViewItem)_table[host.ID] != null && _selectedPinger == host)
					{
						_tbStartHost.Enabled = false;
						_tbRemoveHost.Enabled = false;
						_tbStopHost.Enabled = true;
					}
				}
			}
		}

		private void hp_OnStopPinging(HostPinger host)
		{
			if (base.InvokeRequired)
			{
				OnPingDelegate method = OnHostPing;
				object[] args = new object[1]
				{
					host
				};
				Invoke(method, args);
			}
			else
			{
				lock (_table)
				{
					ListViewItem listViewItem = (ListViewItem)_table[host.ID];
					if (listViewItem != null)
					{
						listViewItem.BackColor = Color.White;
						listViewItem.ForeColor = Color.Black;
						if (_selectedPinger == host)
						{
							_tbStartHost.Enabled = true;
							_tbRemoveHost.Enabled = true;
							_tbStopHost.Enabled = false;
						}
					}
				}
			}
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingForm));
            this._notifyIconMenu = new System.Windows.Forms.ContextMenuStrip();
            this.aDDNewHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeHostToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nimRestore = new System.Windows.Forms.ToolStripMenuItem();
            this._nimMaximize = new System.Windows.Forms.ToolStripMenuItem();
            this._nimMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this._nimExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._nimStartAll = new System.Windows.Forms.ToolStripMenuItem();
            this._nimStopAll = new System.Windows.Forms.ToolStripMenuItem();
            this._tbStartAll = new System.Windows.Forms.ToolStripButton();
            this._tbStopAll = new System.Windows.Forms.ToolStripButton();
            this._tbClearAllStatistics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._tbStartHost = new System.Windows.Forms.ToolStripButton();
            this._tbStopHost = new System.Windows.Forms.ToolStripButton();
            this._tbClearStatistics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._tbAddNewHost = new System.Windows.Forms.ToolStripButton();
            this._tbHostOptions = new System.Windows.Forms.ToolStripButton();
            this._tbRemoveHost = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._tbOptions = new System.Windows.Forms.ToolStripButton();
            this._tbAbout = new System.Windows.Forms.ToolStripButton();
            this._tbSave = new System.Windows.Forms.ToolStripButton();
            this._colIpAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colHostDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colPacketSent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colPacketReceived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colPacketReceivedPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colPacketLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colPacketLostPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colLastPacketLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colRecPacketReceived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colRecPacketReceivedPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colRecPacketLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colRecPacketLostPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colCurrentResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colAvargeResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colStatusDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colAliveStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colDeadStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colDnsErrorStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colUnknownStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colAvailability = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colTestDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colCurTestDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._lvHosts = new HostsPinger.ListViewDB();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HOSTN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HOSTD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.STATUS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SENT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RECEIV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LOST = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LAST = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RESEIVREC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RESEIVRECC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LOSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LOSTTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CURRENT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AVIRAGE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.STATUSDUR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ACTIVE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DEAD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DnsErr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UNKSTAUS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HOSTAV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TESTDU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CURRENTTES = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.@__tbStartAll = new System.Windows.Forms.ToolStripButton();
            this.@__tbStopAll = new System.Windows.Forms.ToolStripButton();
            this.@__tbClearAllStatistics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.@__tbStartHost = new System.Windows.Forms.ToolStripButton();
            this.@__tbStopHost = new System.Windows.Forms.ToolStripButton();
            this.@__tbClearStatistics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.@__tbAddNewHost = new System.Windows.Forms.ToolStripButton();
            this.@__tbHostOptions = new System.Windows.Forms.ToolStripButton();
            this.@__tbRemoveHost = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.@__tbSave = new System.Windows.Forms.ToolStripButton();
            this.@__tbOptions = new System.Windows.Forms.ToolStripButton();
            this.@__tbAbout = new System.Windows.Forms.ToolStripButton();
            this._toolbar = new System.Windows.Forms.ToolStrip();
            this.formAssistant1 = new DevExpress.XtraBars.FormAssistant();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.tbStartAll = new DevExpress.XtraBars.BarButtonItem();
            this.tbStopAll = new DevExpress.XtraBars.BarButtonItem();
            this.tbClearAllStatistics = new DevExpress.XtraBars.BarButtonItem();
            this.tbStartHost = new DevExpress.XtraBars.BarButtonItem();
            this.tbStopHost = new DevExpress.XtraBars.BarButtonItem();
            this.tbClearStatistics = new DevExpress.XtraBars.BarButtonItem();
            this.tbAddNewHost = new DevExpress.XtraBars.BarButtonItem();
            this.tbHostOptions = new DevExpress.XtraBars.BarButtonItem();
            this.nAnnulerCalcul = new DevExpress.XtraBars.BarButtonItem();
            this.nFactureAvoir = new DevExpress.XtraBars.BarButtonItem();
            this.nCNASATS = new DevExpress.XtraBars.BarButtonItem();
            this.nCNASMouvement = new DevExpress.XtraBars.BarButtonItem();
            this.nCNASDeclaration = new DevExpress.XtraBars.BarButtonItem();
            this.nRubrique = new DevExpress.XtraBars.BarButtonItem();
            this.nVenteauComptoire = new DevExpress.XtraBars.BarButtonItem();
            this.nBultinPaie = new DevExpress.XtraBars.BarButtonItem();
            this.nDeclaration = new DevExpress.XtraBars.BarButtonItem();
            this.nImpGenrale = new DevExpress.XtraBars.BarButtonItem();
            this.nSaisiePresence = new DevExpress.XtraBars.BarButtonItem();
            this.nB20AA = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem25 = new DevExpress.XtraBars.BarButtonItem();
            this.nClassification = new DevExpress.XtraBars.BarButtonItem();
            this.nPOSTE = new DevExpress.XtraBars.BarButtonItem();
            this.nSTRUCTURE = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem31 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem32 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem33 = new DevExpress.XtraBars.BarButtonItem();
            this.nLocalisation = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem35 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem36 = new DevExpress.XtraBars.BarButtonItem();
            this.nMODEPAIEMENT = new DevExpress.XtraBars.BarButtonItem();
            this.nTables = new DevExpress.XtraBars.BarButtonItem();
            this.nBANQUE = new DevExpress.XtraBars.BarButtonItem();
            this.nAgenceBancaire = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem41 = new DevExpress.XtraBars.BarButtonItem();
            this.nRevaloriserCMP = new DevExpress.XtraBars.BarButtonItem();
            this.nEcart = new DevExpress.XtraBars.BarButtonItem();
            this.nReglementClient = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem45 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem46 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem47 = new DevExpress.XtraBars.BarButtonItem();
            this.nStatistique = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem49 = new DevExpress.XtraBars.BarButtonItem();
            this.nAgenda = new DevExpress.XtraBars.BarButtonItem();
            this.ntableauDeBord = new DevExpress.XtraBars.BarButtonItem();
            this.nInitialiser = new DevExpress.XtraBars.BarButtonItem();
            this.mnReseaux1 = new DevExpress.XtraBars.BarButtonItem();
            this.nTransfererCompta1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem55 = new DevExpress.XtraBars.BarButtonItem();
            this.nRequetteLibre = new DevExpress.XtraBars.BarButtonItem();
            this.nEnregistrement = new DevExpress.XtraBars.BarButtonItem();
            this.naide = new DevExpress.XtraBars.BarButtonItem();
            this.tbAbout = new DevExpress.XtraBars.BarButtonItem();
            this.nEtatG50 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem61 = new DevExpress.XtraBars.BarButtonItem();
            this.nTransfererCompta = new DevExpress.XtraBars.BarButtonItem();
            this.nUsers1 = new DevExpress.XtraBars.BarButtonItem();
            this.barListItem1 = new DevExpress.XtraBars.BarListItem();
            this.skinDropDownButtonItem2 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.tbRemoveHost = new DevExpress.XtraBars.BarButtonItem();
            this.nCalculerETArchiver = new DevExpress.XtraBars.BarButtonItem();
            this.nAvanaces = new DevExpress.XtraBars.BarButtonItem();
            this.nGenererFacture = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.nUsers = new DevExpress.XtraBars.BarButtonItem();
            this.nJournal = new DevExpress.XtraBars.BarButtonItem();
            this.nPersonel = new DevExpress.XtraBars.BarButtonItem();
            this.nPaieinverse = new DevExpress.XtraBars.BarButtonItem();
            this.nPret = new DevExpress.XtraBars.BarButtonItem();
            this.mConge = new DevExpress.XtraBars.BarButtonItem();
            this.bbOrdreMission = new DevExpress.XtraBars.BarButtonItem();
            this.nContrat_Click = new DevExpress.XtraBars.BarButtonItem();
            this.nSaisiVaraibles = new DevExpress.XtraBars.BarButtonItem();
            this.tbSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.tbOptions = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage9 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon();
            this._notifyIconMenu.SuspendLayout();
            this._toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // _notifyIconMenu
            // 
            this._notifyIconMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDDNewHostToolStripMenuItem,
            this.hostOptionsToolStripMenuItem,
            this.clearStatisticsToolStripMenuItem,
            this.startPingToolStripMenuItem,
            this.removeHostToolStripMenuItem,
            this.toolStripMenuItem3,
            this.stopAllToolStripMenuItem});
            this._notifyIconMenu.Name = "_notifyIconMenu";
            this._notifyIconMenu.Size = new System.Drawing.Size(143, 154);
            // 
            // aDDNewHostToolStripMenuItem
            // 
            this.aDDNewHostToolStripMenuItem.Name = "aDDNewHostToolStripMenuItem";
            this.aDDNewHostToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.aDDNewHostToolStripMenuItem.Text = "Restore";
            this.aDDNewHostToolStripMenuItem.Click += new System.EventHandler(this._nimRestore_Click);
            // 
            // hostOptionsToolStripMenuItem
            // 
            this.hostOptionsToolStripMenuItem.Name = "hostOptionsToolStripMenuItem";
            this.hostOptionsToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.hostOptionsToolStripMenuItem.Text = "Maximize";
            this.hostOptionsToolStripMenuItem.Click += new System.EventHandler(this._nimMaximize_Click);
            // 
            // clearStatisticsToolStripMenuItem
            // 
            this.clearStatisticsToolStripMenuItem.Name = "clearStatisticsToolStripMenuItem";
            this.clearStatisticsToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.clearStatisticsToolStripMenuItem.Text = "Minimize";
            this.clearStatisticsToolStripMenuItem.Click += new System.EventHandler(this._nimMinimize_Click);
            // 
            // startPingToolStripMenuItem
            // 
            this.startPingToolStripMenuItem.Name = "startPingToolStripMenuItem";
            this.startPingToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.startPingToolStripMenuItem.Text = "Exit";
            this.startPingToolStripMenuItem.Click += new System.EventHandler(this._nimExit_Click);
            // 
            // removeHostToolStripMenuItem
            // 
            this.removeHostToolStripMenuItem.Name = "removeHostToolStripMenuItem";
            this.removeHostToolStripMenuItem.Size = new System.Drawing.Size(139, 6);
            this.removeHostToolStripMenuItem.Click += new System.EventHandler(this._tbRemoveHost_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(142, 24);
            this.toolStripMenuItem3.Text = "Start All";
            this.toolStripMenuItem3.Click += new System.EventHandler(this._tbStartAll_Click);
            // 
            // stopAllToolStripMenuItem
            // 
            this.stopAllToolStripMenuItem.Name = "stopAllToolStripMenuItem";
            this.stopAllToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.stopAllToolStripMenuItem.Text = "Stop All";
            this.stopAllToolStripMenuItem.Click += new System.EventHandler(this._tbStopAll_Click);
            // 
            // _nimRestore
            // 
            this._nimRestore.Name = "_nimRestore";
            this._nimRestore.Size = new System.Drawing.Size(124, 22);
            this._nimRestore.Text = "Restore";
            this._nimRestore.Click += new System.EventHandler(this._nimRestore_Click);
            // 
            // _nimMaximize
            // 
            this._nimMaximize.Name = "_nimMaximize";
            this._nimMaximize.Size = new System.Drawing.Size(124, 22);
            this._nimMaximize.Text = "Maximize";
            this._nimMaximize.Click += new System.EventHandler(this._nimMaximize_Click);
            // 
            // _nimMinimize
            // 
            this._nimMinimize.Name = "_nimMinimize";
            this._nimMinimize.Size = new System.Drawing.Size(124, 22);
            this._nimMinimize.Text = "Minimize";
            this._nimMinimize.Click += new System.EventHandler(this._nimMinimize_Click);
            // 
            // _nimExit
            // 
            this._nimExit.Name = "_nimExit";
            this._nimExit.Size = new System.Drawing.Size(124, 22);
            this._nimExit.Text = "Exit";
            this._nimExit.Click += new System.EventHandler(this._nimExit_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // _nimStartAll
            // 
            this._nimStartAll.Name = "_nimStartAll";
            this._nimStartAll.Size = new System.Drawing.Size(124, 22);
            this._nimStartAll.Text = "Start All";
            this._nimStartAll.Click += new System.EventHandler(this._tbStartAll_Click);
            // 
            // _nimStopAll
            // 
            this._nimStopAll.Name = "_nimStopAll";
            this._nimStopAll.Size = new System.Drawing.Size(124, 22);
            this._nimStopAll.Text = "Stop All";
            this._nimStopAll.Click += new System.EventHandler(this._tbStopAll_Click);
            // 
            // _tbStartAll
            // 
            this._tbStartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbStartAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbStartAll.Name = "_tbStartAll";
            this._tbStartAll.Size = new System.Drawing.Size(36, 36);
            this._tbStartAll.Text = "Start All";
            this._tbStartAll.Click += new System.EventHandler(this._tbStartAll_Click);
            // 
            // _tbStopAll
            // 
            this._tbStopAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbStopAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbStopAll.Name = "_tbStopAll";
            this._tbStopAll.Size = new System.Drawing.Size(36, 36);
            this._tbStopAll.Text = "Stop All";
            this._tbStopAll.Click += new System.EventHandler(this._tbStopAll_Click);
            // 
            // _tbClearAllStatistics
            // 
            this._tbClearAllStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbClearAllStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbClearAllStatistics.Name = "_tbClearAllStatistics";
            this._tbClearAllStatistics.Size = new System.Drawing.Size(36, 36);
            this._tbClearAllStatistics.Text = "Clear All Statistics";
            this._tbClearAllStatistics.Click += new System.EventHandler(this._tbClearAllStatistics_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // _tbStartHost
            // 
            this._tbStartHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbStartHost.Enabled = false;
            this._tbStartHost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbStartHost.Name = "_tbStartHost";
            this._tbStartHost.Size = new System.Drawing.Size(36, 36);
            this._tbStartHost.Text = "Start Host";
            this._tbStartHost.Click += new System.EventHandler(this._tbStartHost_Click);
            // 
            // _tbStopHost
            // 
            this._tbStopHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbStopHost.Enabled = false;
            this._tbStopHost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbStopHost.Name = "_tbStopHost";
            this._tbStopHost.Size = new System.Drawing.Size(36, 36);
            this._tbStopHost.Text = "Stop Host";
            this._tbStopHost.Click += new System.EventHandler(this._tbStopHost_Click);
            // 
            // _tbClearStatistics
            // 
            this._tbClearStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbClearStatistics.Enabled = false;
            this._tbClearStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbClearStatistics.Name = "_tbClearStatistics";
            this._tbClearStatistics.Size = new System.Drawing.Size(36, 36);
            this._tbClearStatistics.Text = "Clear Statistics";
            this._tbClearStatistics.Click += new System.EventHandler(this._tbClearStatistics_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // _tbAddNewHost
            // 
            this._tbAddNewHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbAddNewHost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbAddNewHost.Name = "_tbAddNewHost";
            this._tbAddNewHost.Size = new System.Drawing.Size(36, 36);
            this._tbAddNewHost.Text = "Add New Host";
            this._tbAddNewHost.Click += new System.EventHandler(this._tbAddNewHost_Click);
            // 
            // _tbHostOptions
            // 
            this._tbHostOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbHostOptions.Enabled = false;
            this._tbHostOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbHostOptions.Name = "_tbHostOptions";
            this._tbHostOptions.Size = new System.Drawing.Size(36, 36);
            this._tbHostOptions.Text = "Host Options";
            this._tbHostOptions.Click += new System.EventHandler(this._tbHostOptions_Click);
            // 
            // _tbRemoveHost
            // 
            this._tbRemoveHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbRemoveHost.Enabled = false;
            this._tbRemoveHost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbRemoveHost.Name = "_tbRemoveHost";
            this._tbRemoveHost.Size = new System.Drawing.Size(36, 36);
            this._tbRemoveHost.Text = "Remove Host";
            this._tbRemoveHost.Click += new System.EventHandler(this._tbRemoveHost_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // _tbOptions
            // 
            this._tbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbOptions.Name = "_tbOptions";
            this._tbOptions.Size = new System.Drawing.Size(36, 36);
            this._tbOptions.Text = "Options";
            this._tbOptions.Click += new System.EventHandler(this._tbOptions_Click);
            // 
            // _tbAbout
            // 
            this._tbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbAbout.Name = "_tbAbout";
            this._tbAbout.Size = new System.Drawing.Size(36, 36);
            this._tbAbout.Text = "About PingHost";
            this._tbAbout.Click += new System.EventHandler(this._tbAbout_Click);
            // 
            // _tbSave
            // 
            this._tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tbSave.Name = "_tbSave";
            this._tbSave.Size = new System.Drawing.Size(36, 36);
            this._tbSave.Text = "Save Hosts";
            this._tbSave.Click += new System.EventHandler(this._tbSave_Click);
            // 
            // _colIpAddr
            // 
            this._colIpAddr.Text = "IP Address";
            this._colIpAddr.Width = 108;
            // 
            // _colHostName
            // 
            this._colHostName.Text = "Host Name";
            this._colHostName.Width = 127;
            // 
            // _colHostDescription
            // 
            this._colHostDescription.Text = "Host Description";
            this._colHostDescription.Width = 164;
            // 
            // _colStatus
            // 
            this._colStatus.Text = "Status";
            this._colStatus.Width = 61;
            // 
            // _colPacketSent
            // 
            this._colPacketSent.Text = "Sent";
            this._colPacketSent.Width = 50;
            // 
            // _colPacketReceived
            // 
            this._colPacketReceived.Text = "Received";
            // 
            // _colPacketReceivedPercent
            // 
            this._colPacketReceivedPercent.Text = "Received %";
            this._colPacketReceivedPercent.Width = 74;
            // 
            // _colPacketLost
            // 
            this._colPacketLost.Text = "Lost";
            this._colPacketLost.Width = 50;
            // 
            // _colPacketLostPercent
            // 
            this._colPacketLostPercent.Text = "Lost %";
            this._colPacketLostPercent.Width = 55;
            // 
            // _colLastPacketLost
            // 
            this._colLastPacketLost.Text = "Last Packet Lost";
            // 
            // _colRecPacketReceived
            // 
            this._colRecPacketReceived.Text = "Received (Recent)";
            // 
            // _colRecPacketReceivedPercent
            // 
            this._colRecPacketReceivedPercent.Text = "Received % (Recent)";
            // 
            // _colRecPacketLost
            // 
            this._colRecPacketLost.Text = "Lost (Recent)";
            // 
            // _colRecPacketLostPercent
            // 
            this._colRecPacketLostPercent.Text = "Lost % (Recent)";
            // 
            // _colCurrentResponseTime
            // 
            this._colCurrentResponseTime.Text = "Current R.T.";
            this._colCurrentResponseTime.Width = 70;
            // 
            // _colAvargeResponseTime
            // 
            this._colAvargeResponseTime.Text = "Avarge R.T.";
            this._colAvargeResponseTime.Width = 70;
            // 
            // _colStatusDuration
            // 
            this._colStatusDuration.Text = "Status Duration";
            this._colStatusDuration.Width = 86;
            // 
            // _colAliveStatus
            // 
            this._colAliveStatus.Text = "Alive Status";
            // 
            // _colDeadStatus
            // 
            this._colDeadStatus.Text = "Dead Status";
            // 
            // _colDnsErrorStatus
            // 
            this._colDnsErrorStatus.Text = "Dns Error Status";
            // 
            // _colUnknownStatus
            // 
            this._colUnknownStatus.Text = "Unknown Status";
            // 
            // _colAvailability
            // 
            this._colAvailability.Text = "Host Availability";
            // 
            // _colTestDuration
            // 
            this._colTestDuration.Text = "Test Duration";
            this._colTestDuration.Width = 76;
            // 
            // _colCurTestDuration
            // 
            this._colCurTestDuration.Text = "Current Test Duration";
            // 
            // _lvHosts
            // 
            this._lvHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lvHosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.HOSTN,
            this.HOSTD,
            this.STATUS,
            this.SENT,
            this.RECEIV,
            this.LOST,
            this.LAST,
            this.RESEIVREC,
            this.RESEIVRECC,
            this.LOSTT,
            this.LOSTTT,
            this.CURRENT,
            this.AVIRAGE,
            this.STATUSDUR,
            this.ACTIVE,
            this.DEAD,
            this.DnsErr,
            this.UNKSTAUS,
            this.HOSTAV,
            this.TESTDU,
            this.CURRENTTES});
            this._lvHosts.FullRowSelect = true;
            this._lvHosts.GridLines = true;
            this._lvHosts.Location = new System.Drawing.Point(0, 153);
            this._lvHosts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._lvHosts.MultiSelect = false;
            this._lvHosts.Name = "_lvHosts";
            this._lvHosts.Size = new System.Drawing.Size(1122, 312);
            this._lvHosts.TabIndex = 0;
            this._lvHosts.UseCompatibleStateImageBehavior = false;
            this._lvHosts.View = System.Windows.Forms.View.Details;
            this._lvHosts.SelectedIndexChanged += new System.EventHandler(this._lvHosts_SelectedIndexChanged);
            this._lvHosts.DoubleClick += new System.EventHandler(this._lvHosts_DoubleClick);
            this._lvHosts.MouseUp += new System.Windows.Forms.MouseEventHandler(this._lvHosts_MouseUp);
            // 
            // IP
            // 
            this.IP.Text = "IP Adress";
            this.IP.Width = 120;
            // 
            // HOSTN
            // 
            this.HOSTN.Text = "Host Name";
            this.HOSTN.Width = 200;
            // 
            // HOSTD
            // 
            this.HOSTD.Text = "Host Description";
            this.HOSTD.Width = 250;
            // 
            // STATUS
            // 
            this.STATUS.Text = "Status";
            // 
            // SENT
            // 
            this.SENT.Text = "Sent";
            this.SENT.Width = 50;
            // 
            // RECEIV
            // 
            this.RECEIV.Text = "Received %";
            this.RECEIV.Width = 70;
            // 
            // LOST
            // 
            this.LOST.Text = "Lost";
            // 
            // LAST
            // 
            this.LAST.Text = "Last Packet Lost";
            this.LAST.Width = 80;
            // 
            // RESEIVREC
            // 
            this.RESEIVREC.Text = "Received (Recent)";
            this.RESEIVREC.Width = 70;
            // 
            // RESEIVRECC
            // 
            this.RESEIVRECC.Text = "Received % (Recent)";
            this.RESEIVRECC.Width = 70;
            // 
            // LOSTT
            // 
            this.LOSTT.Text = "Lost (Recent)";
            // 
            // LOSTTT
            // 
            this.LOSTTT.Text = "Lost % (Recent)";
            // 
            // CURRENT
            // 
            this.CURRENT.Text = "Current R.T.";
            this.CURRENT.Width = 70;
            // 
            // AVIRAGE
            // 
            this.AVIRAGE.Text = "Avirage  R.T.";
            // 
            // STATUSDUR
            // 
            this.STATUSDUR.Text = "Status Durations";
            this.STATUSDUR.Width = 90;
            // 
            // ACTIVE
            // 
            this.ACTIVE.Text = "Active Status";
            this.ACTIVE.Width = 90;
            // 
            // DEAD
            // 
            this.DEAD.Text = "Dead Status";
            this.DEAD.Width = 90;
            // 
            // DnsErr
            // 
            this.DnsErr.Text = "Dns Error Status";
            this.DnsErr.Width = 80;
            // 
            // UNKSTAUS
            // 
            this.UNKSTAUS.Text = "Unknow Status";
            this.UNKSTAUS.Width = 70;
            // 
            // HOSTAV
            // 
            this.HOSTAV.Text = "Host Availability";
            this.HOSTAV.Width = 80;
            // 
            // TESTDU
            // 
            this.TESTDU.Text = "Test Duration";
            this.TESTDU.Width = 70;
            // 
            // CURRENTTES
            // 
            this.CURRENTTES.Text = "Current Test Duration";
            this.CURRENTTES.Width = 70;
            // 
            // __tbStartAll
            // 
            this.@__tbStartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbStartAll.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbStartAll.Name = "__tbStartAll";
            this.@__tbStartAll.Size = new System.Drawing.Size(23, 22);
            this.@__tbStartAll.Text = "Start All";
            this.@__tbStartAll.Click += new System.EventHandler(this._tbStartAll_Click);
            // 
            // __tbStopAll
            // 
            this.@__tbStopAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbStopAll.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbStopAll.Name = "__tbStopAll";
            this.@__tbStopAll.Size = new System.Drawing.Size(23, 22);
            this.@__tbStopAll.Text = "Stop All";
            this.@__tbStopAll.Click += new System.EventHandler(this._tbStopAll_Click);
            // 
            // __tbClearAllStatistics
            // 
            this.@__tbClearAllStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbClearAllStatistics.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbClearAllStatistics.Name = "__tbClearAllStatistics";
            this.@__tbClearAllStatistics.Size = new System.Drawing.Size(23, 22);
            this.@__tbClearAllStatistics.Text = "Clear All Statistics";
            this.@__tbClearAllStatistics.Click += new System.EventHandler(this._tbClearAllStatistics_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // __tbStartHost
            // 
            this.@__tbStartHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbStartHost.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbStartHost.Name = "__tbStartHost";
            this.@__tbStartHost.Size = new System.Drawing.Size(23, 22);
            this.@__tbStartHost.Text = "Start Host";
            this.@__tbStartHost.Click += new System.EventHandler(this._tbStartHost_Click);
            // 
            // __tbStopHost
            // 
            this.@__tbStopHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbStopHost.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbStopHost.Name = "__tbStopHost";
            this.@__tbStopHost.Size = new System.Drawing.Size(23, 22);
            this.@__tbStopHost.Text = "Stop Host";
            this.@__tbStopHost.Click += new System.EventHandler(this._tbStopHost_Click);
            // 
            // __tbClearStatistics
            // 
            this.@__tbClearStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbClearStatistics.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbClearStatistics.Name = "__tbClearStatistics";
            this.@__tbClearStatistics.Size = new System.Drawing.Size(23, 22);
            this.@__tbClearStatistics.Text = "Clear Statistics";
            this.@__tbClearStatistics.Click += new System.EventHandler(this._tbClearStatistics_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // __tbAddNewHost
            // 
            this.@__tbAddNewHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbAddNewHost.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbAddNewHost.Name = "__tbAddNewHost";
            this.@__tbAddNewHost.Size = new System.Drawing.Size(23, 22);
            this.@__tbAddNewHost.Text = "Add New Host";
            this.@__tbAddNewHost.Click += new System.EventHandler(this._tbAddNewHost_Click);
            // 
            // __tbHostOptions
            // 
            this.@__tbHostOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbHostOptions.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbHostOptions.Name = "__tbHostOptions";
            this.@__tbHostOptions.Size = new System.Drawing.Size(23, 22);
            this.@__tbHostOptions.Text = "Host Options";
            this.@__tbHostOptions.Click += new System.EventHandler(this._tbHostOptions_Click);
            // 
            // __tbRemoveHost
            // 
            this.@__tbRemoveHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbRemoveHost.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbRemoveHost.Name = "__tbRemoveHost";
            this.@__tbRemoveHost.Size = new System.Drawing.Size(23, 22);
            this.@__tbRemoveHost.Text = "Remove Host";
            this.@__tbRemoveHost.Click += new System.EventHandler(this._tbRemoveHost_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // __tbSave
            // 
            this.@__tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbSave.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbSave.Name = "__tbSave";
            this.@__tbSave.Size = new System.Drawing.Size(23, 22);
            this.@__tbSave.Text = "Save Hosts";
            this.@__tbSave.Click += new System.EventHandler(this._tbSave_Click);
            // 
            // __tbOptions
            // 
            this.@__tbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbOptions.ImageTransparentColor = System.Drawing.Color.White;
            this.@__tbOptions.Name = "__tbOptions";
            this.@__tbOptions.Size = new System.Drawing.Size(23, 22);
            this.@__tbOptions.Text = "Options";
            this.@__tbOptions.Click += new System.EventHandler(this._tbOptions_Click);
            // 
            // __tbAbout
            // 
            this.@__tbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.@__tbAbout.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.@__tbAbout.Name = "__tbAbout";
            this.@__tbAbout.Size = new System.Drawing.Size(23, 22);
            this.@__tbAbout.Text = "About PingHost";
            this.@__tbAbout.Click += new System.EventHandler(this._tbAbout_Click);
            // 
            // _toolbar
            // 
            this._toolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this._toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__tbStartAll,
            this.@__tbStopAll,
            this.@__tbClearAllStatistics,
            this.toolStripSeparator2,
            this.@__tbStartHost,
            this.@__tbStopHost,
            this.@__tbClearStatistics,
            this.toolStripSeparator4,
            this.@__tbAddNewHost,
            this.@__tbHostOptions,
            this.@__tbRemoveHost,
            this.toolStripSeparator6,
            this.@__tbSave,
            this.@__tbOptions,
            this.@__tbAbout});
            this._toolbar.Location = new System.Drawing.Point(0, 0);
            this._toolbar.Name = "_toolbar";
            this._toolbar.Size = new System.Drawing.Size(1122, 25);
            this._toolbar.TabIndex = 3;
            this._toolbar.Text = "Toolbar";
            this._toolbar.Visible = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.tbStartAll,
            this.tbStopAll,
            this.tbClearAllStatistics,
            this.tbStartHost,
            this.tbStopHost,
            this.tbClearStatistics,
            this.tbAddNewHost,
            this.tbHostOptions,
            this.nAnnulerCalcul,
            this.nFactureAvoir,
            this.nCNASATS,
            this.nCNASMouvement,
            this.nCNASDeclaration,
            this.nRubrique,
            this.nVenteauComptoire,
            this.nBultinPaie,
            this.nDeclaration,
            this.nImpGenrale,
            this.nSaisiePresence,
            this.nB20AA,
            this.barButtonItem25,
            this.nClassification,
            this.nPOSTE,
            this.nSTRUCTURE,
            this.barButtonItem31,
            this.barButtonItem32,
            this.barButtonItem33,
            this.nLocalisation,
            this.barButtonItem35,
            this.barButtonItem36,
            this.nMODEPAIEMENT,
            this.nTables,
            this.nBANQUE,
            this.nAgenceBancaire,
            this.barButtonItem41,
            this.nRevaloriserCMP,
            this.nEcart,
            this.nReglementClient,
            this.barButtonItem45,
            this.barButtonItem46,
            this.barButtonItem47,
            this.nStatistique,
            this.barButtonItem49,
            this.nAgenda,
            this.ntableauDeBord,
            this.nInitialiser,
            this.mnReseaux1,
            this.nTransfererCompta1,
            this.barButtonItem55,
            this.nRequetteLibre,
            this.nEnregistrement,
            this.naide,
            this.tbAbout,
            this.nEtatG50,
            this.barButtonItem61,
            this.nTransfererCompta,
            this.nUsers1,
            this.barListItem1,
            this.skinDropDownButtonItem2,
            this.tbRemoveHost,
            this.nCalculerETArchiver,
            this.nAvanaces,
            this.nGenererFacture,
            this.barButtonItem17,
            this.nUsers,
            this.nJournal,
            this.nPersonel,
            this.nPaieinverse,
            this.nPret,
            this.mConge,
            this.bbOrdreMission,
            this.nContrat_Click,
            this.nSaisiVaraibles,
            this.tbSave,
            this.barButtonItem1,
            this.barButtonItem3,
            this.tbOptions,
            this.barButtonItem4});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonControl1.MaxItemId = 79;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage9});
            this.ribbonControl1.Size = new System.Drawing.Size(1122, 145);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // tbStartAll
            // 
            this.tbStartAll.Caption = "Start All";
            this.tbStartAll.Id = 1;
            this.tbStartAll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbStartAll.ImageOptions.SvgImage")));
            this.tbStartAll.Name = "tbStartAll";
            this.tbStartAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this._tbStartAll_Click);
            // 
            // tbStopAll
            // 
            this.tbStopAll.Caption = "Stop All";
            this.tbStopAll.Id = 3;
            this.tbStopAll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbStopAll.ImageOptions.SvgImage")));
            this.tbStopAll.Name = "tbStopAll";
            this.tbStopAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbStopAll_ItemClick);
            // 
            // tbClearAllStatistics
            // 
            this.tbClearAllStatistics.Caption = "Clear All Statistics";
            this.tbClearAllStatistics.Id = 4;
            this.tbClearAllStatistics.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbClearAllStatistics.ImageOptions.SvgImage")));
            this.tbClearAllStatistics.Name = "tbClearAllStatistics";
            this.tbClearAllStatistics.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbClearAllStatistics_ItemClick);
            // 
            // tbStartHost
            // 
            this.tbStartHost.Caption = "Start Host";
            this.tbStartHost.Id = 5;
            this.tbStartHost.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbStartHost.ImageOptions.SvgImage")));
            this.tbStartHost.Name = "tbStartHost";
            this.tbStartHost.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbStartHost_ItemClick);
            // 
            // tbStopHost
            // 
            this.tbStopHost.Caption = "Stop Host";
            this.tbStopHost.Id = 6;
            this.tbStopHost.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbStopHost.ImageOptions.SvgImage")));
            this.tbStopHost.Name = "tbStopHost";
            this.tbStopHost.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbStopHost_ItemClick);
            // 
            // tbClearStatistics
            // 
            this.tbClearStatistics.Caption = "Clear Statistics";
            this.tbClearStatistics.Id = 7;
            this.tbClearStatistics.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbClearStatistics.ImageOptions.SvgImage")));
            this.tbClearStatistics.Name = "tbClearStatistics";
            this.tbClearStatistics.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbClearStatistics_ItemClick);
            // 
            // tbAddNewHost
            // 
            this.tbAddNewHost.Caption = "Add New Host";
            this.tbAddNewHost.Id = 8;
            this.tbAddNewHost.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbAddNewHost.ImageOptions.SvgImage")));
            this.tbAddNewHost.Name = "tbAddNewHost";
            this.tbAddNewHost.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbAddNewHost_ItemClick);
            // 
            // tbHostOptions
            // 
            this.tbHostOptions.Caption = "Host Options";
            this.tbHostOptions.Id = 9;
            this.tbHostOptions.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbHostOptions.ImageOptions.SvgImage")));
            this.tbHostOptions.Name = "tbHostOptions";
            this.tbHostOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbHostOptions_ItemClick);
            // 
            // nAnnulerCalcul
            // 
            this.nAnnulerCalcul.Caption = "Annuler le Calcul";
            this.nAnnulerCalcul.Id = 10;
            this.nAnnulerCalcul.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nAnnulerCalcul.ImageOptions.SvgImage")));
            this.nAnnulerCalcul.Name = "nAnnulerCalcul";
            // 
            // nFactureAvoir
            // 
            this.nFactureAvoir.Caption = "Facture Avoire FRN";
            this.nFactureAvoir.Id = 12;
            this.nFactureAvoir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nFactureAvoir.ImageOptions.LargeImage")));
            this.nFactureAvoir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nFactureAvoir.ImageOptions.SvgImage")));
            this.nFactureAvoir.Name = "nFactureAvoir";
            // 
            // nCNASATS
            // 
            this.nCNASATS.Caption = "ATS";
            this.nCNASATS.Id = 13;
            this.nCNASATS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nCNASATS.ImageOptions.SvgImage")));
            this.nCNASATS.Name = "nCNASATS";
            // 
            // nCNASMouvement
            // 
            this.nCNASMouvement.Caption = "Mouvement";
            this.nCNASMouvement.Id = 14;
            this.nCNASMouvement.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nCNASMouvement.ImageOptions.LargeImage")));
            this.nCNASMouvement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nCNASMouvement.ImageOptions.SvgImage")));
            this.nCNASMouvement.Name = "nCNASMouvement";
            // 
            // nCNASDeclaration
            // 
            this.nCNASDeclaration.Caption = "Déclaration";
            this.nCNASDeclaration.Id = 15;
            this.nCNASDeclaration.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nCNASDeclaration.ImageOptions.SvgImage")));
            this.nCNASDeclaration.Name = "nCNASDeclaration";
            // 
            // nRubrique
            // 
            this.nRubrique.Caption = "Rubriques (plan paie)";
            this.nRubrique.Id = 17;
            this.nRubrique.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nRubrique.ImageOptions.SvgImage")));
            this.nRubrique.Name = "nRubrique";
            // 
            // nVenteauComptoire
            // 
            this.nVenteauComptoire.Caption = "Vente au Comptoire";
            this.nVenteauComptoire.Id = 19;
            this.nVenteauComptoire.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nVenteauComptoire.ImageOptions.Image")));
            this.nVenteauComptoire.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nVenteauComptoire.ImageOptions.LargeImage")));
            this.nVenteauComptoire.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nVenteauComptoire.ImageOptions.SvgImage")));
            this.nVenteauComptoire.Name = "nVenteauComptoire";
            // 
            // nBultinPaie
            // 
            this.nBultinPaie.Caption = "Bulletins de Paie";
            this.nBultinPaie.Id = 20;
            this.nBultinPaie.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nBultinPaie.ImageOptions.Image")));
            this.nBultinPaie.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nBultinPaie.ImageOptions.LargeImage")));
            this.nBultinPaie.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nBultinPaie.ImageOptions.SvgImage")));
            this.nBultinPaie.Name = "nBultinPaie";
            // 
            // nDeclaration
            // 
            this.nDeclaration.Caption = "Declaration Social et Fiscal";
            this.nDeclaration.Id = 22;
            this.nDeclaration.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nDeclaration.ImageOptions.Image")));
            this.nDeclaration.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nDeclaration.ImageOptions.LargeImage")));
            this.nDeclaration.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nDeclaration.ImageOptions.SvgImage")));
            this.nDeclaration.Name = "nDeclaration";
            // 
            // nImpGenrale
            // 
            this.nImpGenrale.Caption = "Impression Générale";
            this.nImpGenrale.Id = 23;
            this.nImpGenrale.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nImpGenrale.ImageOptions.Image")));
            this.nImpGenrale.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nImpGenrale.ImageOptions.LargeImage")));
            this.nImpGenrale.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nImpGenrale.ImageOptions.SvgImage")));
            this.nImpGenrale.Name = "nImpGenrale";
            // 
            // nSaisiePresence
            // 
            this.nSaisiePresence.Caption = "Saisie Présence";
            this.nSaisiePresence.Id = 24;
            this.nSaisiePresence.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nSaisiePresence.ImageOptions.SvgImage")));
            this.nSaisiePresence.Name = "nSaisiePresence";
            // 
            // nB20AA
            // 
            this.nB20AA.Caption = "Facture Avoire Client";
            this.nB20AA.Id = 25;
            this.nB20AA.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nB20AA.ImageOptions.Image")));
            this.nB20AA.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nB20AA.ImageOptions.LargeImage")));
            this.nB20AA.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nB20AA.ImageOptions.SvgImage")));
            this.nB20AA.Name = "nB20AA";
            // 
            // barButtonItem25
            // 
            this.barButtonItem25.Caption = "Client";
            this.barButtonItem25.Id = 26;
            this.barButtonItem25.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem25.ImageOptions.Image")));
            this.barButtonItem25.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem25.ImageOptions.LargeImage")));
            this.barButtonItem25.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem25.ImageOptions.SvgImage")));
            this.barButtonItem25.Name = "barButtonItem25";
            // 
            // nClassification
            // 
            this.nClassification.Caption = "Classification";
            this.nClassification.Id = 29;
            this.nClassification.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nClassification.ImageOptions.Image")));
            this.nClassification.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nClassification.ImageOptions.LargeImage")));
            this.nClassification.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nClassification.ImageOptions.SvgImage")));
            this.nClassification.Name = "nClassification";
            // 
            // nPOSTE
            // 
            this.nPOSTE.Caption = "Poste";
            this.nPOSTE.Id = 30;
            this.nPOSTE.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nPOSTE.ImageOptions.Image")));
            this.nPOSTE.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nPOSTE.ImageOptions.LargeImage")));
            this.nPOSTE.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nPOSTE.ImageOptions.SvgImage")));
            this.nPOSTE.Name = "nPOSTE";
            // 
            // nSTRUCTURE
            // 
            this.nSTRUCTURE.Caption = "Structure";
            this.nSTRUCTURE.Id = 31;
            this.nSTRUCTURE.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nSTRUCTURE.ImageOptions.Image")));
            this.nSTRUCTURE.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nSTRUCTURE.ImageOptions.LargeImage")));
            this.nSTRUCTURE.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nSTRUCTURE.ImageOptions.SvgImage")));
            this.nSTRUCTURE.Name = "nSTRUCTURE";
            // 
            // barButtonItem31
            // 
            this.barButtonItem31.Caption = "Fabrication";
            this.barButtonItem31.Id = 32;
            this.barButtonItem31.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem31.ImageOptions.Image")));
            this.barButtonItem31.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem31.ImageOptions.LargeImage")));
            this.barButtonItem31.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem31.ImageOptions.SvgImage")));
            this.barButtonItem31.Name = "barButtonItem31";
            // 
            // barButtonItem32
            // 
            this.barButtonItem32.Caption = "Désassemblage";
            this.barButtonItem32.Id = 33;
            this.barButtonItem32.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem32.ImageOptions.Image")));
            this.barButtonItem32.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem32.ImageOptions.LargeImage")));
            this.barButtonItem32.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem32.ImageOptions.SvgImage")));
            this.barButtonItem32.Name = "barButtonItem32";
            // 
            // barButtonItem33
            // 
            this.barButtonItem33.Caption = "Journal de Fabrication";
            this.barButtonItem33.Id = 34;
            this.barButtonItem33.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem33.ImageOptions.Image")));
            this.barButtonItem33.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem33.ImageOptions.LargeImage")));
            this.barButtonItem33.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem33.ImageOptions.SvgImage")));
            this.barButtonItem33.Name = "barButtonItem33";
            // 
            // nLocalisation
            // 
            this.nLocalisation.Caption = "Liste Des Dépots";
            this.nLocalisation.Id = 35;
            this.nLocalisation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nLocalisation.ImageOptions.Image")));
            this.nLocalisation.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nLocalisation.ImageOptions.LargeImage")));
            this.nLocalisation.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nLocalisation.ImageOptions.SvgImage")));
            this.nLocalisation.Name = "nLocalisation";
            // 
            // barButtonItem35
            // 
            this.barButtonItem35.Caption = "Transfert Entre Dépots";
            this.barButtonItem35.Id = 36;
            this.barButtonItem35.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem35.ImageOptions.Image")));
            this.barButtonItem35.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem35.ImageOptions.LargeImage")));
            this.barButtonItem35.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem35.ImageOptions.SvgImage")));
            this.barButtonItem35.Name = "barButtonItem35";
            // 
            // barButtonItem36
            // 
            this.barButtonItem36.Caption = "Etat des Dépots";
            this.barButtonItem36.Id = 37;
            this.barButtonItem36.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem36.ImageOptions.Image")));
            this.barButtonItem36.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem36.ImageOptions.LargeImage")));
            this.barButtonItem36.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem36.ImageOptions.SvgImage")));
            this.barButtonItem36.Name = "barButtonItem36";
            // 
            // nMODEPAIEMENT
            // 
            this.nMODEPAIEMENT.Caption = "Mode de Paiment";
            this.nMODEPAIEMENT.Id = 38;
            this.nMODEPAIEMENT.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nMODEPAIEMENT.ImageOptions.Image")));
            this.nMODEPAIEMENT.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nMODEPAIEMENT.ImageOptions.LargeImage")));
            this.nMODEPAIEMENT.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nMODEPAIEMENT.ImageOptions.SvgImage")));
            this.nMODEPAIEMENT.Name = "nMODEPAIEMENT";
            // 
            // nTables
            // 
            this.nTables.Caption = "Tables";
            this.nTables.Id = 39;
            this.nTables.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nTables.ImageOptions.Image")));
            this.nTables.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nTables.ImageOptions.LargeImage")));
            this.nTables.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nTables.ImageOptions.SvgImage")));
            this.nTables.Name = "nTables";
            // 
            // nBANQUE
            // 
            this.nBANQUE.Caption = "Banques";
            this.nBANQUE.Id = 40;
            this.nBANQUE.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nBANQUE.ImageOptions.Image")));
            this.nBANQUE.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nBANQUE.ImageOptions.LargeImage")));
            this.nBANQUE.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nBANQUE.ImageOptions.SvgImage")));
            this.nBANQUE.Name = "nBANQUE";
            // 
            // nAgenceBancaire
            // 
            this.nAgenceBancaire.Caption = "Agence Bancaire";
            this.nAgenceBancaire.Id = 41;
            this.nAgenceBancaire.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nAgenceBancaire.ImageOptions.Image")));
            this.nAgenceBancaire.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nAgenceBancaire.ImageOptions.LargeImage")));
            this.nAgenceBancaire.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nAgenceBancaire.ImageOptions.SvgImage")));
            this.nAgenceBancaire.Name = "nAgenceBancaire";
            // 
            // barButtonItem41
            // 
            this.barButtonItem41.Caption = "Bon de Sortie";
            this.barButtonItem41.Id = 42;
            this.barButtonItem41.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem41.ImageOptions.Image")));
            this.barButtonItem41.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem41.ImageOptions.LargeImage")));
            this.barButtonItem41.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem41.ImageOptions.SvgImage")));
            this.barButtonItem41.Name = "barButtonItem41";
            // 
            // nRevaloriserCMP
            // 
            this.nRevaloriserCMP.Caption = "Revalorisé le cout moyen pondéré";
            this.nRevaloriserCMP.Id = 43;
            this.nRevaloriserCMP.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nRevaloriserCMP.ImageOptions.Image")));
            this.nRevaloriserCMP.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nRevaloriserCMP.ImageOptions.LargeImage")));
            this.nRevaloriserCMP.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nRevaloriserCMP.ImageOptions.SvgImage")));
            this.nRevaloriserCMP.Name = "nRevaloriserCMP";
            // 
            // nEcart
            // 
            this.nEcart.Caption = "Gestion des écarts";
            this.nEcart.Id = 44;
            this.nEcart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nEcart.ImageOptions.Image")));
            this.nEcart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nEcart.ImageOptions.LargeImage")));
            this.nEcart.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nEcart.ImageOptions.SvgImage")));
            this.nEcart.Name = "nEcart";
            // 
            // nReglementClient
            // 
            this.nReglementClient.Caption = "Réglements Clients";
            this.nReglementClient.Id = 45;
            this.nReglementClient.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nReglementClient.ImageOptions.Image")));
            this.nReglementClient.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nReglementClient.ImageOptions.LargeImage")));
            this.nReglementClient.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nReglementClient.ImageOptions.SvgImage")));
            this.nReglementClient.Name = "nReglementClient";
            // 
            // barButtonItem45
            // 
            this.barButtonItem45.Caption = "Paiements Fournisseurs";
            this.barButtonItem45.Id = 46;
            this.barButtonItem45.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem45.ImageOptions.Image")));
            this.barButtonItem45.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem45.ImageOptions.LargeImage")));
            this.barButtonItem45.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem45.ImageOptions.SvgImage")));
            this.barButtonItem45.Name = "barButtonItem45";
            // 
            // barButtonItem46
            // 
            this.barButtonItem46.Caption = "Autre Encaissements";
            this.barButtonItem46.Id = 47;
            this.barButtonItem46.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem46.ImageOptions.Image")));
            this.barButtonItem46.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem46.ImageOptions.LargeImage")));
            this.barButtonItem46.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem46.ImageOptions.SvgImage")));
            this.barButtonItem46.Name = "barButtonItem46";
            // 
            // barButtonItem47
            // 
            this.barButtonItem47.Caption = "Autre Decaissement";
            this.barButtonItem47.Id = 48;
            this.barButtonItem47.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem47.ImageOptions.Image")));
            this.barButtonItem47.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem47.ImageOptions.LargeImage")));
            this.barButtonItem47.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem47.ImageOptions.SvgImage")));
            this.barButtonItem47.Name = "barButtonItem47";
            // 
            // nStatistique
            // 
            this.nStatistique.Caption = "Chiffre d\'Affaire";
            this.nStatistique.Id = 49;
            this.nStatistique.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nStatistique.ImageOptions.Image")));
            this.nStatistique.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nStatistique.ImageOptions.LargeImage")));
            this.nStatistique.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nStatistique.ImageOptions.SvgImage")));
            this.nStatistique.Name = "nStatistique";
            // 
            // barButtonItem49
            // 
            this.barButtonItem49.Caption = "Tableau de Bord";
            this.barButtonItem49.Id = 50;
            this.barButtonItem49.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem49.ImageOptions.Image")));
            this.barButtonItem49.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem49.ImageOptions.LargeImage")));
            this.barButtonItem49.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem49.ImageOptions.SvgImage")));
            this.barButtonItem49.Name = "barButtonItem49";
            // 
            // nAgenda
            // 
            this.nAgenda.Caption = "Agenda";
            this.nAgenda.Id = 51;
            this.nAgenda.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nAgenda.ImageOptions.Image")));
            this.nAgenda.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nAgenda.ImageOptions.LargeImage")));
            this.nAgenda.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nAgenda.ImageOptions.SvgImage")));
            this.nAgenda.Name = "nAgenda";
            // 
            // ntableauDeBord
            // 
            this.ntableauDeBord.Caption = "Tableau de Bord";
            this.ntableauDeBord.Id = 52;
            this.ntableauDeBord.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ntableauDeBord.ImageOptions.SvgImage")));
            this.ntableauDeBord.Name = "ntableauDeBord";
            // 
            // nInitialiser
            // 
            this.nInitialiser.Caption = "Initialiser Un Dossier";
            this.nInitialiser.Id = 53;
            this.nInitialiser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nInitialiser.ImageOptions.Image")));
            this.nInitialiser.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nInitialiser.ImageOptions.LargeImage")));
            this.nInitialiser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nInitialiser.ImageOptions.SvgImage")));
            this.nInitialiser.Name = "nInitialiser";
            // 
            // mnReseaux1
            // 
            this.mnReseaux1.Caption = "Connexion Réseaux";
            this.mnReseaux1.Id = 54;
            this.mnReseaux1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnReseaux1.ImageOptions.Image")));
            this.mnReseaux1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mnReseaux1.ImageOptions.LargeImage")));
            this.mnReseaux1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnReseaux1.ImageOptions.SvgImage")));
            this.mnReseaux1.Name = "mnReseaux1";
            // 
            // nTransfererCompta1
            // 
            this.nTransfererCompta1.Caption = "Transferer vers comptabilité";
            this.nTransfererCompta1.Id = 55;
            this.nTransfererCompta1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nTransfererCompta1.ImageOptions.Image")));
            this.nTransfererCompta1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nTransfererCompta1.ImageOptions.LargeImage")));
            this.nTransfererCompta1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nTransfererCompta1.ImageOptions.SvgImage")));
            this.nTransfererCompta1.Name = "nTransfererCompta1";
            this.nTransfererCompta1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem55
            // 
            this.barButtonItem55.Caption = "Tables";
            this.barButtonItem55.Id = 56;
            this.barButtonItem55.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem55.ImageOptions.Image")));
            this.barButtonItem55.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem55.ImageOptions.LargeImage")));
            this.barButtonItem55.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem55.ImageOptions.SvgImage")));
            this.barButtonItem55.Name = "barButtonItem55";
            // 
            // nRequetteLibre
            // 
            this.nRequetteLibre.Caption = "Requettes Libres";
            this.nRequetteLibre.Id = 57;
            this.nRequetteLibre.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nRequetteLibre.ImageOptions.Image")));
            this.nRequetteLibre.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nRequetteLibre.ImageOptions.LargeImage")));
            this.nRequetteLibre.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nRequetteLibre.ImageOptions.SvgImage")));
            this.nRequetteLibre.Name = "nRequetteLibre";
            // 
            // nEnregistrement
            // 
            this.nEnregistrement.Caption = "Enregistrement";
            this.nEnregistrement.Id = 58;
            this.nEnregistrement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nEnregistrement.ImageOptions.Image")));
            this.nEnregistrement.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nEnregistrement.ImageOptions.LargeImage")));
            this.nEnregistrement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nEnregistrement.ImageOptions.SvgImage")));
            this.nEnregistrement.Name = "nEnregistrement";
            this.nEnregistrement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.nEnregistrement_ItemClick);
            // 
            // naide
            // 
            this.naide.Caption = "Help";
            this.naide.Id = 59;
            this.naide.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("naide.ImageOptions.Image")));
            this.naide.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("naide.ImageOptions.LargeImage")));
            this.naide.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("naide.ImageOptions.SvgImage")));
            this.naide.Name = "naide";
            // 
            // tbAbout
            // 
            this.tbAbout.Caption = "About HostsPinger";
            this.tbAbout.Id = 60;
            this.tbAbout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tbAbout.ImageOptions.Image")));
            this.tbAbout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("tbAbout.ImageOptions.LargeImage")));
            this.tbAbout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbAbout.ImageOptions.SvgImage")));
            this.tbAbout.Name = "tbAbout";
            this.tbAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbAbout_ItemClick);
            // 
            // nEtatG50
            // 
            this.nEtatG50.Caption = "Etat G50";
            this.nEtatG50.Id = 62;
            this.nEtatG50.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nEtatG50.ImageOptions.Image")));
            this.nEtatG50.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nEtatG50.ImageOptions.LargeImage")));
            this.nEtatG50.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nEtatG50.ImageOptions.SvgImage")));
            this.nEtatG50.Name = "nEtatG50";
            this.nEtatG50.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem61
            // 
            this.barButtonItem61.Caption = "Configuration Journal";
            this.barButtonItem61.Id = 63;
            this.barButtonItem61.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem61.ImageOptions.Image")));
            this.barButtonItem61.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem61.ImageOptions.LargeImage")));
            this.barButtonItem61.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem61.ImageOptions.SvgImage")));
            this.barButtonItem61.Name = "barButtonItem61";
            // 
            // nTransfererCompta
            // 
            this.nTransfererCompta.Caption = "Transfert vers Compta";
            this.nTransfererCompta.Id = 64;
            this.nTransfererCompta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nTransfererCompta.ImageOptions.Image")));
            this.nTransfererCompta.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nTransfererCompta.ImageOptions.LargeImage")));
            this.nTransfererCompta.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nTransfererCompta.ImageOptions.SvgImage")));
            this.nTransfererCompta.Name = "nTransfererCompta";
            // 
            // nUsers1
            // 
            this.nUsers1.Caption = "Utilisateurs";
            this.nUsers1.Id = 69;
            this.nUsers1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nUsers1.ImageOptions.Image")));
            this.nUsers1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nUsers1.ImageOptions.LargeImage")));
            this.nUsers1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nUsers1.ImageOptions.SvgImage")));
            this.nUsers1.Name = "nUsers1";
            this.nUsers1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barListItem1
            // 
            this.barListItem1.Caption = "Styles";
            this.barListItem1.Id = 70;
            this.barListItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barListItem1.ImageOptions.Image")));
            this.barListItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barListItem1.ImageOptions.LargeImage")));
            this.barListItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barListItem1.ImageOptions.SvgImage")));
            this.barListItem1.ItemIndex = 2;
            this.barListItem1.Name = "barListItem1";
            this.barListItem1.Strings.AddRange(new object[] {
            "DevExpress Style",
            "The Bezier",
            "DevExpress Dark Style",
            "Visual Studio 2013 Blue",
            "Visual Studio 2013 Dark",
            "Visual Studio 2013 Light",
            "Visual Studio 2010 ",
            "Office 2016 Colorful",
            "Office 2016 Dark",
            "Office 2016 Black",
            "Office 2013 White",
            "Office 2013 Dark Gray",
            "Office 2013 Light Gray",
            "Caramel",
            "Money Twins",
            "Lilian",
            "The Asphalt World",
            "iMaginary",
            "Black",
            "Blue",
            "Coffee",
            "Liquid Sky",
            "London Liquid Sky",
            "Glass Oceans",
            "Stardust",
            "Xmas 2008 Blue",
            "Valentine",
            "McSkin",
            "Summer 2008",
            "Pumpkin",
            "Dark Side",
            "Springtime",
            "Darkroom",
            "Foggy",
            "High Contrast",
            "Seven",
            "Seven Classic",
            "Sharp",
            "Sharp Plus",
            "DevExpress Style",
            "Office 2007 Blue",
            "Office 2007 Black",
            "Office 2007 Silver",
            "Office 2007 Green",
            "Office 2007 Pink",
            "Office 2010 Blue",
            "Office 2010 Black",
            "Office 2010 Silver"});
            this.barListItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // skinDropDownButtonItem2
            // 
            this.skinDropDownButtonItem2.Id = 71;
            this.skinDropDownButtonItem2.Name = "skinDropDownButtonItem2";
            // 
            // tbRemoveHost
            // 
            this.tbRemoveHost.Caption = "Remove Host";
            this.tbRemoveHost.Id = 72;
            this.tbRemoveHost.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("tbRemoveHost.ImageOptions.DisabledLargeImage")));
            this.tbRemoveHost.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbRemoveHost.ImageOptions.SvgImage")));
            this.tbRemoveHost.Name = "tbRemoveHost";
            this.tbRemoveHost.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbRemoveHost_ItemClick);
            // 
            // nCalculerETArchiver
            // 
            this.nCalculerETArchiver.Caption = "Calculer Et Archiver";
            this.nCalculerETArchiver.Id = 73;
            this.nCalculerETArchiver.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nCalculerETArchiver.ImageOptions.Image")));
            this.nCalculerETArchiver.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nCalculerETArchiver.ImageOptions.LargeImage")));
            this.nCalculerETArchiver.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nCalculerETArchiver.ImageOptions.SvgImage")));
            this.nCalculerETArchiver.Name = "nCalculerETArchiver";
            // 
            // nAvanaces
            // 
            this.nAvanaces.Caption = "Avances";
            this.nAvanaces.Id = 74;
            this.nAvanaces.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nAvanaces.ImageOptions.SvgImage")));
            this.nAvanaces.Name = "nAvanaces";
            // 
            // nGenererFacture
            // 
            this.nGenererFacture.Caption = "Générer Facteur";
            this.nGenererFacture.Id = 75;
            this.nGenererFacture.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nGenererFacture.ImageOptions.Image")));
            this.nGenererFacture.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nGenererFacture.ImageOptions.LargeImage")));
            this.nGenererFacture.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nGenererFacture.ImageOptions.SvgImage")));
            this.nGenererFacture.Name = "nGenererFacture";
            // 
            // barButtonItem17
            // 
            this.barButtonItem17.Caption = "Revalorisé le cout moyen pondéré";
            this.barButtonItem17.Id = 1;
            this.barButtonItem17.Name = "barButtonItem17";
            // 
            // nUsers
            // 
            this.nUsers.Caption = "Utilisateur";
            this.nUsers.Id = 2;
            this.nUsers.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nUsers.ImageOptions.SvgImage")));
            this.nUsers.Name = "nUsers";
            // 
            // nJournal
            // 
            this.nJournal.Caption = "Journal de Paie";
            this.nJournal.Id = 3;
            this.nJournal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nJournal.ImageOptions.SvgImage")));
            this.nJournal.Name = "nJournal";
            // 
            // nPersonel
            // 
            this.nPersonel.Caption = "Personel";
            this.nPersonel.Id = 4;
            this.nPersonel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nPersonel.ImageOptions.SvgImage")));
            this.nPersonel.Name = "nPersonel";
            // 
            // nPaieinverse
            // 
            this.nPaieinverse.Caption = "Paie Inversé";
            this.nPaieinverse.Id = 6;
            this.nPaieinverse.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nPaieinverse.ImageOptions.SvgImage")));
            this.nPaieinverse.Name = "nPaieinverse";
            // 
            // nPret
            // 
            this.nPret.Caption = "Gestion des Prets";
            this.nPret.Id = 7;
            this.nPret.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nPret.ImageOptions.SvgImage")));
            this.nPret.Name = "nPret";
            // 
            // mConge
            // 
            this.mConge.Caption = "Calcul Paie Congé";
            this.mConge.Id = 8;
            this.mConge.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mConge.ImageOptions.SvgImage")));
            this.mConge.Name = "mConge";
            // 
            // bbOrdreMission
            // 
            this.bbOrdreMission.Caption = "Ordres de missions";
            this.bbOrdreMission.Id = 9;
            this.bbOrdreMission.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbOrdreMission.ImageOptions.SvgImage")));
            this.bbOrdreMission.Name = "bbOrdreMission";
            // 
            // nContrat_Click
            // 
            this.nContrat_Click.Caption = "Contrats";
            this.nContrat_Click.Id = 10;
            this.nContrat_Click.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nContrat_Click.ImageOptions.SvgImage")));
            this.nContrat_Click.Name = "nContrat_Click";
            // 
            // nSaisiVaraibles
            // 
            this.nSaisiVaraibles.Caption = "Saisie Variables";
            this.nSaisiVaraibles.Id = 11;
            this.nSaisiVaraibles.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nSaisiVaraibles.ImageOptions.SvgImage")));
            this.nSaisiVaraibles.Name = "nSaisiVaraibles";
            // 
            // tbSave
            // 
            this.tbSave.Caption = "Save";
            this.tbSave.Id = 74;
            this.tbSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbSave.ImageOptions.SvgImage")));
            this.tbSave.Name = "tbSave";
            this.tbSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbSave_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Exporter XML";
            this.barButtonItem1.Id = 75;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 76;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // tbOptions
            // 
            this.tbOptions.Caption = "Options";
            this.tbOptions.Id = 77;
            this.tbOptions.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tbOptions.ImageOptions.SvgImage")));
            this.tbOptions.Name = "tbOptions";
            this.tbOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbOptions_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 78;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Fichier";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.tbStartAll);
            this.ribbonPageGroup1.ItemLinks.Add(this.tbStopAll);
            this.ribbonPageGroup1.ItemLinks.Add(this.tbClearAllStatistics);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.tbStartHost);
            this.ribbonPageGroup3.ItemLinks.Add(this.tbStopHost);
            this.ribbonPageGroup3.ItemLinks.Add(this.tbClearStatistics);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.tbAddNewHost);
            this.ribbonPageGroup4.ItemLinks.Add(this.tbHostOptions);
            this.ribbonPageGroup4.ItemLinks.Add(this.tbRemoveHost);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.tbSave);
            this.ribbonPageGroup5.ItemLinks.Add(this.tbOptions);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPage9
            // 
            this.ribbonPage9.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup11,
            this.ribbonPageGroup2});
            this.ribbonPage9.Name = "ribbonPage9";
            this.ribbonPage9.Text = "Help";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.nEnregistrement);
            this.ribbonPageGroup11.ItemLinks.Add(this.tbAbout);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barListItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.skinDropDownButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Save";
            this.barButtonItem2.Id = 74;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // _notifyIcon
            // 
            this._notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this._notifyIcon.ContextMenuStrip = this._notifyIconMenu;
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "HostsPinger";
            this._notifyIcon.Visible = true;
            // 
            // PingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 479);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this._lvHosts);
            this.Controls.Add(this._toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HostsPinger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PingForm_FormClosing);
            this.Load += new System.EventHandler(this.PingForm_Load);
            this._notifyIconMenu.ResumeLayout(false);
            this._toolbar.ResumeLayout(false);
            this._toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void LoadSettings()
		{
			if (!Options.Instance.UseDefaultColumnsWidths)
			{
				foreach (ColumnHeader column in _lvHosts.Columns)
				{
					column.Width = Options.Instance.GetColumnWidth(column.Index);
				}
			}
			if (!Options.Instance.UseDefaultPosition)
			{
				base.Location = new Point(Options.Instance.WindowPositionX, Options.Instance.WindowPositionY);
			}
			if (!Options.Instance.UseDefaultSize)
			{
				base.Width = Options.Instance.WindowsWidth;
				base.Height = Options.Instance.WindowsHeight;
			}
		}

		public static void NotifyMessage(HostPinger host, string message)
		{
			if (Application.OpenForms.Count > 0)
			{
				((PingForm)Application.OpenForms[0])?._notifyIcon.ShowBalloonTip(10000, host.HostName + "(" + host.HostIP.ToString() + ")", message, ToolTipIcon.Info);
			}
		}

		private void OnHostPing(HostPinger host)
		{
			if (base.InvokeRequired)
			{
				OnPingDelegate method = OnHostPing;
				object[] args = new object[1]
				{
					host
				};
				Invoke(method, args);
			}
			else
			{
				lock (_table)
				{
					ListViewItem listViewItem = (ListViewItem)_table[host.ID];
					if (listViewItem == null)
					{
						string[] items = new string[24]
						{
							host.HostIP.ToString(),
							host.HostName,
							host.HostDescription,
							host.Status.ToString(),
							host.SentPackets.ToString(),
							host.RecivedPackets.ToString(),
							PercentToString(host.RecivedPacketsPercent),
							host.LostPackets.ToString(),
							PercentToString(host.LostPacketsPercent),
							host.LastPacketLost ? "Yes" : "No",
							host.RecentlyRecivedPackets.ToString(),
							PercentToString(host.RecentlyRecivedPacketsPercent),
							host.RecentlyLostPackets.ToString(),
							PercentToString(host.RecentlyLostPacketsPercent),
							host.CurrentResponseTime.ToString(),
							host.AvargeResponseTime.ToString("F"),
							DurationToString(host.CurrentStatusDuration),
							DurationToString(host.GetStatusDuration(HostStatus.Alive)),
							DurationToString(host.GetStatusDuration(HostStatus.Dead)),
							DurationToString(host.GetStatusDuration(HostStatus.DnsError)),
							DurationToString(host.GetStatusDuration(HostStatus.Unknown)),
							PercentToString(host.HostAvailability),
							DurationToString(host.TotalTestDuration),
							DurationToString(host.CurrentTestDuration)
						};
						listViewItem = new ListViewItem(items);
						_table.Add(host.ID, listViewItem);
						listViewItem.Tag = host;
						_lvHosts.Items.Insert(0, listViewItem);
					}
					else
					{
						listViewItem.SubItems[0].Text = host.HostIP.ToString();
						listViewItem.SubItems[1].Text = host.HostName;
						listViewItem.SubItems[2].Text = host.HostDescription;
						listViewItem.SubItems[3].Text = host.Status.ToString();
						listViewItem.SubItems[4].Text = host.SentPackets.ToString();
						listViewItem.SubItems[5].Text = host.RecivedPackets.ToString();
						listViewItem.SubItems[6].Text = PercentToString(host.RecivedPacketsPercent);
						listViewItem.SubItems[7].Text = host.LostPackets.ToString();
						listViewItem.SubItems[8].Text = PercentToString(host.LostPacketsPercent);
						listViewItem.SubItems[9].Text = (host.LastPacketLost ? "Yes" : "No");
						listViewItem.SubItems[10].Text = host.RecentlyRecivedPackets.ToString();
						listViewItem.SubItems[11].Text = PercentToString(host.RecentlyRecivedPacketsPercent);
						listViewItem.SubItems[12].Text = host.RecentlyLostPackets.ToString();
						listViewItem.SubItems[13].Text = PercentToString(host.RecentlyLostPacketsPercent);
						listViewItem.SubItems[14].Text = host.CurrentResponseTime.ToString();
						listViewItem.SubItems[15].Text = host.AvargeResponseTime.ToString("F");
						listViewItem.SubItems[16].Text = DurationToString(host.CurrentStatusDuration);
						listViewItem.SubItems[17].Text = DurationToString(host.GetStatusDuration(HostStatus.Alive));
						listViewItem.SubItems[18].Text = DurationToString(host.GetStatusDuration(HostStatus.Dead));
						listViewItem.SubItems[19].Text = DurationToString(host.GetStatusDuration(HostStatus.DnsError));
						listViewItem.SubItems[20].Text = DurationToString(host.GetStatusDuration(HostStatus.Unknown));
						listViewItem.SubItems[21].Text = PercentToString(host.HostAvailability);
						listViewItem.SubItems[22].Text = DurationToString(host.TotalTestDuration);
						listViewItem.SubItems[23].Text = DurationToString(host.CurrentTestDuration);
					}
					switch (host.Status)
					{
					case HostStatus.Dead:
						listViewItem.BackColor = Color.Red;
						listViewItem.ForeColor = Color.White;
						break;
					case HostStatus.Alive:
						listViewItem.BackColor = Color.LightGreen;
						listViewItem.ForeColor = Color.Black;
						break;
					case HostStatus.DnsError:
						listViewItem.BackColor = Color.OrangeRed;
						listViewItem.ForeColor = Color.White;
						break;
					case HostStatus.Unknown:
						listViewItem.BackColor = Color.Yellow;
						listViewItem.ForeColor = Color.Black;
						break;
					}
					if (host == _selectedPinger)
					{
						_tbStartHost.Enabled = !_selectedPinger.IsRunning;
						_tbRemoveHost.Enabled = !_selectedPinger.IsRunning;
						_tbStopHost.Enabled = _selectedPinger.IsRunning;
					}
				}
			}
		}

		private string PercentToString(float percent)
		{
			return $"{percent / 100f:P}";
		}

		private void PingForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_hostListChanged)
			{
				switch (MessageBox.Show("Host list has been changed. Do you want to save changes?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
				case DialogResult.Cancel:
					e.Cancel = true;
					return;
				case DialogResult.Yes:
					_tbSave_Click(sender, e);
					break;
				}
			}
			SaveSettings();
		}

		private void PingForm_SizeChanged(object sender, EventArgs e)
		{
			if (base.WindowState != FormWindowState.Minimized)
			{
				_oldState = base.WindowState;
			}
			base.Visible = (base.WindowState != FormWindowState.Minimized);
		}

		private void SaveSettings()
		{
			foreach (ColumnHeader column in _lvHosts.Columns)
			{
				Options.Instance.SetColumnWidth(column.Index, column.Width);
			}
			Options.Instance.WindowPositionX = base.Location.X;
			Options.Instance.WindowPositionY = base.Location.Y;
			if (base.WindowState == FormWindowState.Normal)
			{
				Options.Instance.WindowsWidth = base.Width;
				Options.Instance.WindowsHeight = base.Height;
			}
		}

        private void _tbStartAll_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lock (_hosts)
            {
                foreach (HostPinger host in _hosts)
                {
                    host.Start();
                }
            }
        }

        private void tbStopAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lock (_hosts)
            {
                foreach (HostPinger host in _hosts)
                {
                    host.Stop();
                }
            }
        }

        private void tbClearAllStatistics_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool flag = false;
            if (!Options.Instance.ClearTimeStatistics)
            {
                DialogResult dialogResult = MessageBox.Show("Clear time statistics as well?", "Time Statistics", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
                flag = (dialogResult == DialogResult.Yes);
            }
            else
            {
                flag = true;
            }
            lock (_hosts)
            {
                foreach (HostPinger host in _hosts)
                {
                    host.ClearStatistics(flag);
                }
            }
        }

        private void tbStartHost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedPinger != null)
            {
                _selectedPinger.Start();
            }
        }

        private void tbStopHost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedPinger != null)
            {
                _selectedPinger.Stop();
            }
        }

        private void tbClearStatistics_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedPinger == null)
            {
                return;
            }
            bool flag = false;
            if (!Options.Instance.ClearTimeStatistics)
            {
                DialogResult dialogResult = MessageBox.Show("Clear time statistics as well?", "Time Statistics", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
                flag = (dialogResult == DialogResult.Yes);
            }
            else
            {
                flag = true;
            }
            _selectedPinger.ClearStatistics(flag);
        }

        private void tbAddNewHost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HostOptions hostOptions = new HostOptions();
            if (hostOptions.ShowDialog(this, null) != DialogResult.OK)
            {
                return;
            }
            bool flag = false;
            lock (_hosts)
            {
                foreach (HostPinger host in _hosts)
                {
                    if (host.HostIP != null && host.HostIP == hostOptions.Host.HostIP)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {
                MessageBox.Show("Host already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            hostOptions.Host.Logger = DefaultLogger.Instance;
            hostOptions.Host.OnPing += OnHostPing;
            hostOptions.Host.OnStopPinging += hp_OnStopPinging;
            hostOptions.Host.OnStartPinging += hp_OnStartPinging;
            lock (_hosts)
            {
                _hosts.Add(hostOptions.Host);
            }
            _hostListChanged = true;
            if (MessageBox.Show("Start pinging of the host?", "Start", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                hostOptions.Host.Start();
            }
        }

        private void tbHostOptions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedPinger != null)
            {
                new HostOptions().ShowDialog(this, _selectedPinger);
            }
        }

        private void tbRemoveHost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Remove host from list?", "Remove host", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No && _selectedPinger != null && !_selectedPinger.IsRunning)
            {
                lock (_table)
                {
                    lock (_hosts)
                    {
                        _hosts.Remove(_selectedPinger);
                    }
                    _selectedPinger.OnPing -= OnHostPing;
                    _selectedPinger.OnStopPinging -= hp_OnStopPinging;
                    _selectedPinger.OnStartPinging -= hp_OnStartPinging;
                    ListViewItem item = (ListViewItem)_table[_selectedPinger.ID];
                    _table.Remove(_selectedPinger.ID);
                    _lvHosts.Items.Remove(item);
                    _hostListChanged = true;
                }
            }
        }

        private void tbSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                CloseOutput = true,
                Indent = true
            };
            try
            {
                XmlWriter xmlWriter = XmlWriter.Create("hosts.cfg", settings);
                try
                {
                    xmlWriter.WriteStartElement("pinger");
                    lock (_hosts)
                    {
                        foreach (HostPinger host in _hosts)
                        {
                            host.Save(xmlWriter);
                        }
                    }
                    xmlWriter.WriteEndElement();
                    _hostListChanged = false;
                }
                finally
                {
                    xmlWriter.Close();
                }
            }
            catch
            {
                MessageBox.Show("An error ocurred while saving host list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void tbOptions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProgramOptions programOptions = new ProgramOptions();
            for (int num = Options.NUMBER_OF_COLUMNS - 1; num >= 0; num--)
            {
                programOptions.SelectedColumns.SetItemChecked(num, Options.Instance.GetComlumnVisability(num));
            }
            if (programOptions.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            for (int num2 = Options.NUMBER_OF_COLUMNS - 1; num2 >= 0; num2--)
            {
                bool comlumnVisability = Options.Instance.GetComlumnVisability(num2);
                Options.Instance.SetColumnVisability(num2, programOptions.SelectedColumns.GetItemChecked(num2));
                if (!comlumnVisability)
                {
                    _lvHosts.Columns[num2].Width = Options.Instance.GetColumnWidth(num2);
                }
                if (!Options.Instance.GetComlumnVisability(num2))
                {
                    _lvHosts.Columns[num2].Width = 0;
                }
            }
            Options.Instance.StartWithWindows = programOptions.StartWithWindows;
            Options.Instance.StartPingingOnProgramStart = programOptions.StartPingingOnProgramStart;
            Options.Instance.ShowErrorMessages = programOptions.ShowErrorMessages;
            Options.Instance.ClearTimeStatistics = programOptions.ClearTimeStatistics;
        }

        private void tbAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new AboutForm().ShowDialog(this);
        }

        private void PingForm_Load(object sender, EventArgs e)
        {
            this.SR = new StreamReader(string.Concat(Application.StartupPath, "\\Style.dat"));
            string str = this.SR.ReadLine();
            this.barListItem1.Caption = "Style (" + str + ")";
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(str);
        }

        private void nEnregistrement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Registration().ShowDialog(this);
        }
    }
}
