using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.Reports;
using CrystalDecisions.CrystalReports.Engine;
using ATS.EnterpriseSystem.SmartClients;
using System.Data;

namespace ATS.Accounting
{
    class RepIncomeStatementProcess : ReportProcess
    {
        protected ReportDocument LoadReportDocumentCore()
        {
            ReportDocument rep = new RepIncomeStatement();
            DataSet ds = new DataSet();
            Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "Account", "Select * from [vw_Account] Where [AccountKind] in(4,5) Order By [AccountNumber] ;");
            foreach (DataRow x in ds.Tables[0].Rows)
            {
                if (object.Equals(Constants.SystemConstants.NetAccountID, x["AccountID"]))
                {
                    x["currentbalance"] = Services.Get<RootEntityService>().GetGeneralNet();
                    break;
                }
            }
            rep.SetDataSource(ds);
            return rep;
        }
    }
}
