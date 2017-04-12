using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI;
using ATS.EnterpriseSystem.AppService;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace ATS.EnterpriseSystem.SmartClients
{
    public class DataBaseManager : IDataBaseManager
    {
        WorkItem workItem;
        DataBaseConnection dataBaseConnection;
        DataBaseInfo currentDataBase;

        public DataBaseManager(WorkItem workItem, DataBaseConnection dataBaseConnection)
        {
            this.workItem = workItem;
            this.dataBaseConnection = dataBaseConnection;
        }

        WorkItem WorkItem
        { get { return workItem; } }

        public DataBaseConnection DataBaseConnection
        {
            get { return dataBaseConnection; }
        }

        #region IDataBaseManager Members

        IDataBaseConnection IDataBaseManager.DataBaseConnection
        {
            get { return this.DataBaseConnection; }
        }

        public DataBaseInfo CurrentDataBase
        {
            get { return currentDataBase; }
        }

        public bool IsOpen
        {
            get { return this.dataBaseConnection.IsOpen(); }
        }

        public void Open(string fullPath)
        {
            this.ReleaseCurrentDataBase();
            DataBaseInfo db = new DataBaseInfo();
            try
            {
                db.dataBaseFile = System.IO.Path.GetFileName(fullPath);
                db.fullPath = fullPath;
                db.connectionString = ConnectionStringHelper.GetJetConnectionString(fullPath);
                this.DataBaseConnection.Open(db.connectionString);
                ISystemInfoService systemInfoService = WorkItem.Services.Get<ISystemInfoService>();
                if (systemInfoService != null && !systemInfoService.IsValidDBDocument(DataBaseConnection))
                    throw new System.Exception("Data Base Error");
                this.currentDataBase = db;
                this.OnDataBaseOpened(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                WorkItem.Services.Get<IUIService>().ShowException(ex);
                this.DataBaseConnection.Close();
                this.currentDataBase = null;
            }

            UpdateShell();

        }

        public void Close()
        {
            this.ReleaseCurrentDataBase();
            UpdateShell();
        }

        [EventPublication(DataBaseManagerConstants.DataBaseClosed, PublicationScope.Global)]
        public event EventHandler DataBaseClosed;

        [EventPublication(DataBaseManagerConstants.DataBaseOpened, PublicationScope.Global)]
        public event EventHandler DataBaseOpened;

        protected virtual void OnDataBaseClosed(EventArgs e)
        {
            if (DataBaseClosed != null)
                this.DataBaseClosed(this, e);
        }

        protected virtual void OnDataBaseOpened(EventArgs e)
        {
            if (DataBaseOpened != null)
                this.DataBaseOpened(this, e);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.ReleaseCurrentDataBase();
            }
        }

        #endregion

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            return null;
        }

        #endregion

        protected void ReleaseCurrentDataBase()
        {
            bool raiseEvent = false;
            if (IsOpen)
            {
                raiseEvent = true;


            }

            this.dataBaseConnection.Close();
            this.currentDataBase = null;

            if (raiseEvent)
            {
                try
                {
                    this.OnDataBaseClosed(EventArgs.Empty);
                }
                catch (Exception) { }
            }

        }


        //string BiludStringConnection(string dbFileName)
        //{
        //    return String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}", dbFileName);
        //}

        public virtual void UpdateShell()
        { }
    }

    public class DataBaseManagerConstants
    {
        public const string DataBaseClosed = "DataBaseClosed";
        public const string DataBaseOpened = "DataBaseOpened";

    }
}
