using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.Commands;

namespace ATS.EnterpriseSystem.SmartClients.EntityExplorer
{
    // 
    public partial class EntityExplorerToolBar : ToolStrip
    {
        private EntityExplorer explorer;

        public EntityExplorerToolBar()
        {
            InitializeComponent();
        }

        public EntityExplorer Explorer
        {
            get { return explorer; }
            set { explorer = value; }
        }

        public static void BindToExplorer(EntityExplorer explorer, EntityExplorerToolBar tb)
        {
            tb.Explorer = explorer;
            explorer.Commands[EntityExplorerConstants.NewObjectCommand].AddInvoker(tb.newToolStripButton, "Click");
            explorer.Commands[EntityExplorerConstants.OpenObjectCommand].AddInvoker(tb.openToolStripButton, "Click");
            explorer.Commands[EntityExplorerConstants.DeleteObjectCommand].AddInvoker(tb.deleteToolStripButton, "Click");
            explorer.Commands[EntityExplorerConstants.RefershCommand].AddInvoker(tb.refershToolStripButton, "Click");
            explorer.Commands[EntityExplorerConstants.HelpCommand].AddInvoker(tb.helpToolStripButton, "Click");


        }
    }
}
