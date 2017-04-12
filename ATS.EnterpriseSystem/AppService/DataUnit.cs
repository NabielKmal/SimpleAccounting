using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace ATS.EnterpriseSystem.AppService
{
    public class DataUnit : DataSet, IDataUnit
    {
        private int typeCode;

        public DataUnit(int typeCode)
        {
            this.typeCode = typeCode;
        }

        public int TypeCode
        {
            get { return typeCode; }
            //set { typeCode = value; }
        }

        public Guid ID
        {
            get
            {
                if (Tables.Count > 0)
                {
                    System.Data.DataTable tbl = Tables[0];
                    if (tbl.Rows.Count > 0)
                    {
                        System.Data.DataRow dr = tbl.Rows[0];
                        switch (dr.RowState)
                        {
                            case System.Data.DataRowState.Added:
                            case System.Data.DataRowState.Modified:
                            case System.Data.DataRowState.Unchanged:
                                return DataUtil.NZ<Guid>(dr[0]);
                            case System.Data.DataRowState.Deleted:
                                return DataUtil.NZ<Guid>(dr[0, DataRowVersion.Original]);
                        }
                    }
                }
                return Guid.Empty;
            }
        }

        public DataRow RootObject
        {
            get { return this.GetRootRow(); }
        }

        public ObjectIdentity RootObjectID
        {
            get
            {
                return new ObjectIdentity(TypeCode, ID);
            }
        }

        private DataTable GetRootTable()
        {
            return Tables.Count > 0 ? Tables[0] : null;
        }

        private DataRow GetRootRow()
        {
            DataTable rootTable = GetRootTable();
            if (rootTable != null && rootTable.Rows.Count > 0)
            {
                return rootTable.Rows[0];
            }

            return null;
        }

        public DataUnitState State
        {
            get
            {
                DataRow dr = GetRootRow();
                if (dr != null)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Added:
                            return DataUnitState.Added;

                        case DataRowState.Deleted:
                            return DataUnitState.Deleted;

                        case DataRowState.Modified:
                            return DataUnitState.Modified;

                        case DataRowState.Unchanged:
                            return DataUnitState.Unchanged;

                    }
                }

                return DataUnitState.NA;
            }
        }

        #region Dirty Members
        bool dirty;
        public bool IsDirty
        {
            get
            {
                return dirty;
            }
            set
            {

                dirty = value;
            }
        }

        #endregion
    }
}
