using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace ATS.EnterpriseSystem.SmartClients.EntityExplorer
{
    public class SimpleEntityExplorer : EntityExplorer
    {
        private int typeCode;
        private string entityPrimaryKey;

        public SimpleEntityExplorer(int typeCode, string entityPrimaryKey)
        {
            this.typeCode = typeCode;
            this.entityPrimaryKey = entityPrimaryKey;
        }

        protected override void DoInitializeProcess()
        {
            base.DoInitializeProcess();
            this.Items.AddNew<EntityExplorerController>();
        }

        public int TypeCode
        {
            get { return typeCode; }
        }

        protected string EntityPrimaryKey
        {
            get { return entityPrimaryKey; }
        }

        protected virtual ObjectIdentity ResolveObjectIdentity(object e)
        {
            DataRowView drv = e as DataRowView;
            if (drv != null)
            {

                Guid id = (Guid)drv[EntityPrimaryKey];
                return new ObjectIdentity(TypeCode, id);
            }
            return null;
        }

        public ObjectIdentity PrimarySelection
        {
            get
            {
                ////DataRowView drv = this.Services.Get<ISelectionService>().PrimarySelection as DataRowView;
                ////if (drv != null)
                ////{

                ////    Guid id = (Guid)drv[EntityPrimaryKey];
                ////    return new ObjectIdentity(TypeCode, id);
                ////}
                ////return null;

                return ResolveObjectIdentity(this.Services.Get<ISelectionService>().PrimarySelection);

            }
        }

        protected override void InitializeServices()
        {
            base.InitializeServices();
            this.Services.AddNew<SimpleSelectionService, ISelectionService>();
        }

        public override void NewObject()
        {
            try
            {
                this.Services.Get<EntityEditor.EntityEditorHomeManager>()[TypeCode].NewObject();
            }
            catch (Exception ex)
            {
                this.Services.Get<IUIService>().ShowException(ex);
            }
        }



        public override void OpenObject()
        {
            try
            {
                if (PrimarySelection == null) return;
                this.Services.Get<EntityEditor.EntityEditorHomeManager>()[TypeCode].OpenObject(PrimarySelection.ObjectId);
            }
            catch (Exception ex)
            {
                this.Services.Get<IUIService>().ShowException(ex);
            }
        }

        public override void DeleteObject()
        {
            try
            {
                if (PrimarySelection == null) return;
                ////if (this.Services.Get<IUIService>().Show(Properties.Resources.DeleteMsg1, System.Windows.Forms.MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                ////    return;

                ////this.Services.Get<EntityEditor.EntityEditorHomeManager>()[TypeCode].DataUnitAdapter.Delete(PrimarySelection.ObjectId);
                ////this.Refersh();
                this.Services.Get<EntityEditor.EntityEditorHomeManager>()[TypeCode].DeleteObject(PrimarySelection.ObjectId);
            }
            catch (Exception ex)
            {
                this.Services.Get<IUIService>().ShowException(ex);
            }
        }

        [EventSubscription(ObjectChangeService.ObjectChaneEvent)]
        public void OnObjectChangeHandler(object sender, ObjectChangeEventArgs e)
        {
            if (this.TypeCode == e.ObjectTypeCode)
                Refersh();
        }
    }
}
