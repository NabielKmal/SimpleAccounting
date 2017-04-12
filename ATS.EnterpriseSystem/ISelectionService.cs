using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;

namespace ATS.EnterpriseSystem.SmartClients
{
    public interface ISelectionService
    {
        ICollection GetSelectedObjects();

        object PrimarySelection { get; }

        void SetSelectedObjects(ICollection objects, SelectionTypes selectionType);

        event System.EventHandler SelectionChanged;
        event System.EventHandler SelectionChanging;


    }

    public enum SelectionTypes
    {
        Normal,
        Primary,
        Remove,
        Add,
        Replace,
    }

    public class SimpleSelectionService : ISelectionService
    {
        List<object> list = new List<object>();

        #region ISelectionService Members

        public ICollection GetSelectedObjects()
        {
            if (list.Count == 0)
                return null;

            return list.ToArray();
        }

        public object PrimarySelection
        {
            get
            {
                if (list.Count > 0)
                    return list[0];
                return null;
            }
        }

        public void SetSelectedObjects(ICollection objects, SelectionTypes selectionType)
        {

            switch (selectionType)
            {
                case SelectionTypes.Normal:
                    this.OnSelectionChanging(System.EventArgs.Empty);
                    list.Clear();
                    if (objects != null && objects.Count > 0)
                    {
                        foreach (object x in objects)
                        {
                            if (x != null && !list.Contains(x))
                                list.Add(x);

                        }
                    }
                    this.OnSelectionChanged(System.EventArgs.Empty);
                    break;
                default:
                    throw new System.NotSupportedException();
                    break;
            }


        }

        public event EventHandler SelectionChanged;

        public event EventHandler SelectionChanging;

        protected virtual void OnSelectionChanged(System.EventArgs e)
        {
            if (this.SelectionChanged != null)
            {
                this.SelectionChanged(this, e);
            }
        }

        protected virtual void OnSelectionChanging(System.EventArgs e)
        {
            if (this.SelectionChanging != null)
            {
                this.SelectionChanging(this, e);
            }
        }

        #endregion
    }
}
