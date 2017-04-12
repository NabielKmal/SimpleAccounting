using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.AppService;
using System.Data.OleDb;
using System.Data;
using ATS.EnterpriseSystem;

namespace ATS.Accounting
{
    class OrganizationDataAdapter : DataUnitAdapter
    {
        public OrganizationDataAdapter()
            : base((int)Accounting.ObjectTypeCode.Organization)
        { }

        protected override bool ExistCore(Guid id)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select Count(*) from Organization Where OrganizationID=?;";
            cmd.Parameters.Add(new OleDbParameter("OrganizationID", id));
            object c = this.DataBaseConnection.ExecuteScalar(cmd);

            return DataUtil.NZ<int>(c) == 1;
        }

        protected override DataUnit LoadCore(Guid id)
        {
            OrganizationDataUnit r = new OrganizationDataUnit();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select * from vw_Organization Where OrganizationID=?;";
            cmd.Parameters.Add(new OleDbParameter("OrganizationID", id));
            this.DataBaseConnection.Fill(r, "Organization", cmd);
            return r;
        }

        protected override void SaveCore(DataUnit data)
        {
            AV.Assert(data.State == DataUnitState.Modified || data.State == DataUnitState.Unchanged);
            this.DataBaseConnection.UpdateDataSet(data, "Organization", null, GetUpdateCommand(), null);
        }

        OleDbCommand GetUpdateCommand()
        {
            OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = @"UPDATE `Organization` SET `AddressLine1`=?,`AddressLine2`=?,`AddressLine3`=?,`City`=?,`County`=?,`CurrentDate`=?,`CurrentJournalEntryNumber`=?,`Description`=?,`Fax`=?,`FiscalYearEnd`=?,`FiscalYearStart`=?,`Name`=?,`PostalCode`=?,`PostOfficeBox`=?,`StateOrProvince`=?,`SysState`=?,`Telephone1`=?,`Telephone2`=?,`Telephone3`=? WHERE `OrganizationID`=?";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AddressLine1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "AddressLine1", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AddressLine2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "AddressLine2", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("AddressLine3", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "AddressLine3", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("City", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("County", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "County", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("CurrentDate", System.Data.OleDb.OleDbType.Date, -1, System.Data.ParameterDirection.Input, 0, 0, "CurrentDate", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("CurrentJournalEntryNumber", System.Data.OleDb.OleDbType.BigInt, -1, System.Data.ParameterDirection.Input, 0, 0, "CurrentJournalEntryNumber", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, -1, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "Fax", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("FiscalYearEnd", System.Data.OleDb.OleDbType.Date, -1, System.Data.ParameterDirection.Input, 0, 0, "FiscalYearEnd", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("FiscalYearStart", System.Data.OleDb.OleDbType.Date, -1, System.Data.ParameterDirection.Input, 0, 0, "FiscalYearStart", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("PostalCode", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "PostalCode", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("PostOfficeBox", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "PostOfficeBox", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("StateOrProvince", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "StateOrProvince", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("SysState", System.Data.OleDb.OleDbType.TinyInt, -1, System.Data.ParameterDirection.Input, 0, 0, "SysState", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Telephone1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "Telephone1", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Telephone2", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "Telephone2", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Telephone3", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, 0, 0, "Telephone3", System.Data.DataRowVersion.Current, false, null));
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("Orginal_OrganizationID", System.Data.OleDb.OleDbType.Guid, -1, System.Data.ParameterDirection.Input, 0, 0, "OrganizationID", System.Data.DataRowVersion.Original, false, null));



            return cmd;
        }

        protected override void DeleteCore(Guid id)
        {
            throw new InvalidOperationException();
        }

        protected override bool MayDeleteCore(Guid id)
        {
            return false;
        }

        protected override void ValidateCore(DataUnit data, ValidationErrorCollection errors)
        {
            ValidationContext context = new ValidationContext(this.DataBaseConnection, errors);
            DoValidateTable(data.Tables["Organization"], new ValidateRow(ValidateOrganization), context);
        }

        void ValidateOrganization(DataRow self, ValidationContext context)
        {
            context.CheckNull(self["OrganizationID"], "المعرف مطلوب", self, "OrganizationID");
            context.CheckForEmptyString(self["Name"], "الأسم مطلوب", self, "Name");
            context.CheckStringMaxLength(60, self["Name"], "الأسم طويل", self, "Name");

            context.CheckNull(self["FiscalYearStart"], "التاريخ الأفتتاحي مطلوب", self, "FiscalYearStart");
            context.CheckNull(self["FiscalYearEnd"], "التاريخ النهائي مطلوب", self, "FiscalYearEnd");
            context.CheckNull(self["CurrentDate"], "التاريخ الحالي مطلوب", self, "CurrentDate");
            bool c = Organization_fiscalYearMustBeValid(self);
            context.Assert(c, "السنة المحاسبية غير صحيحة", self, "FiscalYearStart");
            context.Assert(c, "السنة المحاسبية غير صحيحة", self, "FiscalYearEnd");

            context.Assert(Organization_currentDateMustBeInFiscalYear(self), "التاريخ الحالي يجب ان يكون ضمن السنة المحاسبية", self, "CurrentDate");

            c = Organization_fiscalYearMustNotBroken(self);
            context.Assert(c, "السنة المحاسبية لا تتلائم والقيود الحالية", self, "FiscalYearStart");
            context.Assert(c, "السنة المحاسبية لا تتلائم والقيود الحالية", self, "FiscalYearEnd");

        }



        public bool Organization_fiscalYearMustBeValid(DataRow self)
        {
            if (self.IsNull("FiscalYearStart") || self.IsNull("FiscalYearEnd")) return true;

            return (DateTime)self["FiscalYearEnd"] >= (DateTime)self["FiscalYearStart"];
        }

        

        /// <summary>
        /// التحقق من 
        /// السنة المحاسبية لا تخرق التواريخ في القيود الحالية في النظام
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public bool Organization_fiscalYearMustNotBroken(DataRow self)
        {
            if (self.IsNull("FiscalYearStart") || self.IsNull("FiscalYearEnd")) return true;
            if ((DateTime)self["FiscalYearEnd"] < (DateTime)self["FiscalYearStart"]) return true;
            DateTime start = (DateTime)self["FiscalYearStart"];
            DateTime end = (DateTime)self["FiscalYearEnd"];

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select min(EntryDate) from JournalEntry;";
            //استرجاع تاريخ اول قيد
            object minDate = this.DataBaseConnection.ExecuteScalar(cmd);
            if (minDate != DBNull.Value)
            {
                if ((DateTime)minDate < start) return false;
            }
            cmd.CommandText = "Select max(EntryDate) from JournalEntry;";
            //استرجاع تاريخ آخر قيد
            object maxDate = this.DataBaseConnection.ExecuteScalar(cmd);
            if (maxDate != DBNull.Value)
            {
                if ((DateTime)maxDate > end) return false;
            }

            return true;
        }

        public bool Organization_currentDateMustBeInFiscalYear(DataRow self)
        {
            if (self.IsNull("FiscalYearStart") || self.IsNull("FiscalYearEnd") || self.IsNull("CurrentDate")) return true;
            //إذا كانت السنة المحاسبية غير صحيحة فلا يمكن المقارنة
            if ((DateTime)self["FiscalYearEnd"] < (DateTime)self["FiscalYearStart"]) return true;
            DateTime start = (DateTime)self["FiscalYearStart"];
            DateTime end = (DateTime)self["FiscalYearEnd"];
            DateTime c = (DateTime)self["CurrentDate"];

            return start <= c && c <= end;
        }
    }
}
