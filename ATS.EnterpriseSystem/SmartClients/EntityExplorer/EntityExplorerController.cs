using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;

namespace ATS.EnterpriseSystem.SmartClients.EntityExplorer
{
    public class EntityExplorerController : Controller
    {
        public EntityExplorer Explorer
        {
            get { return this.WorkItem as EntityExplorer; }
        }

        [CommandHandler(EntityExplorerConstants.NewObjectCommand)]
        public void NewObject(object sender, EventArgs e)
        {
            NewObject();
        }

        [CommandHandler(EntityExplorerConstants.OpenObjectCommand)]
        public void OpenObject(object sender, EventArgs e)
        {
            OpenObject();
        }

        [CommandHandler(EntityExplorerConstants.DeleteObjectCommand)]
        public void DeleteObject(object sender, EventArgs e)
        {
            DeleteObject();
        }

        [CommandHandler(EntityExplorerConstants.RefershCommand)]
        public void Refersh(object sender, EventArgs e)
        {
            Refersh();
        }

        [CommandHandler(EntityExplorerConstants.HelpCommand)]
        public void Help(object sender, EventArgs e)
        {
            Help();
        }

        /// <summary>
        /// إنشاء كائن جديد
        /// </summary>
        public void NewObject()
        {
            this.Explorer.NewObject();
        }

        /// <summary>
        /// فتح نموذج الكائن الحالي
        /// </summary>
        public void OpenObject()
        {
            this.Explorer.OpenObject();
        }

        /// <summary>
        /// حذف الكائن الحالي
        /// </summary>
        public void DeleteObject()
        {
            this.Explorer.DeleteObject();
        }

        /// <summary>
        /// إعادة تحديث المستكشف
        /// </summary>
        public void Refersh()
        {
            this.Explorer.Refersh();
        }

        public void Help()
        {
            this.Explorer.OnHelp();
        }

    }
}
