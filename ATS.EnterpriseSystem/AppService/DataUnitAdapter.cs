using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Collections;
using System.Data.OleDb;

namespace ATS.EnterpriseSystem.AppService
{
    public abstract class DataUnitAdapter : DACElement, IDataUnitAdapter
    {
        int objectTypeCode;
        protected DataUnitAdapter(int objectTypeCode)
        {
            this.objectTypeCode = objectTypeCode;
        }

        public int ObjectTypeCode { get { return this.objectTypeCode; } }

        #region IDataUnitAdapter Members

        public bool Exist(Guid id)
        {
            AssertConnection();
            return ExistCore(id);
        }

        protected abstract bool ExistCore(Guid id);


        public DataUnit Load(Guid id)
        {
            AssertConnection();
            DataUnit r = LoadCore(id);
            AV.CheckForNullReference(r);
            AV.Assert(r.State == DataUnitState.Unchanged);
            return r;
        }

        protected abstract DataUnit LoadCore(Guid id);

        public void Save(DataUnit data)
        {
            AssertConnection();
            AV.CheckForNullReference(data);
            AV.Assert(ObjectTypeCode == data.TypeCode);
            AV.Assert(data.State == DataUnitState.Added || data.State == DataUnitState.Modified || data.State == DataUnitState.Unchanged);
            ValidationErrorCollection r = Validate(data);
            if (!r.IsValid)
            {
                throw new System.Exception();
            }
            SaveCore(data);
        }

        protected abstract void SaveCore(DataUnit data);

        public void Delete(Guid id)
        {
            AssertConnection();
            AV.Assert(MayDelete(id));
            DeleteCore(id);
        }

        protected abstract void DeleteCore(Guid id);

        public bool MayDelete(Guid id)
        {
            return MayDeleteCore(id);
        }

        protected abstract bool MayDeleteCore(Guid id);


        #endregion

        #region IDataUnitAdapter Members

        bool IDataUnitAdapter.Exist(Guid id)
        {
            return this.Exist(id);
        }

        IDataUnit IDataUnitAdapter.Load(Guid id)
        {
            return this.Load(id);
        }

        void IDataUnitAdapter.Save(IDataUnit data)
        {
            this.Save((DataUnit)data);
        }

        void IDataUnitAdapter.Delete(Guid id)
        {
            this.Delete(id);
        }

        #endregion

        private void AssertConnection()
        {
            AV.Assert(this.DataBaseConnection != null && this.DataBaseConnection.IsOpen());


        }

        public bool IsValid(DataUnit data)
        {
            ValidationErrorCollection r = Validate(data);
            return r.IsValid;
        }

        public ValidationErrorCollection Validate(DataUnit data)
        {
            ValidationErrorCollection errors = new ValidationErrorCollection();
            this.ValidateCore(data, errors);
            return errors;
        }

        protected abstract void ValidateCore(DataUnit data, ValidationErrorCollection errors);

        protected void DoValidateTable(DataTable tbl, ValidateRow validate, ValidationContext context)
        {
            foreach (System.Data.DataRow x in tbl.Rows)
            {
                switch (x.RowState)
                {
                    case DataRowState.Added:
                    case DataRowState.Modified:
                    case DataRowState.Unchanged:
                        validate(x, context);
                        break;
                }
            }
        }
        protected delegate void ValidateRow(DataRow self, ValidationContext context);

        public interface IValidationContext
        {
            ValidationErrorCollection Errors { get; }
            void CheckNull(object value, string errorText, object obj, string property);
            void CheckForEmptyString(object value, string errorText, object obj, string property);
            void CheckStringMaxLength(int maxLength, object value, string errorText, object obj, string property);
            void Assert(bool condition, string errorText, object obj, string property);
            void Assert(bool condition, int errorCode, string errorText, object obj, string property);
        }

        public class ValidationContext : IValidationContext
        {
            ValidationErrorCollection errors;
            DataBaseConnection dataBaseConnection;

            public ValidationContext(DataBaseConnection dataBaseConnection)
                : this(dataBaseConnection, new ValidationErrorCollection())
            {

            }

