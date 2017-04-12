using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.AppService;
using System.Data.OleDb;
using ATS.EnterpriseSystem;
using System.Data;

namespace ATS.Accounting
{
    public class JournalEntryDataAdapter : DataUnitAdapter
    {
        public JournalEntryDataAdapter()
            : base((int)Accounting.ObjectTypeCode.JournalEntry)
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
            cmd.CommandText = "Select Count(*) from JournalEntry Where JournalEntryID=?;";
            cmd.Parameters.Add(new OleDbParameter("JournalEntryID", id));
            object c = this.DataBaseConnection.ExecuteScalar(cmd);

            return DataUtil.NZ<int>(c) == 1;
        }

        protected override DataUnit LoadCore(Guid id)
        {
            JournalEntryDataUnit r = new JournalEntryDataUnit();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select * from vw_JournalEntry Where JournalEntryID=?;";
            cmd.Parameters.Add(new OleDbParameter("JournalEntryID", id));

            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = "Select * from vw_JournalEntryLine Where JournalEntryID=? ORDER BY [AmountSide], [LineNumber] ;";
            //cmd2.CommandText = "Select * from vw_JournalEntryLine Where JournalEntryID=?;";
            cmd2.Parameters.Add(new OleDbParameter("JournalEntryID", id));

            this.DataBaseConnection.Fill(r, "JournalEntry", cmd);
            this.DataBaseConnection.Fill(r, "JournalEntryLine", cmd2);
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
            return true;
        }



        #region save
        protected override void SaveCore(DataUnit data)
        {
            System.Exception exception = null;
            PrepareJournalEntry(data);
            this.DataBaseConnection.BeginTransaction();
            try
            {
                if (data.RootObject.RowState == DataRowState.Added)
                {
                    data.RootObject["EntryNumber"] = GetNextJournalEntryNumber();
                }
                this.DataBaseConnection.UpdateDataSet(data, "JournalEntry", GetInsertCommand(), GetUpdateCommand(), null);
                this.DataBaseConnection.UpdateDataSet(data, "JournalEntryLine", JournalEntryLineCommands.GetInsertCommand(), JournalEntryLineCommands.GetUpdateCommand(), JournalEntryLineCommands.GetDeleteCommand());

                this.DataBaseConnection.CommitTransaction();
            }
            catch (Exception ex)
            {
                this.DataBaseConnection.RollbackTransaction();
                exception = ex;
            }

            if (exception != null)
                throw exception;

        }

        /// <summary>
        /// عداد لترقيم الأسطر
        /// </summary>
        int tempLineNumber;
        void PrepareJournalEntry(DataUnit data)
        {
            tempLineNumber = 0;
            DataTableHelper.DoDataTableAction(data.Tables["JournalEntry"], PrepareJournalEntryRow);
            DataTableHelper.DoDataTableAction(data.Tables["JournalEntryLine"], PrepareJournalEntryLineRow);
        }

        void PrepareJournalEntryRow(DataRow self)
        {
            switch (self.RowState)
            {
                case DataRowState.Added:

                    break;
                case DataRowState.Modified:
                case DataRowState.Unchanged:

                    break;
            }
        }

        void PrepareJournalEntryLineRow(DataRow self)
        {
            switch (self.RowState)
            {
                case DataRowState.Added:
                case DataRowState.Modified:
                case DataRowState.Unchanged:
                    self["LineNumber"] = tempLineNumber++;
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "SELECT BalanceType FROM ACCOUNT WHERE AccountID=?";
                    cmd.Parameters.Add(new OleDbParameter("AccountID", (Guid)self["AccountID"]));
                    short balanceType = (short)(byte)this.DataBaseConnection.ExecuteScalar(cmd);
                    decimal factor = 0;
                    DebitCredit amountSide = (DebitCredit)(short)self["AmountSide"];

                    if (balanceType == (short)amountSide) factor = 1;
                    else factor = -1;
                    self["PostedAmount"] = (decimal)self["Amount"] * factor;

                    //إذا كانت العملة نفس  عملة الحساب 
                    if (object.Equals(RootEntityService.GetAccountCurrency((Guid)self["AccountID"]), (Guid)self["AuxiliaryCurrencyID"]))
                    {
                        //يرصد مبلغ العملة
                        self["PostedAuxiliaryAmount"] = (decimal)self["AuxiliaryAmount"] * factor;
                    }
                    else
                    {
                        //لا يرصد مبلغ العملة
                        self["PostedAuxiliaryAmount"] = 0;
                    }

                    break;
            }
        }


