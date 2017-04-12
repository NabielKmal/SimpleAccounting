using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients;
using ATS.EnterpriseSystem.AppService;
using System.Data.OleDb;
using System.Data;
using System.Reflection;

namespace ATS.Accounting
{
    class SystemInfoService : ISystemInfoService
    {
        /// <summary>
        /// معرف المعلومة وهو ثابت لا يتغير من تطبيق لآخر
        /// </summary>
        public readonly Guid SystemInfoID = new Guid("{6B1C66B2-1623-4BCF-A79C-77D9B5E2804E}");
        /// <summary>
        /// معرف التطبيق الحالي
        /// </summary>
        public readonly Guid ApplicationID = new Guid("{391A26DC-0C8F-4C7D-AB48-17727D670C6C}");


        #region ISystemInfoService Members

        public bool IsValidDBDocument(IDataBaseConnection dataBaseConnection)
        {

            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM [SystemInfo] WHERE [SystemInfoID]=?";
                cmd.Parameters.AddWithValue("SystemInfoID", SystemInfoID);
                DataTable tbl = dataBaseConnection.Fill(cmd);
                if (tbl.Rows.Count == 0) return false;
                if (object.Equals(tbl.Rows[0]["ApplicationID"], ApplicationID) && object.Equals(tbl.Rows[0]["Versionf1"], System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Major))
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        #endregion


    }
}
