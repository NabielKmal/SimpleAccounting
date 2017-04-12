using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.EnterpriseSystem
{

    /// <summary>
    /// Ì„À· „⁄—› ﬂ«∆‰
    /// </summary>
    [Serializable]
    public class ObjectIdentity
    {

        public readonly static ObjectIdentity Empty = new ObjectIdentity();

        private int objectTypeCode;
        private Guid objectId;



        private ObjectIdentity()
        { }

        public ObjectIdentity(int ObjectTypeCode, Guid ObjectId)
        {
            this.objectTypeCode = ObjectTypeCode;
            this.objectId = ObjectId;
        }

        public int ObjectTypeCode
        {
            get { return objectTypeCode; }
            //set { objectTypeCode = value; }
        }

        public Guid ObjectId
        {
            get { return objectId; }
            //set { objectId = value; }
        }

        public override int GetHashCode()
        {
            return objectId.GetHashCode() ^ objectTypeCode;
        }

        public override bool Equals(object obj)
        {
            ObjectIdentity other = obj as ObjectIdentity;
            if (other != null && other.ObjectId == ObjectId && other.ObjectTypeCode == ObjectTypeCode)
                return true;

            return base.Equals(obj);
        }
    }
}
