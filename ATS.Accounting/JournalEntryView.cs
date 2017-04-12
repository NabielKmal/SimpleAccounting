using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;
using ATS.EnterpriseSystem.SmartClients.EntityEditor.LookupEngine;
using ATS.EnterpriseSystem;

namespace ATS.Accounting
{
    public partial class JournalEntryView : EntityEditorView
    {
        private DataTable journalEntryLineTable;
        public JournalEntryView()
        {
            InitializeComponent();
            //******************************************
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            //******************************************
        }

        protected override void InitializeView()
        {
            base.InitializeView();
            AddControlBindings();
            //Editor.Title = Properties.Resources.JournalEntryEditor_Title;
            //Editor.Items.AddNew<EntityEditorController>();
            EntityEditorToolBar.BindToEditor(this.Editor, this.entityEditorToolBar1);
            AddEnumLookup();
            BindObjectIDLookup();

            this.journalEntryLineDataGridView.AutoGenerateColumns = false;
            this.journalEntryLineDataGridView.DataSource = this.journalEntryLineBindingSource;
            ControlUtil.PreventDataGridViewColumnSorting(journalEntryLineDataGridView);
            this.journalEntryLineBindingSource.AddingNew += new AddingNewEventHandler(journalEntryLineBindingSource_AddingNew);
            this.BindToDataUnit();

            this.WorkItem.Services.Get<ObjectIDLookupEngine>().LookupUpdated += new EventHandler<Microsoft.Practices.CompositeUI.Utility.DataEventArgs<LookupSource>>(JournalEntryView_LookupUpdated);
        }
         
        void AddControlBindings()
        {
            this.entryNumber.DataBindings.Add(new Binding("Text", rootBindingSource, "EntryNumber"));
            this.entryDate.DataBindings.Add(new Binding("Value", rootBindingSource, "EntryDate", true));
            this.source.DataBindings.Add(new Binding("Text", rootBindingSource, "Source"));
            this.description.DataBindings.Add(new Binding("Text", rootBindingSource, "Description"));
            this.totalDebit.DataBindings.Add(new Binding("Text", rootBindingSource, "TotalDebit", true, DataSourceUpdateMode.Never, "", "N2"));
            this.totalCredit.DataBindings.Add(new Binding("Text", rootBindingSource, "TotalCredit", true, DataSourceUpdateMode.Never, "", "N2"));

        }

        void AddEnumLookup()
        {
            this.amountSideColumn.DisplayMember = "text";
            this.amountSideColumn.ValueMember = "value";
            this.amountSideColumn.DataSource = this.WorkItem.Services.Get<EnumLookupEngine>()["DebitCredit"].List;

        }

        #region BindObjectIDLookup
        bool fUpdateLookup = false;

        void BindObjectIDLookup()
        {
            if (this.IsDisposed)
                return;
            this.accountIDColumn.DataSource = this.WorkItem.Services.Get<ObjectIDLookupEngine>()["AccountLookup"].List;
            this.accountIDColumn.ValueMember = "AccountID";
            this.accountIDColumn.DisplayMember = "DisplayName";

            this.auxiliaryCurrencyIDColumn.DataSource = this.WorkItem.Services.Get<ObjectIDLookupEngine>()["CurrencyLookup"].List;
            this.auxiliaryCurrencyIDColumn.ValueMember = "CurrencyID";
            this.auxiliaryCurrencyIDColumn.DisplayMember = "Name";
        }

