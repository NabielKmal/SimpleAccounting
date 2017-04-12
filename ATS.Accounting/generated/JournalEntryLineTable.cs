using System;
using System.Data;

namespace ATS.Accounting {
    
    
    public class JournalEntryLineTable : System.Data.DataTable {
        
        internal System.Data.DataColumn journalEntryIDColumn;
        
        internal System.Data.DataColumn journalEntryLineIDColumn;
        
        internal System.Data.DataColumn accountIDColumn;
        
        internal System.Data.DataColumn amountColumn;
        
        internal System.Data.DataColumn amountSideColumn;
        
        internal System.Data.DataColumn auxiliaryAmountColumn;
        
        internal System.Data.DataColumn auxiliaryCurrencyIDColumn;
        
        internal System.Data.DataColumn creditColumn;
        
        internal System.Data.DataColumn debitColumn;
        
        internal System.Data.DataColumn descriptionColumn;
        
        internal System.Data.DataColumn exchangeRateColumn;
        
        internal System.Data.DataColumn lineNumberColumn;
        
        internal System.Data.DataColumn postedAmountColumn;
        
        internal System.Data.DataColumn postedAuxiliaryAmountColumn;
        
        public JournalEntryLineTable() {
            this.TableName = "JournalEntryLine";

            // JournalEntryID
            journalEntryIDColumn = new System.Data.DataColumn();
            Columns.Add(journalEntryIDColumn);
            journalEntryIDColumn.ColumnName = "JournalEntryID";
            journalEntryIDColumn.DataType = typeof(System.Guid);
            journalEntryIDColumn.AllowDBNull = true;

            // JournalEntryLineID
            journalEntryLineIDColumn = new System.Data.DataColumn();
            Columns.Add(journalEntryLineIDColumn);
            journalEntryLineIDColumn.ColumnName = "JournalEntryLineID";
            journalEntryLineIDColumn.DataType = typeof(System.Guid);
            journalEntryLineIDColumn.AllowDBNull = true;

            // AccountID
            accountIDColumn = new System.Data.DataColumn();
            Columns.Add(accountIDColumn);
            accountIDColumn.ColumnName = "AccountID";
            accountIDColumn.DataType = typeof(System.Guid);
            accountIDColumn.AllowDBNull = true;

            // Amount
            amountColumn = new System.Data.DataColumn();
            Columns.Add(amountColumn);
            amountColumn.ColumnName = "Amount";
            amountColumn.DataType = typeof(decimal);
            amountColumn.AllowDBNull = true;

            // AmountSide
            amountSideColumn = new System.Data.DataColumn();
            Columns.Add(amountSideColumn);
            amountSideColumn.ColumnName = "AmountSide";
            amountSideColumn.DataType = typeof(short);
            amountSideColumn.AllowDBNull = true;

            // AuxiliaryAmount
            auxiliaryAmountColumn = new System.Data.DataColumn();
            Columns.Add(auxiliaryAmountColumn);
            auxiliaryAmountColumn.ColumnName = "AuxiliaryAmount";
            auxiliaryAmountColumn.DataType = typeof(decimal);
            auxiliaryAmountColumn.AllowDBNull = true;

            // AuxiliaryCurrencyID
            auxiliaryCurrencyIDColumn = new System.Data.DataColumn();
            Columns.Add(auxiliaryCurrencyIDColumn);
            auxiliaryCurrencyIDColumn.ColumnName = "AuxiliaryCurrencyID";
            auxiliaryCurrencyIDColumn.DataType = typeof(System.Guid);
            auxiliaryCurrencyIDColumn.AllowDBNull = true;

            // Credit
            creditColumn = new System.Data.DataColumn();
            Columns.Add(creditColumn);
            creditColumn.ColumnName = "Credit";
            creditColumn.DataType = typeof(decimal);
            creditColumn.AllowDBNull = true;

            // Debit
            debitColumn = new System.Data.DataColumn();
            Columns.Add(debitColumn);
            debitColumn.ColumnName = "Debit";
            debitColumn.DataType = typeof(decimal);
            debitColumn.AllowDBNull = true;

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

            // LineNumber
            lineNumberColumn = new System.Data.DataColumn();
            Columns.Add(lineNumberColumn);
            lineNumberColumn.ColumnName = "LineNumber";
            lineNumberColumn.DataType = typeof(int);
            lineNumberColumn.AllowDBNull = true;

            // PostedAmount
            postedAmountColumn = new System.Data.DataColumn();
            Columns.Add(postedAmountColumn);
            postedAmountColumn.ColumnName = "PostedAmount";
            postedAmountColumn.DataType = typeof(decimal);
            postedAmountColumn.AllowDBNull = true;

            // PostedAuxiliaryAmount
            postedAuxiliaryAmountColumn = new System.Data.DataColumn();
            Columns.Add(postedAuxiliaryAmountColumn);
            postedAuxiliaryAmountColumn.ColumnName = "PostedAuxiliaryAmount";
            postedAuxiliaryAmountColumn.DataType = typeof(decimal);
            postedAuxiliaryAmountColumn.AllowDBNull = true;
        }
        
        protected override System.Type GetRowType() {
            return typeof(JournalEntryLineRow);
        }
        
        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
            return new JournalEntryLineRow(builder);
        }
    }
}
