using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.Reports;
using ATS.EnterpriseSystem.SmartClients;
using System.Data;


namespace ATS.Accounting
{
    class RepGeneralJournalProcess : ReportProcess
    {
        protected CrystalDecisions.CrystalReports.Engine.ReportDocument LoadReportDocumentCore()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rep = null;
            rep = new RepGeneralJournal();
            DataSet ds = new DataSet();
            //Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "JournalEntryLine", "Select * from vw_Account_Journals Order By JournalEntryIDEntryDate, JournalEntryIDEntryNumber;");
            Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "JournalEntryLine", "Select * from vw_Account_Journals Order By JournalEntryIDEntryDate, JournalEntryIDEntryNumber, [AmountSide], [LineNumber];");

            rep.SetDataSource(ds);
            return rep;
        }
    }
}