        void JournalEntryView_LookupUpdated(object sender, Microsoft.Practices.CompositeUI.Utility.DataEventArgs<LookupSource> e)
        {
            ObjectIDLookupSource ols = e.Data as ObjectIDLookupSource;
            if (ols != null && (ols.LookupName == "AccountLookup" || ols.LookupName == "CurrencyLookup"))
            {
                fUpdateLookup = true;
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            try
            {
                if (fUpdateLookup)
                {
                    BindObjectIDLookup();
                }

            }
            catch (Exception)
            {
            }
            fUpdateLookup = false;
        }
        #endregion



        protected override void BindToDataUnit()
        {
            this.rootBindingSource.DataSource = this.DataUnit.Tables["JournalEntry"];
            this.journalEntryLineBindingSource.DataSource = this.DataUnit.Tables["JournalEntryLine"];

            if (this.journalEntryLineTable != null)
            {
                this.journalEntryLineTable.RowChanged -= new DataRowChangeEventHandler(journalEntryLineTable_RowChanged);
                this.journalEntryLineTable.RowDeleted -= new DataRowChangeEventHandler(journalEntryLineTable_RowChanged);
                this.journalEntryLineTable.ColumnChanged -= new DataColumnChangeEventHandler(journalEntryLineTable_ColumnChanged);
            }

            this.journalEntryLineTable = this.DataUnit.Tables["JournalEntryLine"];
            this.journalEntryLineTable.RowChanged += new DataRowChangeEventHandler(journalEntryLineTable_RowChanged);
            this.journalEntryLineTable.RowDeleted += new DataRowChangeEventHandler(journalEntryLineTable_RowChanged);
            this.journalEntryLineTable.ColumnChanged += new DataColumnChangeEventHandler(journalEntryLineTable_ColumnChanged);

            UpdateUI();
        }

        private void UpdateUI()
        {
            try
            {
                Editor.Title = Editor.IsNew ? Properties.Resources.JournalEntryEditor_Title : string.Format("#{0} - {1}", DataUnit.RootObject["EntryNumber"], Properties.Resources.JournalEntryEditor_Title);
            }
            catch (Exception) { }
        }

        protected override bool EndEdit()
        {
            bool r = false;
            if (this.Validate())
            {
                this.rootBindingSource.EndEdit();
                this.journalEntryLineBindingSource.EndEdit();
                r = true;
            }

            return r;
        }

        public override void DisplayValidationResult(ATS.EnterpriseSystem.AppService.ValidationErrorCollection vr)
        {
            base.DisplayValidationResult(vr);
            this.errorProvider1.UpdateBinding();
        }

        #region data table events
        void journalEntryLineTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            /////////////////////////////////////
            //////Test
            ////if (e.Action == DataRowAction.Delete)
            ////    throw new Exception("Invalid");
            /////////////////////////////////////
            CalocTotales();
        }

        void journalEntryLineTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            switch (e.Column.ColumnName)
            {
                case "AccountID":
                    object AccountID = e.Row["AccountID"];
                    if (AccountID == DBNull.Value) return;
                    e.Row["AuxiliaryCurrencyID"] = WorkItem.Services.Get<RootEntityService>().GetAccountCurrency((Guid)AccountID);
                    journalEntryLineBindingSource.ResetCurrentItem();
                    break;

                case "AuxiliaryCurrencyID":
                    object AuxiliaryCurrencyID = e.Row["AuxiliaryCurrencyID"];
                    if (AuxiliaryCurrencyID == DBNull.Value) return;
                    e.Row["ExchangeRate"] = WorkItem.Services.Get<RootEntityService>().GetCurrencyExchangeRate((Guid)AuxiliaryCurrencyID);
                    journalEntryLineBindingSource.ResetCurrentItem();
                    break;

                case "AuxiliaryAmount":
                case "ExchangeRate":
                    e.Row["Amount"] = DataUtil.NZ<decimal>(e.Row["AuxiliaryAmount"]) * DataUtil.NZ<decimal>(e.Row["ExchangeRate"]);
                    journalEntryLineBindingSource.ResetCurrentItem();
                    break;

            }
            CalocTotales();
        }
        #endregion
        JournalEntryDataAdapter DataUnitAdapter
        {
            get
            {
                return (JournalEntryDataAdapter)this.Editor.Home.DataUnitAdapter;
            }
        }
        private void CalocTotales()
        {
            DataRow dr = this.DataUnit.RootObject;
            dr["TotalDebit"] = this.DataUnitAdapter.Get_JournalEntry_TotalDebit(dr);
            dr["TotalCredit"] = this.DataUnitAdapter.Get_JournalEntry_TotalCredit(dr);

            this.totalCredit.DataBindings["Text"].ReadValue();
            this.totalDebit.DataBindings["Text"].ReadValue();

            System.Console.WriteLine("TotalDebit={0},   TotalCredit={1}", dr["TotalDebit"], dr["TotalCredit"]);
        }

        void journalEntryLineBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            DataView dv = (DataView)this.journalEntryLineBindingSource.List;
            DebitCredit amountSide = GetLastAmountSide();
            DataRowView drv = dv.AddNew();
            drv["JournalEntryLineID"] = Guid.NewGuid();
            drv["JournalEntryID"] = this.DataUnit.ID;
            drv["AmountSide"] = amountSide;

            e.NewObject = drv;
        }

        DebitCredit GetLastAmountSide()
        {
            DebitCredit r = DebitCredit.Debit;
            try
            {
                DataView dv = (DataView)this.journalEntryLineBindingSource.List;
                if (dv.Count > 0)
                {
                    r = (DebitCredit)(short)dv[dv.Count - 1]["AmountSide"];
                }
            }
            catch (Exception)
            {
            }

            return r;
        }
    }
}
