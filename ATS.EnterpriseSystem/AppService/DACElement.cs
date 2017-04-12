using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.AppService
{
    public class DACContext : IDACContext
    {
        DataBaseConnection dataBaseConnection;
        IServiceProvider serviceProvider;

        public DACContext(DataBaseConnection dataBaseConnection, IServiceProvider serviceProvider)
        {
            AV.CheckForNullReference(dataBaseConnection);
            this.dataBaseConnection = dataBaseConnection;
            this.serviceProvider = serviceProvider;
        }

        public DataBaseConnection DataBaseConnection
        {
            get { return dataBaseConnection; }
        }

        IDataBaseConnection IDACContext.DataBaseConnection
        {
            get { return dataBaseConnection; }
        }

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            if (serviceProvider != null)
                return serviceProvider.GetService(serviceType);
            return null;
        }

        #endregion


    }

    public class DACElement : IDACElement
    {
        IDACContext context;

        #region IDACElement Members

        public IDACContext Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }

        #endregion

        protected DataBaseConnection DataBaseConnection
        {
            get
            {
                if (this.Context != null)
                    return this.Context.DataBaseConnection as DataBaseConnection;

                return null;
            }
        }
    }


}
