////إصدار جديد بتاريخ 21-اغسطس-2008
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ATS.EnterpriseSystem.AppService
{
    public abstract class DataBaseConnection : IDataBaseConnection
    {
        private DbProviderFactory providerFactory;
        private DbConnection connection;
        private DbTransaction transaction;

        protected DataBaseConnection(DbProviderFactory providerFactory)
        {
            this.providerFactory = providerFactory;
            this.connection = providerFactory.CreateConnection();
        }

        protected DbConnection Connection
        {
            get
            {
                return this.connection;
            }
        }

        protected DbTransaction Transaction
        {
            get
            { return this.transaction; }
        }

        protected void PrepareCommand(DbCommand cmd)
        {
            AV.Assert(IsOpen());
            cmd.Connection = this.Connection;
            if (InTransaction)
                cmd.Transaction = Transaction;
        }

        protected DbCommand CreateCommandForSql(string sql)
        {
            DbCommand r = ProviderFactory.CreateCommand();
            r.CommandText = sql;
            r.CommandType = CommandType.Text;
            PrepareCommand(r);
            return r;
        }

        #region IDataBaseConnection Members

        public DbProviderFactory ProviderFactory
        {
            get { return providerFactory; }
        }

        public int Fill(DataTable tbl, string sql)
        {
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = CreateCommandForSql(sql);
            return adapter.Fill(tbl);
        }

        public DataTable Fill(string sql)
        {
            DataTable tbl = new DataTable();
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = CreateCommandForSql(sql);
            adapter.Fill(tbl);
            return tbl;
        }

        public int Fill(DataSet dataSet, string sql)
        {
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = CreateCommandForSql(sql);
            return adapter.Fill(dataSet);
        }

        public int Fill(DataSet dataSet, string srcTable, string sql)
        {
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = CreateCommandForSql(sql);
            return adapter.Fill(dataSet, srcTable);
        }

        public int Fill(DataSet dataSet, string srcTable, string sql, int startRecord, int maxRecords)
        {
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = CreateCommandForSql(sql);
            return adapter.Fill(dataSet, startRecord, maxRecords, srcTable);
        }

        public int Fill(DataTable tbl, DbCommand cmd)
        {
            PrepareCommand(cmd);
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = cmd;
            return adapter.Fill(tbl);
        }

        public DataTable Fill(DbCommand cmd)
        {
            DataTable tbl = new DataTable();
            PrepareCommand(cmd);
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(tbl);
            return tbl;
        }

        public int Fill(DataSet ds, DbCommand cmd)
        {
            PrepareCommand(cmd);
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = cmd;
            return adapter.Fill(ds);
        }

        public int Fill(DataSet ds, string srcTable, DbCommand cmd)
        {
            PrepareCommand(cmd);
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = cmd;
            return adapter.Fill(ds, srcTable);
        }

        public int Fill(DataSet dataSet, string srcTable, DbCommand cmd, int startRecord, int maxRecords)
        {
            PrepareCommand(cmd);
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            adapter.SelectCommand = cmd;
            return adapter.Fill(dataSet, startRecord, maxRecords, srcTable);
        }

        public int ExecuteNonQuery(string sql)
        {
            return CreateCommandForSql(sql).ExecuteNonQuery();
        }

        public DbDataReader ExecuteReader(string sql)
        {
            return CreateCommandForSql(sql).ExecuteReader();
        }

        public DbDataReader ExecuteReader(string sql, CommandBehavior behavior)
        {
            return CreateCommandForSql(sql).ExecuteReader(behavior);
        }

        public object ExecuteScalar(string sql)
        {
            return CreateCommandForSql(sql).ExecuteScalar();
        }

        public int ExecuteNonQuery(DbCommand cmd)
        {
            PrepareCommand(cmd);
            return cmd.ExecuteNonQuery();
        }

        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            PrepareCommand(cmd);
            return cmd.ExecuteReader();
        }

        public DbDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            PrepareCommand(cmd);
            return cmd.ExecuteReader(behavior);
        }

        public object ExecuteScalar(DbCommand cmd)
        {
            PrepareCommand(cmd);
            return cmd.ExecuteScalar();
        }

        public int UpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand, DbCommand updateCommand, DbCommand deleteCommand)
        {
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();

            if (insertCommand != null)
            {
                PrepareCommand(insertCommand);
                adapter.InsertCommand = insertCommand;
            }

            if (updateCommand != null)
            {
                PrepareCommand(updateCommand);
                adapter.UpdateCommand = updateCommand;
            }

            if (deleteCommand != null)
            {
                PrepareCommand(deleteCommand);
                adapter.DeleteCommand = deleteCommand;
            }

            return adapter.Update(dataSet, tableName);
        }

        #endregion

        #region IConnectionControler Members

        public string ConnectionString
        {
            get { return this.connection.ConnectionString; }
        }

        public ConnectionState State
        {
            get { return this.connection.State; }
        }

        public bool InTransaction
        {
            get
            {
                return transaction != null;
            }
        }

        public bool IsOpen()
        {
            return this.Connection.State != System.Data.ConnectionState.Closed;
        }

        public void Close()
        {
            if (InTransaction)
                RollbackTransaction();
            this.Connection.Close();
        }

        public void Open(string connectionString)
        {
            AV.Assert(this.Connection.State == System.Data.ConnectionState.Closed);
            this.Connection.ConnectionString = connectionString;
            this.Connection.Open();
        }

        public void BeginTransaction()
        {
            AV.Assert(!this.InTransaction);
            AV.Assert(this.IsOpen());
            transaction = this.Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            AV.Assert(this.InTransaction);
            this.transaction.Commit();
            this.transaction = null;
        }

        public void RollbackTransaction()
        {
            AV.Assert(this.InTransaction);
            this.transaction.Rollback();
            this.transaction = null;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.InTransaction)
                {
                    RollbackTransaction();
                }
                this.Connection.Dispose();
            }
        }

        #endregion
    }
}
