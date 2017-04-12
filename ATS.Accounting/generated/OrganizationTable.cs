using System;
using System.Data;

namespace ATS.Accounting {
    
    
    public class OrganizationTable : System.Data.DataTable {
        
        internal System.Data.DataColumn organizationIDColumn;
        
        internal System.Data.DataColumn nameColumn;
        
        internal System.Data.DataColumn addressLine1Column;
        
        internal System.Data.DataColumn addressLine2Column;
        
        internal System.Data.DataColumn addressLine3Column;
        
        internal System.Data.DataColumn cityColumn;
        
        internal System.Data.DataColumn countyColumn;
        
        internal System.Data.DataColumn currentDateColumn;
        
        internal System.Data.DataColumn currentJournalEntryNumberColumn;
        
        internal System.Data.DataColumn descriptionColumn;
        
        internal System.Data.DataColumn faxColumn;
        
        internal System.Data.DataColumn fiscalYearEndColumn;
        
        internal System.Data.DataColumn fiscalYearStartColumn;
        
        internal System.Data.DataColumn postalCodeColumn;
        
        internal System.Data.DataColumn postOfficeBoxColumn;
        
        internal System.Data.DataColumn stateOrProvinceColumn;
        
        internal System.Data.DataColumn sysStateColumn;
        
        internal System.Data.DataColumn telephone1Column;
        
        internal System.Data.DataColumn telephone2Column;
        
        internal System.Data.DataColumn telephone3Column;
        
        public OrganizationTable() {
            this.TableName = "Organization";

            // OrganizationID
            organizationIDColumn = new System.Data.DataColumn();
            Columns.Add(organizationIDColumn);
            organizationIDColumn.ColumnName = "OrganizationID";
            organizationIDColumn.DataType = typeof(System.Guid);
            organizationIDColumn.AllowDBNull = true;

            // Name
            nameColumn = new System.Data.DataColumn();
            Columns.Add(nameColumn);
            nameColumn.ColumnName = "Name";
            nameColumn.DataType = typeof(string);
            nameColumn.AllowDBNull = true;

            // AddressLine1
            addressLine1Column = new System.Data.DataColumn();
            Columns.Add(addressLine1Column);
            addressLine1Column.ColumnName = "AddressLine1";
            addressLine1Column.DataType = typeof(string);
            addressLine1Column.AllowDBNull = true;

            // AddressLine2
            addressLine2Column = new System.Data.DataColumn();
            Columns.Add(addressLine2Column);
            addressLine2Column.ColumnName = "AddressLine2";
            addressLine2Column.DataType = typeof(string);
            addressLine2Column.AllowDBNull = true;

            // AddressLine3
            addressLine3Column = new System.Data.DataColumn();
            Columns.Add(addressLine3Column);
            addressLine3Column.ColumnName = "AddressLine3";
            addressLine3Column.DataType = typeof(string);
            addressLine3Column.AllowDBNull = true;

            // City
            cityColumn = new System.Data.DataColumn();
            Columns.Add(cityColumn);
            cityColumn.ColumnName = "City";
            cityColumn.DataType = typeof(string);
            cityColumn.AllowDBNull = true;

            // County
            countyColumn = new System.Data.DataColumn();
            Columns.Add(countyColumn);
            countyColumn.ColumnName = "County";
            countyColumn.DataType = typeof(string);
            countyColumn.AllowDBNull = true;

            // CurrentDate
            currentDateColumn = new System.Data.DataColumn();
            Columns.Add(currentDateColumn);
            currentDateColumn.ColumnName = "CurrentDate";
            currentDateColumn.DataType = typeof(System.DateTime);
            currentDateColumn.AllowDBNull = true;

            // CurrentJournalEntryNumber
            currentJournalEntryNumberColumn = new System.Data.DataColumn();
            Columns.Add(currentJournalEntryNumberColumn);
            currentJournalEntryNumberColumn.ColumnName = "CurrentJournalEntryNumber";
            currentJournalEntryNumberColumn.DataType = typeof(long);
            currentJournalEntryNumberColumn.AllowDBNull = true;

            // Description
            descriptionColumn = new System.Data.DataColumn();
            Columns.Add(descriptionColumn);
            descriptionColumn.ColumnName = "Description";
            descriptionColumn.DataType = typeof(string);
            descriptionColumn.AllowDBNull = true;

            // Fax
            faxColumn = new System.Data.DataColumn();
            Columns.Add(faxColumn);
            faxColumn.ColumnName = "Fax";
            faxColumn.DataType = typeof(string);
            faxColumn.AllowDBNull = true;

            // FiscalYearEnd
            fiscalYearEndColumn = new System.Data.DataColumn();
            Columns.Add(fiscalYearEndColumn);
            fiscalYearEndColumn.ColumnName = "FiscalYearEnd";
            fiscalYearEndColumn.DataType = typeof(System.DateTime);
            fiscalYearEndColumn.AllowDBNull = true;

            // FiscalYearStart
            fiscalYearStartColumn = new System.Data.DataColumn();
            Columns.Add(fiscalYearStartColumn);
            fiscalYearStartColumn.ColumnName = "FiscalYearStart";
            fiscalYearStartColumn.DataType = typeof(System.DateTime);
            fiscalYearStartColumn.AllowDBNull = true;

            // PostalCode
            postalCodeColumn = new System.Data.DataColumn();
            Columns.Add(postalCodeColumn);
            postalCodeColumn.ColumnName = "PostalCode";
            postalCodeColumn.DataType = typeof(string);
            postalCodeColumn.AllowDBNull = true;

            // PostOfficeBox
            postOfficeBoxColumn = new System.Data.DataColumn();
            Columns.Add(postOfficeBoxColumn);
            postOfficeBoxColumn.ColumnName = "PostOfficeBox";
            postOfficeBoxColumn.DataType = typeof(string);
            postOfficeBoxColumn.AllowDBNull = true;

            // StateOrProvince
            stateOrProvinceColumn = new System.Data.DataColumn();
            Columns.Add(stateOrProvinceColumn);
            stateOrProvinceColumn.ColumnName = "StateOrProvince";
            stateOrProvinceColumn.DataType = typeof(string);
            stateOrProvinceColumn.AllowDBNull = true;

            // SysState
            sysStateColumn = new System.Data.DataColumn();
            Columns.Add(sysStateColumn);
            sysStateColumn.ColumnName = "SysState";
            sysStateColumn.DataType = typeof(short);
            sysStateColumn.AllowDBNull = true;

            // Telephone1
            telephone1Column = new System.Data.DataColumn();
            Columns.Add(telephone1Column);
            telephone1Column.ColumnName = "Telephone1";
            telephone1Column.DataType = typeof(string);
            telephone1Column.AllowDBNull = true;

            // Telephone2
            telephone2Column = new System.Data.DataColumn();
            Columns.Add(telephone2Column);
            telephone2Column.ColumnName = "Telephone2";
            telephone2Column.DataType = typeof(string);
            telephone2Column.AllowDBNull = true;

            // Telephone3
            telephone3Column = new System.Data.DataColumn();
            Columns.Add(telephone3Column);
            telephone3Column.ColumnName = "Telephone3";
            telephone3Column.DataType = typeof(string);
            telephone3Column.AllowDBNull = true;
        }
        
        protected override System.Type GetRowType() {
            return typeof(OrganizationRow);
        }
        
        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
            return new OrganizationRow(builder);
        }
    }
}
