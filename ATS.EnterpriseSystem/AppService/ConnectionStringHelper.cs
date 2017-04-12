using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.AppService
{
    public class ConnectionStringHelper
    {
        /// <summary>
        /// إرجاع نص الأتصال بقاعدة بيانات اكسس
        /// </summary>
        /// <param name="dbFileName">مسار قاعدة البيانات</param>
        /// <returns></returns>
        public static string GetJetConnectionString(string dbFileName)
        {
            return String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}", dbFileName);
        }
    }
}
