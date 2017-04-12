using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI;
using System.Data;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace ATS.EnterpriseSystem.SmartClients.EntityExplorer
{

    //
    public class EntityExplorer : UIProcess.UIProcess, IEntityExplorer
    {
        private DataSet explorerData;

        public DataSet ExplorerData
        {
            get { return explorerData; }
            protected set
            {
                explorerData = value;
                OnExplorerDataChanged(EventArgs.Empty);
            }
        }

        [EventPublication(EntityExplorerConstants.ExplorerDataChanged, PublicationScope.WorkItem)]
        public event EventHandler ExplorerDataChanged;

        protected virtual void OnExplorerDataChanged(EventArgs e)
        {
            if (ExplorerDataChanged != null)
                ExplorerDataChanged(this, e);
        }



        #region IEntityExplorer Members

        public void Refersh()
        {
            LoadExplorerData();
        }

        #endregion

        public virtual void OnHelp()
        { 
            this.Services.Get<IUIService>().Show("Not Supported", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
        }


        private bool firstRun = true;

        protected override void RunCore(object args)
        {
            base.RunCore(args);
            if (firstRun)
            {
                firstRun = false;
                LoadExplorerData();
            }
            Activate();
        }


        protected void LoadExplorerData()
        {
            ThrowIfWorkItemTerminated();
            DataSet ds = DoLoadExplorerData();
            AV.CheckForNullReference(ds);
            this.ExplorerData = ds;
        }

        protected virtual DataSet DoLoadExplorerData()
        {
            return null;
        }

        /// <summary>
        /// إنشاء كائن جديد
        /// </summary>
        public virtual void NewObject()
        { }

        /// <summary>
        /// فتح نموذج الكائن الحالي
        /// </summary>
        public virtual void OpenObject()
        { }

        /// <summary>
        /// حذف الكائن الحالي
        /// </summary>
        public virtual void DeleteObject()
        { }
    }

    

}
