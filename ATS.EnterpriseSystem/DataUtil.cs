using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem
{
    public class DataUtil
    {
        public static T NZ<T>(object v)
        {
            return NZ<T>(v, default(T));
        }

        public static T NZ<T>(object v, T nullValue)
        {
            //if (v == null || v == DBNull.Value)
            //    return nullValue;
            if (IsNull(v))
                return nullValue;

            if (v.GetType().Equals(typeof(T)))
                return (T)v;
            return (T)System.ComponentModel.TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(v);
        }

        public static bool IsNull(object e)
        {
            return e == null || e == DBNull.Value;
        }

        public static bool ArrayIsNullOrEmpty(Array e)
        {
            return e == null || e.Length == 0;
        }
    }
}
