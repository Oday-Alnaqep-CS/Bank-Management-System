using AForge.Video;
using AForge.Video.DirectShow;
using BankSystemBuisniseLayer;
using BankSystemBusinessLayer;
using BankSystemDataAccess.Financial;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Internal.Vectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static BankSystemBuisniseLayer.ClsClient;
using static BankSystemBuisniseLayer.ClsPerson;
using static BankSystemDataAccess.Financial.ClsAccount;
using static OpenCvSharp.Stitcher;

namespace Bank_Managment_System
{
    public partial class UC_AddUser : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        ClsUser _User = new ClsUser();
        ClsNotification _Notification = new ClsNotification();
        private string _UserID = null;

        string _SelectedImagePath = null;
        public UC_AddUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
            lblTitle1.Text = "User Management  > Add New User";
            lblTitle.Text = "Add New User";
            lblTitle.Image = IconChar.AddressCard.ToBitmap(Color.DodgerBlue);

        }

        public UC_AddUser(string UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;

            lblTitle1.Text = "User Management  >  Update User";
            lblTitle.Text = "Update User";
            lblTitle.Image = IconChar.Edit.ToBitmap(Color.DodgerBlue);




        }

        private void US_AddUser_Load(object sender, EventArgs e)
        {
          
              this.DoubleBuffered = true;

            _Design();
            _ApplyRadioButtonStyle(Check_ActiveAccount);
            _ApplyRadioButtonStyle(Check_LockedAccount);
            _ApplyRadioButtonStyle(Check_InActiveAccount);
            _ApplyRadioButtonStyle(Gender_Female);
            _ApplyRadioButtonStyle(Gender_Male);
            _FillAllDepartments();
            _FillAllUserRoles();
            txtUserID.Text = ClsUser.GetNextUserID();


            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _Design()

        {

            PersonalInformationIcone.Image = IconChar.UserAlt.ToBitmap(Color.DodgerBlue);
           
            txtFullName.IconLeft = IconChar.User.ToBitmap(Color.FromArgb(68, 88, 150));
            txtUsername.IconLeft = IconChar.UserAlt.ToBitmap(Color.FromArgb(68, 88, 150));
            txtNationalID.IconLeft = IconChar.IdCard.ToBitmap(Color.FromArgb(68, 88, 150));
            txtEmailAddress.IconLeft = IconChar.Envelope.ToBitmap(Color.FromArgb(68, 88, 150));
            txtPhoneNumber.IconLeft = IconChar.Phone.ToBitmap(Color.FromArgb(68, 88, 150));
            txtPassword.IconLeft = IconChar.Lock.ToBitmap(Color.FromArgb(68, 88, 150));
            txtConfirmPassword.IconLeft = IconChar.Lock.ToBitmap(Color.FromArgb(68, 88, 150));
            txtJobTitle.IconLeft = IconChar.Briefcase.ToBitmap(Color.FromArgb(68, 88, 150));
            txtUserNote.IconLeft = IconChar.StickyNote.ToBitmap(Color.FromArgb(68, 88, 150));


            AccountInformationIcone.Image = IconChar.Lock.ToBitmap(Color.SlateBlue);
            AdditionalInformantionIcone.Image = IconChar.InfoCircle.ToBitmap(Color.SlateBlue);
            PictDepartmentIcone.Image = IconChar.Bank.ToBitmap(Color.DodgerBlue);
            RolePermissionIcone.Image = IconChar.ShieldAlt.ToBitmap(Color.FromArgb(16, 185, 129), 30);
            AccountStatusIcon.Image = IconChar.Clock.ToBitmap(Color.Olive, 30);
            PictIconeCamera1.Image = Properties.Resources.Camera;//IconChar.CameraAlt.ToBitmap(Color.White  );
            PictUserhoto.Image = Properties.Resources.DefaultImage1;//IconChar.CameraAlt.ToBitmap(Color.White  );

       
            txtUserID.Image = IconChar.Copy.ToBitmap(Color.CornflowerBlue);
            btnSaveUser.Image = IconChar.Save.ToBitmap(Color.DodgerBlue);
            btnCancel.Image = IconChar.Cancel.ToBitmap(Color.Red);


        }

        private void _FillAllDepartments()

        {
            string ErrorMessage = string.Empty;
            DataTable dtDepartments = ClsUser.GetDepartments(ref ErrorMessage );
           
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                return;
            }

            CbDepartment.DataSource = dtDepartments;
            CbDepartment.DisplayMember = "DepartmentName";
            CbDepartment.ValueMember = "DepartmentID";

            CbDepartment.SelectedIndex = 4; 
        }

        private void _FillAllUserRoles()

        {
            string ErrorMessage = string.Empty;
            DataTable dtUserRoles = ClsRolePermission.GetAllUserRoles(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                return;
            }

            CbUserRole.DataSource = dtUserRoles;
            CbUserRole.DisplayMember = "RoleName";
            CbUserRole.ValueMember = "RoleID";

            CbUserRole.SelectedIndex = 0; 
        }

        private void _ApplyRadioButtonStyle(Guna.UI2.WinForms.Guna2CustomRadioButton radioButton)
        {

            radioButton.CheckedState.InnerColor = Color.Transparent;
            radioButton.UncheckedState.InnerColor = Color.Transparent;


            radioButton.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            radioButton.CheckedState.FillColor = Color.Transparent;
            radioButton.CheckedState.BorderThickness = 3;


            radioButton.UncheckedState.BorderColor = Color.FromArgb(70, 85, 110);
            radioButton.UncheckedState.FillColor = Color.Transparent;
            radioButton.UncheckedState.BorderThickness = 2;


            radioButton.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void Check_ActiveAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_ActiveAccount.Checked)
            {

                Check_ActiveAccount.BackgroundImage = IconChar.Check.ToBitmap(Color.FromArgb(94, 148, 255), 30);
                lblIsActive.ForeColor = Color.Lime;
            }
            else
            {

                Check_ActiveAccount.BackgroundImage = null;
                lblIsActive.ForeColor = Color.White;

            }
        }

        private void Check_InActiveAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_InActiveAccount.Checked)
            {

                Check_InActiveAccount.BackgroundImage = IconChar.Check.ToBitmap(Color.FromArgb(94, 148, 255), 30);
                lblIsInActive.ForeColor = Color.Red;
            }
            else
            {

                Check_InActiveAccount.BackgroundImage = null;
                lblIsInActive.ForeColor = Color.White;
            }
        }

        private void Check_LockedAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_LockedAccount.Checked)
            {
                Check_LockedAccount.BackgroundImage = IconChar.Check.ToBitmap(Color.FromArgb(94, 148, 255), 30);
                lblIsLocked.ForeColor = Color.Orange; // لون أصفر/برتقالي تحذيري متناسق مع حالة القفل
            }
            else
            {
                Check_LockedAccount.BackgroundImage = null;
                lblIsLocked.ForeColor = Color.White;
            }
        }

        private void Gender_Male_CheckedChanged(object sender, EventArgs e)
        {
            if (Gender_Male.Checked)
            {

                Gender_Male.BackgroundImage = IconChar.Check.ToBitmap(Color.FromArgb(94, 148, 255), 30);
            }
            else
            {
                Gender_Male.BackgroundImage = null;
            }
        }

        private void Gender_Female_CheckedChanged(object sender, EventArgs e)
        {
            if (Gender_Female.Checked)
            {
                Gender_Female.BackgroundImage = IconChar.Check.ToBitmap(Color.FromArgb(94, 148, 255), 30);
            }
            else
            {
                Gender_Female.BackgroundImage = null;
            }
                
        }

        private IconChar _GetIconForControl(string controlName)
        {

            switch (controlName)
            {
                case "txtFullName":
                    return IconChar.User;

                case "txtUsername":
                    return IconChar.UserAlt;

                case "btnCopyUserID":
                    return IconChar.Copy;

                case "txtEmailAddress":
                    return IconChar.Envelope;

                case "txtPhoneNumber":
                    return IconChar.Phone;

                case "txtNationalID":
                    return IconChar.IdCard;

                case "txtPassword":
                    return IconChar.Lock;  

                case "txtConfirmPassword":
                    return IconChar.Lock;  

                case "txtJobTitle":
                    return IconChar.Briefcase;

                case "txtUserNote":
                    return IconChar.StickyNote;

                default:
                    return IconChar.Pen;

            }
        }

        private void txtInput(object sender, EventArgs e)
        {


            if (sender is Guna2TextBox txt)
            {

                IconChar icon = _GetIconForControl(txt.Name);


                bool hasText = !string.IsNullOrEmpty(txt.Text.Trim());

                Color iconColor = hasText ? Color.DodgerBlue : Color.FromArgb(68, 88, 112);


                txt.BorderColor = hasText ? Color.DodgerBlue : Color.FromArgb(68, 88, 112);

                Image oldImage = txt.IconLeft;
                txt.IconLeft = icon.ToBitmap(iconColor, 20);
                oldImage?.Dispose();
            }

        }

        private void txtInputComfirmPassword(object sender, EventArgs e)
        {

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                txtConfirmPassword.IconLeft = IconChar.Lock.ToBitmap(Color.Red);
                txtConfirmPassword.BorderColor = Color.Red;
                txtConfirmPassword.FocusedState.BorderColor = Color.Red;
                errorProvider1.SetError(txtConfirmPassword, "Password and confirmation do not match!");
            }
            else
            {
                txtConfirmPassword.IconLeft = IconChar.Lock.ToBitmap(Color.FromArgb(68, 88, 150));
                txtConfirmPassword.BorderColor = Color.FromArgb(94, 148, 255);
                txtConfirmPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                errorProvider1.SetError(txtConfirmPassword, string.Empty);
            }

        }

        private bool _ValidateControl(Control control, string ErrorMessage)
        {

            bool isInvalid = false;

            if (control is Guna2TextBox txt)
            {
                isInvalid = string.IsNullOrEmpty(txt.Text.Trim());
            }
            else if (control is Guna2NumericUpDown num)
            {
                isInvalid = num.Value <= 0;
            }

            if (isInvalid)
            {
                errorProvider1.SetError(control, ErrorMessage);
                return false;
            }
            else
            {
                errorProvider1.SetError(control, string.Empty);
                return true;
            }


        }

        private bool _ValidateRadioGroup(Guna2CustomRadioButton radio1, Guna2CustomRadioButton radio2, Guna2CustomRadioButton radio3, string errorMessage)
        {
            bool isInvalid = !(radio1.Checked || radio2.Checked || radio3.Checked);

            if (isInvalid)
            {

                errorProvider1.SetError(radio2, errorMessage);
                return false;
            }


            errorProvider1.SetError(radio2, string.Empty);
            return true;
        }

        private bool _ValidateForm()
        {
            bool isValid = true;

            isValid &= _ValidateControl(txtFullName, "Please enter full name");
            isValid &= _ValidateControl(txtUsername, "Please enter username");
            isValid &= _ValidateControl(txtNationalID, "Please enter national ID");
            isValid &= _ValidateControl(txtPhoneNumber, "Please enter phone number");
            isValid &= _ValidateControl(txtEmailAddress, "Please enter email address");
            isValid &= _ValidateRadioGroup(Gender_Male, Gender_Female, Check_LockedAccount, "Please select gender");


            isValid &= _ValidateControl(txtPassword, "Please enter password");
            isValid &= _ValidateControl(txtConfirmPassword, "Please confirm password");
            //isValid &= _ValidateControl(txtPassword, "Passwords do not match");

           
            isValid &= _ValidateControl(txtJobTitle, "Please enter job title");
           // isValid &= _ValidateComboBox(cbDepartments, "Please select department");
            //isValid &= _ValidateComboBox(cbUserRole, "Please select user role");

            // التحقق من مجموعة أزرار الحالة (Active, Inactive, Locked)
            isValid &= _ValidateRadioGroup(Check_ActiveAccount, Check_InActiveAccount, Check_LockedAccount, "Please select account status");
           
            return isValid;
        }

        private void btnCopyUserID_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserID.Text.Trim()))
            {
                Clipboard.SetText(txtUserID.Text.Trim());

                ClsBankingNotification.ShowBankingNotification("Success", "Copied to clipboard successfully", ClsBankingNotification.NotificationType.Success);
            }
            else
            {
                MessageBox.Show("There is no text to copy!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void PictIconeCamera1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @"C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage";



                openFileDialog.RestoreDirectory = true; //


                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Customer Photo";


                if (openFileDialog.ShowDialog() == DialogResult.OK)

                {

                    _SelectedImagePath = openFileDialog.FileName;

                    PictUserhoto.Tag = _SelectedImagePath;


                    //if (_Client != null && _Client.PersonInfo != null)
                    //{
                    //    _Client.PersonInfo.ImagePath = _SelectedImagePath;
                    //}

                    if (PictUserhoto.Image != null)
                    {
                        PictUserhoto.Image.Dispose();
                    }

                    using (var tempImage = Image.FromFile(_SelectedImagePath))
                    {
                        PictUserhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        PictUserhoto.Image = new Bitmap(tempImage);
                    }
                }
            }

        }

        public static void AddPermissionLabel(string permissionName, FlowLayoutPanel Flo)

        {
          
            Guna.UI2.WinForms.Guna2Panel Panel = new Guna.UI2.WinForms.Guna2Panel();
            Panel.Width = Flo.Width - 200; 
            Panel.Height = 40;
            Panel.BorderRadius = 10;
            Panel.FillColor = Color.FromArgb(20, 20, 20);
            Panel.Margin = new Padding(4, 5, 3, 3);
            Panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

      
            TableLayoutPanel Table = new TableLayoutPanel();
            Table.ColumnCount = 2;
            Table.RowCount = 1;
            Table.Dock = DockStyle.Fill;
            Table.BackColor = Color.Transparent;
            Table.Padding = new Padding(3);

            
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

           
            FontAwesome.Sharp.IconPictureBox picStatus = new FontAwesome.Sharp.IconPictureBox();
            picStatus.Size = new System.Drawing.Size(20, 20);
            picStatus.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            picStatus.IconColor = ColorTranslator.FromHtml("#00FF80");
            picStatus.IconSize = 20;
            picStatus.BackColor = Color.Transparent;
            picStatus.SizeMode = PictureBoxSizeMode.CenterImage;
            picStatus.Dock = DockStyle.Fill;

     
            Label lblPermission = new Label();
            lblPermission.Text = permissionName;
            lblPermission.ForeColor = Color.White;  
            lblPermission.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPermission.AutoSize = true;
            lblPermission.Anchor = AnchorStyles.Left;  
           

            Table.Controls.Add(picStatus, 0, 0);
            Table.Controls.Add(lblPermission, 1, 0);

           
            Panel.Controls.Add(Table);
            Flo.Controls.Add(Panel);

        }

        private void CbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CbUserRole.SelectedValue == null) return;

            if (int.TryParse(CbUserRole.SelectedValue.ToString(),out int RoleID))

            {
                flpPermissionsContainer.Controls.Clear();

                string ErrorMessage = string.Empty;

                DataTable dtPermissions = ClsPermission.GetPermissionByRoleID(RoleID, ref ErrorMessage);

                if (dtPermissions.Rows.Count > 0 && dtPermissions != null)

                {
                    foreach (DataRow row in dtPermissions.Rows)
                    {
                        string permName = row["PermissionName"].ToString();

                       
                        AddPermissionLabel(permName, flpPermissionsContainer);
                    }
                }


            }

        }

        private void _ResetDefaultValues()

        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtNationalID.Clear();
            txtPhoneNumber.Clear();
            txtEmailAddress.Clear();
            txtUserID.Text = "";

            txtPassword.Clear();
            txtConfirmPassword.Clear();

            txtJobTitle.Clear();
            txtUserNote.Clear();


          if (CbDepartment.Items.Count > 0) CbDepartment.SelectedIndex = 0;
          if (CbUserRole.Items.Count > 0) CbUserRole.SelectedIndex = 0;
            Check_ActiveAccount.Checked = false;
            Check_InActiveAccount.Checked = false;
            Check_LockedAccount.Checked = false;
            Gender_Female.Checked = false;
            Gender_Male.Checked = false;

            PictUserhoto.Image = Properties.Resources.DefaultImage1;
            PictUserhoto.Tag = null;
            _SelectedImagePath = null;

            _User = new ClsUser();

        }

        private void _SaveUser()

        {
            if (_Mode == enMode.AddNew)

            {
                _User.PersonInfo = new ClsPerson();
            }

            if (PictUserhoto.Tag != null)

            {

                _User.PersonInfo.ImagePath = PictUserhoto.Tag.ToString();
            }
            else
            {
                _User.PersonInfo.ImagePath = "";
            }
            string txtFirstName = "";
            string txtLastName = "";
            string fullName = txtFullName.Text.Trim();
            string[] parts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0)
            {
                txtFirstName = parts[0];
            }

            if (parts.Length > 1)
            {
                txtLastName = string.Join(" ", parts.Skip(1));
            }
            else
            {
                txtLastName = "";
            }

            string ErrorMessage = string.Empty;
         
            _User.PersonInfo.FirstName = txtFirstName;
            _User.PersonInfo.LastName = txtLastName;
           
            _User.PersonInfo.NationalID = txtNationalID.Text.Trim();
            _User.PersonInfo.Phone = txtPhoneNumber.Text.Trim();
            _User.PersonInfo.Email = txtEmailAddress.Text.Trim();

            
            _User.UserName = txtUsername.Text.Trim();
            _User.PasswordHash = txtPassword.Text.Trim();
            _User.UserID = txtUserID.Text.Trim();

           
            _User.DepartmentID = Convert.ToInt32(CbDepartment.SelectedValue); 
            _User.JobTitle = txtJobTitle.Text.Trim();
            _User.RoleID = Convert.ToInt32(CbUserRole.SelectedValue);
            _Notification.Message = txtUserNote.Text.Trim();
            _Notification.Title = "New User Notification";
            _Notification.IsRead = false;


            _User.Status = (byte)(Check_ActiveAccount.Checked ? 1 : (Check_InActiveAccount.Checked ? 0 : 2));
            _User.PersonInfo.Gender = Gender_Male.Checked ? ClsPerson.enGender.Male : ClsPerson.enGender.Female;

            if (_User.Save())
            {


                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("Error: " + _User.ErrorMessage, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _LoadData()

        {

            string ErrorMessage = string.Empty;

            if (_Mode == enMode.AddNew)
            {

                _User = new ClsUser();
                _ResetDefaultValues();
                return;
            }


            _User = ClsUser.Find(_UserID, ref ErrorMessage);


            if (_User == null)
            {

                MessageBox.Show("Error: " + ErrorMessage, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

      

            string FullName = _User.PersonInfo.FirstName + " " + _User.PersonInfo.LastName;

            txtFullName.Text = FullName;
            txtUsername.Text = _User.UserName;
            txtUserID.Text = _User.UserID;
            txtEmailAddress.Text = _User.PersonInfo.Email;
            txtPhoneNumber.Text = _User.PersonInfo.Phone;
            txtNationalID.Text = _User.PersonInfo.NationalID;
            txtJobTitle.Text = _User.JobTitle;

            txtPassword.Text = _User.PasswordHash;
            txtConfirmPassword.Text = _User.PasswordHash;

            CbUserRole.SelectedValue = _User.RoleID;
            DataTable dtPermissions = ClsPermission.GetPermissionByRoleID(_User.RoleID, ref ErrorMessage);

            if (dtPermissions.Rows.Count > 0 && dtPermissions != null)

            {
                foreach (DataRow row in dtPermissions.Rows)
                {
                    string permName = row["PermissionName"].ToString();


                    AddPermissionLabel(permName, flpPermissionsContainer);
                }
            }

            if (_User.PersonInfo.Gender == ClsPerson.enGender.Female)
            {
                Gender_Female.Checked = true;
            }
            else
            {
                Gender_Male.Checked = true;
            }
           

            if (_User.Status == 0) Check_InActiveAccount.Checked = true;
            else if ( _User.Status == 1) Check_ActiveAccount.Checked = true;
            else Check_LockedAccount.Checked = true;

            if (!string.IsNullOrEmpty(_User.PersonInfo.ImagePath) && System.IO.File.Exists(_User.PersonInfo.ImagePath))
            {

                PictUserhoto.ImageLocation = _User.PersonInfo.ImagePath;
            }
            else
            {
                PictUserhoto.Image = (_User.PersonInfo.Gender == enGender.Female)
                    ? Properties.Resources.DefaultFemaleAvatar
                    : Properties.Resources.DefaultMaleAvatar;
            }

        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (_ValidateForm())
            {

                string title = _Mode == enMode.AddNew ? "Are you sure you want to create this client?" : "Are you sure you want to update this client?";

                if (MessageBox.Show(title, "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _SaveUser();
                }

            }
            
         
            

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _ResetDefaultValues();
                ((FrmMain)this.FindForm()).LoadUserControl(new UC_UsersManagement());
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

