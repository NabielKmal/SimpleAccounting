using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using Microsoft.Practices.CompositeUI.Utility;
using ATS.EnterpriseSystem.AppService;
using System.Data.Common;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Data;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor.LookupEngine
{
    #region lookup
    public interface ILookupEngine
    {

    }

    public interface ILookupSource
    {
        IList List { get; }

        event EventHandler ListChanged;
    }

    public abstract class LookupEngine
    {
        List<LookupSource> list = new List<LookupSource>();

        protected IList List
        {
            get
            {
                return this.list;
            }
        }

        internal virtual void NotifyLookupSourceUpdated(LookupSource lookup)
        {
            RaiseLookupUpdated(lookup);
        }

        /// <summary>
        /// حدث تغير قائمة
        /// </summary>
        public event EventHandler<DataEventArgs<LookupSource>> LookupUpdated;

        protected virtual void RaiseLookupUpdated(LookupSource lookup)
        {
            if (this.LookupUpdated != null)
            {
                this.LookupUpdated(this, new DataEventArgs<LookupSource>(lookup));
            }
        }

        public LookupSource this[string lookupName]
        {
            get
            {
                foreach (LookupSource x in this.List)
                {
                    if (string.Equals(lookupName, x.LookupName, StringComparison.OrdinalIgnoreCase))
                        return x;
                }
                return null;
            }
        }
    }

    public abstract class LookupSource
    {
        private string lookupName;
        private object list;
        protected bool loaded = false;
        internal LookupEngine engine;

        protected LookupSource(string lookupName)
        {
            AV.CheckForEmptyString(lookupName);
            this.lookupName = lookupName;
        }

        public string LookupName
        {
            get
            {
                return this.lookupName;
            }
        }

        public object List
        {
            get
            {
                if (!loaded)
                {
                    loaded = true;
                    list = LoadList();
                }

                return list;
            }
        }

        protected abstract object LoadList();


        /// <summary>
        /// إعادة تحميل القائمة
        /// </summary>
        public void UpdateList()
        {
            if (!loaded) return;
            loaded = false;
            list = null;

            this.engine.NotifyLookupSourceUpdated(this);

        }
    }

    public class EnumLookupSource : LookupSource
    {
        Type enumType;
        DataTable table;
        public EnumLookupSource(string lookupName, DataTable table)
            : base(lookupName)
        {
            this.enumType = enumType;
            this.table = table;
        }

        protected override object LoadList()
        {
            return table;

        }

        //System.Data.DataTable Load()
        //{

        //}
    }

    public class EnumLookupEngine : LookupEngine
    {
        public EnumLookupSource Add(string lookupName, Type enumType)
        {
            EnumLookupSource r = new EnumLookupSource(lookupName, GetDataTable(enumType));
            r.engine = this;
            this.List.Add(r);
            return r;
        }

        public EnumLookupSource Add(string lookupName, Dictionary<string, short> values)
        {
            EnumLookupSource r = new EnumLookupSource(lookupName, GetDataTable(values));
            r.engine = this;
            this.List.Add(r);
            return r;
        }

        internal static DataTable CreateEnumTable()
        {
            System.Data.DataTable tbl = new System.Data.DataTable();
            tbl.Columns.Add("value", typeof(short));
            tbl.Columns.Add("text", typeof(string));

            return tbl;
        }

        internal static DataTable GetDataTable(System.Type enumType)
        {
            System.Data.DataTable tbl = CreateEnumTable();
            foreach (string x in Enum.GetNames(enumType))
            {
                tbl.Rows.Add(new object[] { Enum.Parse(enumType, x), x });
            }


            return tbl;
        }

        internal static DataTable GetDataTable(Dictionary<string, short> values)
        {
            //
            System.Data.DataTable tbl = CreateEnumTable();
            foreach (KeyValuePair<string, short> x in values)
            {
                tbl.Rows.Add(new object[] { x.Value, x.Key });
            }


            return tbl;
        }
    }

    public class ObjectIDLookupEngine : LookupEngine
    {


        public void UpdateByObjectTypeCode(int objectTypeCode)
        {
            foreach (LookupSource x in this.List)
            {
                ObjectIDLookupSource oil = x as ObjectIDLookupSource;
                if (oil != null && oil.ObjectTypeCode == objectTypeCode)
                {
                    oil.UpdateList();
                }
            }
        }

        public void UpdateAll()
        {
            foreach (LookupSource x in this.List)
            {
                ObjectIDLookupSource oil = x as ObjectIDLookupSource;
                if (oil != null)
                {
                    oil.UpdateList();
                }
            }
        }

        public ObjectIDLookupSource Add(string lookupName, IDataBaseConnection dataBaseConnection, int objectTypeCode, string sql)
        {
            DbCommand cmd = dataBaseConnection.ProviderFactory.CreateCommand();
            cmd.CommandText = sql;
            return Add(lookupName, dataBaseConnection, objectTypeCode, cmd);
        }

        public ObjectIDLookupSource Add(string lookupName, IDataBaseConnection dataBaseConnection, int objectTypeCode, DbCommand cmd)
        {
            ObjectIDLookupSource r = new ObjectIDLookupSource(lookupName, dataBaseConnection, objectTypeCode, cmd);
            r.engine = this;
            this.List.Add(r);
            return r;
        }

        [EventSubscription(ObjectChangeService.ObjectChaneEvent)]
        public void OnObjectChangeHandler(object sender, ObjectChangeEventArgs e)
        {
            this.UpdateByObjectTypeCode(e.ObjectTypeCode);
        }
    }

    public class ObjectIDLookupSource : LookupSource
    {
        private IDataBaseConnection dataBaseConnection;
        private int objectTypeCode;
        private DbCommand cmd;

        public ObjectIDLookupSource(string lookupName, IDataBaseConnection dataBaseConnection, int objectTypeCode, DbCommand cmd)
            : base(lookupName)
        {
            AV.CheckForNullReference(dataBaseConnection);
            AV.CheckForNullReference(cmd);
            this.dataBaseConnection = dataBaseConnection;
            this.objectTypeCode = objectTypeCode;
            this.cmd = cmd;
        }

        public int ObjectTypeCode
        {
            get
            { return this.objectTypeCode; }
        }

        protected override object LoadList()
        {
            return this.dataBaseConnection.Fill(cmd);
        }
    }
    #endregion



    class SyncLookupSourceTest
    {
        ObjectIDLookupEngine engine;
        IObjectChangeService objectChangeService;

        public SyncLookupSourceTest(ObjectIDLookupEngine engine, IObjectChangeService objectChangeService)
        {
            this.engine = engine;
            this.objectChangeService = objectChangeService;

            this.objectChangeService.ObjectChange += new EventHandler<ObjectChangeEventArgs>(objectChangeService_ObjectChange);
        }

        void objectChangeService_ObjectChange(object sender, ObjectChangeEventArgs e)
        {
            this.engine.UpdateByObjectTypeCode(e.ObjectTypeCode);
        }

    }

}
