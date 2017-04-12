using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATS.EnterpriseSystem;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;
using ATS.EnterpriseSystem.AppService;
using Microsoft.Practices.CompositeUI;
using ATS.EnterpriseSystem.SmartClients;

namespace ATS.Accounting
{
    //
    public partial class OrganizationView : Form
    {
        internal OrganizationService organizationService;
        internal DataUnit dataUnit;


        public OrganizationView()
        {
            InitializeComponent();
        }

        OrganizationService OrganizationService
        {
            get
            {
                return organizationService;
            }
        }
        public WorkItem WorkItem
        {
            get { return OrganizationService.WorkItem; }
        }

        public DataUnit DataUnit
        {
            get
            {
                return dataUnit;
            }
        }

        internal void InitializeView()
        {
            AddControlBindings();
            this.BindToDataUnit();
        }

        void AddControlBindings()
        {
            this.name.DataBindings.Add(new Binding("Text", organizationBindingSource, "Name"));
            this.city.DataBindings.Add(new Binding("Text", organizationBindingSource, "City"));
            this.stateOrProvince.DataBindings.Add(new Binding("Text", organizationBindingSource, "StateOrProvince"));
            this.postalCode.DataBindings.Add(new Binding("Text", organizationBindingSource, "PostalCode"));
            this.county.DataBindings.Add(new Binding("Text", organizationBindingSource, "County"));
            this.telephone1.DataBindings.Add(new Binding("Text", organizationBindingSource, "Telephone1"));
            this.fax.DataBindings.Add(new Binding("Text", organizationBindingSource, "Fax"));
            this.description.DataBindings.Add(new Binding("Text", organizationBindingSource, "Description"));

            this.fiscalYearStart.DataBindings.Add(new Binding("Value", organizationBindingSource, "FiscalYearStart", true));
            this.fiscalYearEnd.DataBindings.Add(new Binding("Value", organizationBindingSource, "FiscalYearEnd", true));
            this.currentDate.DataBindings.Add(new Binding("Value", organizationBindingSource, "CurrentDate", true));
        }

        protected void BindToDataUnit()
        {

            this.organizationBindingSource.DataSource = this.DataUnit.Tables["Organization"];
        }

        protected bool EndEdit()
        {
            bool r = false;
            if (this.Validate())
            {
                this.organizationBindingSource.EndEdit();
                r = true;
            }

            return r;
        }

        public virtual void DisplayValidationResult(ValidationErrorCollection vr)
        {
            ClearValidationErrors();

            foreach (ValidationError x in vr)
            {
                DataRow dr = x.Object as DataRow;
                if (dr != null)
                {
                    if (dr.Table.Columns.Contains(x.Property))
                        dr.SetColumnError(x.Property, x.ErrorText);
                }
            }
        }

        protected virtual void ClearValidationErrors()
        {
            if (this.DataUnit == null) return;
            //this.DataUnit.ClearErrors();
            foreach (DataTable x in DataUnit.Tables)
            {
                foreach (DataRow x2 in x.Rows)
                {
                    x2.ClearErrors();
                }
            }
        }

        protected virtual bool SaveCore()
        {
            bool r = false;

            try
            {

                if (!EndEdit()) return false;

                ValidationErrorCollection vr = this.OrganizationService.DataAdapter.Validate(this.DataUnit);
                DisplayValidationResult(vr);
                if (!vr.IsValid)
                {
                    this.WorkItem.Services.Get<IUIService>().Show(ATS.EnterpriseSystem.Properties.Resources.InvalidDataMsg, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }

                this.OrganizationService.DataAdapter.Save(this.DataUnit);
                r = true;
            }
            catch (Exception ex)
            {
                this.WorkItem.Services.Get<IUIService>().ShowException(ex);
                r = false;

            }
            return r;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SaveCore())
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }



    }
}
