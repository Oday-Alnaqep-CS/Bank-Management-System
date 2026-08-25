using BankSystemBuisniseLayer;
using FontAwesome.Sharp;
using NetTopologySuite.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Managment_System
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer |
                  ControlStyles.UserPaint |
                  ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {


            this.DialogResult = DialogResult.None;
 



            string username = "";
            string password = "";


            if (ClsGlobal.GetStoredCredential(ref username, ref password))

            {

                TextUserName.Text = username;
                TextPassword.Text = password;
                CheRememberMe.Checked = true;

               // MessageBox.Show(username);   
            }

            else

            {
                CheRememberMe.Checked = false;
            }



            TextUserName.IconLeft = FontAwesome.Sharp.IconChar.User.ToBitmap(Color.Black, 20);
            TextPassword.IconLeft = FontAwesome.Sharp.IconChar.Lock.ToBitmap(Color.Black, 20);
           

            
            TextPassword.IconRight = FontAwesome.Sharp.IconChar.EyeSlash.ToBitmap(Color.Black, 22);

            
            TextPassword.IconRightCursor = Cursors.Hand;

            TextPassword.IconRightClick -= TextPassword_IconRightClick; 
            TextPassword.IconRightClick += TextPassword_IconRightClick;
        }

        private void TextUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextUserName.Text))

            {


                e.Cancel = true;
                TextUserName.FocusedState.BorderColor = Color.FromArgb(255, 77, 77);
                TextUserName.BorderColor = Color.FromArgb(255, 77, 77);
                errorProvider1.SetError(TextUserName, "Please enter Your username");

            }

            else

            {

                e.Cancel = false;
                errorProvider1.SetError(TextUserName, ""); 
                TextUserName.BorderColor = Color.FromArgb(94, 148, 255);
                TextUserName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);

            }

        }

        private void TextPassword_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(TextPassword.Text))

            {

                e.Cancel = true;
                TextPassword.FocusedState.BorderColor = Color.FromArgb(255, 77, 77);
                TextPassword.BorderColor = Color.FromArgb(255, 77, 77);
                errorProvider1.SetError(TextPassword, "Please enter Your password");

            }

            else

            {

                e.Cancel = false;
                errorProvider1.SetError(TextPassword, ""); 
                TextPassword.BorderColor = Color.FromArgb(94, 148, 255);
                TextPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);

            }

        }

        
        private void TextUserName_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(TextUserName.Text))

            {
                errorProvider1.SetError(TextUserName, "");
                TextUserName.BorderColor = Color.FromArgb(94, 148, 255);
                TextUserName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);

            }

        }

        private void TextPassword_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(TextPassword.Text))

            {
                errorProvider1.SetError(TextUserName, "");
                TextPassword.BorderColor = Color.FromArgb(94, 148, 255);
                TextPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);

            }

        }

        private void TextPassword_IconRightClick(object sender, EventArgs e)
        {


            if (TextPassword.PasswordChar == '\0')
            {
               
                TextPassword.PasswordChar = '*';
                TextPassword.IconRight = FontAwesome.Sharp.IconChar.EyeSlash.ToBitmap(Color.Black, 22);
            }
            else
            {
               
                TextPassword.PasswordChar = '\0';
                TextPassword.IconRight = FontAwesome.Sharp.IconChar.Eye.ToBitmap(Color.Black, 22);
            }
        }


        private void btnSignIn_Click(object sender, EventArgs e)
        {

            string ErrorMessage = string.Empty;

            string username = TextUserName.Text;
            string password = TextPassword.Text;

            ClsUser User = ClsUser.FindByUsernameAndPassword(username, password,ref ErrorMessage);

            if(User != null)

            {

                if (User.Status == 0)

                {

                    MessageBox.Show("This account is inactive. Please contact the system administrator.",
                    "Account Inactive",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return;
                }

                User.UserName = username;

                ClsGlobal.CurrentUser = User;

                if (CheRememberMe.Checked)
                {
                    
                    ClsGlobal.RememberUsernameAndPassword(username, password);
                }
                else
                {
                    
                    ClsGlobal.RememberUsernameAndPassword("", "");
                }

                FrmMain MainForm = new FrmMain();
                MainForm.Show();
                this.Hide();

            }
            else
              {

                MessageBox.Show(ErrorMessage,
                  "Invalid username or password!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }


        }



        protected override CreateParams CreateParams


        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
