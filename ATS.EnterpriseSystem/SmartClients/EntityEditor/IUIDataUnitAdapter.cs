using System;
using System.Collections.Generic;

using System.Text;
using ATS.EnterpriseSystem.AppService;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor
{
    public interface IUIDataUnitAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">id is null.</exception>
        bool Exist(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">id is null.</exception>
        IDataUnit Load(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="System.ArgumentNullException">data is null.</exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        void Save(IDataUnit data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);


        IDataUnit InitializeNew();
    }
}
