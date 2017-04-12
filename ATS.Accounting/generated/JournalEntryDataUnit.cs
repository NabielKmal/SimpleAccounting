using System;
using System.Data;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting
{


    public class JournalEntryDataUnit : DataUnit
    {

        private JournalEntryTable journalEntry;

        private JournalEntryLineTable journalEntryLine;

        public JournalEntryDataUnit()
            : base((int)ObjectTypeCode.JournalEntry)
        {
            this.DataSetName = "JournalEntryDataUnit";

            // JournalEntry
            journalEntry = new JournalEntryTable();
            Tables.Add(journalEntry);

            // JournalEntryLine
            journalEntryLine = new JournalEntryLineTable();
            Tables.Add(journalEntryLine);
            Relations.Add("A_JournalEntry_JournalEntryLine", new System.Data.DataColumn[] {
                        journalEntry.journalEntryIDColumn}, new System.Data.DataColumn[] {
                        journalEntryLine.journalEntryIDColumn}, false);
        }

        public JournalEntryTable JournalEntry
        {
            get
            {
                return journalEntry;
            }
        }

        public JournalEntryLineTable JournalEntryLine
        {
            get
            {
                return journalEntryLine;
            }
        }
    }
}
