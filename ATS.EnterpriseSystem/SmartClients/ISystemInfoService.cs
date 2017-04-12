using System;
using System.Collections.Generic;

using System.Text;
using ATS.EnterpriseSystem.AppService;

namespace ATS.EnterpriseSystem.SmartClients
{
    /// <summary>
    /// خدمة التحقق من صحة قاعدة البيانات،
    /// وان التطبيق يستطيع التعامل معها
    /// </summary>
    public interface ISystemInfoService
    {
        bool IsValidDBDocument(IDataBaseConnection dataBaseConnection);
    }
}
