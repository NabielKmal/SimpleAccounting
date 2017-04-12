using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using CrystalReportsReportDefModelLib;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
//using CrystalDecisions.CrystalReports.Engine;

namespace ATS.EnterpriseSystem.SmartClients.Reports
{
    public partial class ReportViewer : UserControl
    {
        WorkItem workItem;

        public ReportViewer()
        {
            InitializeComponent();

        }

        [ServiceDependency]
        public WorkItem WorkItem
        {
            get { return workItem; }
            set
            {
                workItem = value;
                this.InitializeView();
            }
        }

        public ReportProcess ReportProcess
        {
            get
            {
                return this.WorkItem as ReportProcess;
            }
        }

        public ReportDocument ReportDocument
        {
            get
            {
                if (this.ReportProcess != null) return this.ReportProcess.ReportDocument;
                return null;
            }
        }

        protected virtual void InitializeView()
        {

        }


        protected virtual void BindToReport()
        {
            //this.cViewer.ReportSource = this.ReportDocument;
        }

        [EventSubscription(ReportsConstants.ReportDocumentChanged)]
        public virtual void OnReportDocumentChanged(object sender, EventArgs e)
        {
            this.BindToReport();
        }
    }
}
