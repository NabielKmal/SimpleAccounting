using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI;
using ATS.EnterpriseSystem.AppService;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor
{
    //
    public class EntityEditor : WorkItem, IEntityEditor //, IEntityEditorInternal
    {
        private EntityEditorHome home;
        private DataUnit dataUnit;
        private IWorkspace workspace;
        private EntityEditorView view;
        private string title;

        public DataUnit DataUnit
        {
            get { return dataUnit; }
        }

        public EntityEditorHome Home
        {
            get
            {
                return home;
            }
            internal set
            {
                this.home = value;
            }
        }

        public DataUnitAdapter DataUnitAdapter
        {
            get
            {

                return Home.DataUnitAdapter;
            }
        }

        #region IEntityEditor Members

        IEntityEditorHome IEntityEditor.Home
        {
            get
            {
                return Home;
            }
        }

        IDataUnit IEntityEditor.DataUnit
        {
            get { return this.DataUnit; }
        }

        public bool IsNew
        {
            get
            {
                if (this.DataUnit != null && this.DataUnit.State != DataUnitState.NA)
                    return this.DataUnit.State == DataUnitState.Added;
                return false;
            }
        }

        public bool IsDirty
        {
            get
            {
                if (this.DataUnit != null && this.DataUnit.State != DataUnitState.NA)
                    return this.DataUnit.IsDirty;
                return false;
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

        public string Title
        {
            get
            {

                return title;
            }
            set
            {
                title = value;
                RefershTitle();
            }
        }

        /// <summary>
        /// يحدث عندما تتغير الصفة DataUnit
        /// </summary>
        [EventPublication(EntityEditorConstants.DataUnitChanged, PublicationScope.Descendants)]
        public event EventHandler DataUnitChanged;

        public new void Save()
        {
            SaveCore();
        }

        protected virtual bool SaveCore()
        {
            ThrowIfWorkItemTerminated();

            bool r = false;

            try
            {

                if (!EndEdit()) return false;

                ValidationErrorCollection vr = this.Home.DataUnitAdapter.Validate(this.DataUnit);
                this.View.DisplayValidationResult(vr);
                if (!vr.IsValid)
                {
                    this.Services.Get<IUIService>().Show(Properties.Resources.InvalidDataMsg, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }

                bool isNew = this.IsNew;

                this.Home.DataUnitAdapter.Save(this.DataUnit);
                if (this.Services.Contains<IObjectChangeService>())
                {
                    this.Services.Get<IObjectChangeService>().RaiseObjectChange(this, new ObjectChangeEventArgs(this.DataUnit.TypeCode, this.DataUnit.ID, isNew ? CommonObjectChanges.Add : CommonObjectChanges.Update));
                }

                this.SetDataUnit(this.Home.DataUnitAdapter.Load(this.DataUnit.ID));
                r = true;
            }
            catch (Exception ex)
            {
                this.Services.Get<IUIService>().ShowException(ex);
                r = false;

            }
            return r;
        }

        protected virtual bool EndEdit()
        {
            bool r = false;
            try
            {
                r = ((IEntityEditorView)View).EndEdit();
            }
            catch (Exception ex)
            {
                this.Services.Get<IUIService>().ShowException(ex);
                r = false;
            }
            return r;
        }

        public virtual bool SaveModified()
        {
            ThrowIfWorkItemTerminated();

            if (DataUnit == null)
                return true;

            this.EndEdit();
            if (!DataUnit.IsDirty)
                return true;
            switch (this.Services.Get<IUIService>().Show(Properties.Resources.SaveMsg1, System.Windows.Forms.MessageBoxButtons.OKCancel))
            {
                case System.Windows.Forms.DialogResult.No:
                    return true;
                //break;
                case System.Windows.Forms.DialogResult.OK:
                    if (this.SaveCore())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                //break;
            }
            return true;
        }

        #endregion

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            return this.Services.Get(serviceType);
        }

        #endregion

        #region IEntityEditorInternal Members



        public void SetDataUnit(IDataUnit dataUnit)
        {
            AV.CheckForNullReference(dataUnit);
            AV.Assert(dataUnit.State != DataUnitState.NA);
            this.dataUnit = (DataUnit)dataUnit;
            this.OnDataUnitChanged(EventArgs.Empty);
        }

        bool fInitializeEditorDone = false;
        internal void DoInitializeEditor()
        {
            AV.Assert(!fInitializeEditorDone);
            fInitializeEditorDone = true;

            AV.CheckForNullReference(this.Home);
            AV.CheckForNullReference(this.Workspace);
            AV.CheckForNullReference(this.DataUnit);

            Title = this.GetType().Name;
            Workspace.SmartPartClosing += new EventHandler<WorkspaceCancelEventArgs>(Workspace_SmartPartClosing);
            view = CreateViewInstance();
            AV.CheckForNullReference(view);
            InitializeEditor();

        }

        protected virtual internal void InitializeEditor()
        {

        }
        #endregion

        protected virtual void OnDataUnitChanged(EventArgs e)
        {
            if (this.DataUnitChanged != null)
                this.DataUnitChanged(this, e);
        }

        void Workspace_SmartPartClosing(object sender, WorkspaceCancelEventArgs e)
        {
            if (this.Status == WorkItemStatus.Terminated)
            {
                return;
            }
            IEntityEditorView view = e.SmartPart as IEntityEditorView;
            //هل يمثل العارض الخاص بهذا المحرر
            if (view != null && view.Editor == this)
            {
                if (SaveModified())
                {
                    this.Terminate();
                }
                else
                {
                    e.Cancel = true;
                }
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
            Workspace.SmartPartClosing -= new EventHandler<WorkspaceCancelEventArgs>(Workspace_SmartPartClosing);
        }

        protected void ThrowIfWorkItemTerminated()
        {
            if (this.Status == WorkItemStatus.Terminated)
            {
                throw new InvalidOperationException("WorkItemTerminated");
            }
        }

        #region view
        public EntityEditorView View
        {
            get { return view; }
            protected set { view = value; }
        }

        protected virtual EntityEditorView CreateViewInstance()
        {
            EntityEditorView r = null;
            System.Type type = Services.Get<TypeCodeRegistry>()[Home.TypeCode].editorViewType;
            r = (EntityEditorView)Items.AddNew(type);
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

        public void RefershTitle()
        {
            if (Workspace != null && Workspace.SmartParts.Contains(View))
            {
                Workspace.ApplySmartPartInfo(View, new SmartPartInfo(Title, string.Empty));
            }
        }
        #endregion

        public virtual void OnHelp()
        {
            this.Services.Get<IUIService>().Show("Not Supported", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
        }
    }
}
