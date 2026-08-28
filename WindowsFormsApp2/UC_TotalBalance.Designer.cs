namespace Bank_Managment_System
{
    partial class UC_TotalBalance
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.DataGridViewAllTotalBalance = new System.Windows.Forms.DataGridView();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.cmbFilterMain = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalBalance = new System.Windows.Forms.Label();
            this.btnBacktoDashboardOverview = new Guna.UI2.WinForms.Guna2Button();
            this.lblTypeAction = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAllTotalBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1338, 734);
            this.guna2Panel1.TabIndex = 2;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderRadius = 20;
            this.guna2Panel3.Controls.Add(this.DataGridViewAllTotalBalance);
            this.guna2Panel3.Controls.Add(this.iconPictureBox1);
            this.guna2Panel3.Controls.Add(this.cmbFilterMain);
            this.guna2Panel3.Controls.Add(this.txtSearch);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.guna2Panel3.Location = new System.Drawing.Point(0, 136);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1338, 595);
            this.guna2Panel3.TabIndex = 2;
            // 
            // DataGridViewAllTotalBalance
            // 
            this.DataGridViewAllTotalBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAllTotalBalance.Location = new System.Drawing.Point(0, 53);
            this.DataGridViewAllTotalBalance.Name = "DataGridViewAllTotalBalance";
            this.DataGridViewAllTotalBalance.RowHeadersWidth = 51;
            this.DataGridViewAllTotalBalance.RowTemplate.Height = 26;
            this.DataGridViewAllTotalBalance.Size = new System.Drawing.Size(1338, 545);
            this.DataGridViewAllTotalBalance.TabIndex = 11;
            this.DataGridViewAllTotalBalance.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewAllTotalBalance_CellFormatting);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 50;
            this.iconPictureBox1.Location = new System.Drawing.Point(1286, 10);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox1.TabIndex = 9;
            this.iconPictureBox1.TabStop = false;
            // 
            // cmbFilterMain
            // 
            this.cmbFilterMain.BackColor = System.Drawing.Color.Transparent;
            this.cmbFilterMain.BorderColor = System.Drawing.Color.Transparent;
            this.cmbFilterMain.BorderRadius = 10;
            this.cmbFilterMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFilterMain.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFilterMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.cmbFilterMain.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbFilterMain.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbFilterMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbFilterMain.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbFilterMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbFilterMain.ItemHeight = 35;
            this.cmbFilterMain.Items.AddRange(new object[] {
            "Client ID",
            "Full Name",
            "Account Number",
            "Currency",
            "Balance",
            "Active",
            "Dormant",
            "Frozen",
            "Currency"});
            this.cmbFilterMain.Location = new System.Drawing.Point(1035, 5);
            this.cmbFilterMain.Name = "cmbFilterMain";
            this.cmbFilterMain.Size = new System.Drawing.Size(287, 41);
            this.cmbFilterMain.StartIndex = 0;
            this.cmbFilterMain.TabIndex = 7;
            this.cmbFilterMain.SelectedIndexChanged += new System.EventHandler(this.cmbFilterMain_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderRadius = 15;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Arial", 12.8F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.IconLeftSize = new System.Drawing.Size(0, 0);
             this.txtSearch.IconRightSize = new System.Drawing.Size(30, 30);
            this.txtSearch.Location = new System.Drawing.Point(9, 2);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtSearch.PlaceholderText = "Search Accounts by Number Or Name...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(835, 47);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextOffset = new System.Drawing.Point(0, -2);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Cyan;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.lblTotalBalance);
            this.guna2Panel2.Controls.Add(this.btnBacktoDashboardOverview);
            this.guna2Panel2.Controls.Add(this.lblTypeAction);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1338, 134);
            this.guna2Panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(421, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(548, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Aggregate of all active customer accounts and reserve funds";
            // 
            // lblTotalBalance
            // 
            this.lblTotalBalance.AutoSize = true;
            this.lblTotalBalance.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBalance.ForeColor = System.Drawing.Color.Khaki;
            this.lblTotalBalance.Location = new System.Drawing.Point(536, 46);
            this.lblTotalBalance.Name = "lblTotalBalance";
            this.lblTotalBalance.Size = new System.Drawing.Size(273, 40);
            this.lblTotalBalance.TabIndex = 4;
            this.lblTotalBalance.Text = "$ 213,321,321,22";
            // 
            // btnBacktoDashboardOverview
            // 
            this.btnBacktoDashboardOverview.BorderColor = System.Drawing.Color.Firebrick;
            this.btnBacktoDashboardOverview.BorderRadius = 20;
            this.btnBacktoDashboardOverview.BorderThickness = 1;
            this.btnBacktoDashboardOverview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBacktoDashboardOverview.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBacktoDashboardOverview.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBacktoDashboardOverview.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBacktoDashboardOverview.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBacktoDashboardOverview.FillColor = System.Drawing.Color.Transparent;
            this.btnBacktoDashboardOverview.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBacktoDashboardOverview.ForeColor = System.Drawing.Color.Firebrick;
            this.btnBacktoDashboardOverview.HoverState.ForeColor = System.Drawing.Color.Lime;
            this.btnBacktoDashboardOverview.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBacktoDashboardOverview.ImageSize = new System.Drawing.Size(30, 30);
            this.btnBacktoDashboardOverview.Location = new System.Drawing.Point(8, 8);
            this.btnBacktoDashboardOverview.Name = "btnBacktoDashboardOverview";
            this.btnBacktoDashboardOverview.Size = new System.Drawing.Size(120, 50);
            this.btnBacktoDashboardOverview.TabIndex = 2;
            this.btnBacktoDashboardOverview.Text = "Back ";
            this.btnBacktoDashboardOverview.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnBacktoDashboardOverview.Click += new System.EventHandler(this.btnBacktoDashboardOverview_Click);
            // 
            // lblTypeAction
            // 
            this.lblTypeAction.AutoSize = true;
            this.lblTypeAction.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblTypeAction.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblTypeAction.Location = new System.Drawing.Point(500, 6);
            this.lblTypeAction.Name = "lblTypeAction";
            this.lblTypeAction.Size = new System.Drawing.Size(366, 33);
            this.lblTypeAction.TabIndex = 3;
            this.lblTypeAction.Text = "BANK TOTAL BALANCE (USD)";
            // 
            // UC_TotalBalance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UC_TotalBalance";
            this.Size = new System.Drawing.Size(1338, 734);
            this.Load += new System.EventHandler(this.UC_TotalBalance_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAllTotalBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblTypeAction;
        private Guna.UI2.WinForms.Guna2Button btnBacktoDashboardOverview;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalBalance;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFilterMain;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.DataGridView DataGridViewAllTotalBalance;
    }
}
