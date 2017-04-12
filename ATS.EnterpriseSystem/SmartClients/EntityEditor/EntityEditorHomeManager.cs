using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor
{
    public class EntityEditorHomeManager : IEntityEditorHomeManager
    {
        Dictionary<int, EntityEditorHome> homes = new Dictionary<int, EntityEditorHome>();
        private WorkItem workItem;
        private IWorkspace workspace;

        public EntityEditorHomeManager(WorkItem workItem, IWorkspace workspace)
        {
            AV.CheckForNullReference(workItem);
            AV.CheckForNullReference(workspace);
            this.workItem = workItem;
            this.workspace = workspace;
        }

        public WorkItem WorkItem
        {
            get
            {
                return workItem;
            }
        }

        public IWorkspace Workspace
        {
            get
            {
                return workspace;
            }
        }

        public EntityEditorHome this[int typeCode]
        {
            get 
            {
                return homes[typeCode];
            }
        }


        #region IEntityEditorHomeManager Members

        IEntityEditorHome IEntityEditorHomeManager.this[int typeCode]
        {
            get { return this[typeCode]; }
        }

        #endregion

        public void Add(EntityEditorHome home)
        {
            AV.CheckForNullReference(home);
            AV.Assert(home.HomeManager == null);
            AV.Assert(!homes.ContainsKey(home.TypeCode));
            this.homes.Add(home.TypeCode, home);
            home.HomeManager = this;

        }
    }
}
