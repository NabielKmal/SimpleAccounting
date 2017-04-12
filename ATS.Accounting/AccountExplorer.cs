using System;
using System.Data;

using ATS.EnterpriseSystem.SmartClients;
using ATS.EnterpriseSystem.SmartClients.EntityExplorer;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace ATS.Accounting
{
    public class AccountExplorer : SimpleEntityExplorer
    {
        public AccountExplorer()
            : base((int)ObjectTypeCode.Account, "AccountID")
        { }

        protected override System.Data.DataSet DoLoadExplorerData()
        {
            DataSet ds = new DataSet();
            //Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, "Select * from vw_Account Order By AccountNumber;");
            Services.Get<IDataBaseManager>().DataBaseConnection.Fill(ds, SqlResource.SQL_Select_Account);


            foreach (DataRow x in ds.Tables[0].Rows)
            {
                if (object.Equals(Constants.SystemConstants.NetAccountID, x["AccountID"]))
                {
                    x["currentbalance"] = Services.Get<RootEntityService>().GetGeneralNet();
                    break;
                }
            }

            return ds;
        }

        [EventSubscription(ObjectChangeService.ObjectChaneEvent)]
        public void OnObjectChangeHandler(object sender, ObjectChangeEventArgs e)
        {
            if (this.TypeCode == e.ObjectTypeCode || (int)ObjectTypeCode.JournalEntry == e.ObjectTypeCode)
                Refersh();
        }
    }
}
