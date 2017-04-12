using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI;

namespace ATS.EnterpriseSystem.SmartClients.UIProcess
{
    public abstract class UIProcessHome
    {
        internal UIProcessHomeManager processHomeManager;
        private string homeID;
        private UIProcessSettings processSettings;
        private IWorkspace workspace;

        public UIProcessHome(string homeID, UIProcessSettings processTemplate, IWorkspace workspace)
        {
            AV.CheckForEmptyString(homeID);
            AV.CheckForNullReference(processTemplate);
            this.homeID = homeID;
            this.processSettings = processTemplate;
            this.workspace = workspace;
        }

        public UIProcessSettings ProcessSettings
        {
            get { return processSettings; }
            internal set { processSettings = value; }
        }

        public UIProcessHomeManager ProcessHomeManager
        {
            get { return processHomeManager; }
            //set { processHomeManager = value; }
        }

        public WorkItem WorkItem
        {
            get
            {
                if (this.processHomeManager != null)
                    return this.processHomeManager.WorkItem;
                return null;
            }
        }



        public IWorkspace Workspace
        {
            get
            {
                if (workspace != null)
                    return workspace;
                if (this.processHomeManager != null)
                    return this.processHomeManager.Workspace;
                return null;
            }
            //set { workspace = value; }
        }

        #region IUIProcessHome Members

        public string HomeID
        {
            get { return homeID; }
        }

        //public IUIProcess Run(string args)
        //{
        //    throw new NotImplementedException();
        //}

        public abstract void Run(object args);


        #endregion

        protected UIProcess CreateProcess()
        {
            return CreateProcess(ProcessSettings.ProcessType);
        }

        protected UIProcess CreateProcess(System.Type type)
        {
            UIProcess r = (UIProcess)WorkItem.WorkItems.AddNew(type);
            r.ProcessHome = this;
            r.Workspace = this.Workspace;
            r.InitializeProcess();

            return r;
        }
    }

    public class SDIProcessHome : UIProcessHome
    {
        public SDIProcessHome(string homeID, UIProcessSettings processTemplate, IWorkspace workspace)
            : base(homeID, processTemplate, workspace)
        { }

        protected UIProcess GetProcess()
        {
            foreach (UIProcess x in WorkItem.WorkItems.FindByType<UIProcess>())
            {
                if (x.ProcessHome == this)
                    return x;
            }
            return null;
        }

        protected UIProcess GetOrCreateProcess()
        {
            UIProcess r = GetProcess();
            if (r == null)
            {
                r = this.CreateProcess();

            }
            return r;
        }



        public override void Run(object args)
        {
            UIProcess r = GetOrCreateProcess();
            r.Run(args);

        }
    }

    public class MDIProcessHome : UIProcessHome
    {
        public MDIProcessHome(string homeID, UIProcessSettings processTemplate, IWorkspace workspace)
            : base(homeID, processTemplate, workspace)
        { }

        public UIProcess Get(object id)
        {

            foreach (UIProcess x in this.WorkItem.WorkItems.FindByType<UIProcess>())
            {
                if (x.ProcessHome == this && object.Equals(id, x.ProcessID))
                {
                    return x;
                }
            }

            return null;

        }

        public UIProcess Open(object id)
        {
            UIProcess r = Get(id);
            if (r == null)
            {
                r = CreateProcess();
                //r.Run(id);
            }
            r.Activate();
            return r;
        }

        public override void Run(object args)
        {
            throw new NotImplementedException();
        }
    }
}
