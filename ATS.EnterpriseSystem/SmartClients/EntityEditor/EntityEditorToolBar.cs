using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor
{
    public partial class EntityEditorToolBar : ToolStrip
    {
        private EntityEditor editor;

        public EntityEditorToolBar()
        {
            InitializeComponent();
        }

        public EntityEditor Editor
        {
            get { return editor; }
            set { editor = value; }
        }

        public static void BindToEditor(EntityEditor editor, EntityEditorToolBar tb)
        {
            editor.Items.AddNew<EntityEditorController>();
            tb.Editor = editor;
            editor.Commands[EntityEditorConstants.SaveObjectCommand].AddInvoker(tb.saveToolStripButton, "Click");
            editor.Commands[EntityEditorConstants.HelpCommand].AddInvoker(tb.helpToolStripButton, "Click");
        }
    }
}
