namespace Bank_Managment_System
{
    partial class FrmUpdateFX
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirmUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtNewBuyRate = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.UpdateFXInformationIcone = new Guna.UI2.WinForms.Guna2Button();
            this.txtTime = new Guna.UI2.WinForms.Guna2Button();
            this.txtDate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel14 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PictCurrencyNameIcone = new Guna.UI2.WinForms.Guna2PictureBox();
            this.CbCurrencyName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCurrentCode = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.Country = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ToplblIcone = new FontAwesome.Sharp.IconPictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtChangeReason = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtLastUpdateBy = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtNewSellRate = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCurrentSellRate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtSpread = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCurrentBuyRate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewBuyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictCurrencyNameIcone)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToplblIcone)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewSellRate)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.Maroon;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Century Schoolbook", 16F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCancel.Location = new System.Drawing.Point(500, 634);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PressedColor = System.Drawing.Color.Transparent;
            this.btnCancel.Size = new System.Drawing.Size(231, 50);
            this.btnCancel.TabIndex = 154;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirmUpdate
            // 
            this.btnConfirmUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConfirmUpdate.BorderRadius = 10;
            this.btnConfirmUpdate.BorderThickness = 2;
            this.btnConfirmUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirmUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirmUpdate.FillColor = System.Drawing.Color.Transparent;
            this.btnConfirmUpdate.Font = new System.Drawing.Font("Century Schoolbook", 16F, System.Drawing.FontStyle.Bold);
            this.btnConfirmUpdate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnConfirmUpdate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConfirmUpdate.HoverState.ForeColor = System.Drawing.Color.Blue;
            this.btnConfirmUpdate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnConfirmUpdate.ImageSize = new System.Drawing.Size(40, 40);
            this.btnConfirmUpdate.Location = new System.Drawing.Point(46, 634);
            this.btnConfirmUpdate.Name = "btnConfirmUpdate";
            this.btnConfirmUpdate.PressedColor = System.Drawing.Color.Transparent;
            this.btnConfirmUpdate.Size = new System.Drawing.Size(397, 50);
            this.btnConfirmUpdate.TabIndex = 153;
            this.btnConfirmUpdate.Text = "Review Update";
            this.btnConfirmUpdate.Click += new System.EventHandler(this.btnConfirmUpdate_Click);
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Panel9.BorderRadius = 7;
            this.guna2Panel9.BorderThickness = 1;
            this.guna2Panel9.Controls.Add(this.txtNewBuyRate);
            this.guna2Panel9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.guna2Panel9.Location = new System.Drawing.Point(38, 335);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.Size = new System.Drawing.Size(338, 48);
            this.guna2Panel9.TabIndex = 152;
            // 
            // txtNewBuyRate
            // 
            this.txtNewBuyRate.BackColor = System.Drawing.Color.Transparent;
            this.txtNewBuyRate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtNewBuyRate.BorderRadius = 7;
            this.txtNewBuyRate.BorderThickness = 0;
            this.txtNewBuyRate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewBuyRate.DecimalPlaces = 2;
            this.txtNewBuyRate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtNewBuyRate.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.txtNewBuyRate.ForeColor = System.Drawing.Color.Lime;
            this.txtNewBuyRate.Location = new System.Drawing.Point(4, 1);
            this.txtNewBuyRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewBuyRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtNewBuyRate.Name = "txtNewBuyRate";
            this.txtNewBuyRate.Size = new System.Drawing.Size(333, 46);
            this.txtNewBuyRate.TabIndex = 120;
            this.txtNewBuyRate.ThousandsSeparator = true;
            this.txtNewBuyRate.UpDownButtonFillColor = System.Drawing.Color.Transparent;
            this.txtNewBuyRate.UpDownButtonForeColor = System.Drawing.Color.Transparent;
            this.txtNewBuyRate.ValueChanged += new System.EventHandler(this.txtNewBuyRate_ValueChanged);
            // 
            // UpdateFXInformationIcone
            // 
            this.UpdateFXInformationIcone.BorderColor = System.Drawing.Color.Transparent;
            this.UpdateFXInformationIcone.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.UpdateFXInformationIcone.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.UpdateFXInformationIcone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.UpdateFXInformationIcone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.UpdateFXInformationIcone.FillColor = System.Drawing.Color.Transparent;
            this.UpdateFXInformationIcone.Font = new System.Drawing.Font("Century Schoolbook", 16F, System.Drawing.FontStyle.Bold);
            this.UpdateFXInformationIcone.ForeColor = System.Drawing.Color.White;
            this.UpdateFXInformationIcone.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UpdateFXInformationIcone.ImageSize = new System.Drawing.Size(30, 30);
            this.UpdateFXInformationIcone.Location = new System.Drawing.Point(12, 0);
            this.UpdateFXInformationIcone.Name = "UpdateFXInformationIcone";
            this.UpdateFXInformationIcone.PressedColor = System.Drawing.Color.Transparent;
            this.UpdateFXInformationIcone.Size = new System.Drawing.Size(433, 42);
            this.UpdateFXInformationIcone.TabIndex = 136;
            this.UpdateFXInformationIcone.Text = "Update Exchange Rate ";
            this.UpdateFXInformationIcone.Click += new System.EventHandler(this.UpdateFXInformationIcone_Click);
            // 
            // txtTime
            // 
            this.txtTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtTime.BorderRadius = 10;
            this.txtTime.BorderThickness = 1;
            this.txtTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtTime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtTime.ForeColor = System.Drawing.Color.Azure;
            this.txtTime.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTime.ImageSize = new System.Drawing.Size(40, 40);
            this.txtTime.Location = new System.Drawing.Point(408, 442);
            this.txtTime.Name = "txtTime";
            this.txtTime.PressedColor = System.Drawing.Color.Transparent;
            this.txtTime.Size = new System.Drawing.Size(335, 48);
            this.txtTime.TabIndex = 150;
            this.txtTime.Text = "USR-2026-90812";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtDate
            // 
            this.txtDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtDate.BorderRadius = 10;
            this.txtDate.BorderThickness = 1;
            this.txtDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtDate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtDate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtDate.ForeColor = System.Drawing.Color.Azure;
            this.txtDate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDate.ImageSize = new System.Drawing.Size(40, 40);
            this.txtDate.Location = new System.Drawing.Point(36, 442);
            this.txtDate.Name = "txtDate";
            this.txtDate.PressedColor = System.Drawing.Color.Transparent;
            this.txtDate.Size = new System.Drawing.Size(335, 48);
            this.txtDate.TabIndex = 149;
            this.txtDate.Text = "USR-2026-90812";
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2HtmlLabel14
            // 
            this.guna2HtmlLabel14.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel14.Font = new System.Drawing.Font("Akhbar MT", 13F);
            this.guna2HtmlLabel14.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel14.Location = new System.Drawing.Point(419, 402);
            this.guna2HtmlLabel14.Name = "guna2HtmlLabel14";
            this.guna2HtmlLabel14.Size = new System.Drawing.Size(142, 36);
            this.guna2HtmlLabel14.TabIndex = 148;
            this.guna2HtmlLabel14.Text = "Update Time";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Akhbar MT", 13F);
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(47, 402);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(136, 36);
            this.guna2HtmlLabel7.TabIndex = 147;
            this.guna2HtmlLabel7.Text = "Update Date";
            // 
            // PictCurrencyNameIcone
            // 
            this.PictCurrencyNameIcone.BorderRadius = 7;
            this.PictCurrencyNameIcone.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.PictCurrencyNameIcone.ImageRotate = 0F;
            this.PictCurrencyNameIcone.Location = new System.Drawing.Point(4, 8);
            this.PictCurrencyNameIcone.Name = "PictCurrencyNameIcone";
            this.PictCurrencyNameIcone.Size = new System.Drawing.Size(35, 35);
            this.PictCurrencyNameIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictCurrencyNameIcone.TabIndex = 120;
            this.PictCurrencyNameIcone.TabStop = false;
            // 
            // CbCurrencyName
            // 
            this.CbCurrencyName.BackColor = System.Drawing.Color.Transparent;
            this.CbCurrencyName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CbCurrencyName.BorderRadius = 7;
            this.CbCurrencyName.BorderThickness = 0;
            this.CbCurrencyName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbCurrencyName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbCurrencyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCurrencyName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.CbCurrencyName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbCurrencyName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbCurrencyName.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.CbCurrencyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CbCurrencyName.IntegralHeight = false;
            this.CbCurrencyName.ItemHeight = 35;
            this.CbCurrencyName.Items.AddRange(new object[] {
            "Select Currency"});
            this.CbCurrencyName.Location = new System.Drawing.Point(41, 3);
            this.CbCurrencyName.MaxDropDownItems = 4;
            this.CbCurrencyName.Name = "CbCurrencyName";
            this.CbCurrencyName.Size = new System.Drawing.Size(293, 41);
            this.CbCurrencyName.StartIndex = 0;
            this.CbCurrencyName.TabIndex = 117;
            this.CbCurrencyName.SelectedIndexChanged += new System.EventHandler(this.CbCurrencyName_SelectedIndexChanged);
            // 
            // lbl
            // 
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.lbl.ForeColor = System.Drawing.Color.White;
            this.lbl.Location = new System.Drawing.Point(47, 109);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(131, 33);
            this.lbl.TabIndex = 140;
            this.lbl.Text = "Currency Code";
            // 
            // txtCurrentCode
            // 
            this.txtCurrentCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtCurrentCode.BorderRadius = 10;
            this.txtCurrentCode.BorderThickness = 1;
            this.txtCurrentCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCurrentCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtCurrentCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtCurrentCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtCurrentCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtCurrentCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtCurrentCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCurrentCode.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtCurrentCode.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentCode.ImageSize = new System.Drawing.Size(40, 40);
            this.txtCurrentCode.Location = new System.Drawing.Point(36, 143);
            this.txtCurrentCode.Name = "txtCurrentCode";
            this.txtCurrentCode.PressedColor = System.Drawing.Color.Transparent;
            this.txtCurrentCode.Size = new System.Drawing.Size(335, 48);
            this.txtCurrentCode.TabIndex = 132;
            this.txtCurrentCode.Text = "USR-2026-90812";
            this.txtCurrentCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Panel3.Controls.Add(this.PictCurrencyNameIcone);
            this.guna2Panel3.Controls.Add(this.CbCurrencyName);
            this.guna2Panel3.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.guna2Panel3.Location = new System.Drawing.Point(34, 46);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(337, 46);
            this.guna2Panel3.TabIndex = 129;
            // 
            // Country
            // 
            this.Country.BackColor = System.Drawing.Color.Transparent;
            this.Country.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.Country.ForeColor = System.Drawing.Color.White;
            this.Country.Location = new System.Drawing.Point(47, 16);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(80, 33);
            this.Country.TabIndex = 130;
            this.Country.Text = "Currency";
            // 
            // ToplblIcone
            // 
            this.ToplblIcone.BackColor = System.Drawing.Color.Transparent;
            this.ToplblIcone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ToplblIcone.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ToplblIcone.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ToplblIcone.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ToplblIcone.IconSize = 50;
            this.ToplblIcone.Location = new System.Drawing.Point(3, -11);
            this.ToplblIcone.Name = "ToplblIcone";
            this.ToplblIcone.Size = new System.Drawing.Size(60, 50);
            this.ToplblIcone.TabIndex = 139;
            this.ToplblIcone.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.guna2Panel4);
            this.guna2Panel1.Controls.Add(this.txtChangeReason);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel8);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel6);
            this.guna2Panel1.Controls.Add(this.txtLastUpdateBy);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel4);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel5);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2Panel1.Controls.Add(this.txtCurrentSellRate);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel1.Controls.Add(this.txtSpread);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Controls.Add(this.txtCurrentBuyRate);
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.btnConfirmUpdate);
            this.guna2Panel1.Controls.Add(this.guna2Panel9);
            this.guna2Panel1.Controls.Add(this.txtTime);
            this.guna2Panel1.Controls.Add(this.txtDate);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel14);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel7);
            this.guna2Panel1.Controls.Add(this.lbl);
            this.guna2Panel1.Controls.Add(this.txtCurrentCode);
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Controls.Add(this.Country);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.guna2Panel1.Location = new System.Drawing.Point(3, 45);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(764, 702);
            this.guna2Panel1.TabIndex = 137;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Panel4.BorderThickness = 1;
            this.guna2Panel4.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.guna2Panel4.Location = new System.Drawing.Point(34, 92);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(337, 2);
            this.guna2Panel4.TabIndex = 171;
            // 
            // txtChangeReason
            // 
            this.txtChangeReason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtChangeReason.BorderRadius = 7;
            this.txtChangeReason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChangeReason.DefaultText = "";
            this.txtChangeReason.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtChangeReason.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtChangeReason.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChangeReason.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChangeReason.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtChangeReason.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChangeReason.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.txtChangeReason.ForeColor = System.Drawing.Color.White;
            this.txtChangeReason.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChangeReason.IconLeftSize = new System.Drawing.Size(35, 35);
            this.txtChangeReason.IconRightSize = new System.Drawing.Size(35, 35);
            this.txtChangeReason.Location = new System.Drawing.Point(122, 537);
            this.txtChangeReason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChangeReason.Name = "txtChangeReason";
            this.txtChangeReason.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtChangeReason.PlaceholderText = "Enter any Reason about this Changing...";
            this.txtChangeReason.SelectedText = "";
            this.txtChangeReason.Size = new System.Drawing.Size(472, 74);
            this.txtChangeReason.TabIndex = 170;
            this.txtChangeReason.TextOffset = new System.Drawing.Point(0, -16);
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(47, 504);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(152, 33);
            this.guna2HtmlLabel8.TabIndex = 169;
            this.guna2HtmlLabel8.Text = "Change Reason :";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(422, 299);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(127, 33);
            this.guna2HtmlLabel6.TabIndex = 168;
            this.guna2HtmlLabel6.Text = "Last Update By";
            // 
            // txtLastUpdateBy
            // 
            this.txtLastUpdateBy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtLastUpdateBy.BorderRadius = 10;
            this.txtLastUpdateBy.BorderThickness = 1;
            this.txtLastUpdateBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtLastUpdateBy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtLastUpdateBy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtLastUpdateBy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtLastUpdateBy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtLastUpdateBy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtLastUpdateBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtLastUpdateBy.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtLastUpdateBy.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLastUpdateBy.ImageSize = new System.Drawing.Size(40, 40);
            this.txtLastUpdateBy.Location = new System.Drawing.Point(411, 334);
            this.txtLastUpdateBy.Name = "txtLastUpdateBy";
            this.txtLastUpdateBy.PressedColor = System.Drawing.Color.Transparent;
            this.txtLastUpdateBy.Size = new System.Drawing.Size(335, 48);
            this.txtLastUpdateBy.TabIndex = 167;
            this.txtLastUpdateBy.Text = "USR-2026-90812";
            this.txtLastUpdateBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(419, 203);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(121, 33);
            this.guna2HtmlLabel4.TabIndex = 166;
            this.guna2HtmlLabel4.Text = "New Sell Rate";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Panel2.BorderRadius = 7;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.txtNewSellRate);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.guna2Panel2.Location = new System.Drawing.Point(410, 240);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(338, 48);
            this.guna2Panel2.TabIndex = 165;
            // 
            // txtNewSellRate
            // 
            this.txtNewSellRate.BackColor = System.Drawing.Color.Transparent;
            this.txtNewSellRate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtNewSellRate.BorderRadius = 7;
            this.txtNewSellRate.BorderThickness = 0;
            this.txtNewSellRate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewSellRate.DecimalPlaces = 2;
            this.txtNewSellRate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtNewSellRate.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.txtNewSellRate.ForeColor = System.Drawing.Color.Lime;
            this.txtNewSellRate.Location = new System.Drawing.Point(4, 1);
            this.txtNewSellRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewSellRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtNewSellRate.Name = "txtNewSellRate";
            this.txtNewSellRate.Size = new System.Drawing.Size(333, 46);
            this.txtNewSellRate.TabIndex = 120;
            this.txtNewSellRate.ThousandsSeparator = true;
            this.txtNewSellRate.UpDownButtonFillColor = System.Drawing.Color.Transparent;
            this.txtNewSellRate.UpDownButtonForeColor = System.Drawing.Color.Transparent;
            this.txtNewSellRate.ValueChanged += new System.EventHandler(this.txtNewSellRate_ValueChanged);
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(47, 299);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(122, 33);
            this.guna2HtmlLabel5.TabIndex = 164;
            this.guna2HtmlLabel5.Text = "New  Buy Rate";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(419, 108);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(144, 33);
            this.guna2HtmlLabel3.TabIndex = 160;
            this.guna2HtmlLabel3.Text = "Current Sell Rate";
            // 
            // txtCurrentSellRate
            // 
            this.txtCurrentSellRate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtCurrentSellRate.BorderRadius = 10;
            this.txtCurrentSellRate.BorderThickness = 1;
            this.txtCurrentSellRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCurrentSellRate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtCurrentSellRate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtCurrentSellRate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtCurrentSellRate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtCurrentSellRate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtCurrentSellRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCurrentSellRate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtCurrentSellRate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentSellRate.ImageSize = new System.Drawing.Size(40, 40);
            this.txtCurrentSellRate.Location = new System.Drawing.Point(408, 143);
            this.txtCurrentSellRate.Name = "txtCurrentSellRate";
            this.txtCurrentSellRate.PressedColor = System.Drawing.Color.Transparent;
            this.txtCurrentSellRate.Size = new System.Drawing.Size(335, 48);
            this.txtCurrentSellRate.TabIndex = 159;
            this.txtCurrentSellRate.Text = "USR-2026-90812";
            this.txtCurrentSellRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(419, 16);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(64, 33);
            this.guna2HtmlLabel2.TabIndex = 158;
            this.guna2HtmlLabel2.Text = "Spread";
            // 
            // txtSpread
            // 
            this.txtSpread.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtSpread.BorderRadius = 10;
            this.txtSpread.BorderThickness = 1;
            this.txtSpread.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSpread.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtSpread.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtSpread.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtSpread.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtSpread.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtSpread.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSpread.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtSpread.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSpread.ImageSize = new System.Drawing.Size(40, 40);
            this.txtSpread.Location = new System.Drawing.Point(408, 51);
            this.txtSpread.Name = "txtSpread";
            this.txtSpread.PressedColor = System.Drawing.Color.Transparent;
            this.txtSpread.Size = new System.Drawing.Size(335, 48);
            this.txtSpread.TabIndex = 157;
            this.txtSpread.Text = "USR-2026-90812";
            this.txtSpread.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(47, 200);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(145, 33);
            this.guna2HtmlLabel1.TabIndex = 156;
            this.guna2HtmlLabel1.Text = "Current Buy Rate";
            // 
            // txtCurrentBuyRate
            // 
            this.txtCurrentBuyRate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtCurrentBuyRate.BorderRadius = 10;
            this.txtCurrentBuyRate.BorderThickness = 1;
            this.txtCurrentBuyRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCurrentBuyRate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtCurrentBuyRate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtCurrentBuyRate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtCurrentBuyRate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtCurrentBuyRate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtCurrentBuyRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCurrentBuyRate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtCurrentBuyRate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentBuyRate.ImageSize = new System.Drawing.Size(40, 40);
            this.txtCurrentBuyRate.Location = new System.Drawing.Point(36, 235);
            this.txtCurrentBuyRate.Name = "txtCurrentBuyRate";
            this.txtCurrentBuyRate.PressedColor = System.Drawing.Color.Transparent;
            this.txtCurrentBuyRate.Size = new System.Drawing.Size(335, 48);
            this.txtCurrentBuyRate.TabIndex = 155;
            this.txtCurrentBuyRate.Text = "USR-2026-90812";
            this.txtCurrentBuyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // FrmUpdateFX
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.ClientSize = new System.Drawing.Size(770, 752);
            this.Controls.Add(this.UpdateFXInformationIcone);
            this.Controls.Add(this.ToplblIcone);
            this.Controls.Add(this.guna2Panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUpdateFX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUpdateFX";
            this.Load += new System.EventHandler(this.FrmUpdateFX_Load);
            this.guna2Panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNewBuyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictCurrencyNameIcone)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToplblIcone)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNewSellRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnConfirmUpdate;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtNewBuyRate;
        private Guna.UI2.WinForms.Guna2Button UpdateFXInformationIcone;
        private Guna.UI2.WinForms.Guna2Button txtTime;
        private Guna.UI2.WinForms.Guna2Button txtDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel14;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2PictureBox PictCurrencyNameIcone;
        private Guna.UI2.WinForms.Guna2ComboBox CbCurrencyName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl;
        private Guna.UI2.WinForms.Guna2Button txtCurrentCode;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel Country;
        private FontAwesome.Sharp.IconPictureBox ToplblIcone;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button txtCurrentBuyRate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2Button txtCurrentSellRate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button txtSpread;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtNewSellRate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2Button txtLastUpdateBy;
        private Guna.UI2.WinForms.Guna2TextBox txtChangeReason;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
    }
}