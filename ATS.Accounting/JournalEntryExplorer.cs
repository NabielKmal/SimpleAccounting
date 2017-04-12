using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients;
using ATS.EnterpriseSystem.SmartClients.EntityExplorer;
using System.Data;

namespace ATS.Accounting
{
    public class JournalEntryExplorer : SimpleEntityExplorer
    {
        public JournalEntryExplorer()
            : base((int)ObjectTypeCode.JournalEntry, "JournalEntryID")
        { }

        protected override System.Data.DataSet DoLoadExplorerData()
        {
            DataSet ds = new DataSet();
            //Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "Select * from vw_JournalEntry Order By EntryNumber;");
            Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "Select * from vw_JournalEntry Order By EntryDate, EntryNumber;");
            return ds;
        }

    }
}
