using System;
using System.Data;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting {
    
    
    public class AccountRow : DataRowBase {

        public AccountRow(System.Data.DataRowBuilder builder) :
            base(builder)
        {
        }

        public System.Guid AccountID
        {
            get
            {
                return NZ<System.Guid>(this["AccountID"]);
            }
            set
            {
                this["AccountID"] = value;
            }
        }

        public short AccountKind
        {
            get
            {
                return NZ<short>(this["AccountKind"]);
            }
            set
            {
                this["AccountKind"] = value;
            }
        }

        public string AccountNumber
        {
            get
            {
                return NZ<string>(this["AccountNumber"]);
            }
            set
            {
                this["AccountNumber"] = value;
            }
        }

        public string Name
        {
            get
            {
                return NZ<string>(this["Name"]);
            }
            set
            {
                this["Name"] = value;
            }
        }

        public System.Guid AuxiliaryCurrencyID
        {
            get
            {
                return NZ<System.Guid>(this["AuxiliaryCurrencyID"]);
            }
            set
            {
                this["AuxiliaryCurrencyID"] = value;
            }
        }

        public decimal AuxiliaryCurrentBalance
        {
            get
            {
                return NZ<decimal>(this["AuxiliaryCurrentBalance"]);
            }
            set
            {
                this["AuxiliaryCurrentBalance"] = value;
            }
        }

        public decimal AuxiliaryJournalBalance
        {
            get
            {
                return NZ<decimal>(this["AuxiliaryJournalBalance"]);
            }
            set
            {
                this["AuxiliaryJournalBalance"] = value;
            }
        }

        public decimal AuxiliaryOpeningBalance
        {
            get
            {
                return NZ<decimal>(this["AuxiliaryOpeningBalance"]);
            }
            set
            {
                this["AuxiliaryOpeningBalance"] = value;
            }
        }

        public short BalanceType
        {
            get
            {
                return NZ<short>(this["BalanceType"]);
            }
            set
            {
                this["BalanceType"] = value;
            }
        }

        public decimal CurrentBalance
        {
            get
            {
                return NZ<decimal>(this["CurrentBalance"]);
            }
            set
            {
                this["CurrentBalance"] = value;
            }
        }

        public string Description
        {
            get
            {
                return NZ<string>(this["Description"]);
            }
            set
            {
                this["Description"] = value;
            }
        }

        public decimal ExchangeRate
        {
            get
            {
                return NZ<decimal>(this["ExchangeRate"]);
            }
            set
            {
                this["ExchangeRate"] = value;
            }
        }

        public decimal JournalBalance
        {
            get
            {
                return NZ<decimal>(this["JournalBalance"]);
            }
            set
            {
                this["JournalBalance"] = value;
            }
        }

        public decimal OpeningBalance
        {
            get
            {
                return NZ<decimal>(this["OpeningBalance"]);
            }
            set
            {
                this["OpeningBalance"] = value;
            }
        }

        public System.Guid OrganizationID
        {
            get
            {
                return NZ<System.Guid>(this["OrganizationID"]);
            }
            set
            {
                this["OrganizationID"] = value;
            }
        }
    }
}