        #region commands
        OleDbCommand GetInsertCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "INSERT INTO `JournalEntry`(`Description`,`EntryDate`,`EntryNumber`,`JournalEntryI" +
                "D`,`OrganizationID`,`Source`) VALUES (?,?,?,?,?,?)";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, -1, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntryDate", System.Data.OleDb.OleDbType.Date, -1, System.Data.ParameterDirection.Input, 0, 0, "EntryDate", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntryNumber", System.Data.OleDb.OleDbType.Integer, 200, System.Data.ParameterDirection.Input, 0, 0, "EntryNumber", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("JournalEntryID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "JournalEntryID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("OrganizationID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "OrganizationID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Source", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, 0, 0, "Source", System.Data.DataRowVersion.Current, false, null));



            return cmd;
        }

        OleDbCommand GetUpdateCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "UPDATE `JournalEntry` SET `Description`=?,`EntryDate`=?,`EntryNumber`=?,`Organiza" +
                "tionID`=?,`Source`=? WHERE `JournalEntryID`=?";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, -1, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntryDate", System.Data.OleDb.OleDbType.Date, -1, System.Data.ParameterDirection.Input, 0, 0, "EntryDate", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntryNumber", System.Data.OleDb.OleDbType.Integer, 200, System.Data.ParameterDirection.Input, 0, 0, "EntryNumber", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("OrganizationID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "OrganizationID", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Source", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, 0, 0, "Source", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Orginal_JournalEntryID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "JournalEntryID", System.Data.DataRowVersion.Original, false, null));


