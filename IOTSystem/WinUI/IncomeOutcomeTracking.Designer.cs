namespace IOTSystem.WinUI
{
    partial class IncomeOutcomeTracking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelNavbar = new System.Windows.Forms.Panel();
            this.btnReports = new FontAwesome.Sharp.IconButton();
            this.btnBalance = new FontAwesome.Sharp.IconButton();
            this.btnOutcome = new FontAwesome.Sharp.IconButton();
            this.btnIncome = new FontAwesome.Sharp.IconButton();
            this.btnHome = new FontAwesome.Sharp.IconButton();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelNavbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavbar
            // 
            this.panelNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelNavbar.Controls.Add(this.btnReports);
            this.panelNavbar.Controls.Add(this.btnBalance);
            this.panelNavbar.Controls.Add(this.btnOutcome);
            this.panelNavbar.Controls.Add(this.btnIncome);
            this.panelNavbar.Controls.Add(this.btnHome);
            this.panelNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNavbar.Location = new System.Drawing.Point(0, 0);
            this.panelNavbar.Name = "panelNavbar";
            this.panelNavbar.Padding = new System.Windows.Forms.Padding(5);
            this.panelNavbar.Size = new System.Drawing.Size(1200, 60);
            this.panelNavbar.TabIndex = 0;
            // 
            // btnReports
            // 
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReports.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnReports.IconColor = System.Drawing.Color.Black;
            this.btnReports.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReports.Location = new System.Drawing.Point(565, 5);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(140, 50);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnBalance
            // 
            this.btnBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBalance.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBalance.FlatAppearance.BorderSize = 0;
            this.btnBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalance.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalance.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBalance.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnBalance.IconColor = System.Drawing.Color.Black;
            this.btnBalance.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBalance.Location = new System.Drawing.Point(425, 5);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(140, 50);
            this.btnBalance.TabIndex = 5;
            this.btnBalance.Text = "Balance";
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // btnOutcome
            // 
            this.btnOutcome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOutcome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOutcome.FlatAppearance.BorderSize = 0;
            this.btnOutcome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutcome.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutcome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnOutcome.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnOutcome.IconColor = System.Drawing.Color.Black;
            this.btnOutcome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOutcome.Location = new System.Drawing.Point(285, 5);
            this.btnOutcome.Name = "btnOutcome";
            this.btnOutcome.Size = new System.Drawing.Size(140, 50);
            this.btnOutcome.TabIndex = 2;
            this.btnOutcome.Text = "Outcome";
            this.btnOutcome.UseVisualStyleBackColor = true;
            this.btnOutcome.Click += new System.EventHandler(this.btnOutcome_Click);
            // 
            // btnIncome
            // 
            this.btnIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnIncome.FlatAppearance.BorderSize = 0;
            this.btnIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncome.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnIncome.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnIncome.IconColor = System.Drawing.Color.Black;
            this.btnIncome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIncome.Location = new System.Drawing.Point(145, 5);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(140, 50);
            this.btnIncome.TabIndex = 1;
            this.btnIncome.Text = "Income";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnHome.IconColor = System.Drawing.Color.Black;
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.Location = new System.Drawing.Point(5, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(140, 50);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 60);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(10);
            this.panelContainer.Size = new System.Drawing.Size(1200, 636);
            this.panelContainer.TabIndex = 1;
            // 
            // IncomeOutcomeTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1200, 696);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelNavbar);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "IncomeOutcomeTracking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Income-Outcome Tracking System";
            this.Load += new System.EventHandler(this.IncomeOutcomeTracking_Load);
            this.panelNavbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNavbar;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconButton btnIncome;
        private FontAwesome.Sharp.IconButton btnOutcome;
        private System.Windows.Forms.Panel panelContainer;
        private FontAwesome.Sharp.IconButton btnReports;
        private FontAwesome.Sharp.IconButton btnBalance;
    }
}

