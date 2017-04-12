using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ATS.EnterpriseSystem.SmartClients.EntityExplorer;
using ATS.EnterpriseSystem.SmartClients;
using ATS.EnterpriseSystem;

namespace ATS.Accounting
{
    public partial class AccountExplorerView : EntityExplorerView
    {
        public AccountExplorerView()
        {
            InitializeComponent();
        }

        protected override void InitializeView()
        {
            EntityExplorerToolBar.BindToExplorer(Explorer, entityExplorerToolBar1);

            this.dataGridView.ReadOnly = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.MultiSelect = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.RowHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(dataGridView_RowHeaderMouseDoubleClick);
            this.dataGridView.KeyDown += new KeyEventHandler(dataGridView_KeyDown);
            this.dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView_CellDoubleClick);
            this.dataGridView.DataSource = this.bindingSource;
            ControlUtil.PreventDataGridViewColumnSorting(this.dataGridView);

            dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

            this.bindingSource.CurrentItemChanged += new EventHandler(bindingSource_CurrentItemChanged);

            BindToExplorerData();
        }

        void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == auxiliaryCurrentBalanceColumn.Index)
            {
                
                DataRowView drv = (DataRowView)bindingSource[e.RowIndex];
                if (object.Equals(drv["AuxiliaryCurrencyID"], Constants.SystemConstants.LocalCurrencyID))
                {
                    e.FormattingApplied = true;
                    e.Value = "";
                }
                else
                {
                    string symbol = (string)drv["AuxiliaryCurrencyIDSymbol"].ToString();
                    double auxiliaryCurrentBalance =DataUtil.NZ<double>(drv["AuxiliaryCurrentBalance"]);
                    e.FormattingApplied = true;
                    e.Value = string.Format("{0} {1}", auxiliaryCurrentBalance.ToString("N2"), symbol);
                }
            }
        }

        

        void bindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current == null)
            {
                this.WorkItem.Services.Get<ISelectionService>().SetSelectedObjects(new object[] { }, SelectionTypes.Normal);
            }
            else
            {
                this.WorkItem.Services.Get<ISelectionService>().SetSelectedObjects(new object[] { bindingSource.Current }, SelectionTypes.Normal);
            }
        }

        #region dataGridView
        void dataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Explorer.OpenObject();
        }

        void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Explorer.OpenObject();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.Explorer.DeleteObject();
                e.Handled = true;
            }
        }

        void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            { return; }

            this.Explorer.OpenObject();
        }
        #endregion

        protected override void BindToExplorerData()
        {
            base.BindToExplorerData();
            if (this.ExplorerData != null)
                this.bindingSource.DataSource = this.ExplorerData.Tables[0];
        }

        


    }
}
