using System;
using System.Data;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting {
    
    
    public class JournalEntryLineRow : DataRowBase {
        
        public JournalEntryLineRow(System.Data.DataRowBuilder builder) : 
                base(builder) {
        }
        
        public System.Guid JournalEntryID {
            get {
                return NZ<System.Guid>(this["JournalEntryID"]);
            }
            set {
                this["JournalEntryID"] = value;
            }
        }
        
        public System.Guid JournalEntryLineID {
            get {
                return NZ<System.Guid>(this["JournalEntryLineID"]);
            }
            set {
                this["JournalEntryLineID"] = value;
            }
        }
        
        public System.Guid AccountID {
            get {
                return NZ<System.Guid>(this["AccountID"]);
            }
            set {
                this["AccountID"] = value;
            }
        }
        
        public decimal Amount {
            get {
                return NZ<decimal>(this["Amount"]);
            }
            set {
                this["Amount"] = value;
            }
        }
        
        public short AmountSide {
            get {
                return NZ<short>(this["AmountSide"]);
            }
            set {
                this["AmountSide"] = value;
            }
        }
        
        public decimal AuxiliaryAmount {
            get {
                return NZ<decimal>(this["AuxiliaryAmount"]);
            }
            set {
                this["AuxiliaryAmount"] = value;
            }
        }
        
        public System.Guid AuxiliaryCurrencyID {
            get {
                return NZ<System.Guid>(this["AuxiliaryCurrencyID"]);
            }
            set {
                this["AuxiliaryCurrencyID"] = value;
            }
        }
        
        public decimal Credit {
            get {
                return NZ<decimal>(this["Credit"]);
            }
            set {
                this["Credit"] = value;
            }
        }
        
        public decimal Debit {
            get {
                return NZ<decimal>(this["Debit"]);
            }
            set {
                this["Debit"] = value;
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
        
        public int LineNumber {
            get {
                return NZ<int>(this["LineNumber"]);
            }
            set {
                this["LineNumber"] = value;
            }
        }
        
        public decimal PostedAmount {
            get {
                return NZ<decimal>(this["PostedAmount"]);
            }
            set {
                this["PostedAmount"] = value;
            }
        }
        
        public decimal PostedAuxiliaryAmount {
            get {
                return NZ<decimal>(this["PostedAuxiliaryAmount"]);
            }
            set {
                this["PostedAuxiliaryAmount"] = value;
            }
        }
    }
}
