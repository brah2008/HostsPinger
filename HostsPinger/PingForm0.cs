using HostsPinger;
using Properties;
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

		private NotifyIcon _notifyIcon;

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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(HostsPinger.PingForm));
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingForm));
			_notifyIcon = new System.Windows.Forms.NotifyIcon(components);
			formAssistant1 = new DevExpress.XtraBars.FormAssistant();
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
            this._notifyIconMenu.SuspendLayout();
            this._toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
			_notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(components);
			_nimRestore = new System.Windows.Forms.ToolStripMenuItem();
			_nimMaximize = new System.Windows.Forms.ToolStripMenuItem();
			_nimMinimize = new System.Windows.Forms.ToolStripMenuItem();
			_nimExit = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			_nimStartAll = new System.Windows.Forms.ToolStripMenuItem();
			_nimStopAll = new System.Windows.Forms.ToolStripMenuItem();
			_tbStartAll = new System.Windows.Forms.ToolStripButton();
			_tbStopAll = new System.Windows.Forms.ToolStripButton();
			_tbClearAllStatistics = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			_tbStartHost = new System.Windows.Forms.ToolStripButton();
			_tbStopHost = new System.Windows.Forms.ToolStripButton();
			_tbClearStatistics = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			_tbAddNewHost = new System.Windows.Forms.ToolStripButton();
			_tbHostOptions = new System.Windows.Forms.ToolStripButton();
			_tbRemoveHost = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			_tbOptions = new System.Windows.Forms.ToolStripButton();
			_tbAbout = new System.Windows.Forms.ToolStripButton();
			_tbSave = new System.Windows.Forms.ToolStripButton();
			_colIpAddr = new System.Windows.Forms.ColumnHeader();
			_colHostName = new System.Windows.Forms.ColumnHeader();
			_colHostDescription = new System.Windows.Forms.ColumnHeader();
			_colStatus = new System.Windows.Forms.ColumnHeader();
			_colPacketSent = new System.Windows.Forms.ColumnHeader();
			_colPacketReceived = new System.Windows.Forms.ColumnHeader();
			_colPacketReceivedPercent = new System.Windows.Forms.ColumnHeader();
			_colPacketLost = new System.Windows.Forms.ColumnHeader();
			_colPacketLostPercent = new System.Windows.Forms.ColumnHeader();
			_colLastPacketLost = new System.Windows.Forms.ColumnHeader();
			_colRecPacketReceived = new System.Windows.Forms.ColumnHeader();
			_colRecPacketReceivedPercent = new System.Windows.Forms.ColumnHeader();
			_colRecPacketLost = new System.Windows.Forms.ColumnHeader();
			_colRecPacketLostPercent = new System.Windows.Forms.ColumnHeader();
			_colCurrentResponseTime = new System.Windows.Forms.ColumnHeader();
			_colAvargeResponseTime = new System.Windows.Forms.ColumnHeader();
			_colStatusDuration = new System.Windows.Forms.ColumnHeader();
			_colAliveStatus = new System.Windows.Forms.ColumnHeader();
			_colDeadStatus = new System.Windows.Forms.ColumnHeader();
			_colDnsErrorStatus = new System.Windows.Forms.ColumnHeader();
			_colUnknownStatus = new System.Windows.Forms.ColumnHeader();
			_colAvailability = new System.Windows.Forms.ColumnHeader();
			_colTestDuration = new System.Windows.Forms.ColumnHeader();
			_colCurTestDuration = new System.Windows.Forms.ColumnHeader();
			aDDNewHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			hostOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			clearStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			startPingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			removeHostToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
			stopAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			_lvHosts = new HostsPinger.ListViewDB();
			IP = new System.Windows.Forms.ColumnHeader();
			HOSTN = new System.Windows.Forms.ColumnHeader();
			HOSTD = new System.Windows.Forms.ColumnHeader();
			STATUS = new System.Windows.Forms.ColumnHeader();
			SENT = new System.Windows.Forms.ColumnHeader();
			RECEIV = new System.Windows.Forms.ColumnHeader();
			LOST = new System.Windows.Forms.ColumnHeader();
			LAST = new System.Windows.Forms.ColumnHeader();
			RESEIVREC = new System.Windows.Forms.ColumnHeader();
			RESEIVRECC = new System.Windows.Forms.ColumnHeader();
			LOSTT = new System.Windows.Forms.ColumnHeader();
			LOSTTT = new System.Windows.Forms.ColumnHeader();
			CURRENT = new System.Windows.Forms.ColumnHeader();
			AVIRAGE = new System.Windows.Forms.ColumnHeader();
			STATUSDUR = new System.Windows.Forms.ColumnHeader();
			ACTIVE = new System.Windows.Forms.ColumnHeader();
			DEAD = new System.Windows.Forms.ColumnHeader();
			DnsErr = new System.Windows.Forms.ColumnHeader();
			UNKSTAUS = new System.Windows.Forms.ColumnHeader();
			HOSTAV = new System.Windows.Forms.ColumnHeader();
			TESTDU = new System.Windows.Forms.ColumnHeader();
			CURRENTTES = new System.Windows.Forms.ColumnHeader();
			__tbStartAll = new System.Windows.Forms.ToolStripButton();
			__tbStopAll = new System.Windows.Forms.ToolStripButton();
			__tbClearAllStatistics = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			__tbStartHost = new System.Windows.Forms.ToolStripButton();
			__tbStopHost = new System.Windows.Forms.ToolStripButton();
			__tbClearStatistics = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			__tbAddNewHost = new System.Windows.Forms.ToolStripButton();
			__tbHostOptions = new System.Windows.Forms.ToolStripButton();
			__tbRemoveHost = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			__tbSave = new System.Windows.Forms.ToolStripButton();
			__tbOptions = new System.Windows.Forms.ToolStripButton();
			__tbAbout = new System.Windows.Forms.ToolStripButton();
			_toolbar = new System.Windows.Forms.ToolStrip();
			_notifyIconMenu.SuspendLayout();
			_toolbar.SuspendLayout();
			SuspendLayout();
			_notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			_notifyIcon.ContextMenuStrip = _notifyIconMenu;
			_notifyIcon.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("_notifyIcon.Icon");
			_notifyIcon.Text = "HostsPinger";
			_notifyIcon.Visible = true;
			_notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(_notifyIcon_MouseClick);
			_notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(_notifyIcon_MouseDoubleClick);
			_notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[7]
			{
				aDDNewHostToolStripMenuItem,
				hostOptionsToolStripMenuItem,
				clearStatisticsToolStripMenuItem,
				startPingToolStripMenuItem,
				removeHostToolStripMenuItem,
				toolStripMenuItem3,
				stopAllToolStripMenuItem
			});
			_notifyIconMenu.Name = "_notifyIconMenu";
			_notifyIconMenu.Size = new System.Drawing.Size(126, 142);
			_nimRestore.Name = "_nimRestore";
			_nimRestore.Size = new System.Drawing.Size(124, 22);
			_nimRestore.Text = "Restore";
			_nimRestore.Click += new System.EventHandler(_nimRestore_Click);
			_nimMaximize.Name = "_nimMaximize";
			_nimMaximize.Size = new System.Drawing.Size(124, 22);
			_nimMaximize.Text = "Maximize";
			_nimMaximize.Click += new System.EventHandler(_nimMaximize_Click);
			_nimMinimize.Name = "_nimMinimize";
			_nimMinimize.Size = new System.Drawing.Size(124, 22);
			_nimMinimize.Text = "Minimize";
			_nimMinimize.Click += new System.EventHandler(_nimMinimize_Click);
			_nimExit.Name = "_nimExit";
			_nimExit.Size = new System.Drawing.Size(124, 22);
			_nimExit.Text = "Exit";
			_nimExit.Click += new System.EventHandler(_nimExit_Click);
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
			_nimStartAll.Name = "_nimStartAll";
			_nimStartAll.Size = new System.Drawing.Size(124, 22);
			_nimStartAll.Text = "Start All";
			_nimStartAll.Click += new System.EventHandler(_tbStartAll_Click);
			_nimStopAll.Name = "_nimStopAll";
			_nimStopAll.Size = new System.Drawing.Size(124, 22);
			_nimStopAll.Text = "Stop All";
			_nimStopAll.Click += new System.EventHandler(_tbStopAll_Click);
			_tbStartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbStartAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbStartAll.Name = "_tbStartAll";
			_tbStartAll.Size = new System.Drawing.Size(36, 36);
			_tbStartAll.Text = "Start All";
			_tbStartAll.Click += new System.EventHandler(_tbStartAll_Click);
			_tbStopAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbStopAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbStopAll.Name = "_tbStopAll";
			_tbStopAll.Size = new System.Drawing.Size(36, 36);
			_tbStopAll.Text = "Stop All";
			_tbStopAll.Click += new System.EventHandler(_tbStopAll_Click);
			_tbClearAllStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbClearAllStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbClearAllStatistics.Name = "_tbClearAllStatistics";
			_tbClearAllStatistics.Size = new System.Drawing.Size(36, 36);
			_tbClearAllStatistics.Text = "Clear All Statistics";
			_tbClearAllStatistics.Click += new System.EventHandler(_tbClearAllStatistics_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			_tbStartHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbStartHost.Enabled = false;
			_tbStartHost.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbStartHost.Name = "_tbStartHost";
			_tbStartHost.Size = new System.Drawing.Size(36, 36);
			_tbStartHost.Text = "Start Host";
			_tbStartHost.Click += new System.EventHandler(_tbStartHost_Click);
			_tbStopHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbStopHost.Enabled = false;
			_tbStopHost.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbStopHost.Name = "_tbStopHost";
			_tbStopHost.Size = new System.Drawing.Size(36, 36);
			_tbStopHost.Text = "Stop Host";
			_tbStopHost.Click += new System.EventHandler(_tbStopHost_Click);
			_tbClearStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbClearStatistics.Enabled = false;
			_tbClearStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbClearStatistics.Name = "_tbClearStatistics";
			_tbClearStatistics.Size = new System.Drawing.Size(36, 36);
			_tbClearStatistics.Text = "Clear Statistics";
			_tbClearStatistics.Click += new System.EventHandler(_tbClearStatistics_Click);
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
			_tbAddNewHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbAddNewHost.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbAddNewHost.Name = "_tbAddNewHost";
			_tbAddNewHost.Size = new System.Drawing.Size(36, 36);
			_tbAddNewHost.Text = "Add New Host";
			_tbAddNewHost.Click += new System.EventHandler(_tbAddNewHost_Click);
			_tbHostOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbHostOptions.Enabled = false;
			_tbHostOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbHostOptions.Name = "_tbHostOptions";
			_tbHostOptions.Size = new System.Drawing.Size(36, 36);
			_tbHostOptions.Text = "Host Options";
			_tbHostOptions.Click += new System.EventHandler(_tbHostOptions_Click);
			_tbRemoveHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbRemoveHost.Enabled = false;
			_tbRemoveHost.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbRemoveHost.Name = "_tbRemoveHost";
			_tbRemoveHost.Size = new System.Drawing.Size(36, 36);
			_tbRemoveHost.Text = "Remove Host";
			_tbRemoveHost.Click += new System.EventHandler(_tbRemoveHost_Click);
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
			_tbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbOptions.Name = "_tbOptions";
			_tbOptions.Size = new System.Drawing.Size(36, 36);
			_tbOptions.Text = "Options";
			_tbOptions.Click += new System.EventHandler(_tbOptions_Click);
			_tbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbAbout.Name = "_tbAbout";
			_tbAbout.Size = new System.Drawing.Size(36, 36);
			_tbAbout.Text = "About PingHost";
			_tbAbout.Click += new System.EventHandler(_tbAbout_Click);
			_tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			_tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tbSave.Name = "_tbSave";
			_tbSave.Size = new System.Drawing.Size(36, 36);
			_tbSave.Text = "Save Hosts";
			_tbSave.Click += new System.EventHandler(_tbSave_Click);
			_colIpAddr.Text = "IP Address";
			_colIpAddr.Width = 108;
			_colHostName.Text = "Host Name";
			_colHostName.Width = 127;
			_colHostDescription.Text = "Host Description";
			_colHostDescription.Width = 164;
			_colStatus.Text = "Status";
			_colStatus.Width = 61;
			_colPacketSent.Text = "Sent";
			_colPacketSent.Width = 50;
			_colPacketReceived.Text = "Received";
			_colPacketReceivedPercent.Text = "Received %";
			_colPacketReceivedPercent.Width = 74;
			_colPacketLost.Text = "Lost";
			_colPacketLost.Width = 50;
			_colPacketLostPercent.Text = "Lost %";
			_colPacketLostPercent.Width = 55;
			_colLastPacketLost.Text = "Last Packet Lost";
			_colRecPacketReceived.Text = "Received (Recent)";
			_colRecPacketReceivedPercent.Text = "Received % (Recent)";
			_colRecPacketLost.Text = "Lost (Recent)";
			_colRecPacketLostPercent.Text = "Lost % (Recent)";
			_colCurrentResponseTime.Text = "Current R.T.";
			_colCurrentResponseTime.Width = 70;
			_colAvargeResponseTime.Text = "Avarge R.T.";
			_colAvargeResponseTime.Width = 70;
			_colStatusDuration.Text = "Status Duration";
			_colStatusDuration.Width = 86;
			_colAliveStatus.Text = "Alive Status";
			_colDeadStatus.Text = "Dead Status";
			_colDnsErrorStatus.Text = "Dns Error Status";
			_colUnknownStatus.Text = "Unknown Status";
			_colAvailability.Text = "Host Availability";
			_colTestDuration.Text = "Test Duration";
			_colTestDuration.Width = 76;
			_colCurTestDuration.Text = "Current Test Duration";
			aDDNewHostToolStripMenuItem.Name = "aDDNewHostToolStripMenuItem";
			aDDNewHostToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			aDDNewHostToolStripMenuItem.Text = "Restore";
			aDDNewHostToolStripMenuItem.Click += new System.EventHandler(_nimRestore_Click);
			hostOptionsToolStripMenuItem.Name = "hostOptionsToolStripMenuItem";
			hostOptionsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			hostOptionsToolStripMenuItem.Text = "Maximize";
			hostOptionsToolStripMenuItem.Click += new System.EventHandler(_nimMaximize_Click);
			clearStatisticsToolStripMenuItem.Name = "clearStatisticsToolStripMenuItem";
			clearStatisticsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			clearStatisticsToolStripMenuItem.Text = "Minimize";
			clearStatisticsToolStripMenuItem.Click += new System.EventHandler(_nimMinimize_Click);
			startPingToolStripMenuItem.Name = "startPingToolStripMenuItem";
			startPingToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			startPingToolStripMenuItem.Text = "Exit";
			startPingToolStripMenuItem.Click += new System.EventHandler(_nimExit_Click);
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new System.Drawing.Size(125, 22);
			toolStripMenuItem3.Text = "Start All";
			toolStripMenuItem3.Click += new System.EventHandler(_tbStartAll_Click);
			removeHostToolStripMenuItem.Name = "removeHostToolStripMenuItem";
			removeHostToolStripMenuItem.Size = new System.Drawing.Size(122, 6);
			removeHostToolStripMenuItem.Click += new System.EventHandler(_tbRemoveHost_Click);
			stopAllToolStripMenuItem.Name = "stopAllToolStripMenuItem";
			stopAllToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			stopAllToolStripMenuItem.Text = "Stop All";
			stopAllToolStripMenuItem.Click += new System.EventHandler(_tbStopAll_Click);
			_lvHosts.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			_lvHosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[22]
			{
				IP,
				HOSTN,
				HOSTD,
				STATUS,
				SENT,
				RECEIV,
				LOST,
				LAST,
				RESEIVREC,
				RESEIVRECC,
				LOSTT,
				LOSTTT,
				CURRENT,
				AVIRAGE,
				STATUSDUR,
				ACTIVE,
				DEAD,
				DnsErr,
				UNKSTAUS,
				HOSTAV,
				TESTDU,
				CURRENTTES
			});
			_lvHosts.FullRowSelect = true;
			_lvHosts.GridLines = true;
			_lvHosts.Location = new System.Drawing.Point(0, 44);
			_lvHosts.MultiSelect = false;
			_lvHosts.Name = "_lvHosts";
			_lvHosts.Size = new System.Drawing.Size(962, 217);
			_lvHosts.TabIndex = 0;
			_lvHosts.UseCompatibleStateImageBehavior = false;
			_lvHosts.View = System.Windows.Forms.View.Details;
			_lvHosts.SelectedIndexChanged += new System.EventHandler(_lvHosts_SelectedIndexChanged);
			_lvHosts.DoubleClick += new System.EventHandler(_lvHosts_DoubleClick);
			_lvHosts.MouseUp += new System.Windows.Forms.MouseEventHandler(_lvHosts_MouseUp);
			IP.Text = "IP Adress";
			IP.Width = 120;
			HOSTN.Text = "Host Name";
			HOSTN.Width = 200;
			HOSTD.Text = "Host Description";
			HOSTD.Width = 250;
			STATUS.Text = "Status";
			SENT.Text = "Sent";
			SENT.Width = 50;
			RECEIV.Text = "Received %";
			RECEIV.Width = 70;
			LOST.Text = "Lost";
			LAST.Text = "Last Packet Lost";
			LAST.Width = 80;
			RESEIVREC.Text = "Received (Recent)";
			RESEIVREC.Width = 70;
			RESEIVRECC.Text = "Received % (Recent)";
			RESEIVRECC.Width = 70;
			LOSTT.Text = "Lost (Recent)";
			LOSTTT.Text = "Lost % (Recent)";
			CURRENT.Text = "Current R.T.";
			CURRENT.Width = 70;
			AVIRAGE.Text = "Avirage  R.T.";
			STATUSDUR.Text = "Status Durations";
			STATUSDUR.Width = 90;
			ACTIVE.Text = "Active Status";
			ACTIVE.Width = 90;
			DEAD.Text = "Dead Status";
			DEAD.Width = 90;
			DnsErr.Text = "Dns Error Status";
			DnsErr.Width = 80;
			UNKSTAUS.Text = "Unknow Status";
			UNKSTAUS.Width = 70;
			HOSTAV.Text = "Host Availability";
			HOSTAV.Width = 80;
			TESTDU.Text = "Test Duration";
			TESTDU.Width = 70;
			CURRENTTES.Text = "Current Test Duration";
			CURRENTTES.Width = 70;
			__tbStartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbStartAll.Image = Properties.Resources._11;
			__tbStartAll.ImageTransparentColor = System.Drawing.Color.White;
			__tbStartAll.Name = "__tbStartAll";
			__tbStartAll.Size = new System.Drawing.Size(36, 36);
			__tbStartAll.Text = "Start All";
			__tbStartAll.Click += new System.EventHandler(_tbStartAll_Click);
			__tbStopAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbStopAll.Image = Properties.Resources._21;
			__tbStopAll.ImageTransparentColor = System.Drawing.Color.White;
			__tbStopAll.Name = "__tbStopAll";
			__tbStopAll.Size = new System.Drawing.Size(36, 36);
			__tbStopAll.Text = "Stop All";
			__tbStopAll.Click += new System.EventHandler(_tbStopAll_Click);
			__tbClearAllStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbClearAllStatistics.Image = Properties.Resources._31;
			__tbClearAllStatistics.ImageTransparentColor = System.Drawing.Color.White;
			__tbClearAllStatistics.Name = "__tbClearAllStatistics";
			__tbClearAllStatistics.Size = new System.Drawing.Size(36, 36);
			__tbClearAllStatistics.Text = "Clear All Statistics";
			__tbClearAllStatistics.Click += new System.EventHandler(_tbClearAllStatistics_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
			__tbStartHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbStartHost.Image = Properties.Resources._11;
			__tbStartHost.ImageTransparentColor = System.Drawing.Color.White;
			__tbStartHost.Name = "__tbStartHost";
			__tbStartHost.Size = new System.Drawing.Size(36, 36);
			__tbStartHost.Text = "Start Host";
			__tbStartHost.Click += new System.EventHandler(_tbStartHost_Click);
			__tbStopHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbStopHost.Image = Properties.Resources._21;
			__tbStopHost.ImageTransparentColor = System.Drawing.Color.White;
			__tbStopHost.Name = "__tbStopHost";
			__tbStopHost.Size = new System.Drawing.Size(36, 36);
			__tbStopHost.Text = "Stop Host";
			__tbStopHost.Click += new System.EventHandler(_tbStopHost_Click);
			__tbClearStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbClearStatistics.Image = Properties.Resources._31;
			__tbClearStatistics.ImageTransparentColor = System.Drawing.Color.White;
			__tbClearStatistics.Name = "__tbClearStatistics";
			__tbClearStatistics.Size = new System.Drawing.Size(36, 36);
			__tbClearStatistics.Text = "Clear Statistics";
			__tbClearStatistics.Click += new System.EventHandler(_tbClearStatistics_Click);
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
			__tbAddNewHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbAddNewHost.Image = Properties.Resources._41;
			__tbAddNewHost.ImageTransparentColor = System.Drawing.Color.White;
			__tbAddNewHost.Name = "__tbAddNewHost";
			__tbAddNewHost.Size = new System.Drawing.Size(36, 36);
			__tbAddNewHost.Text = "Add New Host";
			__tbAddNewHost.Click += new System.EventHandler(_tbAddNewHost_Click);
			__tbHostOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbHostOptions.Image = Properties.Resources._51;
			__tbHostOptions.ImageTransparentColor = System.Drawing.Color.White;
			__tbHostOptions.Name = "__tbHostOptions";
			__tbHostOptions.Size = new System.Drawing.Size(36, 36);
			__tbHostOptions.Text = "Host Options";
			__tbHostOptions.Click += new System.EventHandler(_tbHostOptions_Click);
			__tbRemoveHost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbRemoveHost.Image = Properties.Resources._61;
			__tbRemoveHost.ImageTransparentColor = System.Drawing.Color.White;
			__tbRemoveHost.Name = "__tbRemoveHost";
			__tbRemoveHost.Size = new System.Drawing.Size(36, 36);
			__tbRemoveHost.Text = "Remove Host";
			__tbRemoveHost.Click += new System.EventHandler(_tbRemoveHost_Click);
			toolStripSeparator6.Name = "toolStripSeparator6";
			toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
			__tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbSave.Image = Properties.Resources._71;
			__tbSave.ImageTransparentColor = System.Drawing.Color.White;
			__tbSave.Name = "__tbSave";
			__tbSave.Size = new System.Drawing.Size(36, 36);
			__tbSave.Text = "Save Hosts";
			__tbSave.Click += new System.EventHandler(_tbSave_Click);
			__tbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbOptions.Image = Properties.Resources._81;
			__tbOptions.ImageTransparentColor = System.Drawing.Color.White;
			__tbOptions.Name = "__tbOptions";
			__tbOptions.Size = new System.Drawing.Size(36, 36);
			__tbOptions.Text = "Options";
			__tbOptions.Click += new System.EventHandler(_tbOptions_Click);
			__tbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			//__tbAbout.Image = Properties.Resources._91;
			__tbAbout.ImageTransparentColor = System.Drawing.Color.Transparent;
			__tbAbout.Name = "__tbAbout";
			__tbAbout.Size = new System.Drawing.Size(36, 36);
			__tbAbout.Text = "About PingHost";
			__tbAbout.Click += new System.EventHandler(_tbAbout_Click);
			_toolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
			_toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[15]
			{
				__tbStartAll,
				__tbStopAll,
				__tbClearAllStatistics,
				toolStripSeparator2,
				__tbStartHost,
				__tbStopHost,
				__tbClearStatistics,
				toolStripSeparator4,
				__tbAddNewHost,
				__tbHostOptions,
				__tbRemoveHost,
				toolStripSeparator6,
				__tbSave,
				__tbOptions,
				__tbAbout
			});
			_toolbar.Location = new System.Drawing.Point(0, 0);
			_toolbar.Name = "_toolbar";
			_toolbar.Size = new System.Drawing.Size(962, 39);
			_toolbar.TabIndex = 3;
			_toolbar.Text = "Toolbar";
			
			
			
			
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
            this.tbAbout.Caption = "About PingHost";
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
			
			
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(962, 271);
			base.Controls.Add(_toolbar);
			base.Controls.Add(_lvHosts);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "PingForm";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "HostsPinger";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(PingForm_FormClosing);
			base.Load += new System.EventHandler(PingForm_Load);
			base.SizeChanged += new System.EventHandler(PingForm_SizeChanged);
			_notifyIconMenu.ResumeLayout(performLayout: false);
			_toolbar.ResumeLayout(performLayout: false);
			_toolbar.PerformLayout();
			ResumeLayout(performLayout: false);
			PerformLayout();
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
	}
}
