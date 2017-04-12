namespace ATS.Accounting
{
    partial class JournalEntryView
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
                if (this.WorkItem != null)
                    this.WorkItem.Items.Remove(this);
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
            this.entityEditorToolBar1 = new ATS.EnterpriseSystem.SmartClients.EntityEditor.EntityEditorToolBar();
            this.source = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.entryDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.entryNumber = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.journalEntryLineDataGridView = new System.Windows.Forms.DataGridView();
            this.accountIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.amountSideColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.auxiliaryAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auxiliaryCurrencyIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ExchangeRateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rootBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.journalEntryLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalDebit = new System.Windows.Forms.TextBox();
            this.totalCredit = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.journalEntryLineDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalEntryLineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // entityEditorToolBar1
            // 
            this.entityEditorToolBar1.Editor = null;
            this.entityEditorToolBar1.Location = new System.Drawing.Point(0, 0);
            this.entityEditorToolBar1.Name = "entityEditorToolBar1";
            this.entityEditorToolBar1.Size = new System.Drawing.Size(744, 25);
            this.entityEditorToolBar1.TabIndex = 6;
            this.entityEditorToolBar1.Text = "entityEditorToolBar1";
            // 
            // source
            // 
            this.source.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.source, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.source.Location = new System.Drawing.Point(322, 53);
            this.source.MaxLength = 50;
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(121, 20);
            this.source.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.errorProvider1.SetIconAlignment(this.label1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.label1.Location = new System.Drawing.Point(449, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "المرجع";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(696, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "التاريخ";
            // 
            // entryDate
            // 
            this.entryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.entryDate, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.entryDate.Location = new System.Drawing.Point(555, 53);
            this.entryDate.Name = "entryDate";
            this.entryDate.RightToLeftLayout = true;
            this.entryDate.Size = new System.Drawing.Size(121, 20);
            this.entryDate.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(682, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "رقم القيد";
            // 
            // entryNumber
            // 
            this.entryNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.entryNumber, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.entryNumber.Location = new System.Drawing.Point(555, 28);
            this.entryNumber.Name = "entryNumber";
            this.entryNumber.ReadOnly = true;
            this.entryNumber.Size = new System.Drawing.Size(121, 20);
            this.entryNumber.TabIndex = 6;
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.description, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.description.Location = new System.Drawing.Point(322, 79);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(354, 60);
            this.description.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(694, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "الوصف";
            // 
            // journalEntryLineDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.journalEntryLineDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.journalEntryLineDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.journalEntryLineDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.journalEntryLineDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountIDColumn,
            this.amountSideColumn,
            this.auxiliaryAmountColumn,
            this.auxiliaryCurrencyIDColumn,
            this.ExchangeRateColumn,
            this.amountColumn});
            this.journalEntryLineDataGridView.Location = new System.Drawing.Point(44, 145);
            this.journalEntryLineDataGridView.Name = "journalEntryLineDataGridView";
            this.journalEntryLineDataGridView.Size = new System.Drawing.Size(697, 230);
            this.journalEntryLineDataGridView.TabIndex = 3;
            // 
            // accountIDColumn
            // 
            this.accountIDColumn.DataPropertyName = "AccountID";
            this.accountIDColumn.Frozen = true;
            this.accountIDColumn.HeaderText = "الحســاب";
            this.accountIDColumn.Name = "accountIDColumn";
            this.accountIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.accountIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.accountIDColumn.Width = 150;
            // 
            // amountSideColumn
            // 
            this.amountSideColumn.DataPropertyName = "AmountSide";
            this.amountSideColumn.HeaderText = "م/د";
            this.amountSideColumn.Name = "amountSideColumn";
            // 
            // auxiliaryAmountColumn
            // 
            this.auxiliaryAmountColumn.DataPropertyName = "AuxiliaryAmount";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.auxiliaryAmountColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.auxiliaryAmountColumn.HeaderText = "المبلغ .ع";
            this.auxiliaryAmountColumn.Name = "auxiliaryAmountColumn";
            // 
            // auxiliaryCurrencyIDColumn
            // 
            this.auxiliaryCurrencyIDColumn.DataPropertyName = "AuxiliaryCurrencyID";
            this.auxiliaryCurrencyIDColumn.HeaderText = "العملة";
            this.auxiliaryCurrencyIDColumn.Name = "auxiliaryCurrencyIDColumn";
            // 
            // ExchangeRateColumn
            // 
            this.ExchangeRateColumn.DataPropertyName = "ExchangeRate";
            this.ExchangeRateColumn.HeaderText = "سعر الصرف";
            this.ExchangeRateColumn.Name = "ExchangeRateColumn";
            // 
            // amountColumn
            // 
            this.amountColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.amountColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.amountColumn.HeaderText = "المبلغ";
            this.amountColumn.Name = "amountColumn";
            this.amountColumn.ReadOnly = true;
            // 
            // totalDebit
            // 
            this.totalDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalDebit.Location = new System.Drawing.Point(147, 381);
            this.totalDebit.MaxLength = 4;
            this.totalDebit.Name = "totalDebit";
            this.totalDebit.ReadOnly = true;
            this.totalDebit.Size = new System.Drawing.Size(97, 20);
            this.totalDebit.TabIndex = 4;
            this.toolTip1.SetToolTip(this.totalDebit, "إجمالي المدين");
            // 
            // totalCredit
            // 
            this.totalCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.totalCredit, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.totalCredit.Location = new System.Drawing.Point(44, 381);
            this.totalCredit.MaxLength = 4;
            this.totalCredit.Name = "totalCredit";
            this.totalCredit.ReadOnly = true;
            this.totalCredit.Size = new System.Drawing.Size(97, 20);
            this.totalCredit.TabIndex = 5;
            this.toolTip1.SetToolTip(this.totalCredit, "إجمالي الدائن");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.rootBindingSource;
            // 
            // JournalEntryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.journalEntryLineDataGridView);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.entryDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.entryNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalCredit);
            this.Controls.Add(this.totalDebit);
            this.Controls.Add(this.source);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entityEditorToolBar1);
            this.Name = "JournalEntryView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(744, 405);
            ((System.ComponentModel.ISupportInitialize)(this.journalEntryLineDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalEntryLineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATS.EnterpriseSystem.SmartClients.EntityEditor.EntityEditorToolBar entityEditorToolBar1;
        private System.Windows.Forms.TextBox source;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker entryDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox entryNumber;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView journalEntryLineDataGridView;
        private System.Windows.Forms.BindingSource rootBindingSource;
        private System.Windows.Forms.BindingSource journalEntryLineBindingSource;
        private System.Windows.Forms.TextBox totalDebit;
        private System.Windows.Forms.TextBox totalCredit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewComboBoxColumn accountIDColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn amountSideColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn auxiliaryAmountColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn auxiliaryCurrencyIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExchangeRateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountColumn;
    }
}
