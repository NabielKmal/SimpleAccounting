using System;
using System.Collections.Generic;

using System.Text;

namespace ATS.EnterpriseSystem.SmartClients
{
    public class TypeCodeRegistry : Dictionary<int, TypeCodeInfo>
    { }

    public class TypeCodeInfo
    {
        public System.Type dataUnitType;
        public System.Type dataUnitAdapterType;
        public System.Type editorType;
        public System.Type editorViewType;

        public TypeCodeInfo()
        { }

        public TypeCodeInfo(
            Type dataUnitType, 
            Type dataUnitAdapterType, 
            Type editorType, 
            Type editorViewType)
        {
            this.dataUnitType = dataUnitType;
            this.dataUnitAdapterType = dataUnitAdapterType;
            this.editorType = editorType;
            this.editorViewType = editorViewType;
        }
    }
}
