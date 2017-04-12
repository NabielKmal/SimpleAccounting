using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;
using ATS.EnterpriseSystem.SmartClients.EntityEditor.LookupEngine;
using ATS.EnterpriseSystem;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace ATS.Accounting
{
    public partial class AccountView : EntityEditorView
    {
        public AccountView()
        {
            InitializeComponent();

            //******************************************
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            //******************************************
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

                this.WorkItem.Services.Get<ObjectIDLookupEngine>().LookupUpdated -= new EventHandler<Microsoft.Practices.CompositeUI.Utility.DataEventArgs<LookupSource>>(AccountView_LookupUpdated);
            }
            base.Dispose(disposing);
        }

        protected override void InitializeView()
        {
            base.InitializeView();
            //Editor.Items.AddNew<EntityEditorController>();
            EntityEditorToolBar.BindToEditor(this.Editor, this.entityEditorToolBar1);
            AddControlBindings();
            AddEnumLookup();
            BindObjectIDLookup();

            this.BindToDataUnit();

            this.WorkItem.Services.Get<ObjectIDLookupEngine>().LookupUpdated += new EventHandler<Microsoft.Practices.CompositeUI.Utility.DataEventArgs<LookupSource>>(AccountView_LookupUpdated);
        }

        #region BindObjectIDLookup
        bool fUpdateLookup = false;
        void AccountView_LookupUpdated(object sender, Microsoft.Practices.CompositeUI.Utility.DataEventArgs<LookupSource> e)
        {
            ObjectIDLookupSource ols = e.Data as ObjectIDLookupSource;
            if (ols != null && (ols.LookupName == "CurrencyLookup"))
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



        void BindObjectIDLookup()
        {
            if (this.IsDisposed)
                return;
            this.rootBindingSource.SuspendBinding();
            //this.auxiliaryCurrencyID.BeginUpdate();
            this.auxiliaryCurrencyID.DataSource = this.WorkItem.Services.Get<ObjectIDLookupEngine>()["CurrencyLookup"].List;
            this.auxiliaryCurrencyID.DisplayMember = "Name";
            this.auxiliaryCurrencyID.ValueMember = "CurrencyID";
            //this.auxiliaryCurrencyID.EndUpdate();
            this.rootBindingSource.ResumeBinding();
            //this.rootBindingSource.ResetBindings(false);
        }

        #endregion

        void AddControlBindings()
        {
            this.accountKind.DataBindings.Add(new Binding("SelectedValue", rootBindingSource, "AccountKind"));
            this.accountNumber.DataBindings.Add(new Binding("Text", rootBindingSource, "AccountNumber", true, DataSourceUpdateMode.OnValidation, ""));
            this.name.DataBindings.Add(new Binding("Text", rootBindingSource, "Name"));
            this.description.DataBindings.Add(new Binding("Text", rootBindingSource, "Description"));
            this.auxiliaryOpeningBalance.DataBindings.Add(new Binding("Text", rootBindingSource, "AuxiliaryOpeningBalance", true, DataSourceUpdateMode.OnValidation, "", "N2"));
            this.auxiliaryCurrentBalance.DataBindings.Add(new Binding("Text", rootBindingSource, "AuxiliaryCurrentBalance", true, DataSourceUpdateMode.Never, "", "N2"));
            this.currentBalance.DataBindings.Add(new Binding("Text", rootBindingSource, "CurrentBalance", true, DataSourceUpdateMode.Never, "", "N2"));
            this.auxiliaryCurrencyID.DataBindings.Add(new Binding("SelectedValue", rootBindingSource, "AuxiliaryCurrencyID", true, DataSourceUpdateMode.OnPropertyChanged));
            this.exchangeRate.DataBindings.Add(new Binding("Text", rootBindingSource, "ExchangeRate"));
        }

        void AddEnumLookup()
        {
            this.accountKind.BeginUpdate();
            this.accountKind.DisplayMember = "text";
            this.accountKind.ValueMember = "value";
            this.accountKind.DataSource = this.WorkItem.Services.Get<EnumLookupEngine>()["AccountKind"].List;
            this.accountKind.EndUpdate();
        }


        DataTable tblAccount;
        protected override void BindToDataUnit()
        {
            this.rootBindingSource.DataSource = this.DataUnit.Tables["Account"];

            if (tblAccount != null)
            {
                tblAccount.ColumnChanged -= new DataColumnChangeEventHandler(tblAccount_ColumnChanged);
                tblAccount.ColumnChanging -= new DataColumnChangeEventHandler(tblAccount_ColumnChanging);
            }

            tblAccount = this.DataUnit.Tables["Account"];
            tblAccount.ColumnChanged += new DataColumnChangeEventHandler(tblAccount_ColumnChanged);
            tblAccount.ColumnChanging += new DataColumnChangeEventHandler(tblAccount_ColumnChanging);
            UpdateUI();
        }



        private void UpdateUI()
        {
            bool isNetAccount = DataUnit.ID == Constants.SystemConstants.NetAccountID;
            bool isLocalCurrency = object.Equals(Constants.SystemConstants.LocalCurrencyID, DataUnit.RootObject["AuxiliaryCurrencyID"]);
            this.accountKind.Enabled = Editor.IsNew;
            this.auxiliaryCurrencyID.Enabled = Editor.IsNew;
            this.auxiliaryOpeningBalance.ReadOnly = isNetAccount;
            this.exchangeRate.ReadOnly = isLocalCurrency && !Editor.IsNew;
            
            bool auxiliaryCurrentBalanceVisible = !isLocalCurrency || Editor.IsNew;
            this.auxiliaryCurrentBalance.Visible = auxiliaryCurrentBalanceVisible;
            this.auxiliaryCurrentBalanceLabel.Visible = auxiliaryCurrentBalanceVisible;

            try
            {
                Editor.Title = Editor.IsNew ? Properties.Resources.AccountEditor_Title : string.Format("{0} - {1}", DataUnit.RootObject["AccountNumber"], Properties.Resources.AccountEditor_Title);
            }
            catch (Exception) { }
            


        }

        protected override bool EndEdit()
        {
            bool r = false;
            if (this.Validate())
            {
                this.rootBindingSource.EndEdit();
                r = true;
            }
            return r;
        }

        public override void DisplayValidationResult(ATS.EnterpriseSystem.AppService.ValidationErrorCollection vr)
        {
            base.DisplayValidationResult(vr);
            this.errorProvider1.UpdateBinding();
        }

        #region Table Events
        void tblAccount_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {

        }

        void tblAccount_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            switch (e.Column.ColumnName)
            {
                case "AuxiliaryCurrencyID":
                    object AuxiliaryCurrencyID = e.Row["AuxiliaryCurrencyID"];
                    if (AuxiliaryCurrencyID == DBNull.Value) return;
                    e.Row["ExchangeRate"] = WorkItem.Services.Get<RootEntityService>().GetCurrencyExchangeRate((Guid)AuxiliaryCurrencyID);
                    rootBindingSource.ResetCurrentItem();
                    break;

            }
        }
        #endregion

    }
}
