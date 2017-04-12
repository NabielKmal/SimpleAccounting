using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI;
using System.Windows.Forms;

namespace ATS.EnterpriseSystem.SmartClients
{
    public class ApplicationWorkItem : WorkItem
    {
        //
        Form shell;
        public Form Shell
        {
            get
            {
                return shell;
            }
            set
            {
                shell = value;
            }
        }

    }
}
