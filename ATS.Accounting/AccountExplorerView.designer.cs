namespace ATS.Accounting
{
    partial class AccountExplorerView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.entityExplorerToolBar1 = new ATS.EnterpriseSystem.SmartClients.EntityExplorer.EntityExplorerToolBar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auxiliaryCurrentBalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentBalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // entityExplorerToolBar1
            // 
            this.entityExplorerToolBar1.Explorer = null;
            this.entityExplorerToolBar1.Location = new System.Drawing.Point(0, 0);
            this.entityExplorerToolBar1.Name = "entityExplorerToolBar1";
            this.entityExplorerToolBar1.Size = new System.Drawing.Size(459, 25);
            this.entityExplorerToolBar1.TabIndex = 0;
            this.entityExplorerToolBar1.Text = "entityExplorerToolBar1";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountNumberColumn,
            this.nameColumn,
            this.auxiliaryCurrentBalanceColumn,
            this.currentBalanceColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(459, 277);
            this.dataGridView.TabIndex = 1;
            // 
            // accountNumberColumn
            // 
            this.accountNumberColumn.DataPropertyName = "AccountNumber";
            this.accountNumberColumn.HeaderText = "الرقم";
            this.accountNumberColumn.Name = "accountNumberColumn";
            this.accountNumberColumn.ReadOnly = true;
            this.accountNumberColumn.Width = 50;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "Name";
            this.nameColumn.HeaderText = "الأسم";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 200;
            // 
            // auxiliaryCurrentBalanceColumn
            // 
            this.auxiliaryCurrentBalanceColumn.DataPropertyName = "AuxiliaryCurrentBalance";
            dataGridViewCellStyle2.Format = "N2";
            this.auxiliaryCurrentBalanceColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.auxiliaryCurrentBalanceColumn.HeaderText = "الرصيد .ع";
            this.auxiliaryCurrentBalanceColumn.Name = "auxiliaryCurrentBalanceColumn";
            this.auxiliaryCurrentBalanceColumn.ReadOnly = true;
            this.auxiliaryCurrentBalanceColumn.Width = 150;
            // 
            // currentBalanceColumn
            // 
            this.currentBalanceColumn.DataPropertyName = "CurrentBalance";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.currentBalanceColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.currentBalanceColumn.HeaderText = "الرصيد";
            this.currentBalanceColumn.Name = "currentBalanceColumn";
            this.currentBalanceColumn.ReadOnly = true;
            this.currentBalanceColumn.Width = 150;
            // 
            // AccountExplorerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.entityExplorerToolBar1);
            this.Name = "AccountExplorerView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(459, 302);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATS.EnterpriseSystem.SmartClients.EntityExplorer.EntityExplorerToolBar entityExplorerToolBar1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn auxiliaryCurrentBalanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentBalanceColumn;
    }
}
