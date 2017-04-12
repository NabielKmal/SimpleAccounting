using System;
using System.Data;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting {
    
    
    public class OrganizationRow : DataRowBase {
        
        public OrganizationRow(System.Data.DataRowBuilder builder) : 
                base(builder) {
        }
        
        public System.Guid OrganizationID {
            get {
                return NZ<System.Guid>(this["OrganizationID"]);
            }
            set {
                this["OrganizationID"] = value;
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
        
        public string AddressLine1 {
            get {
                return NZ<string>(this["AddressLine1"]);
            }
            set {
                this["AddressLine1"] = value;
            }
        }
        
        public string AddressLine2 {
            get {
                return NZ<string>(this["AddressLine2"]);
            }
            set {
                this["AddressLine2"] = value;
            }
        }
        
        public string AddressLine3 {
            get {
                return NZ<string>(this["AddressLine3"]);
            }
            set {
                this["AddressLine3"] = value;
            }
        }
        
        public string City {
            get {
                return NZ<string>(this["City"]);
            }
            set {
                this["City"] = value;
            }
        }
        
        public string County {
            get {
                return NZ<string>(this["County"]);
            }
            set {
                this["County"] = value;
            }
        }
        
        public System.DateTime CurrentDate {
            get {
                return NZ<System.DateTime>(this["CurrentDate"]);
            }
            set {
                this["CurrentDate"] = value;
            }
        }
        
        public long CurrentJournalEntryNumber {
            get {
                return NZ<long>(this["CurrentJournalEntryNumber"]);
            }
            set {
                this["CurrentJournalEntryNumber"] = value;
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
        
        public string Fax {
            get {
                return NZ<string>(this["Fax"]);
            }
            set {
                this["Fax"] = value;
            }
        }
        
        public System.DateTime FiscalYearEnd {
            get {
                return NZ<System.DateTime>(this["FiscalYearEnd"]);
            }
            set {
                this["FiscalYearEnd"] = value;
            }
        }
        
        public System.DateTime FiscalYearStart {
            get {
                return NZ<System.DateTime>(this["FiscalYearStart"]);
            }
            set {
                this["FiscalYearStart"] = value;
            }
        }
        
        public string PostalCode {
            get {
                return NZ<string>(this["PostalCode"]);
            }
            set {
                this["PostalCode"] = value;
            }
        }
        
        public string PostOfficeBox {
            get {
                return NZ<string>(this["PostOfficeBox"]);
            }
            set {
                this["PostOfficeBox"] = value;
            }
        }
        
        public string StateOrProvince {
            get {
                return NZ<string>(this["StateOrProvince"]);
            }
            set {
                this["StateOrProvince"] = value;
            }
        }
        
        public short SysState {
            get {
                return NZ<short>(this["SysState"]);
            }
            set {
                this["SysState"] = value;
            }
        }
        
        public string Telephone1 {
            get {
                return NZ<string>(this["Telephone1"]);
            }
            set {
                this["Telephone1"] = value;
            }
        }
        
        public string Telephone2 {
            get {
                return NZ<string>(this["Telephone2"]);
            }
            set {
                this["Telephone2"] = value;
            }
        }
        
        public string Telephone3 {
            get {
                return NZ<string>(this["Telephone3"]);
            }
            set {
                this["Telephone3"] = value;
            }
        }
    }
}
