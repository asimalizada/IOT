﻿using IOTSystem.WinUI.Custom.MessageBox;
using System.Windows.Forms;

namespace Core.WinFormUI.Design.MessageBox
{
    public abstract class DevMsgBox
    {
        public static DialogResult Show(string text)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text))
                result = msgForm.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text, caption))
                result = msgForm.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text, caption, buttons))
                result = msgForm.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text, caption, buttons, icon))
                result = msgForm.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text, caption, buttons, icon, defaultButton))
                result = msgForm.ShowDialog();
            return result;
        }

        /*   IWin32Window Owner:
        *      Displays a message box in front of the specified object and with the other specified parameters.
        *      An implementation of IWin32Window that will own the modal dialog box.
        */
        public static DialogResult Show(IWin32Window owner, string text)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text))
                result = msgForm.ShowDialog(owner);
            return result;
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text, caption))
                result = msgForm.ShowDialog(owner);
            return result;
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text, caption, buttons))
                result = msgForm.ShowDialog(owner);
            return result;
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text, caption, buttons, icon))
                result = msgForm.ShowDialog(owner);
            return result;
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            DialogResult result;
            using (var msgForm = new DevMessageBox(text, caption, buttons, icon, defaultButton))
                result = msgForm.ShowDialog(owner);
            return result;
        }

    }
}