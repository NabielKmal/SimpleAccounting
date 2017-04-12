using System;
using System.Collections.Generic;
using System.Text;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;
using System.Data;

namespace ATS.Accounting
{
    public class JournalEntryEditor : EntityEditor
    {
        protected override void InitializeEditor()
        {
            base.InitializeEditor();
            //this.Items.AddNew<EntityEditorController>();
            //this.Title = Properties.Resources.JournalEntryEditor_Title;
        }

        public bool IsAccountReferenced(Guid accountID)
        {
            if (DataUnit == null || View == null)
                return false;
            foreach (DataRow x in DataUnit.Tables["JournalEntryLine"].Select(null, null, DataViewRowState.CurrentRows))
            {
                if (object.Equals(accountID, x["AccountID"]))
                    return true;
            }
            return false;
        }

        public bool IsCurrencyReferenced(Guid auxiliaryCurrencyID)
        {
            if (DataUnit == null || View == null)
                return false;
            foreach (DataRow x in DataUnit.Tables["JournalEntryLine"].Select(null, null, DataViewRowState.CurrentRows))
            {
                if (object.Equals(auxiliaryCurrencyID, x["AuxiliaryCurrencyID"]))
                    return true;
            }
            return false;
        }
    }
}
