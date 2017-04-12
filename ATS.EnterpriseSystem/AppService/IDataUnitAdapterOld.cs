using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.AppService
{
    public interface IDataUnitAdapter : IDACElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">id is null.</exception>
        bool Exist(ObjectIdentity id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">id is null.</exception>
        IDataUnit Load(ObjectIdentity id);

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
        void Delete(ObjectIdentity id);
    }
}
