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
using ATS.EnterpriseSystem.AppService;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor
{
    [SmartPart]
    public partial class EntityEditorView : UserControl, IEntityEditorView, ISmartPartInfoProvider //, IEntityEditorViewInternal
    {
        WorkItem workItem;

        public EntityEditorView()
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
                DoInitializeView();
            }
        }

        public EntityEditor Editor
        {
            get
            {
                return this.WorkItem as EntityEditor;
            }
        }

        public DataUnit DataUnit
        {
            get
            {
                if (this.Editor != null) return this.Editor.DataUnit;
                return null;
            }
        }

        #region IEntityEditorView Members



        protected virtual bool EndEdit()
        {
            return true;
        }

        #endregion

        #region IEntityEditorViewInternal Members

        internal void DoInitializeView()
        {
            InitializeView();
        }

        protected virtual void InitializeView()
        {

        }

        protected virtual void BindToDataUnit()
        {

        }

        protected virtual void BindLookups()
        {

        }

        protected void SetUIDirty()
        {
            this.Editor.DataUnit.IsDirty = true;

        }

        [EventSubscription(EntityEditorConstants.DataUnitChanged)]
        public virtual void OnDataUnitChanged(object sender, EventArgs e)
        {
            this.BindToDataUnit();
        }

        #endregion



        #region IEntityEditorView Members

        IEntityEditor IEntityEditorView.Editor
        {
            get { return this.Editor; }
        }

        bool IEntityEditorView.EndEdit()
        {
            return this.EndEdit();
        }

        #endregion

        #region ISmartPartInfoProvider Members

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            if (typeof(SmartPartInfo) == smartPartInfoType)
            {
                SmartPartInfo r = new SmartPartInfo();
                r.Title = "";

                return r;
            }

            return null;
        }

        #endregion

        public virtual void DisplayValidationResult(ValidationErrorCollection vr)
        {
            ClearValidationErrors();
            foreach (ValidationError x in vr)
            {
                DataRow dr = x.Object as DataRow;
                if (dr != null && !string.IsNullOrEmpty(x.Property) && dr.Table.Columns.Contains(x.Property))
                {
                    dr.SetColumnError(x.Property, x.ErrorText);
                }
            }
        }

        protected virtual void ClearValidationErrors()
        {
            if (this.DataUnit == null) return;
            foreach (DataTable x in DataUnit.Tables)
            {
                foreach (DataRow x2 in x.Rows)
                {
                    x2.ClearErrors();
                }
            }
        }
    }
}
