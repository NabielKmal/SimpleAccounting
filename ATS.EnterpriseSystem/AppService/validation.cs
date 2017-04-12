using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;

namespace ATS.EnterpriseSystem.AppService
{
    //public interface IValidationResult
    //{
    //    bool IsValid { get; }

    //    ICollection Errors { get; }
    //}

    //public class ValidationResult
    //{
    //    bool isValid;
    //    ICollection errors;

    //    public ValidationResult(bool isValid, ICollection errors)
    //    {
    //        this.isValid = isValid;
    //        this.errors = errors;
    //    }

    //    public bool IsValid
    //    {
    //        get { return isValid; }
    //    }

    //    public ICollection Errors
    //    {
    //        get { return errors; }
    //    }



    //}

    //public class ValidationResult
    //{

    //    ValidationErrorCollection errors;

    //    public ValidationResult()
    //    {

    //        this.errors = new ValidationErrorCollection();
    //    }

    //    public bool IsValid
    //    {
    //        get { return errors.Count == 0; }
    //    }

    //    public ValidationErrorCollection Errors
    //    {
    //        get { return errors; }
    //    }



    //}

    //public interface IValidator
    //{
    //    ValidationResult Validate(Object value);

    //    void Validate(object value, ValidationResult result);
    //}

    public class ValidationError
    {
        private string errorText;
        private int errorCode;
        private object @object;
        private string property;

        public ValidationError()
        { }

        public ValidationError(string errorText, object @object, string property)
            : this(errorText, -1, @object, property)
        {
        }

        public ValidationError(string errorText, int errorCode, object @object, string property)
        {
            this.errorText = errorText;
            this.errorCode = errorCode;
            this.@object = @object;
            this.property = property;
        }


        public string ErrorText
        {
            get { return errorText; }
            set { errorText = value; }
        }


        public int ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        public object Object
        {
            get { return @object; }
            set { @object = value; }
        }


        public string Property
        {
            get { return property; }
            set { property = value; }
        }
    }

    public class ValidationErrorCollection : System.Collections.ObjectModel.Collection<ValidationError>
    {
        ////public bool Assert(bool condition, string errorText, object obj, string property)
        ////{
        ////    return Assert(condition, -1, errorText, obj, property);
        ////}

        ////public bool Assert(bool condition, int errorCode, string errorText, object obj, string property)
        ////{
        ////    if (!condition)
        ////    {
        ////        Add(new ValidationError(errorText, errorCode, obj, property));
        ////    }
        ////    return condition;
        ////}

        public bool IsValid
        {
            get { return Count == 0; }
        }

        public ValidationErrorCollection FindErrors(object obj)
        {
            ValidationErrorCollection r = new ValidationErrorCollection();
            foreach (ValidationError x in this)
            {
                if (x.Object == obj)
                    r.Add(x);
            }
            return r;
        }

        public ValidationErrorCollection FindErrors(object obj, string property)
        {
            ValidationErrorCollection r = new ValidationErrorCollection();
            foreach (ValidationError x in this)
            {
                if (x.Object == obj && x.Property == property)
                    r.Add(x);
            }
            return r;
        }
    }

    //public class ValidationHelper
    //{
    //    public static bool IsNull(object v)
    //    {
    //        return v == null || v == DBNull.Value;

    //    }

    //    public static bool IsNullOrEmptyString(object v)
    //    {
    //        if (IsNull(v))
    //            v = string.Empty;
    //        return string.IsNullOrEmpty((string)v);
    //    }

    //    /// <summary>
    //    /// التحقق من ان القيمة ليست خالية
    //    /// </summary>
    //    /// <param name="v"></param>
    //    /// <returns>
    //    /// تعيد صح إذا لم تكن القيمة خالية، وغير ذلك تعيد خطأ
    //    /// </returns>
    //    public static bool CheckForNull(object v)
    //    {
    //        if (IsNull(v))
    //            return false;
    //        return true;
    //    }

    //    public static bool CheckForNullOrEmptyString(string v)
    //    {
    //        //return !string.IsNullOrEmpty(v);
    //        return !IsNullOrEmptyString(v);
    //    }

    //    public static bool CheckForNullOrEmptyString(object v)
    //    {
    //        return !IsNullOrEmptyString(v);
    //    }

    //    public static bool CheckStringMaxLength(object v, int maxLength)
    //    {

    //        if (object.Equals(DBNull.Value, v))
    //            v = string.Empty;
    //        if (((string)v).Length > maxLength)
    //        {
    //            return false;
    //        }
    //        return true;
    //    }

    //    //Unique
    //    //Lookup
    //}
}
