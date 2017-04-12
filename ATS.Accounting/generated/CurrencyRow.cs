using System;
using System.Data;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting {
    
    
    public class CurrencyRow : DataRowBase {
        
        public CurrencyRow(System.Data.DataRowBuilder builder) : 
                base(builder) {
        }
        
        public System.Guid CurrencyID {
            get {
                return NZ<System.Guid>(this["CurrencyID"]);
            }
            set {
                this["CurrencyID"] = value;
            }
        }
        
        public string Name {
            get {
                return NZ<string>(this["Name"]);
            }
            set {
                this["Name"] = value;
            }
        }
        
        public int DecimalPlaces {
            get {
                return NZ<int>(this["DecimalPlaces"]);
            }
            set {
                this["DecimalPlaces"] = value;
            }
        }
        
        public string Description {
            get {
                return NZ<string>(this["Description"]);
            }
            set {
                this["Description"] = value;
            }
        }
        
        public decimal ExchangeRate {
            get {
                return NZ<decimal>(this["ExchangeRate"]);
            }
            set {
                this["ExchangeRate"] = value;
            }
        }
        
        public System.Guid OrganizationID {
            get {
                return NZ<System.Guid>(this["OrganizationID"]);
            }
            set {
                this["OrganizationID"] = value;
            }
        }
        
        public string Symbol {
            get {
                return NZ<string>(this["Symbol"]);
            }
            set {
                this["Symbol"] = value;
            }
        }
    }
}
