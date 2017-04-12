using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using Microsoft.Practices.CompositeUI.Utility;
using ATS.EnterpriseSystem.AppService;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor.LookupEngine
{
    #region form
    /// <summary>
    /// OrderForm
    /// </summary>
    class EntityFormTest : System.Windows.Forms.UserControl
    {
        ObjectIDLookupEngine lookupEngine;
        System.Windows.Forms.ComboBox customerID;
        public EntityFormTest()
        {

        }

        void InitializeLookupEngine()
        {
            DataBaseConnection dataBaseConnection = null;
            int objectTypeCode = 5;
            string sql = "Select CustomerID, Name from Customer";
            //lookupEngine.Add("customerLookup", dataBaseConnection, objectTypeCode, sql);
        }

        void InitializeView()
        {
            lookupEngine.LookupUpdated += new EventHandler<DataEventArgs<LookupSource>>(lookupEngine_LookupUpdated);
        }

        void InitializeLookupControl()
        {
            //lookupControlMap.Add("customerLookup", this.customerID);
            lookupControlMap.Add(new LookupControlInfo("customerLookup", customerID, "", ""));
        }

        void lookupEngine_LookupUpdated(object sender, DataEventArgs<LookupSource> e)
        {
            if (lookupControlMap.Contains(e.Data.LookupName))
            {
                updatedList.Add(e.Data.LookupName);
            }

            if (this.ContainsFocus)
            {
                ReBindUpdatedLookups();
            }
        }

        LookupControlInfoCollection lookupControlMap = new LookupControlInfoCollection();
        List<object> updatedList = new List<object>();




        void BindAllLookups()
        {
            foreach (LookupControlInfo x in lookupControlMap)
            {
                BindLookup(x);
            }
        }

        void BindLookup(LookupControlInfo control)
        {
            LookupControlHelper.BindControl(control.control, lookupEngine[control.lookupSource], control.displayMember, control.valueMember);
        }

        /// <summary>
        /// تحديث العناصر التي تم إعادة تحميل قوائمها
        /// </summary>
        void ReBindUpdatedLookups()
        {
            foreach (string x in updatedList)
            { }

            updatedList.Clear();
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            ReBindUpdatedLookups();
        }

    }

    public class LookupControlInfo
    {
        public string lookupSource;
        public object control;
        public string displayMember;
        public string valueMember;

        public LookupControlInfo(string lookupSource, object control, string displayMember, string valueMember)
        {
            this.lookupSource = lookupSource;
            this.control = control;
            this.displayMember = displayMember;
            this.valueMember = valueMember;
        }
    }

    public class LookupControlInfoCollection : CollectionBase
    {
        public void Add(LookupControlInfo control)
        {
            this.List.Add(control);
        }

        public LookupControlInfo this[string lookupSource]
        {
            get
            {
                foreach (LookupControlInfo x in List)
                {
                    if (string.Equals(lookupSource, x.lookupSource, StringComparison.OrdinalIgnoreCase))
                        return x;
                }
                return null;
            }
        }

        public bool Contains(string lookupSource)
        {
            return this[lookupSource] != null;
        }
    }

    public class LookupControlHelper
    {
        public static void BindControl(object control, object dataSource, string displayMember, string valueMember)
        { }
    }
    #endregion
}
