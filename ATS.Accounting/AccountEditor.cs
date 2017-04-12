using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;

namespace ATS.Accounting
{
    public class AccountEditor : EntityEditor
    {
        protected override void InitializeEditor()
        {
            base.InitializeEditor();
            //this.Title = Properties.Resources.AccountEditor_Title;
        }

        public bool IsCurrencyReferenced(Guid auxiliaryCurrencyID)
        {
            if (DataUnit == null || View == null)
                return false;
            if (object.Equals(auxiliaryCurrencyID,DataUnit.RootObject["AuxiliaryCurrencyID"]))
                return true;
            return false;
        }
    }
}
