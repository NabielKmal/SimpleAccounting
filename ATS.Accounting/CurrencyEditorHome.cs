using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;

namespace ATS.Accounting
{
    public class CurrencyEditorHome : EntityEditorHome
    {
        public CurrencyEditorHome()
            : base((int)ObjectTypeCode.Currency)
        { }

        public override ATS.EnterpriseSystem.AppService.IDataUnit InitializeNewDataUnit()
        {
            CurrencyDataUnit r = new CurrencyDataUnit();
            CurrencyRow dr = (CurrencyRow)r.Currency.NewRow();
            dr.CurrencyID = Guid.NewGuid();
            dr.OrganizationID = WorkItem.Services.Get<RootEntityService>().GetRootID();
            dr.DecimalPlaces = 2;
            dr.ExchangeRate = 1;
            r.Currency.Rows.Add(dr);
            return r;

        }

        public override bool MayDeleteByUI(Guid id)
        {
            foreach (AccountEditor x in this.WorkItem.WorkItems.FindByType<AccountEditor>())
            {
                if (x.IsCurrencyReferenced(id))
                    return false;
            }

            foreach (JournalEntryEditor x in this.WorkItem.WorkItems.FindByType<JournalEntryEditor>())
            {
                if (x.IsCurrencyReferenced(id))
                    return false;
            }
            return true;
        }
    }
}
