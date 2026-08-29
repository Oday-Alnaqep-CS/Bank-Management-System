namespace Bank_Managment_System
{
    partial class US_ViewAllClients
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
            this.lblTypeAction = new System.Windows.Forms.Label();
            this.btnBacktoDashboardOverview = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.DataGridViewAllClients = new System.Windows.Forms.DataGridView();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.cmbFilterMain = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAllClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.lblTypeAction);
            this.guna2Panel1.Controls.Add(this.btnBacktoDashboardOverview);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1338, 734);
            this.guna2Panel1.TabIndex = 1;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // lblTypeAction
            // 
            this.lblTypeAction.AutoSize = true;
            this.lblTypeAction.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeAction.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblTypeAction.Location = new System.Drawing.Point(745, 12);
            this.lblTypeAction.Name = "lblTypeAction";
            this.lblTypeAction.Size = new System.Drawing.Size(249, 36);
            this.lblTypeAction.TabIndex = 3;
            this.lblTypeAction.Text = "All System Clients";
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
            this.btnBacktoDashboardOverview.Location = new System.Drawing.Point(14, 12);
            this.btnBacktoDashboardOverview.Name = "btnBacktoDashboardOverview";
            this.btnBacktoDashboardOverview.Size = new System.Drawing.Size(354, 50);
            this.btnBacktoDashboardOverview.TabIndex = 2;
            this.btnBacktoDashboardOverview.Text = "Back to Dashboard Overview";
            this.btnBacktoDashboardOverview.Click += new System.EventHandler(this.btnBacktoDashboardOverview_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.Controls.Add(this.DataGridViewAllClients);
            this.guna2Panel2.Controls.Add(this.iconPictureBox1);
            this.guna2Panel2.Controls.Add(this.cmbFilterMain);
            this.guna2Panel2.Controls.Add(this.guna2CheckBox1);
            this.guna2Panel2.Controls.Add(this.txtSearch);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 79);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1338, 652);
            this.guna2Panel2.TabIndex = 1;
            // 
            // DataGridViewAllClients
            // 
            this.DataGridViewAllClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAllClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataGridViewAllClients.Location = new System.Drawing.Point(0, 61);
            this.DataGridViewAllClients.Name = "DataGridViewAllClients";
            this.DataGridViewAllClients.RowHeadersWidth = 51;
            this.DataGridViewAllClients.RowTemplate.Height = 26;
            this.DataGridViewAllClients.Size = new System.Drawing.Size(1338, 591);
            this.DataGridViewAllClients.TabIndex = 10;
            this.DataGridViewAllClients.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewAllClients_CellFormatting);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 50;
            this.iconPictureBox1.Location = new System.Drawing.Point(1253, 10);
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
            this.cmbFilterMain.ForeColor = System.Drawing.Color.White;
            this.cmbFilterMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbFilterMain.ItemHeight = 35;
            this.cmbFilterMain.Items.AddRange(new object[] {
            "All Filters",
            "Client ID",
            "Full Name",
            "Active",
            "Inactive",
            "Country"});
            this.cmbFilterMain.Location = new System.Drawing.Point(1003, 6);
            this.cmbFilterMain.Name = "cmbFilterMain";
            this.cmbFilterMain.Size = new System.Drawing.Size(287, 41);
            this.cmbFilterMain.StartIndex = 0;
            this.cmbFilterMain.TabIndex = 7;
            this.cmbFilterMain.SelectedIndexChanged += new System.EventHandler(this.cmbFilterMain_SelectedIndexChanged);
            // 
            // guna2CheckBox1
            // 
            this.guna2CheckBox1.AutoSize = true;
            this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.CheckedState.BorderRadius = 0;
            this.guna2CheckBox1.CheckedState.BorderThickness = 0;
            this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2CheckBox1.ForeColor = System.Drawing.Color.White;
            this.guna2CheckBox1.Location = new System.Drawing.Point(396, 10);
            this.guna2CheckBox1.Name = "guna2CheckBox1";
            this.guna2CheckBox1.Size = new System.Drawing.Size(84, 32);
            this.guna2CheckBox1.TabIndex = 6;
            this.guna2CheckBox1.Text = "Filter";
            this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox1.UncheckedState.BorderRadius = 0;
            this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
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
            this.txtSearch.IconLeftSize = new System.Drawing.Size(25, 30);
            this.txtSearch.IconRightSize = new System.Drawing.Size(30, 30);
            this.txtSearch.Location = new System.Drawing.Point(8, 6);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearch.PlaceholderText = "Search...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(380, 46);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextOffset = new System.Drawing.Point(0, -3);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // US_ViewAllClients
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "US_ViewAllClients";
            this.Size = new System.Drawing.Size(1338, 734);
            this.Load += new System.EventHandler(this.US_ViewAllClients_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAllClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnBacktoDashboardOverview;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblTypeAction;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFilterMain;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.DataGridView DataGridViewAllClients;
    }
}
