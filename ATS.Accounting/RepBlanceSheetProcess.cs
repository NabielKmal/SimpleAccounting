using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.Reports;
using CrystalDecisions.CrystalReports.Engine;
using ATS.EnterpriseSystem.SmartClients;
using System.Data;

namespace ATS.Accounting
{
    class RepBlanceSheetProcess : ReportProcess
    {
        protected ReportDocument LoadReportDocumentCore()
        {
            ReportDocument rep = new RepBlanceSheet();
            DataSet ds = new DataSet();
            Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "Account", "Select * from [vw_Account] Where [AccountKind] in(1,2,3) Order By [AccountNumber] ;");
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

        //ToDo:حذف هذا الكود
        private bool firstRun = true;
        protected override void RunCore(object args)
        {
            if (firstRun)
            {
                firstRun = false;
                if (!Services.Get<RootEntityService>().IsAccoutingEquationCorrect())
                {
                    this.Dispose();
                    return;
                }

                LoadReportDocument();
            }
            Activate();
        }

    }
}
