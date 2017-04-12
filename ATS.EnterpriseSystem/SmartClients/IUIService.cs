using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;

namespace ATS.EnterpriseSystem.SmartClients
{
    public interface IUIService
    {
        DialogResult Show(string text);
        DialogResult Show(string text, string caption);
        DialogResult Show(string text, string caption, MessageBoxButtons buttons);
        DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);


        DialogResult Show(string text, MessageBoxButtons buttons);
        DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon);

        void ShowException(System.Exception ex);

    }

    public class UIService : IUIService
    {
        string caption;

        public string Caption
        {
            get
            {
                if (string.IsNullOrEmpty(caption))
                    return Application.ProductName;
                return caption;
            }
            set { caption = value; }
        }

        #region IUIService Members

        public DialogResult Show(string text)
        {
            return MessageBox.Show(text, Caption);
        }

        public DialogResult Show(string text, string caption)
        {
            return MessageBox.Show(text, caption);
        }

        public DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(text, caption, buttons);
        }

        public DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public DialogResult Show(string text, MessageBoxButtons buttons)
        {
            return MessageBox.Show(text, Caption, buttons);
        }

        public DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, Caption, buttons, icon);
        }

        public void ShowException(Exception ex)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                MessageBox.Show(ex.ToString(), Caption);
                System.Console.WriteLine(ex.ToString());
            }
            else
            {
                MessageBox.Show(ex.Message, Caption);
            }

        }

        #endregion
    }
}
