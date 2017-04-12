using System;
using System.Data;

namespace ATS.Accounting {
    
    
    public class CurrencyTable : System.Data.DataTable {
        
        internal System.Data.DataColumn currencyIDColumn;
        
        internal System.Data.DataColumn nameColumn;
        
        internal System.Data.DataColumn decimalPlacesColumn;
        
        internal System.Data.DataColumn descriptionColumn;
        
        internal System.Data.DataColumn exchangeRateColumn;
        
        internal System.Data.DataColumn organizationIDColumn;
        
        internal System.Data.DataColumn symbolColumn;
        
        public CurrencyTable() {
            this.TableName = "Currency";

            // CurrencyID
            currencyIDColumn = new System.Data.DataColumn();
            Columns.Add(currencyIDColumn);
            currencyIDColumn.ColumnName = "CurrencyID";
            currencyIDColumn.DataType = typeof(System.Guid);
            currencyIDColumn.AllowDBNull = true;

            // Name
            nameColumn = new System.Data.DataColumn();
            Columns.Add(nameColumn);
            nameColumn.ColumnName = "Name";
            nameColumn.DataType = typeof(string);
            nameColumn.AllowDBNull = true;

            // DecimalPlaces
            decimalPlacesColumn = new System.Data.DataColumn();
            Columns.Add(decimalPlacesColumn);
            decimalPlacesColumn.ColumnName = "DecimalPlaces";
            decimalPlacesColumn.DataType = typeof(int);
            decimalPlacesColumn.AllowDBNull = true;

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

            // OrganizationID
            organizationIDColumn = new System.Data.DataColumn();
            Columns.Add(organizationIDColumn);
            organizationIDColumn.ColumnName = "OrganizationID";
            organizationIDColumn.DataType = typeof(System.Guid);
            organizationIDColumn.AllowDBNull = true;

            // Symbol
            symbolColumn = new System.Data.DataColumn();
            Columns.Add(symbolColumn);
            symbolColumn.ColumnName = "Symbol";
            symbolColumn.DataType = typeof(string);
            symbolColumn.AllowDBNull = true;
        }
        
        protected override System.Type GetRowType() {
            return typeof(CurrencyRow);
        }
        
        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
            return new CurrencyRow(builder);
        }
    }
}
