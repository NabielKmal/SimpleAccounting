using System;
using System.Data;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting {


    public class CurrencyDataUnit : DataUnit
    {
        
        private CurrencyTable currency;
        
        public CurrencyDataUnit() 
            :base((int)ObjectTypeCode.Currency)
        {
            this.DataSetName = "CurrencyDataUnit";

            // Currency
            currency = new CurrencyTable();
            Tables.Add(currency);
        }
        
        public CurrencyTable Currency {
            get {
                return currency;
            }
        }
    }
}
