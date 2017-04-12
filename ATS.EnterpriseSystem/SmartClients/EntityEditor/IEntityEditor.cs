using System;
using System.Collections.Generic;

using System.Text;
using ATS.EnterpriseSystem.AppService;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace ATS.EnterpriseSystem.SmartClients.EntityEditor
{
    public interface IEntityEditor : IServiceProvider
    {
        IEntityEditorHome Home { get; }

        IDataUnit DataUnit { get; }
        bool IsNew { get; }
        bool IsDirty { get; }
        IWorkspace Workspace { get; }

        event EventHandler DataUnitChanged;

        void Save();

        bool SaveModified();


        //IUIService UIService { get; }

    }
    public interface IEntityEditorInternal : IEntityEditor
    {
        object GetOrCreateView();
        void SetDataUnit(IDataUnit dataUnit);
    }

    public interface IEntityEditorView
    {
        IEntityEditor Editor { get; }

        bool EndEdit();
    }

    public interface IEntityEditorViewInternal : IEntityEditorView
    {
        void InitializeView();

        void BindToDataUnit();

        void BindLookups();

        void SetUIDirty();

        void OnDataUnitChanged(object sender, EventArgs e);
    }

}
