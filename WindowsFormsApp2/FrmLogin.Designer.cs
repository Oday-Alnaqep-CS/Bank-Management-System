namespace Bank_Managment_System
{
    partial class FrmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TextUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.TextPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.CheRememberMe = new System.Windows.Forms.CheckBox();
            this.btnSignIn = new Guna.UI2.WinForms.Guna2Button();
            this.btnSignUp = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(653, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "BANK MANAGEMENT SYSTEM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 30.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(708, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 56);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(669, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sign into your Account";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 14.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(656, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "User Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 14.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(656, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // TextUserName
            // 
            this.TextUserName.BorderColor = System.Drawing.Color.SlateBlue;
            this.TextUserName.BorderRadius = 10;
            this.TextUserName.BorderThickness = 2;
            this.TextUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextUserName.DefaultText = "";
            this.TextUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextUserName.Font = new System.Drawing.Font("Akhbar MT", 13F);
            this.TextUserName.ForeColor = System.Drawing.Color.Black;
            this.TextUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextUserName.IconLeftSize = new System.Drawing.Size(30, 30);
            this.TextUserName.IconRightSize = new System.Drawing.Size(25, 25);
            this.TextUserName.Location = new System.Drawing.Point(649, 290);
            this.TextUserName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TextUserName.Name = "TextUserName";
            this.TextUserName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.TextUserName.PlaceholderText = "User name";
            this.TextUserName.SelectedText = "";
            this.TextUserName.Size = new System.Drawing.Size(290, 49);
            this.TextUserName.TabIndex = 7;
            this.TextUserName.TextChanged += new System.EventHandler(this.TextUserName_TextChanged);
            this.TextUserName.Validating += new System.ComponentModel.CancelEventHandler(this.TextUserName_Validating);
            // 
            // TextPassword
            // 
            this.TextPassword.BorderColor = System.Drawing.Color.SlateBlue;
            this.TextPassword.BorderRadius = 10;
            this.TextPassword.BorderThickness = 2;
            this.TextPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextPassword.DefaultText = "";
            this.TextPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextPassword.Font = new System.Drawing.Font("Akhbar MT", 13F);
            this.TextPassword.ForeColor = System.Drawing.Color.Black;
            this.TextPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextPassword.IconLeftSize = new System.Drawing.Size(35, 35);
            this.TextPassword.IconRightSize = new System.Drawing.Size(25, 25);
            this.TextPassword.Location = new System.Drawing.Point(649, 391);
            this.TextPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.PasswordChar = '*';
            this.TextPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.TextPassword.PlaceholderText = "Password";
            this.TextPassword.SelectedText = "";
            this.TextPassword.Size = new System.Drawing.Size(290, 49);
            this.TextPassword.TabIndex = 8;
            this.TextPassword.TextChanged += new System.EventHandler(this.TextPassword_TextChanged);
            this.TextPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TextPassword_Validating);
            // 
            // CheRememberMe
            // 
            this.CheRememberMe.AutoSize = true;
            this.CheRememberMe.Font = new System.Drawing.Font("Times New Roman", 16.8F, System.Drawing.FontStyle.Bold);
            this.CheRememberMe.Location = new System.Drawing.Point(700, 470);
            this.CheRememberMe.Name = "CheRememberMe";
            this.CheRememberMe.Size = new System.Drawing.Size(204, 35);
            this.CheRememberMe.TabIndex = 9;
            this.CheRememberMe.Text = "Remember Me";
            this.CheRememberMe.UseVisualStyleBackColor = true;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.Transparent;
            this.btnSignIn.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSignIn.BorderRadius = 20;
            this.btnSignIn.BorderThickness = 2;
            this.btnSignIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSignIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSignIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSignIn.FillColor = System.Drawing.Color.MidnightBlue;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 12.8F, System.Drawing.FontStyle.Bold);
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(639, 547);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(135, 49);
            this.btnSignIn.TabIndex = 10;
            this.btnSignIn.Text = "SIGN IN";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.Transparent;
            this.btnSignUp.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSignUp.BorderRadius = 20;
            this.btnSignUp.BorderThickness = 2;
            this.btnSignUp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignUp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSignUp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 12.8F, System.Drawing.FontStyle.Bold);
            this.btnSignUp.ForeColor = System.Drawing.Color.Black;
            this.btnSignUp.Location = new System.Drawing.Point(833, 547);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(135, 49);
            this.btnSignUp.TabIndex = 11;
            this.btnSignUp.Text = "SIGN UP";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 300;
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(115F, 115F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(995, 854);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.CheRememberMe);
            this.Controls.Add(this.TextPassword);
            this.Controls.Add(this.TextUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox TextUserName;
        private Guna.UI2.WinForms.Guna2TextBox TextPassword;
        private System.Windows.Forms.CheckBox CheRememberMe;
        private Guna.UI2.WinForms.Guna2Button btnSignIn;
        private Guna.UI2.WinForms.Guna2Button btnSignUp;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}