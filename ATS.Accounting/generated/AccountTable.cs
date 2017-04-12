using System;
using System.Data;

namespace ATS.Accounting {
    
    
    public class AccountTable : System.Data.DataTable {

        internal System.Data.DataColumn accountIDColumn;

        internal System.Data.DataColumn accountKindColumn;

        internal System.Data.DataColumn accountNumberColumn;

        internal System.Data.DataColumn nameColumn;

        internal System.Data.DataColumn auxiliaryCurrencyIDColumn;

        internal System.Data.DataColumn auxiliaryCurrentBalanceColumn;

        internal System.Data.DataColumn auxiliaryJournalBalanceColumn;

        internal System.Data.DataColumn auxiliaryOpeningBalanceColumn;

        internal System.Data.DataColumn balanceTypeColumn;

        internal System.Data.DataColumn currentBalanceColumn;

        internal System.Data.DataColumn descriptionColumn;

        internal System.Data.DataColumn exchangeRateColumn;

        internal System.Data.DataColumn journalBalanceColumn;

        internal System.Data.DataColumn openingBalanceColumn;

        internal System.Data.DataColumn organizationIDColumn;

        public AccountTable()
        {
            this.TableName = "Account";

            // AccountID
            accountIDColumn = new System.Data.DataColumn();
            Columns.Add(accountIDColumn);
            accountIDColumn.ColumnName = "AccountID";
            accountIDColumn.DataType = typeof(System.Guid);
            accountIDColumn.AllowDBNull = true;

            // AccountKind
            accountKindColumn = new System.Data.DataColumn();
            Columns.Add(accountKindColumn);
            accountKindColumn.ColumnName = "AccountKind";
            accountKindColumn.DataType = typeof(short);
            accountKindColumn.AllowDBNull = true;

            // AccountNumber
            accountNumberColumn = new System.Data.DataColumn();
            Columns.Add(accountNumberColumn);
            accountNumberColumn.ColumnName = "AccountNumber";
            accountNumberColumn.DataType = typeof(string);
            accountNumberColumn.AllowDBNull = true;

            // Name
            nameColumn = new System.Data.DataColumn();
            Columns.Add(nameColumn);
            nameColumn.ColumnName = "Name";
            nameColumn.DataType = typeof(string);
            nameColumn.AllowDBNull = true;

            // AuxiliaryCurrencyID
            auxiliaryCurrencyIDColumn = new System.Data.DataColumn();
            Columns.Add(auxiliaryCurrencyIDColumn);
            auxiliaryCurrencyIDColumn.ColumnName = "AuxiliaryCurrencyID";
            auxiliaryCurrencyIDColumn.DataType = typeof(System.Guid);
            auxiliaryCurrencyIDColumn.AllowDBNull = true;

            // AuxiliaryCurrentBalance
            auxiliaryCurrentBalanceColumn = new System.Data.DataColumn();
            Columns.Add(auxiliaryCurrentBalanceColumn);
            auxiliaryCurrentBalanceColumn.ColumnName = "AuxiliaryCurrentBalance";
            auxiliaryCurrentBalanceColumn.DataType = typeof(decimal);
            auxiliaryCurrentBalanceColumn.AllowDBNull = true;

            // AuxiliaryJournalBalance
            auxiliaryJournalBalanceColumn = new System.Data.DataColumn();
            Columns.Add(auxiliaryJournalBalanceColumn);
            auxiliaryJournalBalanceColumn.ColumnName = "AuxiliaryJournalBalance";
            auxiliaryJournalBalanceColumn.DataType = typeof(decimal);
            auxiliaryJournalBalanceColumn.AllowDBNull = true;

            // AuxiliaryOpeningBalance
            auxiliaryOpeningBalanceColumn = new System.Data.DataColumn();
            Columns.Add(auxiliaryOpeningBalanceColumn);
            auxiliaryOpeningBalanceColumn.ColumnName = "AuxiliaryOpeningBalance";
            auxiliaryOpeningBalanceColumn.DataType = typeof(decimal);
            auxiliaryOpeningBalanceColumn.AllowDBNull = true;

            // BalanceType
            balanceTypeColumn = new System.Data.DataColumn();
            Columns.Add(balanceTypeColumn);
            balanceTypeColumn.ColumnName = "BalanceType";
            balanceTypeColumn.DataType = typeof(short);
            balanceTypeColumn.AllowDBNull = true;

            // CurrentBalance
            currentBalanceColumn = new System.Data.DataColumn();
            Columns.Add(currentBalanceColumn);
            currentBalanceColumn.ColumnName = "CurrentBalance";
            currentBalanceColumn.DataType = typeof(decimal);
            currentBalanceColumn.AllowDBNull = true;

            // Description
            descriptionColumn = new System.Data.DataColumn();
            Columns.Add(descriptionColumn);
            descriptionColumn.ColumnName = "Description";
            descriptionColumn.DataType = typeof(string);
            descriptionColumn.AllowDBNull = true;

            // ExchangeRate
            exchangeRateColumn = new System.Data.DataColumn();
            Columns.Add(exchangeRateColumn);
            exchangeRateColumn.ColumnName = "ExchangeRate";
            exchangeRateColumn.DataType = typeof(decimal);
            exchangeRateColumn.AllowDBNull = true;

            // JournalBalance
            journalBalanceColumn = new System.Data.DataColumn();
            Columns.Add(journalBalanceColumn);
            journalBalanceColumn.ColumnName = "JournalBalance";
            journalBalanceColumn.DataType = typeof(decimal);
            journalBalanceColumn.AllowDBNull = true;

            // OpeningBalance
            openingBalanceColumn = new System.Data.DataColumn();
            Columns.Add(openingBalanceColumn);
            openingBalanceColumn.ColumnName = "OpeningBalance";
            openingBalanceColumn.DataType = typeof(decimal);
            openingBalanceColumn.AllowDBNull = true;

            // OrganizationID
            organizationIDColumn = new System.Data.DataColumn();
            Columns.Add(organizationIDColumn);
            organizationIDColumn.ColumnName = "OrganizationID";
            organizationIDColumn.DataType = typeof(System.Guid);
            organizationIDColumn.AllowDBNull = true;
        }

        protected override System.Type GetRowType()
        {
            return typeof(AccountRow);
        }

        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
        {
            return new AccountRow(builder);
        }
    }
}
