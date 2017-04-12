using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor
{
    public interface IEntityEditorHome
    {
        int TypeCode { get; }

        /// <summary>
        /// فتح نموذج كائن جديد
        /// </summary>
        void NewObject();

        /// <summary>
        /// فتح نموذج كائن جديد
        /// </summary>
        /// <param name="source"></param>
        void NewObjectFromExist(ObjectIdentity source);

        /// <summary>
        /// فتح نموذج كائن معين
        /// </summary>
        /// <param name="identity"></param>
        void OpenObject(Guid identity);

    }


    public interface IEntityEditorHomeManager
    {
        IEntityEditorHome this[int typeCode] { get; }
    }

}
