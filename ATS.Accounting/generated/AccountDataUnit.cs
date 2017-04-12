using System;
using System.Data;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting {


    public class AccountDataUnit : DataUnit
    {
        
        private AccountTable account;
        
        public AccountDataUnit()
            :base((int)ObjectTypeCode.Account)
        {
            this.DataSetName = "AccountDataUnit";

            // Account
            account = new AccountTable();
            Tables.Add(account);
        }
        
        public AccountTable Account {
            get {
                return account;
            }
        }
    }
}
