namespace ATS.Accounting
{
    partial class OrganizationView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.description = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.telephone1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.county = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.postalCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stateOrProvince = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.currentDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.fiscalYearEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.fiscalYearStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.organizationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.organizationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "موافق";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "إلغاء الأمر";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(461, 275);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.description);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.fax);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.telephone1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.county);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.postalCode);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.stateOrProvince);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.city);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.name);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(453, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "المنظمة";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.description, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.description.Location = new System.Drawing.Point(3, 189);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(349, 60);
            this.description.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "الوصف";
            // 
            // fax
            // 
            this.fax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.fax, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.fax.Location = new System.Drawing.Point(209, 163);
            this.fax.Name = "fax";
            this.fax.Size = new System.Drawing.Size(143, 20);
            this.fax.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(404, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "الفاكس";
            // 
            // telephone1
            // 
            this.telephone1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.telephone1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.telephone1.Location = new System.Drawing.Point(209, 137);
            this.telephone1.Name = "telephone1";
            this.telephone1.Size = new System.Drawing.Size(143, 20);
            this.telephone1.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "التليفون";
            // 
            // county
            // 
            this.county.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.county, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.county.Location = new System.Drawing.Point(209, 111);
            this.county.Name = "county";
            this.county.Size = new System.Drawing.Size(143, 20);
            this.county.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(418, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "البلد";
            // 
            // postalCode
            // 
            this.postalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.postalCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.postalCode.Location = new System.Drawing.Point(209, 85);
            this.postalCode.Name = "postalCode";
            this.postalCode.Size = new System.Drawing.Size(143, 20);
            this.postalCode.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "صندوق البريد";
            // 
            // stateOrProvince
            // 
            this.stateOrProvince.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.stateOrProvince, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.stateOrProvince.Location = new System.Drawing.Point(209, 59);
            this.stateOrProvince.Name = "stateOrProvince";
            this.stateOrProvince.Size = new System.Drawing.Size(143, 20);
            this.stateOrProvince.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "الولاية او المحافظة";
            // 
            // city
            // 
            this.city.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.city, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.city.Location = new System.Drawing.Point(209, 33);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(143, 20);
            this.city.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "المدينة";
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.name, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.name.Location = new System.Drawing.Point(59, 7);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(293, 20);
            this.name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "الأسم";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.currentDate);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.fiscalYearEnd);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.fiscalYearStart);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(453, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "السنة المحاسبية";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // currentDate
            // 
            this.currentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.currentDate, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.currentDate.Location = new System.Drawing.Point(157, 66);
            this.currentDate.Name = "currentDate";
            this.currentDate.RightToLeftLayout = true;
            this.currentDate.Size = new System.Drawing.Size(200, 20);
            this.currentDate.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(377, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "التاريخ الحالي";
            // 
            // fiscalYearEnd
            // 
            this.fiscalYearEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.fiscalYearEnd, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.fiscalYearEnd.Location = new System.Drawing.Point(157, 40);
            this.fiscalYearEnd.Name = "fiscalYearEnd";
            this.fiscalYearEnd.RightToLeftLayout = true;
            this.fiscalYearEnd.Size = new System.Drawing.Size(200, 20);
            this.fiscalYearEnd.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(374, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "التاريخ النهائي";
            // 
            // fiscalYearStart
            // 
            this.fiscalYearStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider1.SetIconAlignment(this.fiscalYearStart, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.fiscalYearStart.Location = new System.Drawing.Point(157, 14);
            this.fiscalYearStart.Name = "fiscalYearStart";
            this.fiscalYearStart.RightToLeftLayout = true;
            this.fiscalYearStart.Size = new System.Drawing.Size(200, 20);
            this.fiscalYearStart.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "التاريخ الأفتتاحي";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.organizationBindingSource;
            // 
            // OrganizationView
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(461, 313);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrganizationView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيانات المنظمة";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.organizationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox postalCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox stateOrProvince;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fiscalYearStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker fiscalYearEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource organizationBindingSource;
        private System.Windows.Forms.TextBox fax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox telephone1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox county;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker currentDate;
        private System.Windows.Forms.Label label11;

    }
}
