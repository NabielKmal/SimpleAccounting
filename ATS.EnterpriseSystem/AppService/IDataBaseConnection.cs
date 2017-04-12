////إصدار جديد بتاريخ 21-اغسطس-2008
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ATS.EnterpriseSystem.AppService
{
    public interface IConnectionControler : IDisposable
    {
        string ConnectionString { get; }

        ConnectionState State { get; }
        bool InTransaction { get; }
        bool IsOpen();

        void Close();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <exception cref="">العنصر في حالة اتصال مسبقاً</exception>
        /// <exception cref=""></exception>
        /// <exception cref=""></exception>
        void Open(string connectionString);

        /// <summary>
        /// 
        /// </summary>
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }


    /// <summary>
    /// 
    /// </summary>
    public partial interface IDataBaseConnection : IConnectionControler
    {
        DbProviderFactory ProviderFactory { get; }

        #region Fill

        #region Sql
        int Fill(DataTable tbl, string sql);
        DataTable Fill(string sql);

        int Fill(DataSet ds, string sql);
        int Fill(DataSet ds, string srcTable, string sql);

        int Fill(System.Data.DataSet dataSet, string srcTable, string sql, int startRecord, int maxRecords);
        #endregion

        #region Command
        int Fill(DataTable tbl, DbCommand cmd);
        DataTable Fill(DbCommand cmd);

        int Fill(DataSet ds, DbCommand cmd);
        int Fill(DataSet ds, string srcTable, DbCommand cmd);

        int Fill(System.Data.DataSet dataSet, string srcTable, DbCommand cmd, int startRecord, int maxRecords);
        #endregion

        #endregion

        #region Execute

        #region Sql
        int ExecuteNonQuery(string sql);
        DbDataReader ExecuteReader(string sql);
        DbDataReader ExecuteReader(string sql, CommandBehavior behavior);
        object ExecuteScalar(string sql);
        #endregion

        #region Command
        int ExecuteNonQuery(DbCommand cmd);
        DbDataReader ExecuteReader(DbCommand cmd);
        DbDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior);
        object ExecuteScalar(DbCommand cmd);
        #endregion

        #endregion

        int UpdateDataSet(DataSet dataSet,
         string tableName,
         DbCommand insertCommand,
         DbCommand updateCommand,
         DbCommand deleteCommand);
    }




    ///// <summary>
    ///// ICommandHelper
    ///// </summary>
    //public partial interface IDataBaseConnection
    //{






    //}





    //public interface IDataBaseContext
    //{
    //    DbConnection Connection { get; }
    //    DbTransaction Transaction { get; }

    //}




}
