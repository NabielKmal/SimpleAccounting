using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.SmartClients.UIProcess
{
    public class UIProcessSettings
    {
        protected Dictionary<string, object> dic = new Dictionary<string, object>();

        internal UIProcessSettings()
        { }

        public UIProcessSettings(string title, Type processType, Type processViewType)
        {
            dic.Add("Title", title);
            dic.Add("ProcessType", processType);
            dic.Add("ProcessViewType", processViewType);
        }

        public UIProcessSettings(KeyValuePair<string, object>[] d)
        {
            foreach (KeyValuePair<string, object> x in d)
            {
                dic.Add(x.Key, x.Value);
            }

        }


        #region IUIProcessTemplate Members

        public object this[string key]
        {
            get
            {
                if (!dic.ContainsKey(key))
                    return null;
                return dic[key];
            }
            set
            {
                if (!dic.ContainsKey(key))
                    this.dic[key] = value;
                else
                {
                    this.dic.Add(key, value);
                }

            }
        }

        public string Title
        {
            get
            {
                return (string)this["Title"];
            }
        }

        public Type ProcessType
        {
            get
            {
                return (Type)this["ProcessType"];
            }
        }

        public Type ProcessViewType
        {
            get
            {
                return (Type)this["ProcessViewType"];
            }
        }

        #endregion
    }
}
