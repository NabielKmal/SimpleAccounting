using System;
using System.Data;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting {
    
    
    public class JournalEntryRow : DataRowBase {
        
        public JournalEntryRow(System.Data.DataRowBuilder builder) : 
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
        
        public int EntryNumber {
            get {
                return NZ<int>(this["EntryNumber"]);
            }
            set {
                this["EntryNumber"] = value;
            }
        }
        
        public System.DateTime EntryDate {
            get {
                return NZ<System.DateTime>(this["EntryDate"]);
            }
            set {
                this["EntryDate"] = value;
            }
        }
        
        public string Source {
            get {
                return NZ<string>(this["Source"]);
            }
            set {
                this["Source"] = value;
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
        
        public System.Guid OrganizationID {
            get {
                return NZ<System.Guid>(this["OrganizationID"]);
            }
            set {
                this["OrganizationID"] = value;
            }
        }
        
        public decimal TotalCredit {
            get {
                return NZ<decimal>(this["TotalCredit"]);
            }
            set {
                this["TotalCredit"] = value;
            }
        }
        
        public decimal TotalDebit {
            get {
                return NZ<decimal>(this["TotalDebit"]);
            }
            set {
                this["TotalDebit"] = value;
            }
        }
    }
}
