using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace ATS.EnterpriseSystem.SmartClients.UIProcess
{
    public abstract class UIProcess : WorkItem
    {
        internal UIProcessHome processHome;
        private IWorkspace workspace;
        private object view;
        private string title;

        #region IUIProcess Members

        public virtual object ProcessID
        {
            get { return this.ID; }
        }

        public virtual bool IsDirty
        {
            get { return false; }
        }

        public string Title
        {
            get
            {

                return title;
            }
            set { title = value; }
        }



        public virtual void Close()
        {
            throw new NotImplementedException();
        }


        public void Run(object args)
        {
            Run();
            RunCore(args);
        }

        protected virtual void RunCore(object args)
        { }

        #endregion

        public UIProcessHome ProcessHome
        {
            get { return processHome; }
            internal set { this.processHome = value; }
        }

        public UIProcessSettings Settings
        {
            get
            {
                if (this.ProcessHome != null)
                    return this.ProcessHome.ProcessSettings;
                return null;

            }
        }

        public IWorkspace Workspace
        {
            get { return workspace; }
            internal set
            {
                this.workspace = value;
            }
        }

        public object View
        {
            get { return view; }
            protected set { view = value; }
        }

        bool fInitializeEditorDone = false;
        internal void InitializeProcess()
        {
            AV.Assert(!fInitializeEditorDone);
            fInitializeEditorDone = true;

            AV.CheckForNullReference(this.ProcessHome);
            AV.CheckForNullReference(this.Workspace);


            Title = string.IsNullOrEmpty(this.Settings.Title) ? this.GetType().Name : this.Settings.Title;
            Workspace.SmartPartClosing += new EventHandler<WorkspaceCancelEventArgs>(Workspace_SmartPartClosing);
            view = CreateViewInstance();
            AV.CheckForNullReference(view);
            DoInitializeProcess();
        }

        protected virtual void DoInitializeProcess()
        { }

        void Workspace_SmartPartClosing(object sender, WorkspaceCancelEventArgs e)
        {
            if (this.Status == WorkItemStatus.Terminated)
            {
                return;
            }

            //هل يمثل العارض الخاص بهذا المحرر
            if (object.Equals(e.SmartPart, View))
            {
                this.Terminate();
            }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            ShowView();
        }

        protected override void OnTerminated()
        {
            base.OnTerminated();
            try
            {
                Workspace.SmartPartClosing -= new EventHandler<WorkspaceCancelEventArgs>(Workspace_SmartPartClosing);
            }
            catch { }
        }

        protected virtual object CreateViewInstance()
        {
            object r = null;
            System.Type type = this.Settings.ProcessViewType;
            r = Items.AddNew(type);
            return r;
        }

        protected virtual ISmartPartInfo GetViewSmartPartInfo()
        {
            SmartPartInfo spi = new SmartPartInfo();
            spi.Title = this.Title;
            return spi;
        }

        protected virtual void ShowView()
        {
            ThrowIfWorkItemTerminated();
            if (Workspace.SmartParts.Contains(View))
            {
                Workspace.Activate(View);
            }
            else
            {
                ISmartPartInfo viewInfo = GetViewSmartPartInfo();
                Workspace.Show(View, viewInfo);

            }

            if (Workspace.ActiveSmartPart != View)
            {
                Workspace.Activate(View);
            }

        }

        protected void ThrowIfWorkItemTerminated()
        {
            if (this.Status == WorkItemStatus.Terminated)
            {
                throw new InvalidOperationException("WorkItemTerminated");
            }
        }


        protected void UpdateViewSmartPartInfo(ISmartPartInfo spi)
        {
            if (view == null) return;
            if (!Workspace.SmartParts.Contains(view)) return;
            Workspace.ApplySmartPartInfo(view, spi);
        }
    }


}
