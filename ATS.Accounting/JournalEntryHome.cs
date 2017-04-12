using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting
{
    public class JournalEntryHome : EntityEditorHome
    {
        public JournalEntryHome()
            : base((int)ObjectTypeCode.JournalEntry)
        { }

        public override IDataUnit InitializeNewDataUnit()
        {
            JournalEntryDataUnit r = new JournalEntryDataUnit();
            JournalEntryRow dr = (JournalEntryRow)r.JournalEntry.NewRow();
            dr.JournalEntryID = Guid.NewGuid();
            dr.OrganizationID = WorkItem.Services.Get<RootEntityService>().GetRootID();
            dr.EntryDate = WorkItem.Services.Get<RootEntityService>().GetOrganizationCurrentDate();
            dr.TotalCredit = 0;
            dr.TotalDebit = 0;
            r.JournalEntry.Rows.Add(dr);
            return r;
        }

    }
}
