using Core.WinFormUI.Design.MessageBox;
using IOTSystem.Business;
using IOTSystem.Business.Abstract;
using IOTSystem.Entities.Concrete;
using IOTSystem.Helpers;
using IOTSystem.IoC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IOTSystem.WinUI
{
    public partial class OutcomeReasonForm : Form
    {
        private readonly IOutcomeReasonService _service;
        private bool _loaded;

        public OutcomeReasonForm()
        {
            InitializeComponent();
            _service = InstanceFactory.GetInstance<IOutcomeReasonService>(new BusinessModule());
            _loaded = false;
        }

        private void OutcomeReasonForm_Load(object sender, EventArgs e)
        {
            DesignDataGridView(this.dgwReasons);
        }

        private void LoadData()
        {
            dgwReasons.DataSource = _service.GetAll();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var val = this.dgwReasons.DataSource;
            if (DevMsgBox.Show(Messages.AreYouSure, "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            var result = HandleException(() =>
            {
                _service.Add(new OutcomeReason
                {
                    Name = tbxName.Texts,
                    Amount = nudAmount.Value > 0 ? nudAmount.Value : -1
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
                _service.Add(new OutcomeReason
                {
                    Id = Convert.ToInt32(dgwReasons.CurrentRow.Cells[0].Value),
                    Name = tbxName.Texts,
                    Amount = nudAmount.Value > 0 ? nudAmount.Value : -1
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
                _service.Delete(Convert.ToInt32(dgwReasons.CurrentRow.Cells[0].Value));
            });

            if (result)
                LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            dgwReasons.Enabled = true;

            tbxName.Texts = string.Empty;
            nudAmount.Value = 0;
        }

        private void tbxNameSearch__TextChanged(object sender, EventArgs e)
        {
            dgwReasons.DataSource = _service.GetByName(tbxName.Texts.Trim());
        }

        private void dgwReasons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwReasons.Rows.Count == 0)
                return;

            btnCancel.Visible = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            dgwReasons.Enabled = false;

            var cells = dgwReasons.CurrentRow.Cells;

            tbxName.Texts = cells[1].Value.ToString();
            nudAmount.Value = Convert.ToDecimal(cells[2].Value);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_loaded)
                return;

            LoadData();
            _loaded = true;
        }
    }
}
