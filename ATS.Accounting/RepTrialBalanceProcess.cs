using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.Reports;
using CrystalDecisions.CrystalReports.Engine;
using ATS.EnterpriseSystem.SmartClients;
using System.Data;
using System.Data.OleDb;

namespace ATS.Accounting
{
    class RepTrialBalanceProcess : ReportProcess
    {
        protected ReportDocument LoadReportDocumentCore()
        {
            ReportDocument rep = new RepTrialBalance();
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select * from [vw_Account] WHERE AccountID<>? Order By [AccountNumber] ;";
            cmd.Parameters.AddWithValue("ACCOUNTID", Constants.SystemConstants.NetAccountID);

            Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "Account", cmd);
            rep.SetDataSource(ds);
            return rep;
        }

    }
}
