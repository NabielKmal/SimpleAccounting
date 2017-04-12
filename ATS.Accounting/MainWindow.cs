using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using ATS.EnterpriseSystem.SmartClients;
using Microsoft.Practices.CompositeUI.EventBroker;
using ATS.EnterpriseSystem.SmartClients.UIProcess;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;
using ATS.EnterpriseSystem.SmartClients.EntityEditor.LookupEngine;

namespace ATS.Accounting
{
    public partial class MainWindow : Form
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        WorkItem workItem;
        [ServiceDependency]
        public WorkItem WorkItem
        {
            get { return workItem; }
            set { workItem = value; }
        }

        IDataBaseManager DataBaseManager
        {
            get
            {
                return this.WorkItem.Services.Get<IDataBaseManager>();
            }
        }

        [EventSubscription(DataBaseManagerConstants.DataBaseClosed)]
        public void OnDataBaseClosed(object sender, EventArgs e)
        {
            try
            {
                foreach (UIProcess x in this.WorkItem.WorkItems.FindByType<UIProcess>())
                {
                    x.Dispose();
                }

                foreach (EntityEditor x in this.WorkItem.WorkItems.FindByType<EntityEditor>())
                {
                    x.Dispose();
                }

                UpdateShell();
                this.WorkItem.Services.Get<ObjectIDLookupEngine>().UpdateAll();
            }
            catch (Exception)
            {

                
            }
        }

        [EventSubscription(DataBaseManagerConstants.DataBaseOpened)]
        public void OnDataBaseOpened(object sender, EventArgs e)
        {
            try
            {
                UpdateShell();
                this.WorkItem.Services.Get<ObjectIDLookupEngine>().UpdateAll();
            }
            catch (Exception)
            {

                
            }
        }

        public void UpdateShell()
        {
            if (this.DataBaseManager.IsOpen)
            {
                RootEntityService rootEntityService = WorkItem.Services.Get<RootEntityService>();
                //Text = string.Format("{0} - {1}", rootEntityService.GetOrganizationName(), Application.ProductName);
                Text = string.Format("{0} - {1}", WorkItem.Services.Get<IDataBaseManager>().CurrentDataBase.dataBaseFile, Application.ProductName);
                this.reportsToolStripMenuItem.Enabled = true;
                this.actionsToolStrip.Enabled = true;
                this.optionsToolStripMenuItem.Enabled = true;
                this.currentDatetoolStripButton.Text = rootEntityService.GetOrganizationCurrentDate().ToShortDateString();
                this.orgnizationNameSSl.Text = rootEntityService.GetOrganizationName();
            }
            else
            {
                Text = string.Format("{0}", Application.ProductName);
                this.reportsToolStripMenuItem.Enabled = false;
                this.actionsToolStrip.Enabled = false;
                this.optionsToolStripMenuItem.Enabled = false;
                this.currentDatetoolStripButton.Text = "...";
                this.orgnizationNameSSl.Text = "";
            }
        }

        

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = Properties.Resources.FileDialog_Filter1;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                this.WorkItem.Services.Get<IDataBaseManager>().Open(ofd.FileName);
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccountList_Click(object sender, EventArgs e)
        {
            if (!this.WorkItem.Services.Get<IDataBaseManager>().IsOpen)
                return;
            WorkItem.Services.Get<UIProcessHomeManager>()["AccountExplorer"].Run(null);
        }

        private void btnTransctionList_Click(object sender, EventArgs e)
        {
            if (!this.WorkItem.Services.Get<IDataBaseManager>().IsOpen)
                return;
            WorkItem.Services.Get<UIProcessHomeManager>()["JournalEntryExplorer"].Run(null);
        }

        private void btnCurrencyList_Click(object sender, EventArgs e)
        {
            if (!this.WorkItem.Services.Get<IDataBaseManager>().IsOpen)
                return;
            WorkItem.Services.Get<UIProcessHomeManager>()["CurrencyExplorer"].Run(null);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WorkItem.Services.Get<OrganizationService>().ShowOrganizationInfo();
                this.UpdateShell();
            }
            catch (Exception ex)
            {
                this.WorkItem.Services.Get<IUIService>().ShowException(ex);

            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataBaseManager.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }

        private void blanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.WorkItem.Services.Get<IDataBaseManager>().IsOpen)
                return;
            WorkItem.Services.Get<UIProcessHomeManager>()["RepBlanceSheetProcess"].Run(null);
        }

        private void incomeStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.WorkItem.Services.Get<IDataBaseManager>().IsOpen)
                return;
            WorkItem.Services.Get<UIProcessHomeManager>()["RepIncomeStatementProcess"].Run(null);
        }

        private void currentDatetoolStripButton_Click(object sender, EventArgs e)
        {
            if (!this.WorkItem.Services.Get<IDataBaseManager>().IsOpen)
                return;
            try
            {
                WorkItem.Services.Get<OrganizationService>().OnSetCurrentDate();
                this.UpdateShell();
            }
            catch (Exception ex)
            {
                this.WorkItem.Services.Get<IUIService>().ShowException(ex);

            }
        }

        private void generalJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.WorkItem.Services.Get<IDataBaseManager>().IsOpen)
                return;
            WorkItem.Services.Get<UIProcessHomeManager>()["RepGeneralJournalProcess"].Run(null);
        }

        private void generalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.WorkItem.Services.Get<IDataBaseManager>().IsOpen)
                return;
            WorkItem.Services.Get<UIProcessHomeManager>()["RepGeneralLedgerProcess"].Run(null);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WorkItem.Services.Get<OrganizationService>().OnNewOrganization2();
            }
            catch (Exception ex)
            {
                this.WorkItem.Services.Get<IUIService>().ShowException(ex);

            }
        }

        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.WorkItem.Services.Get<IDataBaseManager>().IsOpen)
                return;
            WorkItem.Services.Get<UIProcessHomeManager>()["RepTrialBalanceProcess"].Run(null);
        }

        

        
    }
}
