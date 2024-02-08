using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace IOTSystem.WinUI.Custom.Controls
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public class DevComboBox : UserControl
    {
        private Color _backColor = Color.WhiteSmoke;
        private Color _iconColor = Color.MediumSlateBlue;
        private Color _listBackColor = Color.FromArgb(230, 228, 245);
        private Color _listTextColor = Color.DimGray;
        private Color _borderColor = Color.MediumSlateBlue;
        private int _borderSize = 1;

        private ComboBox _cmbList;
        private Label _lblText;
        private Button _btnIcon;


        public event EventHandler OnSelectedIndexChanged;

        public DevComboBox()
        {
            _cmbList = new ComboBox();
            _lblText = new Label();
            _btnIcon = new Button();
            SuspendLayout();

            _cmbList.BackColor = ListBackColor;
            _cmbList.Font = new Font(Font.Name, 10F);
            _cmbList.ForeColor = ListTextColor;
            _cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            _cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);

            _btnIcon.Dock = DockStyle.Right;
            _btnIcon.FlatStyle = FlatStyle.Flat;
            _btnIcon.FlatAppearance.BorderSize = 0;
            _btnIcon.BackColor = BackColor;
            _btnIcon.Size = new Size(30, 30);
            _btnIcon.Cursor = Cursors.Hand;
            _btnIcon.Click += new EventHandler(Icon_Click);
            _btnIcon.Paint += new PaintEventHandler(Icon_Paint);

            _lblText.Dock = DockStyle.Fill;
            _lblText.AutoSize = false;
            _lblText.BackColor = BackColor;
            _lblText.TextAlign = ContentAlignment.MiddleLeft;
            _lblText.Padding = new Padding(8, 0, 0, 0);
            _lblText.Font = new Font(Font.Name, 10F);

            _lblText.Click += new EventHandler(Surface_Click);
            _lblText.MouseEnter += new EventHandler(Surface_MouseEnter);
            _lblText.MouseLeave += new EventHandler(Surface_MouseLeave);

            Controls.Add(_lblText);
            Controls.Add(_btnIcon);
            Controls.Add(_cmbList);
            MinimumSize = new Size(200, 30);
            Size = new Size(200, 30);
            ForeColor = Color.DimGray;
            Padding = new Padding(BorderSize);
            base.BackColor = BorderColor;
            ResumeLayout();
            AdjustComboBoxDimensions();
        }

        public int BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = value;
                Padding = new Padding(_borderSize);
                AdjustComboBoxDimensions();
            }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                base.BackColor = _borderColor;
            }
        }

        public Color ListTextColor
        {
            get => _listTextColor;
            set
            {
                _listTextColor = value;
                _cmbList.ForeColor = _listTextColor;
            }
        }

        public Color ListBackColor
        {
            get => _listBackColor;
            set
            {
                _listBackColor = value;
                _cmbList.BackColor = _listBackColor;
            }
        }

        public Color IconColor
        {
            get => _iconColor;
            set
            {
                _iconColor = value;
                _btnIcon.Invalidate();

            }
        }

        public new Color BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                _lblText.BackColor = _backColor;
                _btnIcon.BackColor = _backColor;
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                _lblText.ForeColor = value;
            }
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                _lblText.Font = value;
                _cmbList.Font = value;
            }
        }

        public string Texts
        {
            get => _lblText.Text;
            set => _lblText.Text = value;
        }

        public ComboBoxStyle DropDownStyle
        {
            get => _cmbList.DropDownStyle;
            set
            {
                if (_cmbList.DropDownStyle != ComboBoxStyle.Simple)
                    _cmbList.DropDownStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items => _cmbList.Items;

        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get => _cmbList.DataSource;
            set => _cmbList.DataSource = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get => _cmbList.AutoCompleteCustomSource;
            set => _cmbList.AutoCompleteCustomSource = value;
        }

        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get => _cmbList.AutoCompleteSource;
            set => _cmbList.AutoCompleteSource = value;
        }

        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get => _cmbList.AutoCompleteMode;
            set => _cmbList.AutoCompleteMode = value;
        }

        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get => _cmbList.SelectedItem;
            set => _cmbList.SelectedItem = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => _cmbList.SelectedIndex;
            set => _cmbList.SelectedIndex = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedValue
        {
            get => _cmbList.SelectedValue;
            set => _cmbList.SelectedValue = value;
        }

        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get => _cmbList.DisplayMember;
            set => _cmbList.DisplayMember = value;
        }

        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get => _cmbList.ValueMember;
            set => _cmbList.ValueMember = value;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedIndexChanged?.Invoke(sender, e);

            _lblText.Text = _cmbList.Text;
        }

        private void AdjustComboBoxDimensions()
        {
            _cmbList.Width = _lblText.Width;
            _cmbList.Location = new Point
            {
                X = Width - Padding.Right - _cmbList.Width,
                Y = _lblText.Bottom - _cmbList.Height
            };
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            OnClick(e);
            _cmbList.Select();
            if (_cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                _cmbList.DroppedDown = true;
            }
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle(
                (_btnIcon.Width - iconWidth) / 2,
                (_btnIcon.Height - iconHeight) / 2,
                iconWidth,
                iconHeight);
            Graphics graph = e.Graphics;

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(IconColor, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + iconWidth / 2, rectIcon.Bottom);
                path.AddLine(rectIcon.X + iconWidth / 2, rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen, path);
            }
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            _cmbList.Select();
            _cmbList.DroppedDown = true;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            _lblText.Text = _cmbList.Text;
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}
