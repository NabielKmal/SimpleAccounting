using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;

namespace ATS.Accounting
{
    public partial class CurrencyView : EntityEditorView
    {
        public CurrencyView()
        {
            InitializeComponent();
            //******************************************
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            //******************************************
        }

        protected override void InitializeView()
        {
            base.InitializeView();
            //Editor.Items.AddNew<EntityEditorController>();
            EntityEditorToolBar.BindToEditor(this.Editor, this.entityEditorToolBar1);
            AddControlBindings();
            this.BindToDataUnit();
        }

        void AddControlBindings()
        {
            this.name.DataBindings.Add(new Binding("Text", rootBindingSource, "Name"));
            this.exchangeRate.DataBindings.Add(new Binding("Text", rootBindingSource, "ExchangeRate"));
            this.decimalPlaces.DataBindings.Add(new Binding("Text", rootBindingSource, "DecimalPlaces"));
            this.symbol.DataBindings.Add(new Binding("Text", rootBindingSource, "Symbol"));
            this.description.DataBindings.Add(new Binding("Text", rootBindingSource, "Description"));
            
        }

        protected override void BindToDataUnit()
        {
            rootBindingSource.DataSource = this.DataUnit.Tables["Currency"];
            UpdateUI();
        }

        private void UpdateUI()
        {
            bool isLocalCurrency = DataUnit.ID == Constants.SystemConstants.LocalCurrencyID;
            exchangeRate.ReadOnly = isLocalCurrency;

            try
            {
                Editor.Title = Editor.IsNew ? Properties.Resources.CurrencyEditor_Title : string.Format("{0} - {1}", DataUnit.RootObject["Name"], Properties.Resources.CurrencyEditor_Title);
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
    }
}
