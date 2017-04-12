using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.AppService;
using System.Data.OleDb;
using ATS.EnterpriseSystem;
using System.Data;
using System.Collections;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting
{
    public class AccountDataAdapter : DataUnitAdapter
    {
        public AccountDataAdapter()
            : base((int)Accounting.ObjectTypeCode.Account)
        { }

        RootEntityService RootEntityService
        {
            get
            {
                return new RootEntityService(this.DataBaseConnection);
            }
        }

        protected override bool ExistCore(Guid id)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select Count(*) from Account Where AccountID=?;";
            cmd.Parameters.Add(new OleDbParameter("AccountID", id));
            object c = this.DataBaseConnection.ExecuteScalar(cmd);

            return DataUtil.NZ<int>(c) == 1;
            //return ||
        }

        protected override DataUnit LoadCore(Guid id)
        {
            AccountDataUnit r = new AccountDataUnit();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select * from vw_Account Where AccountID=?;";
            cmd.Parameters.Add(new OleDbParameter("AccountID", id));
            this.DataBaseConnection.Fill(r, "Account", cmd);
            if (object.Equals(id, Constants.SystemConstants.NetAccountID))
            {
                r.RootObject["CurrentBalance"] = this.RootEntityService.GetGeneralNet();
                r.AcceptChanges();
            }
            return r;
        }



        protected override void DeleteCore(Guid id)
        {
            OleDbCommand cmd = GetDeleteCommand();
            cmd.Parameters[0].Value = id;
            this.DataBaseConnection.ExecuteNonQuery(cmd);
        }

        protected override bool MayDeleteCore(Guid id)
        {
            if (object.Equals(Constants.SystemConstants.NetAccountID, id))
            {
                return false;
            }
            if (HasJournalEntryLines(id))
                return false;

            return true;
            throw new NotImplementedException();
        }

        public bool HasJournalEntryLines(Guid id)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select Count(*) from JournalEntryLine Where AccountID=?";
            cmd.Parameters.Add(new OleDbParameter("AccountID", id));
            return DataUtil.NZ<int>(DataBaseConnection.ExecuteScalar(cmd)) > 0;
        }


        #region save

        OleDbCommand GetInsertCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "INSERT INTO `Account`(`AccountID`,`AccountKind`,`AccountNumber`,`BalanceType`,`De" +
                "scription`,`Name`,`OpeningBalance`,`OrganizationID`,`AuxiliaryCurrencyID`,`Auxil" +
                "iaryOpeningBalance`,`ExchangeRate`) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AccountID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "AccountID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AccountKind", System.Data.OleDb.OleDbType.TinyInt, -1, System.Data.ParameterDirection.Input, 0, 0, "AccountKind", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AccountNumber", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, 0, 0, "AccountNumber", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("BalanceType", System.Data.OleDb.OleDbType.TinyInt, -1, System.Data.ParameterDirection.Input, 0, 0, "BalanceType", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, -1, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("OpeningBalance", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "OpeningBalance", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("OrganizationID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "OrganizationID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AuxiliaryCurrencyID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "AuxiliaryCurrencyID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AuxiliaryOpeningBalance", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "AuxiliaryOpeningBalance", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "ExchangeRate", System.Data.DataRowVersion.Current, false, null));


            return cmd;
        }

        OleDbCommand GetUpdateCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "UPDATE `Account` SET `AccountKind`=?,`AccountNumber`=?,`BalanceType`=?,`Descripti" +
                "on`=?,`Name`=?,`OpeningBalance`=?,`OrganizationID`=?,`AuxiliaryCurrencyID`=?,`Au" +
                "xiliaryOpeningBalance`=?,`ExchangeRate`=? WHERE `AccountID`=?";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AccountKind", System.Data.OleDb.OleDbType.TinyInt, -1, System.Data.ParameterDirection.Input, 0, 0, "AccountKind", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AccountNumber", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, 0, 0, "AccountNumber", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("BalanceType", System.Data.OleDb.OleDbType.TinyInt, -1, System.Data.ParameterDirection.Input, 0, 0, "BalanceType", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, -1, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("OpeningBalance", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "OpeningBalance", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("OrganizationID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "OrganizationID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AuxiliaryCurrencyID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "AuxiliaryCurrencyID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AuxiliaryOpeningBalance", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "AuxiliaryOpeningBalance", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "ExchangeRate", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Orginal_AccountID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "AccountID", System.Data.DataRowVersion.Original, false, null));

            return cmd;
        }

        OleDbCommand GetDeleteCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "DELETE FROM `Account` WHERE `AccountID`=?";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Orginal_AccountID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "AccountID", System.Data.DataRowVersion.Original, false, null));
            return cmd;
        }


        protected override void SaveCore(DataUnit data)
        {
            PrepareAccount(data);
            this.DataBaseConnection.UpdateDataSet(data, "Account", GetInsertCommand(), GetUpdateCommand(), null);
        }

        void PrepareAccount(DataUnit data)
        {
            DataTableHelper.DoDataTableAction(data.Tables["Account"], new DataTableHelper.Action(PrepareAccountRow));
        }

        void PrepareAccountRow(DataRow self)
        {
            switch (self.RowState)
            {
                case DataRowState.Added:
                    self["BalanceType"] = (short)GetAccountBalanceType(self);
                    self["OpeningBalance"] = GetOpeningBalance(self);
                    break;
                case DataRowState.Modified:
                case DataRowState.Unchanged:
                    self["BalanceType"] = (short)GetAccountBalanceType(self);
                    self["OpeningBalance"] = GetOpeningBalance(self);
                    break;
            }
        }

        private static decimal GetOpeningBalance(DataRow self)
        {
            return DataUtil.NZ<decimal>(self["ExchangeRate"]) * DataUtil.NZ<decimal>(self["AuxiliaryOpeningBalance"]);
        }

        DebitCredit GetAccountBalanceType(DataRow self)
        {
            AccountKind kind = (AccountKind)Enum.Parse(typeof(AccountKind), self["AccountKind"].ToString());
            return GetAccountBalanceType(kind);
        }

        private static DebitCredit GetAccountBalanceType(AccountKind kind)
        {
            switch (kind)
            {
                case AccountKind.Asset:
                case AccountKind.Expens:
                    return DebitCredit.Debit;

                case AccountKind.Equity:
                case AccountKind.Liability:
                case AccountKind.Revenue:
                    return DebitCredit.Credit;
            }
            throw new System.Exception("خطأ في تحديد طبيعة الحساب");
        }

        #endregion

        #region Validation
        protected override void ValidateCore(DataUnit data, ValidationErrorCollection errors)
        {
            ValidationContext context = new ValidationContext(this.DataBaseConnection, errors);
            DoValidateTable(data.Tables["Account"], Validate_Account, context);
        }



        public void Validate_Account(DataRow self, ValidationContext context)
        {
            context.CheckNull(self["AccountID"], "معرف الحساب مطلوب", self, "AccountID");
            context.CheckNull(self["AccountKind"], "نوع الحساب مطلوب", self, "AccountKind");
            context.CheckForEmptyString(self["AccountNumber"], "رقم الحساب مطلوب", self, "AccountNumber");
            context.CheckStringMaxLength(4, self["AccountNumber"], "رقم الحساب يتكون من اكثر من اربعة ارقام", self, "AccountNumber");
            context.CheckForEmptyString(self["Name"], "اسم الحساب مطلوب", self, "Name");
            context.CheckStringMaxLength(60, self["Name"], "الأسم طويل", self, "Name");
            context.CheckNull(self["OrganizationID"], "خطأ", self, "OrganizationID");

            context.CheckNull(self["AuxiliaryCurrencyID"], "مطلوب", self, "AuxiliaryCurrencyID");
            context.CheckNull(self["ExchangeRate"], "مطلوب", self, "ExchangeRate");

            context.CheckUnique("Account", "AccountID", "AccountNumber", (Guid)self["AccountID"], self["AccountNumber"], "يوجد حساب آخر له نفس الرقم", self, "AccountNumber");
            context.Assert(Account_accountNumberMustConformWithKind(self), "رقم الحساب لا يتلائم ونوع الحساب", self, "AccountNumber");

            context.Assert(Account_ExchangeRateMustValid(self), "سعر الصرف غير سليم", self, "ExchangeRate");

        }

        public bool Account_accountNumberMustConformWithKind(DataRow self)
        {
            if (self.IsNull("AccountKind") || self.IsNull("AccountNumber") || string.IsNullOrEmpty(self["AccountNumber"].ToString())) return true;
            string accountNumber = (string)self["AccountNumber"];
            short accountKind = (short)self["AccountKind"];
            return accountNumber.StartsWith(accountKind.ToString());

        }

        public bool Account_ExchangeRateMustValid(DataRow self)
        {
            if (self.IsNull("ExchangeRate")) return true;
            decimal exchangeRate = (decimal)self["ExchangeRate"];
            if (exchangeRate <= 0) return false;
            return !object.Equals(Constants.SystemConstants.LocalCurrencyID, self["AuxiliaryCurrencyID"]) || (decimal)self["ExchangeRate"] == 1;
        }




        #endregion

    }


}
