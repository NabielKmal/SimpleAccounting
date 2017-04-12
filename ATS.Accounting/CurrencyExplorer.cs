using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.EntityExplorer;
using ATS.EnterpriseSystem.SmartClients;
using System.Data;
using System.Data.OleDb;

namespace ATS.Accounting
{
    public class CurrencyExplorer : SimpleEntityExplorer
    {
        public CurrencyExplorer()
            : base((int)ObjectTypeCode.Currency, "CurrencyID")
        { }

        protected override System.Data.DataSet DoLoadExplorerData()
        {
            DataSet ds = new DataSet();
            //Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "Select * from [vw_Currency] Order By [Name];");
            // 
            //OleDbCommand cmd = new OleDbCommand("Select * , IIf([CurrencyID]=?,0,1) AS ExplorerPriority from [vw_Currency] Order By ExplorerPriority , [Name];");
            OleDbCommand cmd = new OleDbCommand("Select * from [vw_Currency] Order By IIf([CurrencyID]=?,0,1) , [Name];");
            cmd.Parameters.AddWithValue("LocalCurrencyID", Constants.SystemConstants.LocalCurrencyID);
            Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, cmd);
            
            return ds;
        }
    }
}
