using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;
using ATS.EnterpriseSystem.AppService;

namespace ATS.Accounting
{
    public class AccountEditorHome : EntityEditorHome
    {
        public AccountEditorHome()
            : base((int)ObjectTypeCode.Account)
        { }

        public override IDataUnit InitializeNewDataUnit()
        {
            AccountDataUnit r = new AccountDataUnit();
            AccountRow dr =(AccountRow) r.Account.NewRow();
            dr.AccountID = Guid.NewGuid();
            dr.OrganizationID = WorkItem.Services.Get<RootEntityService>().GetRootID();
            dr.AccountKind = (short)AccountKind.Asset;
            dr.CurrentBalance = 0;
            dr.AuxiliaryCurrentBalance = 0;
            dr.AuxiliaryCurrencyID = Constants.SystemConstants.LocalCurrencyID;
            dr.ExchangeRate = 1;
            dr.AuxiliaryOpeningBalance = 0;
            r.Account.Rows.Add(dr);
            return r;
        }

        public override bool MayDeleteByUI(Guid id)
        {
            foreach (JournalEntryEditor x in this.WorkItem.WorkItems.FindByType<JournalEntryEditor>())
            {
                if (x.IsAccountReferenced(id))
                    return false;
            }
            return true;
        }
    }
}