            return cmd;
        }

        OleDbCommand GetDeleteCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "DELETE FROM `JournalEntry` WHERE `JournalEntryID`=?";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Orginal_JournalEntryID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "JournalEntryID", System.Data.DataRowVersion.Original, false, null));
            return cmd;
        }

        class JournalEntryLineCommands
        {
            public static OleDbCommand GetInsertCommand()
            {
                OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = @"INSERT INTO `JournalEntryLine`(`AccountID`,`Amount`,`AmountSide`,`Description`,`JournalEntryID`,`JournalEntryLineID`,`LineNumber`,`PostedAmount`,`AuxiliaryAmount`,`AuxiliaryCurrencyID`,`ExchangeRate`,`PostedAuxiliaryAmount`) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AccountID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "AccountID", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Amount", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "Amount", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AmountSide", System.Data.OleDb.OleDbType.TinyInt, -1, System.Data.ParameterDirection.Input, 0, 0, "AmountSide", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, -1, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("JournalEntryID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "JournalEntryID", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("JournalEntryLineID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "JournalEntryLineID", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("LineNumber", System.Data.OleDb.OleDbType.Integer, -1, System.Data.ParameterDirection.Input, 0, 0, "LineNumber", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("PostedAmount", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "PostedAmount", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AuxiliaryAmount", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "AuxiliaryAmount", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AuxiliaryCurrencyID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "AuxiliaryCurrencyID", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "ExchangeRate", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("PostedAuxiliaryAmount", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "PostedAuxiliaryAmount", System.Data.DataRowVersion.Current, false, null));


                return cmd;
            }

            public static OleDbCommand GetUpdateCommand()
            {
                OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = "UPDATE `JournalEntryLine` SET `AccountID`=?,`Amount`=?,`AmountSide`=?,`Descriptio" +
                    "n`=?,`LineNumber`=?,`PostedAmount`=?,`AuxiliaryAmount`=?,`AuxiliaryCurrencyID`=?" +
                    ",`ExchangeRate`=?,`PostedAuxiliaryAmount`=? WHERE `JournalEntryLineID`=?";
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AccountID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "AccountID", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Amount", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "Amount", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AmountSide", System.Data.OleDb.OleDbType.TinyInt, -1, System.Data.ParameterDirection.Input, 0, 0, "AmountSide", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, -1, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("LineNumber", System.Data.OleDb.OleDbType.Integer, -1, System.Data.ParameterDirection.Input, 0, 0, "LineNumber", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("PostedAmount", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "PostedAmount", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AuxiliaryAmount", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "AuxiliaryAmount", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AuxiliaryCurrencyID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "AuxiliaryCurrencyID", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "ExchangeRate", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("PostedAuxiliaryAmount", System.Data.OleDb.OleDbType.Decimal, -1, System.Data.ParameterDirection.Input, 0, 0, "PostedAuxiliaryAmount", System.Data.DataRowVersion.Current, false, null));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Orginal_JournalEntryLineID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "JournalEntryLineID", System.Data.DataRowVersion.Original, false, null));
                return cmd;
            }
            public static OleDbCommand GetDeleteCommand()
            {
                OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText = "DELETE FROM `JournalEntryLine` WHERE `JournalEntryLineID`=?";
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Orginal_JournalEntryLineID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "JournalEntryLineID", System.Data.DataRowVersion.Original, false, null));


                return cmd;
            }
        }
        #endregion
        #endregion

        #region validation

        protected override void ValidateCore(DataUnit data, ValidationErrorCollection errors)
        {
            ValidationContext context = new ValidationContext(this.DataBaseConnection, errors);
            DoValidateTable(data.Tables["JournalEntry"], new ValidateRow(ValidateJournalEntry), context);
            DoValidateTable(data.Tables["JournalEntryLine"], new ValidateRow(ValidateJournalEntryLine), context);
            //return context.Errors;
        }

        void ValidateJournalEntry(DataRow self, ValidationContext context)
        {
            context.CheckNull(self["JournalEntryID"], "المعرف مطلوب", self, "JournalEntryID");
            context.CheckNull(self["EntryDate"], "تاريخ القيد مطلوب", self, "EntryDate");
            context.CheckNull(self["OrganizationID"], "خطأ", self, "OrganizationID");

            //
            context.Assert(JournalEntry_entryDateMustBeInFiscalYear(self), "تاريخ القيد يجب ان يكون ضمن السنة المحاسبية", self, "EntryDate");
            bool c = JournalEntry_totalesMustBeSame(self);
            context.Assert(c, "إجمالي المدين يجب ان يساوي إجمالي الدائن وكلاهما لا يساوي صفر", self, "TotalDebit");
            context.Assert(c, "إجمالي المدين يجب ان يساوي إجمالي الدائن وكلاهما لا يساوي صفر", self, "TotalCredit");
        }
        //
        public bool JournalEntry_entryDateMustBeInFiscalYear(DataRow self)
        {
            return self.IsNull("EntryDate") || RootEntityService.InFiscalYear((DateTime)self["EntryDate"]);
        }

        public bool JournalEntry_totalesMustBeSame(DataRow self)
        {
            decimal totalDebit = decimal.Round(Get_JournalEntry_TotalDebit(self), 2);
            decimal totalCredit = decimal.Round(Get_JournalEntry_TotalCredit(self), 2);
            return totalDebit == totalCredit && totalDebit != 0 && totalCredit != 0;
        }

        void ValidateJournalEntryLine(DataRow self, ValidationContext context)
        {
            context.CheckNull(self["JournalEntryLineID"], "المعرف مطلوب", self, "JournalEntryLineID");
            context.CheckNull(self["JournalEntryID"], "خطأ", self, "JournalEntryID");
            context.CheckNull(self["AccountID"], "الحساب مطلوب", self, "AccountID");

            context.CheckNull(self["AmountSide"], "مطلوب", self, "AmountSide");
            context.CheckNull(self["AuxiliaryAmount"], "مطلوب", self, "AuxiliaryAmount");
            context.CheckNull(self["AuxiliaryCurrencyID"], "مطلوب", self, "AuxiliaryCurrencyID");
            context.CheckNull(self["ExchangeRate"], "مطلوب", self, "ExchangeRate");

            context.Assert(JournalEntryLine_AuxiliaryCurrencyMustConformWithAccount(self), "لا يمكن استخدام هذه العملة مع الحساب المرافق", self, "AuxiliaryCurrencyID");
            context.Assert(JournalEntryLine_ExchangeRateMustValid(self), "سعر الصرف غير سليم", self, "ExchangeRate");

        }

        /// <summary>
        /// يجب ان تتفق العملة مع عملة الحساب في السطر
        /// فاما ان تكون عملة السطر هي العملة المحلية 
        /// او ان تكون عملة السطر هي نفس عملة الحساب
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        private bool JournalEntryLine_AuxiliaryCurrencyMustConformWithAccount(System.Data.DataRow self)
        {
            if (self.IsNull("AuxiliaryCurrencyID") || self.IsNull("AccountID"))
                return true;
            //إذا كانت العملة هي العملة المحلية فلا مشكلة
            if (object.Equals(Constants.SystemConstants.LocalCurrencyID, (Guid)self["AuxiliaryCurrencyID"]))
                return true;
            if (object.Equals(RootEntityService.GetAccountCurrency((Guid)self["AccountID"]), (Guid)self["AuxiliaryCurrencyID"]))
                return true;

            return false;
        }

        /// <summary>
        /// سعر الصرف يكون سليم إذا كان اكبر من الصفر
        /// ويجب ان يساوي 1 إذا كانت العملة محلية
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public bool JournalEntryLine_ExchangeRateMustValid(DataRow self)
        {
            if (self.IsNull("ExchangeRate")) return true;
            decimal exchangeRate = (decimal)self["ExchangeRate"];
            if (exchangeRate <= 0) return false;
            return !object.Equals(Constants.SystemConstants.LocalCurrencyID, self["AuxiliaryCurrencyID"]) || (decimal)self["ExchangeRate"] == 1;
        }
        #endregion

        public decimal Get_JournalEntry_TotalDebit(DataRow self)
        {
            decimal r = 0;
            foreach (DataRow x in self.Table.DataSet.Tables["JournalEntryLine"].Select(null, null, DataViewRowState.CurrentRows))
            {
                if (object.Equals(x["AmountSide"], (short)DebitCredit.Debit))
                {
                    r += DataUtil.NZ<decimal>(x["Amount"]);
                }
            }
            return r;
        }

        public decimal Get_JournalEntry_TotalCredit(DataRow self)
        {
            decimal r = 0;
            foreach (DataRow x in self.Table.DataSet.Tables["JournalEntryLine"].Select(null, null, DataViewRowState.CurrentRows))
            {
                if (object.Equals(x["AmountSide"], (short)DebitCredit.Credit))
                {
                    r += DataUtil.NZ<decimal>(x["Amount"]);
                }
            }
            return r;
        }

        protected int GetNextJournalEntryNumber()
        {
            int h = 0;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select CurrentJournalEntryNumber from Organization where organizationid=?;";
            cmd.Parameters.Add(new OleDbParameter("OrganizationID", Constants.SystemConstants.OrganizationID));
            int c = (int)this.DataBaseConnection.ExecuteScalar(cmd);
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = "Update Organization set CurrentJournalEntryNumber=CurrentJournalEntryNumber+1 where organizationid=?;";
            cmd2.Parameters.Add(new OleDbParameter("OrganizationID", Constants.SystemConstants.OrganizationID));
            this.DataBaseConnection.ExecuteNonQuery(cmd2);
            return c;
        }

    }
}
