namespace Bank_Managment_System
{
    partial class FrmWithdraw
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
            this.CbCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.WithdrawInformationIcone = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirmWithdraw = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.PictAmountIcone = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtAmount = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2HtmlLabel17 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTransferTime = new Guna.UI2.WinForms.Guna2Button();
            this.txtTransferDate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.PctAccountIcone = new Guna.UI2.WinForms.Guna2PictureBox();
            this.CbAccount = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAmountAfterWithdraw = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel14 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccount = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.PictCustomerIcone = new Guna.UI2.WinForms.Guna2PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Country = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardTotalClientsicon = new Guna.UI2.WinForms.Guna2Button();
            this.Ba = new Guna.UI2.WinForms.Guna2Button();
            this.lblCurrentBalanceOfAccount = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.AfterWithdrawIcone = new FontAwesome.Sharp.IconPictureBox();
            this.CurrentBalanceIcone = new FontAwesome.Sharp.IconPictureBox();
            this.ToplblIcone = new FontAwesome.Sharp.IconPictureBox();
            this.guna2Panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictAmountIcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            this.guna2Panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctAccountIcone)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictCustomerIcone)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AfterWithdrawIcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentBalanceIcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToplblIcone)).BeginInit();
            this.SuspendLayout();
            // 
            // CbCustomer
            // 
            this.CbCustomer.BackColor = System.Drawing.Color.Transparent;
            this.CbCustomer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CbCustomer.BorderRadius = 7;
            this.CbCustomer.BorderThickness = 0;
            this.CbCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.CbCustomer.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbCustomer.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.CbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CbCustomer.IntegralHeight = false;
            this.CbCustomer.ItemHeight = 35;
            this.CbCustomer.Items.AddRange(new object[] {
            "Select Customer"});
            this.CbCustomer.Location = new System.Drawing.Point(41, 2);
            this.CbCustomer.MaxDropDownItems = 4;
            this.CbCustomer.Name = "CbCustomer";
            this.CbCustomer.Size = new System.Drawing.Size(414, 41);
            this.CbCustomer.StartIndex = 0;
            this.CbCustomer.TabIndex = 117;
            this.CbCustomer.SelectedIndexChanged += new System.EventHandler(this.CbCustomer_SelectedIndexChanged);
            // 
            // WithdrawInformationIcone
            // 
            this.WithdrawInformationIcone.BorderColor = System.Drawing.Color.Transparent;
            this.WithdrawInformationIcone.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.WithdrawInformationIcone.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.WithdrawInformationIcone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.WithdrawInformationIcone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.WithdrawInformationIcone.FillColor = System.Drawing.Color.Transparent;
            this.WithdrawInformationIcone.Font = new System.Drawing.Font("Century Schoolbook", 16F, System.Drawing.FontStyle.Bold);
            this.WithdrawInformationIcone.ForeColor = System.Drawing.Color.White;
            this.WithdrawInformationIcone.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.WithdrawInformationIcone.ImageSize = new System.Drawing.Size(30, 30);
            this.WithdrawInformationIcone.Location = new System.Drawing.Point(42, -4);
            this.WithdrawInformationIcone.Name = "WithdrawInformationIcone";
            this.WithdrawInformationIcone.PressedColor = System.Drawing.Color.Transparent;
            this.WithdrawInformationIcone.Size = new System.Drawing.Size(404, 42);
            this.WithdrawInformationIcone.TabIndex = 136;
            this.WithdrawInformationIcone.Text = "Withdraw Information";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Akhbar MT", 11F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(143, 34);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(331, 31);
            this.guna2HtmlLabel1.TabIndex = 138;
            this.guna2HtmlLabel1.Text = "\"Withdraw money from Customer account";
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
            this.btnCancel.Location = new System.Drawing.Point(505, 617);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PressedColor = System.Drawing.Color.Transparent;
            this.btnCancel.Size = new System.Drawing.Size(231, 50);
            this.btnCancel.TabIndex = 154;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirmWithdraw
            // 
            this.btnConfirmWithdraw.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConfirmWithdraw.BorderRadius = 10;
            this.btnConfirmWithdraw.BorderThickness = 2;
            this.btnConfirmWithdraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmWithdraw.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmWithdraw.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmWithdraw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirmWithdraw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirmWithdraw.FillColor = System.Drawing.Color.Transparent;
            this.btnConfirmWithdraw.Font = new System.Drawing.Font("Century Schoolbook", 16F, System.Drawing.FontStyle.Bold);
            this.btnConfirmWithdraw.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnConfirmWithdraw.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConfirmWithdraw.HoverState.ForeColor = System.Drawing.Color.Blue;
            this.btnConfirmWithdraw.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnConfirmWithdraw.ImageSize = new System.Drawing.Size(40, 40);
            this.btnConfirmWithdraw.Location = new System.Drawing.Point(51, 617);
            this.btnConfirmWithdraw.Name = "btnConfirmWithdraw";
            this.btnConfirmWithdraw.PressedColor = System.Drawing.Color.Transparent;
            this.btnConfirmWithdraw.Size = new System.Drawing.Size(397, 50);
            this.btnConfirmWithdraw.TabIndex = 153;
            this.btnConfirmWithdraw.Text = "Review Withdraw";
            this.btnConfirmWithdraw.Click += new System.EventHandler(this.btnConfirmWithdraw_Click);
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Panel9.BorderRadius = 7;
            this.guna2Panel9.BorderThickness = 1;
            this.guna2Panel9.Controls.Add(this.PictAmountIcone);
            this.guna2Panel9.Controls.Add(this.txtAmount);
            this.guna2Panel9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.guna2Panel9.Location = new System.Drawing.Point(33, 535);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.Size = new System.Drawing.Size(494, 48);
            this.guna2Panel9.TabIndex = 152;
            // 
            // PictAmountIcone
            // 
            this.PictAmountIcone.BorderRadius = 7;
            this.PictAmountIcone.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.PictAmountIcone.ImageRotate = 0F;
            this.PictAmountIcone.Location = new System.Drawing.Point(3, 8);
            this.PictAmountIcone.Name = "PictAmountIcone";
            this.PictAmountIcone.Size = new System.Drawing.Size(35, 35);
            this.PictAmountIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictAmountIcone.TabIndex = 121;
            this.PictAmountIcone.TabStop = false;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.Transparent;
            this.txtAmount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.txtAmount.BorderRadius = 7;
            this.txtAmount.BorderThickness = 0;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.txtAmount.ForeColor = System.Drawing.Color.White;
            this.txtAmount.Location = new System.Drawing.Point(39, 1);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(453, 46);
            this.txtAmount.TabIndex = 120;
            this.txtAmount.ThousandsSeparator = true;
            this.txtAmount.UpDownButtonFillColor = System.Drawing.Color.Transparent;
            this.txtAmount.UpDownButtonForeColor = System.Drawing.Color.Transparent;
            this.txtAmount.ValueChanged += new System.EventHandler(this.txtAmount_ValueChanged);
            // 
            // guna2HtmlLabel17
            // 
            this.guna2HtmlLabel17.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel17.Font = new System.Drawing.Font("Akhbar MT", 13F);
            this.guna2HtmlLabel17.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel17.Location = new System.Drawing.Point(48, 496);
            this.guna2HtmlLabel17.Name = "guna2HtmlLabel17";
            this.guna2HtmlLabel17.Size = new System.Drawing.Size(115, 37);
            this.guna2HtmlLabel17.TabIndex = 151;
            this.guna2HtmlLabel17.Text = "Amount ($)";
            // 
            // txtTransferTime
            // 
            this.txtTransferTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtTransferTime.BorderRadius = 10;
            this.txtTransferTime.BorderThickness = 1;
            this.txtTransferTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTransferTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtTransferTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtTransferTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtTransferTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtTransferTime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtTransferTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtTransferTime.ForeColor = System.Drawing.Color.Azure;
            this.txtTransferTime.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransferTime.ImageSize = new System.Drawing.Size(40, 40);
            this.txtTransferTime.Location = new System.Drawing.Point(505, 466);
            this.txtTransferTime.Name = "txtTransferTime";
            this.txtTransferTime.PressedColor = System.Drawing.Color.Transparent;
            this.txtTransferTime.Size = new System.Drawing.Size(246, 48);
            this.txtTransferTime.TabIndex = 150;
            this.txtTransferTime.Text = "USR-2026-90812";
            this.txtTransferTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtTransferDate
            // 
            this.txtTransferDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtTransferDate.BorderRadius = 10;
            this.txtTransferDate.BorderThickness = 1;
            this.txtTransferDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTransferDate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtTransferDate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtTransferDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtTransferDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtTransferDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtTransferDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtTransferDate.ForeColor = System.Drawing.Color.Azure;
            this.txtTransferDate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransferDate.ImageSize = new System.Drawing.Size(40, 40);
            this.txtTransferDate.Location = new System.Drawing.Point(225, 466);
            this.txtTransferDate.Name = "txtTransferDate";
            this.txtTransferDate.PressedColor = System.Drawing.Color.Transparent;
            this.txtTransferDate.Size = new System.Drawing.Size(264, 48);
            this.txtTransferDate.TabIndex = 149;
            this.txtTransferDate.Text = "USR-2026-90812";
            this.txtTransferDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Akhbar MT", 13F);
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(244, 426);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(149, 37);
            this.guna2HtmlLabel7.TabIndex = 147;
            this.guna2HtmlLabel7.Text = "Transfer Date";
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Panel6.BorderRadius = 7;
            this.guna2Panel6.BorderThickness = 1;
            this.guna2Panel6.Controls.Add(this.PctAccountIcone);
            this.guna2Panel6.Controls.Add(this.CbAccount);
            this.guna2Panel6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.guna2Panel6.Location = new System.Drawing.Point(141, 129);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.Size = new System.Drawing.Size(458, 48);
            this.guna2Panel6.TabIndex = 139;
            // 
            // PctAccountIcone
            // 
            this.PctAccountIcone.BorderRadius = 7;
            this.PctAccountIcone.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.PctAccountIcone.ImageRotate = 0F;
            this.PctAccountIcone.Location = new System.Drawing.Point(4, 8);
            this.PctAccountIcone.Name = "PctAccountIcone";
            this.PctAccountIcone.Size = new System.Drawing.Size(35, 35);
            this.PctAccountIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PctAccountIcone.TabIndex = 120;
            this.PctAccountIcone.TabStop = false;
            // 
            // CbAccount
            // 
            this.CbAccount.BackColor = System.Drawing.Color.Transparent;
            this.CbAccount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CbAccount.BorderRadius = 7;
            this.CbAccount.BorderThickness = 0;
            this.CbAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.CbAccount.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbAccount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbAccount.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.CbAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CbAccount.IntegralHeight = false;
            this.CbAccount.ItemHeight = 35;
            this.CbAccount.Items.AddRange(new object[] {
            "Select Customer"});
            this.CbAccount.Location = new System.Drawing.Point(41, 2);
            this.CbAccount.MaxDropDownItems = 4;
            this.CbAccount.Name = "CbAccount";
            this.CbAccount.Size = new System.Drawing.Size(414, 41);
            this.CbAccount.StartIndex = 0;
            this.CbAccount.TabIndex = 117;
            this.CbAccount.SelectedIndexChanged += new System.EventHandler(this.CbAccount_SelectedIndexChanged_1);
            // 
            // lbl
            // 
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.lbl.ForeColor = System.Drawing.Color.White;
            this.lbl.Location = new System.Drawing.Point(154, 99);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(75, 34);
            this.lbl.TabIndex = 140;
            this.lbl.Text = "Account";
            // 
            // lblAmountAfterWithdraw
            // 
            this.lblAmountAfterWithdraw.AutoSize = true;
            this.lblAmountAfterWithdraw.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblAmountAfterWithdraw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAmountAfterWithdraw.Location = new System.Drawing.Point(438, 353);
            this.lblAmountAfterWithdraw.Name = "lblAmountAfterWithdraw";
            this.lblAmountAfterWithdraw.Size = new System.Drawing.Size(68, 33);
            this.lblAmountAfterWithdraw.TabIndex = 137;
            this.lblAmountAfterWithdraw.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(440, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 24);
            this.label3.TabIndex = 138;
            this.label3.Text = "Balance after withdraw";
            // 
            // guna2HtmlLabel14
            // 
            this.guna2HtmlLabel14.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel14.Font = new System.Drawing.Font("Akhbar MT", 13F);
            this.guna2HtmlLabel14.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel14.Location = new System.Drawing.Point(519, 426);
            this.guna2HtmlLabel14.Name = "guna2HtmlLabel14";
            this.guna2HtmlLabel14.Size = new System.Drawing.Size(155, 37);
            this.guna2HtmlLabel14.TabIndex = 148;
            this.guna2HtmlLabel14.Text = "Transfer Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(57, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 24);
            this.label1.TabIndex = 132;
            this.label1.Text = "Current Balance";
            // 
            // txtAccount
            // 
            this.txtAccount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.txtAccount.BorderRadius = 10;
            this.txtAccount.BorderThickness = 1;
            this.txtAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAccount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtAccount.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAccount.ImageSize = new System.Drawing.Size(40, 40);
            this.txtAccount.Location = new System.Drawing.Point(140, 232);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.PressedColor = System.Drawing.Color.Transparent;
            this.txtAccount.Size = new System.Drawing.Size(458, 48);
            this.txtAccount.TabIndex = 132;
            this.txtAccount.Text = "USR-2026-90812";
            this.txtAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(148, 197);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(149, 34);
            this.guna2HtmlLabel6.TabIndex = 131;
            this.guna2HtmlLabel6.Text = "Account Number";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Panel3.BorderRadius = 7;
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.PictCustomerIcone);
            this.guna2Panel3.Controls.Add(this.CbCustomer);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.guna2Panel3.Location = new System.Drawing.Point(141, 35);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(458, 46);
            this.guna2Panel3.TabIndex = 129;
            // 
            // PictCustomerIcone
            // 
            this.PictCustomerIcone.BorderRadius = 7;
            this.PictCustomerIcone.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.PictCustomerIcone.ImageRotate = 0F;
            this.PictCustomerIcone.Location = new System.Drawing.Point(4, 7);
            this.PictCustomerIcone.Name = "PictCustomerIcone";
            this.PictCustomerIcone.Size = new System.Drawing.Size(35, 35);
            this.PictCustomerIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictCustomerIcone.TabIndex = 120;
            this.PictCustomerIcone.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Country
            // 
            this.Country.BackColor = System.Drawing.Color.Transparent;
            this.Country.Font = new System.Drawing.Font("Akhbar MT", 12F);
            this.Country.ForeColor = System.Drawing.Color.White;
            this.Country.Location = new System.Drawing.Point(154, 5);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(88, 34);
            this.Country.TabIndex = 130;
            this.Country.Text = "Customer";
            // 
            // cardTotalClientsicon
            // 
            this.cardTotalClientsicon.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cardTotalClientsicon.BorderRadius = 10;
            this.cardTotalClientsicon.BorderThickness = 1;
            this.cardTotalClientsicon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cardTotalClientsicon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cardTotalClientsicon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cardTotalClientsicon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cardTotalClientsicon.FillColor = System.Drawing.Color.Transparent;
            this.cardTotalClientsicon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cardTotalClientsicon.ForeColor = System.Drawing.Color.White;
            this.cardTotalClientsicon.Location = new System.Drawing.Point(31, 306);
            this.cardTotalClientsicon.Name = "cardTotalClientsicon";
            this.cardTotalClientsicon.Size = new System.Drawing.Size(323, 103);
            this.cardTotalClientsicon.TabIndex = 133;
            // 
            // Ba
            // 
            this.Ba.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Ba.BorderRadius = 10;
            this.Ba.BorderThickness = 1;
            this.Ba.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Ba.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Ba.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Ba.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Ba.FillColor = System.Drawing.Color.Transparent;
            this.Ba.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Ba.ForeColor = System.Drawing.Color.White;
            this.Ba.Location = new System.Drawing.Point(402, 306);
            this.Ba.Name = "Ba";
            this.Ba.Size = new System.Drawing.Size(323, 103);
            this.Ba.TabIndex = 135;
            // 
            // lblCurrentBalanceOfAccount
            // 
            this.lblCurrentBalanceOfAccount.AutoSize = true;
            this.lblCurrentBalanceOfAccount.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblCurrentBalanceOfAccount.ForeColor = System.Drawing.Color.Transparent;
            this.lblCurrentBalanceOfAccount.Location = new System.Drawing.Point(55, 353);
            this.lblCurrentBalanceOfAccount.Name = "lblCurrentBalanceOfAccount";
            this.lblCurrentBalanceOfAccount.Size = new System.Drawing.Size(27, 33);
            this.lblCurrentBalanceOfAccount.TabIndex = 2;
            this.lblCurrentBalanceOfAccount.Text = "c";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.btnConfirmWithdraw);
            this.guna2Panel1.Controls.Add(this.guna2Panel9);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel17);
            this.guna2Panel1.Controls.Add(this.txtTransferTime);
            this.guna2Panel1.Controls.Add(this.txtTransferDate);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel14);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel7);
            this.guna2Panel1.Controls.Add(this.guna2Panel6);
            this.guna2Panel1.Controls.Add(this.lbl);
            this.guna2Panel1.Controls.Add(this.lblAmountAfterWithdraw);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.AfterWithdrawIcone);
            this.guna2Panel1.Controls.Add(this.lblCurrentBalanceOfAccount);
            this.guna2Panel1.Controls.Add(this.CurrentBalanceIcone);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.txtAccount);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel6);
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Controls.Add(this.Country);
            this.guna2Panel1.Controls.Add(this.cardTotalClientsicon);
            this.guna2Panel1.Controls.Add(this.Ba);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.guna2Panel1.Location = new System.Drawing.Point(12, 62);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(764, 702);
            this.guna2Panel1.TabIndex = 137;
            // 
            // AfterWithdrawIcone
            // 
            this.AfterWithdrawIcone.BackColor = System.Drawing.Color.Transparent;
            this.AfterWithdrawIcone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AfterWithdrawIcone.IconChar = FontAwesome.Sharp.IconChar.None;
            this.AfterWithdrawIcone.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AfterWithdrawIcone.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AfterWithdrawIcone.IconSize = 50;
            this.AfterWithdrawIcone.Location = new System.Drawing.Point(657, 313);
            this.AfterWithdrawIcone.Name = "AfterWithdrawIcone";
            this.AfterWithdrawIcone.Size = new System.Drawing.Size(60, 50);
            this.AfterWithdrawIcone.TabIndex = 136;
            this.AfterWithdrawIcone.TabStop = false;
            // 
            // CurrentBalanceIcone
            // 
            this.CurrentBalanceIcone.BackColor = System.Drawing.Color.Transparent;
            this.CurrentBalanceIcone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CurrentBalanceIcone.IconChar = FontAwesome.Sharp.IconChar.None;
            this.CurrentBalanceIcone.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CurrentBalanceIcone.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CurrentBalanceIcone.IconSize = 50;
            this.CurrentBalanceIcone.Location = new System.Drawing.Point(285, 314);
            this.CurrentBalanceIcone.Name = "CurrentBalanceIcone";
            this.CurrentBalanceIcone.Size = new System.Drawing.Size(60, 50);
            this.CurrentBalanceIcone.TabIndex = 134;
            this.CurrentBalanceIcone.TabStop = false;
            // 
            // ToplblIcone
            // 
            this.ToplblIcone.BackColor = System.Drawing.Color.Transparent;
            this.ToplblIcone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ToplblIcone.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ToplblIcone.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ToplblIcone.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ToplblIcone.IconSize = 50;
            this.ToplblIcone.Location = new System.Drawing.Point(12, 6);
            this.ToplblIcone.Name = "ToplblIcone";
            this.ToplblIcone.Size = new System.Drawing.Size(60, 50);
            this.ToplblIcone.TabIndex = 139;
            this.ToplblIcone.TabStop = false;
            // 
            // FrmWithdraw
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.ClientSize = new System.Drawing.Size(788, 774);
            this.Controls.Add(this.ToplblIcone);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.WithdrawInformationIcone);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmWithdraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmWithdraw";
            this.Load += new System.EventHandler(this.FrmWithdraw_Load);
            this.guna2Panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictAmountIcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            this.guna2Panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PctAccountIcone)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictCustomerIcone)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AfterWithdrawIcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentBalanceIcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToplblIcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox PictCustomerIcone;
        private Guna.UI2.WinForms.Guna2ComboBox CbCustomer;
        private Guna.UI2.WinForms.Guna2Button WithdrawInformationIcone;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnConfirmWithdraw;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private Guna.UI2.WinForms.Guna2PictureBox PictAmountIcone;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtAmount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel17;
        private Guna.UI2.WinForms.Guna2Button txtTransferTime;
        private Guna.UI2.WinForms.Guna2Button txtTransferDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private Guna.UI2.WinForms.Guna2PictureBox PctAccountIcone;
        private Guna.UI2.WinForms.Guna2ComboBox CbAccount;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl;
        private System.Windows.Forms.Label lblAmountAfterWithdraw;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconPictureBox ToplblIcone;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel14;
        private FontAwesome.Sharp.IconPictureBox AfterWithdrawIcone;
        private FontAwesome.Sharp.IconPictureBox CurrentBalanceIcone;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button txtAccount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2HtmlLabel Country;
        private Guna.UI2.WinForms.Guna2Button cardTotalClientsicon;
        private Guna.UI2.WinForms.Guna2Button Ba;
        private System.Windows.Forms.Label lblCurrentBalanceOfAccount;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}