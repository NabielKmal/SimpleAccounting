using System;
using System.Collections.Generic;

using System.Text;
//using CrystalDecisions.CrystalReports.Engine;
using CrystalReportsReportDefModelLib;
using Microsoft.Practices.CompositeUI.EventBroker;

namespace ATS.EnterpriseSystem.SmartClients.Reports
{
    //
    public class ReportProcess : UIProcess.UIProcess
    {
        private ReportDocument reportDocument;

        public ReportDocument ReportDocument
        {
            get { return reportDocument; }
            set 
            {
                reportDocument = value;
                this.OnReportDocumentChanged(EventArgs.Empty);
            }
        }

        [EventPublication(ReportsConstants.ReportDocumentChanged, PublicationScope.WorkItem)]
        public event EventHandler ReportDocumentChanged;

        protected virtual void OnReportDocumentChanged(EventArgs e)
        {
            if (this.ReportDocumentChanged != null)
                this.ReportDocumentChanged(this, e);
        }

        protected void LoadReportDocument()
        {
            ThrowIfWorkItemTerminated();
            ReportDocument rep = null;// LoadReportDocumentCore();
            AV.CheckForNullReference(rep);
            this.ReportDocument = rep;
        }

        //protected virtual ReportDocument LoadReportDocumentCore()
        //{
        //    return null;
        //}

        public void Refersh()
        {
            LoadReportDocument();
        }

        private bool firstRun = true;

        protected override void RunCore(object args)
        {
            base.RunCore(args);
            if (firstRun)
            {
                firstRun = false;
                LoadReportDocument();
            }
            Activate();
        }


    }
}
