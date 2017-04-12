using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using ATS.EnterpriseSystem.AppService;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor
{
    public class EntityEditorHome : IEntityEditorHome
    {
        private EntityEditorHomeManager homeManager;
        private int typeCode;
        private DataUnitAdapter dataUnitAdapter;


        ////public EntityEditorHome(EntityEditorHomeManager homeManager, int typeCode)
        ////{
        ////    this.homeManager = homeManager;
        ////    this.typeCode = typeCode;
        ////}

        public EntityEditorHome(int typeCode)
        {
            this.typeCode = typeCode;
        }

        public EntityEditorHomeManager HomeManager
        {
            get
            {
                return this.homeManager;
            }
            internal set
            {
                AV.Assert(this.homeManager == null);
                this.homeManager = value;
            }
        }

        public WorkItem WorkItem
        {
            get
            {
                return HomeManager.WorkItem;
            }
        }

        public virtual IWorkspace Workspace
        {
            get
            {
                return HomeManager.Workspace;
            }
        }


        #region IEntityEditorHome Members

        public int TypeCode
        {
            get { return typeCode; }
        }

        public void NewObject()
        {
            EntityEditor editor = null;
            IDataUnit dataUnit = InitializeNewDataUnit();
            editor = CreateEditor(this.Workspace, dataUnit);
            editor.Activate();
        }

        public void NewObjectFromExist(ObjectIdentity source)
        {
            throw new NotImplementedException();
        }

        public void OpenObject(Guid id)
        {
            try
            {
                EntityEditor editor = null;
                editor = GetOpenedEntityEditor(id);
                if (editor != null)
                {
                    editor.Activate();
                    return;
                }
                if (!DataUnitAdapter.Exist(id))
                {
                    this.WorkItem.Services.Get<IUIService>().Show("not exist");
                    return;
                }

                IDataUnit dataUnit = DataUnitAdapter.Load(id);
                editor = CreateEditor(this.Workspace, dataUnit);
                editor.Activate();
            }
            catch (Exception ex)
            {

                this.WorkItem.Services.Get<IUIService>().ShowException(ex);
            }
        }

        #endregion


        public DataUnitAdapter DataUnitAdapter
        {
            get
            {
                if (dataUnitAdapter == null)
                {
                    System.Type type = WorkItem.Services.Get<TypeCodeRegistry>()[typeCode].dataUnitAdapterType;
                    dataUnitAdapter = (DataUnitAdapter)Activator.CreateInstance(type);
                    dataUnitAdapter.Context = WorkItem.Services.Get<IDACContext>(true);

                }

                return dataUnitAdapter;
            }
        }



        public EntityEditor GetOpenedEntityEditor(Guid id)
        {
            ObjectIdentity identity = new ObjectIdentity(this.typeCode, id);
            foreach (EntityEditor x in this.WorkItem.WorkItems.FindByType<EntityEditor>())
            {
                if (x.Home == this && object.Equals(x.DataUnit.RootObjectID, identity))
                    return x;
            }
            return null;
        }

        protected virtual EntityEditor CreateEditor(IWorkspace workspace, IDataUnit dataUnit)
        {
            System.Type editorType = WorkItem.Services.Get<TypeCodeRegistry>()[typeCode].editorType;
            EntityEditor editor = null;
            editor = (EntityEditor)WorkItem.WorkItems.AddNew(editorType);
            editor.Home = this;
            editor.Workspace = workspace;
            editor.SetDataUnit(dataUnit);
            editor.DoInitializeEditor();
            return editor;
        }

        /// <summary>
        /// تهيئة كائن جديد
        /// </summary>
        /// <returns></returns>
        public virtual IDataUnit InitializeNewDataUnit()
        {
            return null;
        }

        public virtual bool MayDeleteByUI(Guid id)
        {
            return true;
        }

        /// <summary>
        /// حذف كائن
        /// </summary>
        /// <param name="id">معرف كائن العمل المطلوب حذفه</param>
        public virtual void DeleteObject(Guid id)
        {
            if (!DataUnitAdapter.Exist(id))
            {
                this.WorkItem.Services.Get<IUIService>().Show(Properties.Resources.ObjectNotExist, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }

            if (!MayDeleteByUI(id))
            {
                this.WorkItem.Services.Get<IUIService>().Show(Properties.Resources.ObjectNotDeleteAble, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }


            if (!DataUnitAdapter.MayDelete(id))
            {
                this.WorkItem.Services.Get<IUIService>().Show(Properties.Resources.ObjectNotDeleteAble, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }

            if (this.WorkItem.Services.Get<IUIService>().Show(Properties.Resources.DeleteMsg1, System.Windows.Forms.MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                return;
            this.DataUnitAdapter.Delete(id);
            if (this.WorkItem.Services.Contains<IObjectChangeService>())
            {
                this.WorkItem.Services.Get<IObjectChangeService>().RaiseObjectChange(this, new ObjectChangeEventArgs(this.TypeCode, id, CommonObjectChanges.Deleted));
            }
        }

    }
}
