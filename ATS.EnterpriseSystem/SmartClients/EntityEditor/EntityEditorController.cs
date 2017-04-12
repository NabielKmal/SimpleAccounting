using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor
{
    public class EntityEditorController : Controller
    {
        public EntityEditor Editor
        {
            get { return this.WorkItem as EntityEditor; }
        }

        [CommandHandler(EntityEditorConstants.SaveObjectCommand)]
        public void SaveObject(object sender, EventArgs e)
        {
            SaveObject();
        }

        [CommandHandler(EntityEditorConstants.HelpCommand)]
        public void Help(object sender, EventArgs e)
        {
            Help();
        }

        public void SaveObject()
        {
            this.Editor.Save();
        }

        public void Help()
        {
            this.Editor.OnHelp();
        }
    }
}
