namespace Bank_Managment_System
{
    partial class US_CustomersList
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
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.DataGridViewAllClients = new System.Windows.Forms.DataGridView();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.cmbFilterMain = new Guna.UI2.WinForms.Guna2ComboBox();
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
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1338, 734);
            this.guna2Panel1.TabIndex = 2;
            // 
            // lblTypeAction
            // 
            this.lblTypeAction.AutoSize = true;
            this.lblTypeAction.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeAction.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTypeAction.Location = new System.Drawing.Point(15, 15);
            this.lblTypeAction.Name = "lblTypeAction";
            this.lblTypeAction.Size = new System.Drawing.Size(201, 41);
            this.lblTypeAction.TabIndex = 3;
            this.lblTypeAction.Text = "Customers";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.Controls.Add(this.DataGridViewAllClients);
            this.guna2Panel2.Controls.Add(this.iconPictureBox1);
            this.guna2Panel2.Controls.Add(this.cmbFilterMain);
            this.guna2Panel2.Controls.Add(this.txtSearch);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 222);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1338, 509);
            this.guna2Panel2.TabIndex = 1;
            // 
            // DataGridViewAllClients
            // 
            this.DataGridViewAllClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAllClients.Location = new System.Drawing.Point(0, 61);
            this.DataGridViewAllClients.Name = "DataGridViewAllClients";
            this.DataGridViewAllClients.RowHeadersWidth = 51;
            this.DataGridViewAllClients.RowTemplate.Height = 26;
            this.DataGridViewAllClients.Size = new System.Drawing.Size(1338, 591);
            this.DataGridViewAllClients.TabIndex = 10;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 50;
            this.iconPictureBox1.Location = new System.Drawing.Point(585, 10);
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
            "Active",
            "All Filters",
            "Client ID",
            "Country",
            "Full Name",
            "Inactive"});
            this.cmbFilterMain.Location = new System.Drawing.Point(410, 6);
            this.cmbFilterMain.Name = "cmbFilterMain";
            this.cmbFilterMain.Size = new System.Drawing.Size(210, 41);
            this.cmbFilterMain.StartIndex = 1;
            this.cmbFilterMain.TabIndex = 7;
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
            this.txtSearch.IconRight = global::Bank_Managment_System.Properties.Resources.FrmLogin1;
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
            // 
            // US_Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "US_Customers";
            this.Size = new System.Drawing.Size(1338, 734);
            this.Load += new System.EventHandler(this.US_Customers_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAllClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblTypeAction;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.DataGridView DataGridViewAllClients;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFilterMain;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
    }
}
