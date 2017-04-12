using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI.WinForms;
using System.Windows.Forms;

namespace ATS.EnterpriseSystem.SmartClients
{
    public class ShellProgram<TWorkItem, TShell> : FormShellApplication<TWorkItem, TShell>
        where TWorkItem : ApplicationWorkItem, new()
        where TShell : Form
    {
        protected override void AfterShellCreated()
        {
            base.AfterShellCreated();
            this.RootWorkItem.Shell = Shell;
        }
    }
}