            public ValidationContext(DataBaseConnection dataBaseConnection, ValidationErrorCollection errors)
            {
                AV.CheckForNullReference(dataBaseConnection);
                AV.CheckForNullReference(errors);
                this.dataBaseConnection = dataBaseConnection;
                this.errors = errors;
            }

            public static bool IsNull(object v)
            {
                return v == null || v == DBNull.Value;

            }

            public static bool IsNullOrEmptyString(object v)
            {
                if (IsNull(v))
                    v = string.Empty;
                return string.IsNullOrEmpty((string)v);
            }

            #region IValidationContext Members
            public ValidationErrorCollection Errors
            {
                get { return errors; }
            }


            public void Assert(bool condition, string errorText, object obj, string property)
            {
                Assert(condition, -1, errorText, obj, property);
            }

            public void Assert(bool condition, int errorCode, string errorText, object obj, string property)
            {
                if (!condition)
                {
                    Errors.Add(new ValidationError(errorText, errorCode, obj, property));
                }
            }


            public void CheckNull(object value, string errorText, object obj, string property)
            {
                if (IsNull(value)) Errors.Add(new ValidationError(errorText, obj, property));
            }

            public void CheckForEmptyString(object value, string errorText, object obj, string property)
            {
                if (IsNullOrEmptyString(value)) Errors.Add(new ValidationError(errorText, obj, property));
            }

            public void CheckStringMaxLength(int maxLength, object value, string errorText, object obj, string property)
            {
                if (object.Equals(DBNull.Value, value))
                    value = string.Empty;
                if (((string)value).Length > maxLength)
                {
                    Errors.Add(new ValidationError(errorText, obj, property));
                }
            }

            public void CheckEnumValue(Type enumType, object value, string errorText, object obj, string property)
            {
                ArrayList values = new ArrayList();
                foreach (object x in Enum.GetValues(enumType))
                {
                    values.Add((short)x);
                }
                CheckEnumValue(values, value, errorText, obj, property);
            }

            public void CheckEnumValue(IEnumerable values, object value, string errorText, object obj, string property)
            {
                if (IsNull(value)) return;
                if (!InDomain(values, value))
                {
                    Errors.Add(new ValidationError(errorText, obj, property));
                }

            }

            /// <summary>
            /// ارجاع مايفيد عن وجود عنصر في مجال عناصر معين
            /// </summary>
            /// <param name="values"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            private bool InDomain(IEnumerable values, object value)
            {
                foreach (object x in values)
                {
                    if (object.Equals(x, value)) return true;
                }
                return false;
            }

            public void CheckUnique(string table, string primaryKey, string column, Guid objID, object value, string errorText, object obj, string property)
            {
                if (!IsUnique(table, primaryKey, column, objID, value))
                {
                    Errors.Add(new ValidationError(errorText, obj, property));
                }

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="table">اسم الجدول</param>
            /// <param name="primaryKey">اسم عمود المفتاح الأساسي</param>
            /// <param name="column">اسم عمود المفتاح الفريد</param>
            /// <param name="objID">معرف الكائن المطلوب ان يحتوي على القيمة</param>
            /// <param name="value">قيمة العمود الخاص بالمفتاح الفريد</param>
            /// <returns></returns>
            public bool IsUnique(string table, string primaryKey, string column, Guid objID, object value)
            {
                bool r = false;
                OleDbCommand cmd = new OleDbCommand();
                if (IsNull(value))
                {

                    return true;
                }
                else
                {
                    //إذا وجد كائن آخر له نفس القيمة فهذا يعني ان العمود غير فريد
                    cmd.CommandText = string.Format("SELECT COUNT(*) FROM {0} WHERE {1}=? AND {2}<>?", table, column, primaryKey);
                    cmd.Parameters.Add(new OleDbParameter(column, value));
                    cmd.Parameters.Add(new OleDbParameter(primaryKey, objID));
                }
                int c = DataUtil.NZ<int>(dataBaseConnection.ExecuteScalar(cmd));

                return c == 0;
            }

            #endregion
        }

    }
}
