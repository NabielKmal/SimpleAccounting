using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace ATS.EnterpriseSystem.SmartClients.EntityExplorer
{
    [SmartPart]
    public partial class EntityExplorerView : UserControl
    {
        WorkItem workItem;

        public EntityExplorerView()
        {
            InitializeComponent();
        }

        [ServiceDependency]
        public WorkItem WorkItem
        {
            get { return workItem; }
            set 
            {
                workItem = value;
                this.InitializeView();
            }
        }

        public EntityExplorer Explorer
        {
            get
            {
                return this.WorkItem as EntityExplorer;
            }
        }

        public DataSet ExplorerData
        {
            get
            {
                if (this.Explorer != null) return this.Explorer.ExplorerData;
                return null;
            }
        }

        protected virtual void InitializeView()
        {

        }


        protected virtual void BindToExplorerData()
        {

        }


        [EventSubscription(EntityExplorerConstants.ExplorerDataChanged)]
        public virtual void OnExplorerDataChanged(object sender, EventArgs e)
        {
            this.BindToExplorerData();
        }

    }
}
