using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace ATS.EnterpriseSystem.SmartClients.UIProcess
{
    public class UIProcessHomeManager
    {
        Dictionary<string, UIProcessHome> list = new Dictionary<string, UIProcessHome>();
        private WorkItem workItem;
        private IWorkspace workspace;

        public UIProcessHomeManager(WorkItem workItem, IWorkspace workspace)
        {
            AV.CheckForNullReference(workItem);
            AV.CheckForNullReference(workspace);
            this.workItem = workItem;
            this.workspace = workspace;
        }

        #region IUIProcessHomeManager Members

        public UIProcessHome this[string name]
        {
            get
            {
                if (list.ContainsKey(name))
                    return list[name];
                return null;
            }
        }



        ////public void Run(string home, object args)
        ////{

        ////    UIProcessHome h = this[home];
        ////    AV.CheckForNullReference(h);
        ////    h.Run(args);

        ////}

        #endregion



        //[ServiceDependency]
        public WorkItem WorkItem
        {
            get
            {
                return workItem;
            }
            //set
            //{
            //    workItem = value;
            //}
        }

        public IWorkspace Workspace
        {
            get
            { return workspace; }
        }

        public void Add(UIProcessHome ph)
        {
            AV.CheckForNullReference(ph);
            AV.Assert(!this.list.ContainsKey(ph.HomeID));
            AV.Assert(ph.processHomeManager == null);

            ph.processHomeManager = this;
            list.Add(ph.HomeID, ph);
        }
    }
}
