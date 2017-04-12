using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.AppService
{
    public interface IDACContext : IServiceProvider
    {
        IDataBaseConnection DataBaseConnection { get; }
    }

    public interface IDACElement : IDisposable
    {
        IDACContext Context { get; set; }


    }
}
