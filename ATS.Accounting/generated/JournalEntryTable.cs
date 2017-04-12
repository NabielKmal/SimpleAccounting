using System;
using System.Data;

namespace ATS.Accounting {
    
    
    public class JournalEntryTable : System.Data.DataTable {
        
        internal System.Data.DataColumn journalEntryIDColumn;
        
        internal System.Data.DataColumn entryNumberColumn;
        
        internal System.Data.DataColumn entryDateColumn;
        
        internal System.Data.DataColumn sourceColumn;
        
        internal System.Data.DataColumn descriptionColumn;
        
        internal System.Data.DataColumn organizationIDColumn;
        
        internal System.Data.DataColumn totalCreditColumn;
        
        internal System.Data.DataColumn totalDebitColumn;
        
        public JournalEntryTable() {
            this.TableName = "JournalEntry";

            // JournalEntryID
            journalEntryIDColumn = new System.Data.DataColumn();
            Columns.Add(journalEntryIDColumn);
            journalEntryIDColumn.ColumnName = "JournalEntryID";
            journalEntryIDColumn.DataType = typeof(System.Guid);
            journalEntryIDColumn.AllowDBNull = true;

            // EntryNumber
            entryNumberColumn = new System.Data.DataColumn();
            Columns.Add(entryNumberColumn);
            entryNumberColumn.ColumnName = "EntryNumber";
            entryNumberColumn.DataType = typeof(int);
            entryNumberColumn.AllowDBNull = true;

            // EntryDate
            entryDateColumn = new System.Data.DataColumn();
            Columns.Add(entryDateColumn);
            entryDateColumn.ColumnName = "EntryDate";
            entryDateColumn.DataType = typeof(System.DateTime);
            entryDateColumn.AllowDBNull = true;

            // Source
            sourceColumn = new System.Data.DataColumn();
            Columns.Add(sourceColumn);
            sourceColumn.ColumnName = "Source";
            sourceColumn.DataType = typeof(string);
            sourceColumn.AllowDBNull = true;

            // Description
            descriptionColumn = new System.Data.DataColumn();
            Columns.Add(descriptionColumn);
            descriptionColumn.ColumnName = "Description";
            descriptionColumn.DataType = typeof(string);
            descriptionColumn.AllowDBNull = true;

            // OrganizationID
            organizationIDColumn = new System.Data.DataColumn();
            Columns.Add(organizationIDColumn);
            organizationIDColumn.ColumnName = "OrganizationID";
            organizationIDColumn.DataType = typeof(System.Guid);
            organizationIDColumn.AllowDBNull = true;

            // TotalCredit
            totalCreditColumn = new System.Data.DataColumn();
            Columns.Add(totalCreditColumn);
            totalCreditColumn.ColumnName = "TotalCredit";
            totalCreditColumn.DataType = typeof(decimal);
            totalCreditColumn.AllowDBNull = true;

            // TotalDebit
            totalDebitColumn = new System.Data.DataColumn();
            Columns.Add(totalDebitColumn);
            totalDebitColumn.ColumnName = "TotalDebit";
            totalDebitColumn.DataType = typeof(decimal);
            totalDebitColumn.AllowDBNull = true;
        }
        
        protected override System.Type GetRowType() {
            return typeof(JournalEntryRow);
        }
        
        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
            return new JournalEntryRow(builder);
        }
    }
}
