namespace Bank_Managment_System
{
    partial class UC_Notifications
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
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.DataGridViewNotification = new System.Windows.Forms.DataGridView();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.cmbFilterMain = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBacktoDashboardOverview = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.Controls.Add(this.btnBacktoDashboardOverview);
            this.guna2Panel2.Controls.Add(this.DataGridViewNotification);
            this.guna2Panel2.Controls.Add(this.iconPictureBox1);
            this.guna2Panel2.Controls.Add(this.cmbFilterMain);
            this.guna2Panel2.Controls.Add(this.txtSearch);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1338, 734);
            this.guna2Panel2.TabIndex = 9;
            // 
            // DataGridViewNotification
            // 
            this.DataGridViewNotification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataGridViewNotification.Location = new System.Drawing.Point(-1, 61);
            this.DataGridViewNotification.Name = "DataGridViewNotification";
            this.DataGridViewNotification.RowHeadersWidth = 51;
            this.DataGridViewNotification.RowTemplate.Height = 26;
            this.DataGridViewNotification.Size = new System.Drawing.Size(1338, 670);
            this.DataGridViewNotification.TabIndex = 10;
            this.DataGridViewNotification.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewNotification_CellFormatting);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 50;
            this.iconPictureBox1.Location = new System.Drawing.Point(1288, 15);
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
            this.cmbFilterMain.Location = new System.Drawing.Point(1106, 11);
            this.cmbFilterMain.Name = "cmbFilterMain";
            this.cmbFilterMain.Size = new System.Drawing.Size(220, 41);
            this.cmbFilterMain.StartIndex = 0;
            this.cmbFilterMain.TabIndex = 7;
            this.cmbFilterMain.SelectedIndexChanged += new System.EventHandler(this.cmbFilterMain_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderRadius = 15;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.txtSearch.Location = new System.Drawing.Point(173, 6);
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
            this.btnBacktoDashboardOverview.Location = new System.Drawing.Point(3, 3);
            this.btnBacktoDashboardOverview.Name = "btnBacktoDashboardOverview";
            this.btnBacktoDashboardOverview.Size = new System.Drawing.Size(120, 50);
            this.btnBacktoDashboardOverview.TabIndex = 11;
            this.btnBacktoDashboardOverview.Text = "Back ";
            this.btnBacktoDashboardOverview.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnBacktoDashboardOverview.Click += new System.EventHandler(this.btnBacktoDashboardOverview_Click);
            // 
            // UC_Notifications
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel2);
            this.Name = "UC_Notifications";
            this.Size = new System.Drawing.Size(1338, 734);
            this.Load += new System.EventHandler(this.UC_Notifications_Load);
            this.VisibleChanged += new System.EventHandler(this.UC_Notifications_VisibleChanged_1);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.DataGridView DataGridViewNotification;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFilterMain;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnBacktoDashboardOverview;
    }
}
