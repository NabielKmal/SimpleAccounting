namespace ATS.EnterpriseSystem.SmartClients.Reports
{
    partial class ReportViewer
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
            this.cViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cViewer
            // 
            this.cViewer.ActiveViewIndex = -1;
            this.cViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cViewer.DisplayGroupTree = false;
            this.cViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cViewer.Location = new System.Drawing.Point(0, 0);
            this.cViewer.Name = "cViewer";
            this.cViewer.SelectionFormula = "";
            this.cViewer.Size = new System.Drawing.Size(492, 323);
            this.cViewer.TabIndex = 0;
            this.cViewer.ViewTimeSelectionFormula = "";
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cViewer);
            this.Name = "ReportViewer";
            this.Size = new System.Drawing.Size(492, 323);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cViewer;

    }
}
