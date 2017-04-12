using System;
using System.Collections.Generic;
using System.Text;

namespace ATS
{
    internal class AV
    {
        protected AV()
        { }

        public static void CheckForNullReference(object variable)
        {
            CheckForNullReference(variable, "unnamed variable");
        }

        public static void CheckForNullReference(object variable, string variableName)
        {
            if (variableName == null)
                throw new ArgumentException("variableName");

            if (variable == null)
                throw new ArgumentException(variableName);

        }

        public static void CheckForEmptyString(string variable)
        {
            CheckForEmptyString(variable, "unnamed variable");
        }

        public static void CheckForEmptyString(string variable, string variableName)
        {

            CheckForNullReference(variable, variableName);
            if (variable.Length == 0)
                throw new ArgumentException(variableName);
        }

        public static void Assert(bool condition)
        {
            Assert(condition, null);
        }

        public static void Assert(bool condition, string message)
        {
            if (condition == false)
                throw new System.Exception(message);
        }
    }
}
