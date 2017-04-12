using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.SmartClients.EntityExplorer
{
    public interface IEntityExplorer
    {
        /// <summary>
        /// تحديث البيانات في المستكشف
        /// </summary>
        void Refersh();


    }

    public interface IEntityExplorerUICommands
    {
        void DoCmd_OpenCurrent();
        void DoCmd_CreateNew();
        void DoCmd_DeleteCurrent();
        void DoCmd_Refersh();
    }
}
