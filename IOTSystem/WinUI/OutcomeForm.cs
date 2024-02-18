using Core.WinFormUI.Design.MessageBox;
using IOTSystem.Business;
using IOTSystem.Business.Abstract;
using IOTSystem.Entities.Concrete;
using IOTSystem.Helpers;
using IOTSystem.IoC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IOTSystem.WinUI
{
    public partial class OutcomeForm : Form
    {
        internal User User { get; set; }

        private readonly IOutcomeService _service;
        private readonly IOutcomeReasonService _reasonService;

        public OutcomeForm()
        {
            InitializeComponent();
            _service = InstanceFactory.GetInstance<IOutcomeService>(new BusinessModule());
            _reasonService = InstanceFactory.GetInstance<IOutcomeReasonService>(new BusinessModule());
        }

        private void OutcomeForm_Load(object sender, System.EventArgs e)
        {
            DesignDataGridView(dgwOutcomes);
            LoadData();
            LoadReasons();
        }

        private void LoadData()
        {
            dgwOutcomes.DataSource = _service.GetAll();
        }

        private void LoadReasons()
        {
            var data = _reasonService.GetAll();

            cmbReasons.DataSource = data;
            cmbReasons.ValueMember = "Id";
            cmbReasons.DisplayMember = "Name";
        }

        public bool HandleException(Action action)
        {
            bool result = true;
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                result = false;
                DevMsgBox.Show(exception.Message, "System");
            }

            return result;
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
            dgwBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            dgwOutcomes.Enabled = true;

            tbxName.Texts = string.Empty;
            tbxDescription.Texts = string.Empty;
            dtpDate.Value = DateTime.Now;

            try
            {
                cmbReasons.SelectedIndex = 0;
            }
            catch { }
        }

        private void dgwOutcomes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwOutcomes.Rows.Count == 0)
                return;

            btnCancel.Visible = true;
            btnAdd.Enabled = false;
            dgwOutcomes.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            var cells = dgwOutcomes.CurrentRow.Cells;

            tbxName.Texts = cells[1].Value.ToString();
            tbxDescription.Texts = cells[2].Value.ToString();
            dtpDate.Value = Convert.ToDateTime(cells[4].Value);
            cmbReasons.SelectedValue = Convert.ToInt32(cells[3].Value);
            nudAmount.Value = Convert.ToDecimal(cells[4].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DevMsgBox.Show(Messages.AreYouSure, "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            var result = HandleException(() =>
            {
                _service.Add(new Outcome
                {
                    Name = tbxName.Texts,
                    Description = tbxDescription.Texts,
                    Date = dtpDate.Value,
                    ReasonId = Convert.ToInt32(cmbReasons.SelectedValue),
                    UserId = User is null ? 0 : User.Id,
                    Amount = nudAmount.Value
                });
            });

            if (result)
                LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DevMsgBox.Show(Messages.AreYouSure, "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            var result = HandleException(() =>
            {
                _service.Update(new Outcome
                {
                    Id = Convert.ToInt32(dgwOutcomes.CurrentRow.Cells[0].Value),
                    Name = tbxName.Texts,
                    Description = tbxDescription.Texts,
                    Date = dtpDate.Value,
                    ReasonId = Convert.ToInt32(cmbReasons.SelectedValue),
                    UserId = User is null ? 0 : User.Id,
                    Amount = nudAmount.Value
                });
            });

            if (result)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DevMsgBox.Show(Messages.AreYouSure, "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            var result = HandleException(() =>
            {
                _service.Delete(Convert.ToInt32(dgwOutcomes.CurrentRow.Cells[0].Value));
            });

            if (result)
                LoadData();
        }

        private void btnReasons_Click(object sender, EventArgs e)
        {
            var form = new OutcomeReasonForm();
            form.ShowDialog();

            LoadReasons();
        }

        private void cmbReasons_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (cmbReasons.DataSource as List<IncomeReason>).FirstOrDefault(r => r.Id == (int)cmbReasons.SelectedValue);
            if(selectedItem != null && selectedItem.Amount != null && selectedItem.Amount != 0)
            nudAmount.Value = selectedItem.Amount ?? 0;
        }
    }
}
