using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ATS.EnterpriseSystem.SmartClients;
using ATS.EnterpriseSystem.AppService;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using ATS.EnterpriseSystem.SmartClients.UIProcess;
using ATS.EnterpriseSystem.SmartClients.EntityEditor;
using ATS.EnterpriseSystem.SmartClients.EntityEditor.LookupEngine;
using ATS.EnterpriseSystem.SmartClients.Reports;
using System.Data.OleDb;

namespace ATS.Accounting
{
    public class Program : ShellProgram<ApplicationWorkItem, MainWindow>
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                new Program().Run();
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.ErrorMsg001, Application.ProductName);
            }
        }

        protected override void AfterShellCreated()
        {
            base.AfterShellCreated();
            InitializeSystem();
            HandleCommandLineArgs();

            Testing();

            Shell.UpdateShell();

        }

        private void Testing()
        {
            if (!System.Diagnostics.Debugger.IsAttached)
                return;
            RootWorkItem.Services.Get<IDataBaseManager>().Open("DBAccountingC.mdb");
            Console.WriteLine(RootWorkItem.Services.Get<RootEntityService>().IsAccoutingEquationCorrect());
        }

        void HandleCommandLineArgs()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args == null || args.Length != 2)
                return;
            string file = args[1];
            if (string.IsNullOrEmpty(file))
                return;
            RootWorkItem.Services.Get<IDataBaseManager>().Open(file);
        }

        private void InitializeSystem()
        {
            this.RootWorkItem.Services.AddNew<UIService, IUIService>();
            this.RootWorkItem.Services.AddNew<ObjectChangeService, IObjectChangeService>();
            this.RootWorkItem.Services.AddNew<SystemInfoService, ISystemInfoService>();

            // 
            // DataBaseManager
            // 
            DataBaseManager dbm = new DataBaseManager(RootWorkItem, new OleDataBaseConnection());
            RootWorkItem.Services.Add(typeof(IDataBaseManager), dbm);
            RootWorkItem.Services.Add(typeof(IDACContext), new DACContext(dbm.DataBaseConnection, null));
            RootWorkItem.Services.AddNew<OrganizationService>();
            // 
            // RootEntityService
            // 
            RootEntityService rootEntityService = new RootEntityService(dbm.DataBaseConnection);
            RootWorkItem.Services.Add(typeof(IRootEntityService), rootEntityService);
            RootWorkItem.Services.Add(typeof(RootEntityService), rootEntityService);
            // 
            // mainWorkspace
            // 
            IWorkspace mainWorkspace = null;
            //////IDEWorkspace mainWorkspace = new IDEWorkspace(Shell.tabControl1);
            //////this.RootWorkItem.Workspaces.Add(mainWorkspace, Constants.WorkspaceConstants.MainWorkspace);

            mainWorkspace = new DockWorkspace(Shell.dockPanel1);
            this.RootWorkItem.Workspaces.Add(mainWorkspace, Constants.WorkspaceConstants.MainWorkspace);
            WindowWorkspace windowWorkspace = new WindowWorkspace(Shell);
            this.RootWorkItem.Workspaces.Add(windowWorkspace, Constants.WorkspaceConstants.WindowWorkspace);

            // 
            // TypeCodeRegistry
            // 
            RootWorkItem.Services.Add(typeof(TypeCodeRegistry), new TypeCodeRegistry());
            ////RootWorkItem.Services.Get<TypeCodeRegistry>().Add((int)ObjectTypeCode.Organization,
            ////    new TypeCodeInfo(typeof(OrganizationComponent), typeof(OrganizationDataAdapter), typeof(OrganizationEditor), typeof(OrganizationView)));
            RootWorkItem.Services.Get<TypeCodeRegistry>().Add((int)ObjectTypeCode.Account,
                new TypeCodeInfo(typeof(AccountDataUnit), typeof(AccountDataAdapter), typeof(AccountEditor), typeof(AccountView)));
            RootWorkItem.Services.Get<TypeCodeRegistry>().Add((int)ObjectTypeCode.JournalEntry,
                new TypeCodeInfo(typeof(JournalEntryDataUnit), typeof(JournalEntryDataAdapter), typeof(JournalEntryEditor), typeof(JournalEntryView)));
            RootWorkItem.Services.Get<TypeCodeRegistry>().Add((int)ObjectTypeCode.Currency,
                new TypeCodeInfo(typeof(CurrencyDataUnit), typeof(CurrencyDataAdapter), typeof(CurrencyEditor), typeof(CurrencyView)));
            // 
            // EntityEditorHomeManager
            // 
            EntityEditorHomeManager ehm = new EntityEditorHomeManager(RootWorkItem, mainWorkspace);
            RootWorkItem.Services.Add(typeof(EntityEditorHomeManager), ehm);
            ////ehm.Add(new OrganizationHome());
            ehm.Add(new AccountEditorHome());
            ehm.Add(new JournalEntryHome());
            ehm.Add(new CurrencyEditorHome());
            // 
            // UIProcessHomeManager
            // 
            UIProcessHomeManager upm = new UIProcessHomeManager(RootWorkItem, mainWorkspace);
            RootWorkItem.Services.Add(typeof(UIProcessHomeManager), upm);
            upm.Add(new SDIProcessHome("AccountExplorer", new UIProcessSettings(Properties.Resources.Account_Explorer_Title, typeof(AccountExplorer), typeof(AccountExplorerView)), null));
            upm.Add(new SDIProcessHome("JournalEntryExplorer", new UIProcessSettings(Properties.Resources.Journal_Entry_Explorer_Title, typeof(JournalEntryExplorer), typeof(JournalEntryExplorerView)), null));
            upm.Add(new SDIProcessHome("CurrencyExplorer", new UIProcessSettings(Properties.Resources.Currency_Explorer_Title, typeof(CurrencyExplorer), typeof(CurrencyExplorerView)), null));

            upm.Add(new SDIProcessHome("RepGeneralJournalProcess", new UIProcessSettings(Properties.Resources.RepGeneral_Journal, typeof(RepGeneralJournalProcess), typeof(ReportViewer)), null));
            upm.Add(new SDIProcessHome("RepGeneralLedgerProcess", new UIProcessSettings(Properties.Resources.RepGeneralLedger, typeof(RepGeneralLedgerProcess), typeof(ReportViewer)), null));
            upm.Add(new SDIProcessHome("RepBlanceSheetProcess", new UIProcessSettings(Properties.Resources.RepBlanceSheet, typeof(RepBlanceSheetProcess), typeof(ReportViewer)), null));
            upm.Add(new SDIProcessHome("RepIncomeStatementProcess", new UIProcessSettings(Properties.Resources.RepIncomeStatement, typeof(RepIncomeStatementProcess), typeof(ReportViewer)), null));
            upm.Add(new SDIProcessHome("RepTrialBalanceProcess", new UIProcessSettings(Properties.Resources.RepTrialBalanceProcess, typeof(RepTrialBalanceProcess), typeof(ReportViewer)), null));

            //
            // 
            // EnumLookupEngine
            // 
            EnumLookupEngine enumEngine = new EnumLookupEngine();
            this.RootWorkItem.Services.Add(enumEngine);
            enumEngine.Add("AccountKind", GetAccountKindValues());
            enumEngine.Add("DebitCredit", GetDebitCreditValues());


            // 
            // objectLookupEngine
            // 
            ObjectIDLookupEngine objectLookupEngine = new ObjectIDLookupEngine();
            this.RootWorkItem.Services.Add(objectLookupEngine);

            System.Data.OleDb.OleDbCommand cmd = null;

            //objectLookupEngine.Add("CurrencyLookup", this.RootWorkItem.Services.Get<IDataBaseManager>().DataBaseConnection, (int)ObjectTypeCode.Currency, "SELECT CurrencyID , [Name] from [Currency] ORDER BY [NAME]");
            cmd = new System.Data.OleDb.OleDbCommand();
            cmd = new OleDbCommand("Select * from [Currency] Order By IIf([CurrencyID]=?,0,1) , [Name];");
            cmd.Parameters.AddWithValue("LocalCurrencyID", Constants.SystemConstants.LocalCurrencyID);
            objectLookupEngine.Add("CurrencyLookup", this.RootWorkItem.Services.Get<IDataBaseManager>().DataBaseConnection, (int)ObjectTypeCode.Currency, cmd);

            cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "SELECT `AccountID`,AccountNumber + ' '+ Name as DisplayName FROM `Account` WHERE AccountID<>?  ORDER BY AccountNumber";
            cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("", Constants.SystemConstants.NetAccountID));
            objectLookupEngine.Add("AccountLookup", this.RootWorkItem.Services.Get<IDataBaseManager>().DataBaseConnection, (int)ObjectTypeCode.Account, cmd);


        }

        Dictionary<string, short> GetAccountKindValues()
        {
            Dictionary<string, short> r = new Dictionary<string, short>();
            r.Add("اصل", 1);
            r.Add("خصم", 2);
            r.Add("حق ملكية", 3);
            r.Add("إيراد", 4);
            r.Add("مصروف", 5);
            return r;
        }

        Dictionary<string, short> GetDebitCreditValues()
        {
            Dictionary<string, short> r = new Dictionary<string, short>();
            r.Add("مدين", 1);
            r.Add("دائن", 2);
            return r;
        }
    }
}
