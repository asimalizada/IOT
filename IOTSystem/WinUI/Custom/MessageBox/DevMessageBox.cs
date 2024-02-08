using IOTSystem.WinUI.Custom.DropShadowing;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IOTSystem.WinUI.Custom.MessageBox
{
    public partial class DevMessageBox : Form
    {
        private Color primaryColor = Color.FromArgb(33, 33, 33);
        private int borderSize = 2;

        public Color PrimaryColor
        {
            get { return primaryColor; }
            set
            {
                primaryColor = value;
                BackColor = primaryColor;
                panelTitleBar.BackColor = PrimaryColor;
            }
        }

        public DevMessageBox(string text)
        {
            InitializeComponent();
            InitializeItems();
            PrimaryColor = primaryColor;
            labelMessage.Text = text;
            labelCaption.Text = "";
            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
        }

        public DevMessageBox(string text, string caption)
        {
            InitializeComponent();
            InitializeItems();
            PrimaryColor = primaryColor;
            labelMessage.Text = text;
            labelCaption.Text = caption;
            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
        }

        public DevMessageBox(string text, string caption, MessageBoxButtons buttons)
        {
            InitializeComponent();
            InitializeItems();
            PrimaryColor = primaryColor;
            labelMessage.Text = text;
            labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);
        }

        public DevMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();
            InitializeItems();
            PrimaryColor = primaryColor;
            labelMessage.Text = text;
            labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);
            SetIcon(icon);
            new DropShadow().ApplyShadows(this);
        }

        public DevMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            InitializeComponent();
            InitializeItems();
            PrimaryColor = primaryColor;
            labelMessage.Text = text;
            labelCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, defaultButton);
            SetIcon(icon);
        }

        private void InitializeItems()
        {
            FormBorderStyle = FormBorderStyle.None;
            Padding = new Padding(borderSize);
            labelMessage.MaximumSize = new Size(550, 0);
            btnClose.DialogResult = DialogResult.Cancel;
            button1.DialogResult = DialogResult.OK;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void SetFormSize()
        {
            int widht = labelMessage.Width + pictureBoxIcon.Width + panelBody.Padding.Left;
            int height = panelTitleBar.Height + labelMessage.Height + panelButtons.Height + panelBody.Padding.Top;
            Size = new Size(widht, height);
        }

        private void SetButtons(MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            int xCenter = (panelButtons.Width - button1.Width) / 2;
            int yCenter = (panelButtons.Height - button1.Height) / 2;

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    //OK Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter, yCenter);
                    button1.Text = "Ok";
                    button1.DialogResult = DialogResult.OK;

                    //Set Default Button
                    SetDefaultButton(defaultButton);
                    break;
                case MessageBoxButtons.OKCancel:
                    //OK Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - button1.Width / 2 - 5, yCenter);
                    button1.Text = "Ok";
                    button1.DialogResult = DialogResult.OK;

                    //Cancel Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter + button2.Width / 2 + 5, yCenter);
                    button2.Text = "Cancel";
                    button2.DialogResult = DialogResult.Cancel;
                    button2.BackColor = Color.DimGray;

                    //Set Default Button
                    if (defaultButton != MessageBoxDefaultButton.Button3)
                        SetDefaultButton(defaultButton);
                    else SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;

                case MessageBoxButtons.RetryCancel:
                    //Retry Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - button1.Width / 2 - 5, yCenter);
                    button1.Text = "Retry";
                    button1.DialogResult = DialogResult.Retry;

                    //Cancel Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter + button2.Width / 2 + 5, yCenter);
                    button2.Text = "Cancel";
                    button2.DialogResult = DialogResult.Cancel;
                    button2.BackColor = Color.DimGray;

                    //Set Default Button
                    if (defaultButton != MessageBoxDefaultButton.Button3)
                        SetDefaultButton(defaultButton);
                    else SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;

                case MessageBoxButtons.YesNo:
                    //Yes Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - button1.Width / 2 - 5, yCenter);
                    button1.Text = "Yes";
                    button1.DialogResult = DialogResult.Yes;

                    //No Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter + button2.Width / 2 + 5, yCenter);
                    button2.Text = "No";
                    button2.DialogResult = DialogResult.No;
                    button2.BackColor = Color.IndianRed;

                    //Set Default Button
                    if (defaultButton != MessageBoxDefaultButton.Button3)
                        SetDefaultButton(defaultButton);
                    else SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    //Yes Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - button1.Width - 5, yCenter);
                    button1.Text = "Yes";
                    button1.DialogResult = DialogResult.Yes;

                    //No Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter, yCenter);
                    button2.Text = "No";
                    button2.DialogResult = DialogResult.No;
                    button2.BackColor = Color.IndianRed;

                    //Cancel Button
                    button3.Visible = true;
                    button3.Location = new Point(xCenter + button2.Width + 5, yCenter);
                    button3.Text = "Cancel";
                    button3.DialogResult = DialogResult.Cancel;
                    button3.BackColor = Color.DimGray;

                    //Set Default Button
                    SetDefaultButton(defaultButton);
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    //Abort Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - button1.Width - 5, yCenter);
                    button1.Text = "Abort";
                    button1.DialogResult = DialogResult.Abort;
                    button1.BackColor = Color.Goldenrod;

                    //Retry Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter, yCenter);
                    button2.Text = "Retry";
                    button2.DialogResult = DialogResult.Retry;

                    //Ignore Button
                    button3.Visible = true;
                    button3.Location = new Point(xCenter + button2.Width + 5, yCenter);
                    button3.Text = "Ignore";
                    button3.DialogResult = DialogResult.Ignore;
                    button3.BackColor = Color.IndianRed;

                    //Set Default Button
                    SetDefaultButton(defaultButton);
                    break;
            }
        }

        private void SetDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1://Focus button 1
                    button1.Select();
                    button1.ForeColor = Color.White;
                    button1.Font = new Font(button1.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button2://Focus button 2
                    button2.Select();
                    button2.ForeColor = Color.White;
                    button2.Font = new Font(button2.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button3://Focus button 3
                    button3.Select();
                    button3.ForeColor = Color.White;
                    button3.Font = new Font(button3.Font, FontStyle.Underline);
                    break;
            }
        }

        private void SetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    pictureBoxIcon.Image = Properties.Resources.error;
                    //PrimaryColor = Color.FromArgb(224, 79, 95);
                    btnClose.FlatAppearance.MouseOverBackColor = Color.Crimson;
                    break;
                case MessageBoxIcon.Information:
                    pictureBoxIcon.Image = Properties.Resources.information;
                    //PrimaryColor = Color.FromArgb(38, 191, 166);
                    break;
                case MessageBoxIcon.Question:
                    pictureBoxIcon.Image = Properties.Resources.question;
                    //PrimaryColor = Color.FromArgb(10, 119, 232);
                    break;
                case MessageBoxIcon.Exclamation:
                    pictureBoxIcon.Image = Properties.Resources.exclamation;
                    //PrimaryColor = Color.FromArgb(32, 30, 45);
                    break;
                case MessageBoxIcon.None:
                    pictureBoxIcon.Image = Properties.Resources.chat;
                    //PrimaryColor = Color.CornflowerBlue;
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Drag Form

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        #endregion

    }
}
