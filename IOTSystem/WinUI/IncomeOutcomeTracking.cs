using FontAwesome.Sharp;
using IOTSystem.Entities.Concrete;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IOTSystem.WinUI
{
    public partial class IncomeOutcomeTracking : Form
    {
        private Form _activeForm;
        private IconButton _currentButton;

        internal User User { get; set; }

        public IncomeOutcomeTracking()
        {
            InitializeComponent();
        }

        private void IncomeOutcomeTracking_Load(object sender, EventArgs e)
        {
            lblUsername.Text = User?.Username;
            OpenChildForm(new HomeForm(), btnHome);
        }

        private void OpenChildForm(Form childForm, IconButton sender)
        {
            if (_currentButton != null)
                _currentButton.BackColor = Color.FromArgb(23, 21, 32);

            _currentButton = sender;
            _currentButton.BackColor = Color.FromArgb(32, 30, 45);

            _activeForm?.Close();
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HomeForm(), (IconButton)sender);
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new IncomeForm { User = User}, (IconButton)sender);
        }

        private void btnOutcome_Click(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void DesignDataGrid(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(32, 30, 45);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(23, 21, 32);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 7, 17);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected virtual void DesignDataGridView(DataGridView dgwBase)
        {
            dgwBase.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgwBase.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter };
            dgwBase.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgwBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgwBase.BackgroundColor = Color.FromArgb(32, 30, 45);
            dgwBase.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Control,
                ForeColor = SystemColors.WindowText,
                //SelectionBackColor = Color.FromArgb(31, 30, 68),
                SelectionBackColor = Color.FromArgb(11, 7, 17),
                SelectionForeColor = SystemColors.HighlightText,
                //Font = new Font("Microsoft", 12, FontStyle.Regular, GraphicsUnit.Pixel, 204, false),
                WrapMode = DataGridViewTriState.True,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(10)
            };
            dgwBase.RowTemplate = new DataGridViewRow
            {
                DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(32, 30, 45), ForeColor = Color.White, Padding = new Padding(5) },
                Height = 40,
                ReadOnly = true,
            };
            dgwBase.AllowUserToResizeColumns = true;
            dgwBase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwBase.ReadOnly = true;
            dgwBase.Location = new Point(30, 30);
            dgwBase.Margin = new Padding(3, 3, 3, 3);
            dgwBase.MinimumSize = new Size(100, 100);
            dgwBase.RowHeadersWidth = 51;
            //dgwBase.Size = new Size(483, 453);
            dgwBase.ScrollBars = ScrollBars.Both;

            this.DesignDataGrid(dgwBase);
        }
    }
}
