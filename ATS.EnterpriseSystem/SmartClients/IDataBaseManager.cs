using System;
using System.Collections.Generic;

using System.Text;
using ATS.EnterpriseSystem.AppService;

namespace ATS.EnterpriseSystem.SmartClients
{
    public interface IDataBaseManager : IDisposable, IServiceProvider
    {
        IDataBaseConnection DataBaseConnection { get; }


        /// <summary>
        /// استرجاع بيانات الأتصال بقاعدة البيانات الحالية،
        /// او القيمة الخالية إذا لم يكن هناك اتصال
        /// </summary>
        DataBaseInfo CurrentDataBase { get; }

        /// <summary>
        /// هل هو في حالة اتصال حالياً
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// فتح قاعدة بيانات معينة
        /// </summary>
        /// <remarks>يتم اغلاق قاعدة البيانات الحالية قبل فتح قاعدة البيانات الجديدة</remarks>
        /// <param name="fullPath"></param>
        void Open(string fullPath);

        /// <summary>
        /// 
        /// </summary>
        void Close();

        event EventHandler DataBaseClosed;
        event EventHandler DataBaseOpened;
    }



    public class DataBaseInfo
    {
        /// <summary>
        /// اسم قاعدة البيانات بدون المسار
        /// </summary>
        public string dataBaseFile;

        /// <summary>
        /// اسم قاعدة البيانات مع المسار
        /// </summary>
        public string fullPath;

        /// <summary>
        /// نص الأتصال
        /// </summary>
        public string connectionString;
    }

    public interface IDataBaseManagerUICommands
    {
        void OpenDataBase();
        void CloseDataBase();
        void NewDataBase();
        void Exit();
    }

}
