using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATS.EnterpriseSystem.SmartClients.EntityExplorer;
using ATS.EnterpriseSystem.SmartClients;
using ATS.EnterpriseSystem;

namespace ATS.Accounting
{
    public partial class JournalEntryExplorerView : EntityExplorerView
    {
        public JournalEntryExplorerView()
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

            this.bindingSource.CurrentItemChanged += new EventHandler(bindingSource_CurrentItemChanged);

            BindToExplorerData();
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
