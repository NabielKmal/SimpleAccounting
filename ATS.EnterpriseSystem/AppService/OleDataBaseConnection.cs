using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.AppService
{
    public class OleDataBaseConnection : DataBaseConnection
    {
        public OleDataBaseConnection()
            : base(System.Data.OleDb.OleDbFactory.Instance)
        { }
    }
}
