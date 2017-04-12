using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.AppService;
using System.Data;
using System.Data.OleDb;
using ATS.EnterpriseSystem;

namespace ATS.Accounting
{
    public class RootEntityService : IRootEntityService
    {
        DataBaseConnection dataBaseConnection;

        public RootEntityService(DataBaseConnection dataBaseConnection)
        {
            AV.CheckForNullReference(dataBaseConnection);
            this.dataBaseConnection = dataBaseConnection;
        }

        public DataRow GetRootObject()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select * from Organization Where OrganizationID=?;";
            cmd.Parameters.Add(new OleDbParameter("OrganizationID", Constants.SystemConstants.OrganizationID));
            DataTable r = this.DataBaseConnection.Fill(cmd);
            r.TableName = "Organization";
            AV.Assert(r.Rows.Count == 1);
            return r.Rows[0];
        }
        #region IRootEntityService Members

        object IRootEntityService.GetRootObject()
        {
            return this.GetRootObject();
        }

        #endregion

        DataBaseConnection DataBaseConnection
        {
            get
            {
                return this.dataBaseConnection;
            }
        }

        public Guid GetRootID()
        {
            //return (Guid)GetRootObject()["OrganizationID"];
            return Constants.SystemConstants.OrganizationID;
        }

        public Guid GetOrganizationID()
        {
            return GetRootID();
        }

        public string GetOrganizationName()
        {
            return (string)GetRootObject()["Name"];
        }

        public DateTime GetOrganizationCurrentDate()
        {
            return (DateTime)GetRootObject()["CurrentDate"];
        }

        public bool InFiscalYear(DateTime e)
        {
            DataRow dic = this.GetRootObject();
            DateTime start = (DateTime)dic["FiscalYearStart"];
            DateTime end = (DateTime)dic["FiscalYearEnd"];

            return start <= e && e <= end;
        }

        public decimal GetGeneralNet()
        {
            decimal r = GetSectionTotal(4) - GetSectionTotal(5);

            return r;
        }

        public decimal GetSectionTotal(int e)
        {
            decimal r = 0;
            string sql = string.Format("SELECT SUM(currentbalance) FROM vw_Account WHERE AccountKind={0}", e);
            try
            {
                r = new decimal(DataUtil.NZ<double>(this.DataBaseConnection.ExecuteScalar(sql)));
            }
            catch (Exception)
            {

                //throw;
            }
            return r;
        }



        public DateTime? GetLastJournalDate()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select Max(EntryDate) from JournalEntry;";
            object r = this.DataBaseConnection.ExecuteScalar(cmd);
            if (r == DBNull.Value)
                return null;
            return (DateTime)r;
            //return DateTime.Now;
        }

        public void SetCurrentDate(DateTime v)
        {
            AV.Assert(InFiscalYear(v));
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Update Organization set CurrentDate=? Where OrganizationID=?;";
            cmd.Parameters.Add(new OleDbParameter("CurrentDate", v));
            cmd.Parameters.Add(new OleDbParameter("OrganizationID", Constants.SystemConstants.OrganizationID));
            AV.Assert(this.DataBaseConnection.ExecuteNonQuery(cmd) == 1);
        }

        public decimal? GetCurrencyExchangeRate(Guid CurrencyID)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select ExchangeRate from [Currency] WHERE Currencyid=?";
            cmd.Parameters.AddWithValue("CurrencyID", CurrencyID);
            object r = this.DataBaseConnection.ExecuteScalar(cmd);
            if (r == DBNull.Value)
                return null;
            return decimal.Parse(r.ToString());
        }

        public Guid? GetAccountCurrency(Guid AccountID)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Select AuxiliaryCurrencyID from [Account] WHERE AccountID=?";
            cmd.Parameters.AddWithValue("AccountID", AccountID);
            object r = this.DataBaseConnection.ExecuteScalar(cmd);
            if (r == DBNull.Value)
                return null;
            return (Guid)r;
        }

        /// <summary>
        /// ارجاع قيمة الطرف الأيمن او الأيسر في المعادلة المحاسبية
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public decimal GetAccoutingEquationSideTotal(DebitCredit e)
        {
            decimal r = 0;
            string sql = string.Format("SELECT SUM(currentbalance) FROM vw_Account WHERE BalanceType={0}", (short)e);
            try
            {
                r = new decimal(DataUtil.NZ<double>(this.DataBaseConnection.ExecuteScalar(sql)));
            }
            catch (Exception)
            {

                //throw;
            }
            return r;
        }

        /// <summary>
        /// ارجاع قيمة تدل على اتزان المعادلة المحاسبية في قاعدة البيانات الحالية
        /// </summary>
        /// <returns></returns>
        public bool IsAccoutingEquationCorrect()
        {
            decimal debit = decimal.Round(GetAccoutingEquationSideTotal(DebitCredit.Debit), 2);
            decimal credit = decimal.Round(GetAccoutingEquationSideTotal(DebitCredit.Credit), 2);
            return debit == credit;

        }
    }
}
