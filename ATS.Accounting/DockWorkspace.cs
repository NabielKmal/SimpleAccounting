using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using WeifenLuo.WinFormsUI.Docking;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Controls;
using Control = System.Windows.Forms.Control;
using DockPanel = WeifenLuo.WinFormsUI.Docking.DockPanel;

namespace ATS.Accounting
{
    public class DockWorkspace : Workspace<Control, DockSmartPartInfo>
    {
        DockPanel dockPanel;
        Dictionary<Control, DockWindow> dockWindowDictionary = new Dictionary<Control, DockWindow>();
        private bool fireActivatedFromForm = true;

        public DockWorkspace(DockPanel dockPanel)
        {
            AV.CheckForNullReference(dockPanel);
            this.dockPanel = dockPanel;
        }

        #region overrides
        protected override void OnActivate(Control smartPart)
        {
            try
            {
                fireActivatedFromForm = false;
                DockWindow dockWindow = dockWindowDictionary[smartPart];
                dockWindow.BringToFront();
                dockWindow.Activate();

            }
            finally
            {
                fireActivatedFromForm = true;
            }
        }

        protected override void OnApplySmartPartInfo(Control smartPart, DockSmartPartInfo smartPartInfo)
        {
            DockWindow dockWindow = dockWindowDictionary[smartPart];
            this.SetDockWindowProperties(dockWindow, smartPartInfo);
        }

        protected override void OnClose(Control smartPart)
        {
            DockWindow dockWindow = dockWindowDictionary[smartPart];
            smartPart.Disposed -= ControlDisposed;
            dockWindow.Controls.Remove(smartPart);
            dockWindow.Dispose();

        }

        protected override void OnHide(Control smartPart)
        {
            DockWindow dockWindow = dockWindowDictionary[smartPart];
            dockWindow.Hide();
        }

        protected override void OnShow(Control smartPart, DockSmartPartInfo smartPartInfo)
        {
            DockWindow dockWindow = this.GetOrCreateDockWindow(smartPart);

            SetDockWindowProperties(dockWindow, smartPartInfo);
            dockWindow.Show(this.dockPanel);
        }
        #endregion

        private void ControlDisposed(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control != null && base.SmartParts.Contains(sender))
            {
                CloseInternal(control);
            }
        }


        private DockWindow GetOrCreateDockWindow(Control control)
        {
            DockWindow r = null;

            if (dockWindowDictionary.ContainsKey(control))
            {
                r = dockWindowDictionary[control];
            }
            else
            {
                r = new DockWindow();
                r.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                dockWindowDictionary.Add(control, r);
                control.Disposed += new EventHandler(ControlDisposed);
                WireUpForm(r);
            }

            return r;
        }

        private void WireUpForm(DockWindow form)
        {
            form.WindowFormClosing += new EventHandler<WorkspaceCancelEventArgs>(WindowFormClosing);
            form.WindowFormClosed += new EventHandler<WorkspaceEventArgs>(WindowFormClosed);
            form.WindowFormActivated += new EventHandler<WorkspaceEventArgs>(WindowFormActivated);
        }

        private void WindowFormActivated(object sender, WorkspaceEventArgs e)
        {
            if (fireActivatedFromForm)
            {
                RaiseSmartPartActivated(e.SmartPart);
                base.SetActiveSmartPart(e.SmartPart);
            }
        }

        private void WindowFormClosed(object sender, WorkspaceEventArgs e)
        {
            RemoveEntry((Control)e.SmartPart);
            base.InnerSmartParts.Remove((Control)e.SmartPart);
        }

        private void WindowFormClosing(object sender, WorkspaceCancelEventArgs e)
        {
            base.RaiseSmartPartClosing(e);
        }

        private void RemoveEntry(Control spcontrol)
        {
            this.dockWindowDictionary.Remove(spcontrol);
        }

        private void SetDockWindowProperties(DockWindow dockWindow, DockSmartPartInfo info)
        {
            dockWindow.Text = info.Title;
            dockWindow.Icon = info.Icon;
        }

        #region Private Form Class

        /// <summary>
        /// WindowForm class
        /// </summary>
        private class DockWindow : DockContent
        {
            /// <summary>
            /// Fires when form is closing
            /// </summary>
            public event EventHandler<WorkspaceCancelEventArgs> WindowFormClosing;

            /// <summary>
            /// Fires when form is closed
            /// </summary>
            public event EventHandler<WorkspaceEventArgs> WindowFormClosed;

            /// <summary>
            /// Fires when form is activated
            /// </summary>
            public event EventHandler<WorkspaceEventArgs> WindowFormActivated;

            /// <summary>
            /// Handles Activated Event.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnActivated(EventArgs e)
            {
                if (this.Controls.Count > 0)
                {
                    this.WindowFormActivated(this, new WorkspaceEventArgs(this.Controls[0]));
                }

                base.OnActivated(e);
            }


            /// <summary>
            /// Handles the Closing Event
            /// </summary>
            /// <param name="e"></param>
            protected override void OnClosing(CancelEventArgs e)
            {
                if (this.Controls.Count > 0)
                {
                    WorkspaceCancelEventArgs cancelArgs = FireWindowFormClosing(this.Controls[0]);
                    e.Cancel = cancelArgs.Cancel;

                    if (cancelArgs.Cancel == false && this.Controls.Count > 0)
                    {
                        this.Controls[0].Hide();
                    }
                }

                base.OnClosing(e);
            }

            /// <summary>
            /// Handles the Closed Event
            /// </summary>
            /// <param name="e"></param>
            protected override void OnClosed(EventArgs e)
            {
                if ((this.WindowFormClosed != null) &&
                    (this.Controls.Count > 0))
                {
                    this.WindowFormClosed(this, new WorkspaceEventArgs(this.Controls[0]));
                }

                base.OnClosed(e);
            }

            private WorkspaceCancelEventArgs FireWindowFormClosing(object smartPart)
            {
                WorkspaceCancelEventArgs cancelArgs = new WorkspaceCancelEventArgs(smartPart);

                if (this.WindowFormClosing != null)
                {
                    this.WindowFormClosing(this, cancelArgs);
                }

                return cancelArgs;
            }
        }

        #endregion
    }

    public class DockSmartPartInfo : SmartPartInfo
    {
        private Icon icon = null;

        /// <summary>
        /// The Icon that will appear on the window.
        /// </summary>
        [DefaultValue(null)]
        [Category("Layout")]
        public Icon Icon
        {
            get { return icon; }
            set { icon = value; }
        }

    }
}
