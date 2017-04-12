using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;
using ATS.EnterpriseSystem.SmartClients;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting
{

    class OrganizationService
    {
        WorkItem workItem;
        [ServiceDependency]
        public WorkItem WorkItem
        {
            get { return workItem; }
            set { workItem = value; }
        }

        OrganizationDataAdapter dataAdapter;

        public OrganizationDataAdapter DataAdapter
        {
            get
            {
                if (dataAdapter == null)
                {
                    dataAdapter = new OrganizationDataAdapter();
                    dataAdapter.Context = this.WorkItem.Services.Get<IDACContext>(true);
                }
                return dataAdapter;
            }
        }

        OrganizationView view;
        public void ShowOrganizationInfo()
        {
            DataUnit data = DataAdapter.Load(Constants.SystemConstants.OrganizationID);
            view = this.WorkItem.Items.AddNew<OrganizationView>();
            view.organizationService = this;
            view.dataUnit = data;
            view.InitializeView();
            view.ShowDialog(((ApplicationWorkItem)WorkItem.RootWorkItem).Shell);
        }

        

        public void OnNewOrganization2()
        {
            try
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                //sfd.CheckFileExists = false;
                sfd.Filter = Properties.Resources.FileDialog_Filter1;
                if (sfd.ShowDialog(((ApplicationWorkItem)WorkItem.RootWorkItem).Shell) == System.Windows.Forms.DialogResult.OK)
                {
                    CreateDataBaseFile(sfd.FileName);
                    this.WorkItem.Services.Get<IDataBaseManager>().Open(sfd.FileName);
                    this.ShowOrganizationInfo();
                }
            }
            catch (Exception ex)
            {

                this.WorkItem.Services.Get<IUIService>().ShowException(ex);
            }
        }
        void CreateDataBaseFile(string dbFile)
        {
            System.Exception exception = null;
            System.IO.FileStream fs = null;
            try
            {
                fs = new System.IO.FileStream(dbFile, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
                fs.Write(Properties.Resources.DBAccountingC_Template, 0, Properties.Resources.DBAccountingC_Template.Length);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            if (exception != null) throw exception;
        }

        public void OnSetCurrentDate()
        {
            try
            {
                frmCurrentDate frm = new frmCurrentDate();
                RootEntityService res = this.WorkItem.Services.Get<RootEntityService>();
                
                frm.currentDate.MinDate = (DateTime)res.GetRootObject()["FiscalYearStart"];
                frm.currentDate.MaxDate = (DateTime)res.GetRootObject()["FiscalYearEnd"];
                frm.currentDate.Value = (DateTime)res.GetRootObject()["CurrentDate"];

                if (frm.ShowDialog(((ApplicationWorkItem)WorkItem.RootWorkItem).Shell) == System.Windows.Forms.DialogResult.OK)
                {
                    res.SetCurrentDate(frm.currentDate.Value);
                }
            }
            catch (Exception ex)
            {
                this.WorkItem.Services.Get<IUIService>().ShowException(ex);

            }
        }
    }
}
