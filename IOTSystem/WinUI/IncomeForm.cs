using Core.WinFormUI.Design.MessageBox;
using IOTSystem.Business;
using IOTSystem.Business.Abstract;
using IOTSystem.Entities.Concrete;
using IOTSystem.Entities.Dto;
using IOTSystem.Helpers;
using IOTSystem.IoC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IOTSystem.WinUI
{
    public partial class IncomeForm : Form
    {
        private readonly IIncomeService _service;
        private readonly IIncomeReasonService _reasonService;
        private readonly IBalanceService _balanceService;

        private List<IncomeDto> _incomes;
        private List<IncomeReason> _reasons;
        private List<BalanceDto> _balances;

        public IncomeForm()
        {
            InitializeComponent();
            _service = InstanceFactory.GetInstance<IIncomeService>(new BusinessModule());
            _reasonService = InstanceFactory.GetInstance<IIncomeReasonService>(new BusinessModule());
            _balanceService = InstanceFactory.GetInstance<IBalanceService>(new BusinessModule());
        }

        private void IncomeForm_Load(object sender, EventArgs e)
        {
            DesignDataGridView(dgwIncomes);
            LoadData();
            LoadReasons();
            LoadBalances();

            FormHelper.HideColumnsOfDgw(dgwIncomes, "ReasonId", "BalanceId");
            FormHelper.SortColumnsOfDgw(dgwIncomes, "Id", "Name", "Description", "BalanceName", "ReasonName", "Date", "Amount");
            FormHelper.RenameColumnsOfDgw(dgwIncomes, new Dictionary<string, string>
            {
                { "ReasonName", "Reason" },
                { "BalanceName", "Balance" }
            });
        }

        private void LoadData()
        {
            var data = _service.GetAll();
            dgwIncomes.DataSource = data;
            _incomes = data;
        }

        private void LoadReasons()
        {
            var data = _reasonService.GetAll();

            cmbReasons.DataSource = data;
            cmbReasons.ValueMember = "Id";
            cmbReasons.DisplayMember = "Name";

            _reasons = data;
        }

        private void LoadBalances()
        {
            var data = _balanceService.GetAll();

            cmbBalances.DataSource = data;
            cmbBalances.ValueMember = "Id";
            cmbBalances.DisplayMember = "Name";

            _balances = data;

            if (data == null || data.Count == 0)
                DevMsgBox.Show("You have not added any balances yet. Please, add balance first to add outcome action.", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void HandleSafe(Action action)
        {
            try { action.Invoke(); } catch { }
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
            dgwIncomes.Enabled = true;

            ResetForm();

            HandleSafe(() => cmbReasons.SelectedIndex = 0);
            HandleSafe(() => cmbBalances.SelectedIndex = 0);
        }

        private void dgwIncomes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwIncomes.Rows.Count == 0)
                return;

            btnCancel.Visible = true;
            btnAdd.Enabled = false;
            dgwIncomes.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            var income = _incomes.FirstOrDefault(i => i.Id == Convert.ToInt32(dgwIncomes.CurrentRow.Cells[0].Value));

            tbxName.Texts = income.Name;
            tbxDescription.Texts = income.Description;
            dtpDate.Value = income.Date;
            cmbReasons.SelectedValue = income.ReasonId;
            nudAmount.Value = income.Amount;
            cmbBalances.SelectedValue = income.BalanceId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DevMsgBox.Show(Messages.AreYouSure, "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            var result = HandleException(() =>
            {
                _service.Add(new IncomeDto
                {
                    Name = tbxName.Texts,
                    Description = tbxDescription.Texts,
                    Date = dtpDate.Value,
                    ReasonId = Convert.ToInt32(cmbReasons.SelectedValue),
                    Amount = nudAmount.Value,
                    BalanceId = Convert.ToInt32(cmbBalances.SelectedValue)
                });
            });

            if (result)
            {
                LoadData();
                ResetForm();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DevMsgBox.Show(Messages.AreYouSure, "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            var result = HandleException(() =>
            {
                _service.Update(new IncomeDto
                {
                    Id = Convert.ToInt32(dgwIncomes.CurrentRow.Cells[0].Value),
                    Name = tbxName.Texts,
                    Description = tbxDescription.Texts,
                    Date = dtpDate.Value,
                    ReasonId = Convert.ToInt32(cmbReasons.SelectedValue),
                    Amount = nudAmount.Value,
                    BalanceId = Convert.ToInt32(cmbBalances.SelectedValue)
                });
            });

            if (result)
            {
                LoadData();
                ResetForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DevMsgBox.Show(Messages.AreYouSure, "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            var result = HandleException(() =>
            {
                _service.Delete(Convert.ToInt32(dgwIncomes.CurrentRow.Cells[0].Value));
            });

            if (result)
            {
                LoadData();
                ResetForm();
            }
        }

        private void btnReasons_Click(object sender, EventArgs e)
        {
            var form = new IncomeReasonForm();
            form.ShowDialog();

            LoadReasons();
        }

        private void cmbReasons_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = _reasons.FirstOrDefault(r => r.Id == (int)cmbReasons.SelectedValue);
            if (selectedItem != null && selectedItem.Amount != null && selectedItem.Amount != 0)
                nudAmount.Value = selectedItem.Amount ?? 0;
        }
        
        private void ResetForm()
        {
            tbxName.Texts = null;
            tbxDescription.Texts = null;
            dtpDate.Value = DateTime.Now;
            nudAmount.Value = 0;
            cmbReasons.SelectedIndex = 0;
            cmbBalances.SelectedIndex = 0;
        }
    }
}
