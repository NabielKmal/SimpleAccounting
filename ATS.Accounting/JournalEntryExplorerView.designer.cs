namespace ATS.Accounting
{
    partial class JournalEntryExplorerView
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.journalEntryEntryNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entryDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityExplorerToolBar1 = new ATS.EnterpriseSystem.SmartClients.EntityExplorer.EntityExplorerToolBar();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.journalEntryEntryNumberColumn,
            this.entryDateColumn,
            this.descriptionColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(459, 277);
            this.dataGridView.TabIndex = 3;
            // 
            // journalEntryEntryNumberColumn
            // 
            this.journalEntryEntryNumberColumn.DataPropertyName = "EntryNumber";
            this.journalEntryEntryNumberColumn.HeaderText = "الرقم";
            this.journalEntryEntryNumberColumn.Name = "journalEntryEntryNumberColumn";
            this.journalEntryEntryNumberColumn.ReadOnly = true;
            // 
            // entryDateColumn
            // 
            this.entryDateColumn.DataPropertyName = "EntryDate";
            this.entryDateColumn.HeaderText = "التاريخ";
            this.entryDateColumn.Name = "entryDateColumn";
            this.entryDateColumn.ReadOnly = true;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.DataPropertyName = "Description";
            this.descriptionColumn.HeaderText = "البيان";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            this.descriptionColumn.Width = 200;
            // 
            // entityExplorerToolBar1
            // 
            this.entityExplorerToolBar1.Explorer = null;
            this.entityExplorerToolBar1.Location = new System.Drawing.Point(0, 0);
            this.entityExplorerToolBar1.Name = "entityExplorerToolBar1";
            this.entityExplorerToolBar1.Size = new System.Drawing.Size(459, 25);
            this.entityExplorerToolBar1.TabIndex = 2;
            this.entityExplorerToolBar1.Text = "entityExplorerToolBar1";
            // 
            // JournalEntryExplorerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.entityExplorerToolBar1);
            this.Name = "JournalEntryExplorerView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(459, 302);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private ATS.EnterpriseSystem.SmartClients.EntityExplorer.EntityExplorerToolBar entityExplorerToolBar1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn journalEntryEntryNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
    }
}
