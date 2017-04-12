using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace ATS.EnterpriseSystem.SmartClients
{
    //
    public interface IObjectChangeService
    {
        event EventHandler<ObjectChangeEventArgs> ObjectChange;

        void RaiseObjectChange(object sender, ObjectChangeEventArgs e);
    }

    public class CommonObjectChanges
    {
        public const string Add = "Add";
        public const string Update = "Update";
        public const string Deleted = "Deleted";
    }

    //public delegate void ObjectChangeHandler(object sender, ObjectChangeEventArgs e);
    public class ObjectChangeEventArgs : EventArgs
    {
        private int objectTypeCode;
        private Guid objectID;
        private string changeType;

        public ObjectChangeEventArgs(int objectTypeCode, Guid objectID, string changeType)
        {
            this.objectTypeCode = objectTypeCode;
            this.objectID = objectID;
            this.changeType = changeType;
        }

        public int ObjectTypeCode
        {
            get { return objectTypeCode; }
            //set { objectTypeCode = value; }
        }


        public Guid ObjectID
        {
            get { return objectID; }
            //set { objectID = value; }
        }


        public string ChangeType
        {
            get { return changeType; }
            //set { changeType = value; }
        }
    }

    public class ObjectChangeService : IObjectChangeService
    {
        public const string ObjectChaneEvent = "ObjectChangeService";

        #region IObjectChangeService Members

        [EventPublication(ObjectChangeService.ObjectChaneEvent, PublicationScope.Global)]
        public event EventHandler<ObjectChangeEventArgs> ObjectChange;

        public void RaiseObjectChange(object sender, ObjectChangeEventArgs e)
        {
            if (this.ObjectChange != null)
                this.ObjectChange(sender, e);
        }

        ////protected virtual void OnObjectChange(object sender, ObjectChangeEventArgs e)
        ////{
            
        ////}

        #endregion
    }
}
