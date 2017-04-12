using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.AppService
{
    /// <summary>
    /// وحدة بيانات كائن اساسي
    /// </summary>
    public interface IDataUnit
    {
        ObjectIdentity RootObjectID { get; }
        DataUnitState State { get; }

    }

    public enum DataUnitState
    {
        NA,
        Added,
        Modified,
        Unchanged,
        Deleted,
    }

    
}
