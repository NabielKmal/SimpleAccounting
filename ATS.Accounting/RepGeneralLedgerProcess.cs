using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.Reports;
using ATS.EnterpriseSystem.SmartClients;
using System.Data;

namespace ATS.Accounting
{
    public class RepGeneralLedgerProcess : ReportProcess
    {
        protected CrystalDecisions.CrystalReports.Engine.ReportDocument LoadReportDocumentCore()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rep = null;
            rep = new RepGeneralLedger();
            DataSet ds = new DataSet();
            Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "JournalEntryLine", "Select * from vw_Account_Journals Order By AccountIDAccountNumber, JournalEntryIDEntryDate, JournalEntryIDEntryNumber;");

            rep.SetDataSource(ds);
            return rep;
        }
    }
}
