using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.AppService;
using System.Data.OleDb;
using ATS.EnterpriseSystem;
using System.Data;

namespace ATS.Accounting
{
    public class CurrencyDataAdapter : DataUnitAdapter
    {
        public CurrencyDataAdapter()
            : base((int)Accounting.ObjectTypeCode.Currency)
        { }

        protected override bool ExistCore(Guid id)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select Count(*) from [Currency] Where CurrencyID=?;";
            cmd.Parameters.Add(new OleDbParameter("CurrencyID", id));
            object c = this.DataBaseConnection.ExecuteScalar(cmd);

            return DataUtil.NZ<int>(c) == 1;
        }

        protected override DataUnit LoadCore(Guid id)
        {
            CurrencyDataUnit r = new CurrencyDataUnit();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select * from vw_Currency Where CurrencyID=?;";
            cmd.Parameters.Add(new OleDbParameter("CurrencyID", id));
            this.DataBaseConnection.Fill(r, "Currency", cmd);
            return r;
        }

        #region save
        protected override void SaveCore(DataUnit data)
        {
            this.DataBaseConnection.UpdateDataSet(data, "Currency", GetInsertCommand(), GetUpdateCommand(), null);
        }

        OleDbCommand GetInsertCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "INSERT INTO `Currency`(`CurrencyID`,`DecimalPlaces`,`Description`,`ExchangeRate`," +
                "`Name`,`OrganizationID`,`Symbol`) VALUES (?,?,?,?,?,?,?)";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("CurrencyID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "CurrencyID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("DecimalPlaces", System.Data.OleDb.OleDbType.Integer, -1, System.Data.ParameterDirection.Input, 0, 0, "DecimalPlaces", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, -1, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "ExchangeRate", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("OrganizationID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "OrganizationID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Symbol", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "Symbol", System.Data.DataRowVersion.Current, false, null));

            return cmd;
        }

        OleDbCommand GetUpdateCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "UPDATE `Currency` SET `DecimalPlaces`=?,`Description`=?,`ExchangeRate`=?,`Name`=?" +
                ",`OrganizationID`=?,`Symbol`=? WHERE `CurrencyID`=?";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("DecimalPlaces", System.Data.OleDb.OleDbType.Integer, -1, System.Data.ParameterDirection.Input, 0, 0, "DecimalPlaces", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, -1, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "ExchangeRate", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("OrganizationID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "OrganizationID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Symbol", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "Symbol", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Orginal_CurrencyID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "CurrencyID", System.Data.DataRowVersion.Original, false, null));


            return cmd;
        }

        OleDbCommand GetDeleteCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "DELETE FROM `Currency` WHERE `CurrencyID`=?";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Orginal_CurrencyID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "CurrencyID", System.Data.DataRowVersion.Original, false, null));
            return cmd;
        } 
        #endregion

        protected override void DeleteCore(Guid id)
        {
            OleDbCommand cmd = GetDeleteCommand();
            cmd.Parameters[0].Value = id;
            this.DataBaseConnection.ExecuteNonQuery(cmd);
        }

        protected override bool MayDeleteCore(Guid id)
        {
            if (object.Equals(Constants.SystemConstants.LocalCurrencyID, id))
            {
                return false;
            }

            if (HasAccounts(id))
                return false;

            if (HasJournalEntryLines(id))
                return false;

            return true;
        }

        public bool HasAccounts(Guid id)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select Count(*) from [Account] Where AuxiliaryCurrencyID=?";
            cmd.Parameters.Add(new OleDbParameter("AuxiliaryCurrencyID", id));
            object cmdRet = DataBaseConnection.ExecuteScalar(cmd);
            return DataUtil.NZ<int>(cmdRet) > 0;
        }

        public bool HasJournalEntryLines(Guid id)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select Count(*) from JournalEntryLine Where AuxiliaryCurrencyID=?";
            cmd.Parameters.Add(new OleDbParameter("AuxiliaryCurrencyID", id));
            object cmdRet = DataBaseConnection.ExecuteScalar(cmd);
            return DataUtil.NZ<int>(cmdRet) > 0;
        }

        protected override void ValidateCore(DataUnit data, ValidationErrorCollection errors)
        {
            ValidationContext context = new ValidationContext(this.DataBaseConnection, errors);
            DoValidateTable(data.Tables["Currency"], Validate_Currency, context);

        }

        public void Validate_Currency(DataRow self, ValidationContext context)
        {
            context.CheckNull(self["CurrencyID"], "خطأ", self, "CurrencyID");
            context.CheckNull(self["OrganizationID"], "خطأ", self, "OrganizationID");
            context.CheckForEmptyString(self["Name"], "مطلوب", self, "Name");
            context.CheckStringMaxLength(60, self["Name"], "الأسم طويل", self, "Name");
            context.CheckNull(self["ExchangeRate"], "مطلوب", self, "ExchangeRate");

            context.CheckForEmptyString(self["Symbol"], "مطلوب", self, "Symbol");
            context.CheckStringMaxLength(10, self["Symbol"], "طويل", self, "Symbol");

            context.Assert(Currency_ExchangeRateMustValid(self), "سعر الصرف غير سليم", self, "ExchangeRate");

            context.CheckUnique("[Currency]", "CurrencyID", "[Name]", (Guid)self["CurrencyID"], self["Name"], "توجد عملة اخرى بنفس الأسم", self, "Name");
            context.CheckUnique("[Currency]", "CurrencyID", "[Symbol]", (Guid)self["CurrencyID"], self["Symbol"], "توجد عملة اخرى بنفس الرمز", self, "Symbol");
        }

        public bool Currency_ExchangeRateMustValid(DataRow self)
        {
            if (self.IsNull("ExchangeRate")) return true;
            decimal exchangeRate = (decimal)self["ExchangeRate"];
            if (exchangeRate <= 0) return false;
            return !object.Equals(Constants.SystemConstants.LocalCurrencyID, self["CurrencyID"]) || (decimal)self["ExchangeRate"] == 1;
        }


    }
}
