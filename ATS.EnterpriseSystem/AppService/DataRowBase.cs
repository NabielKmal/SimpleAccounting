using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.EnterpriseSystem.AppService
{
    public class DataRowBase : System.Data.DataRow
    {

        protected T NZ<T>(object e)
        {
            if (e != DBNull.Value)
                return (T)e;
            return default(T);
        }

        public DataRowBase(System.Data.DataRowBuilder builder)
            :
                base(builder)
        {
        }
    }
}
