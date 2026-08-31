using AForge.Video;
using AForge.Video.DirectShow;
using BankSystemBuisniseLayer;
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
using System.Windows.Forms;
using static BankSystemBuisniseLayer.ClsClient;
using static BankSystemDataAccess.Financial.ClsAccount;


namespace Bank_Managment_System
{
    public partial class UC_AddCustomer : UserControl
    {

        private ClsClient _Client = new ClsClient();
        private string _SelectedImagePath = string.Empty;
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _ClientID = -1;
       

        public UC_AddCustomer()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;


        }

        public UC_AddCustomer(int clientID)
        {
            InitializeComponent();
            _ClientID = clientID;
            _Mode = enMode.Update;
        }

        private void UC_AddCustomer_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            _ResetDefaultValues();

           
            _ApplyRadioButtonStyle(Check_ActiveAccount);
            _ApplyRadioButtonStyle(Check_InActiveAccount);
            _FillCountriesComboBox();
            _LoadAccountTypes();
            _Design();

          
            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
            else
            {
                _GenerateNationalID();
                string ErrorMessage = string.Empty;
                int NextID = ClsClient.GetNextClientID(ErrorMessage);
                btnCopyAccountNumber.Text = $"CUST-2026-{NextID:D4}";
            }

        }
    
        private void _Design()

        {

            PersonalInformation.Image = IconChar.UserAlt.ToBitmap(Color.DodgerBlue);
            txtFirstName.IconLeft = IconChar.UserAlt.ToBitmap(Color.FromArgb(68, 88, 150));
            txtSecondName.IconLeft = IconChar.UserAlt.ToBitmap(Color.FromArgb(68, 88, 150));
            txtLastName.IconLeft = IconChar.UserAlt.ToBitmap(Color.FromArgb(68, 88, 150));
            txtNationalID.IconLeft = IconChar.IdCard.ToBitmap(Color.FromArgb(68, 88, 150));
            txtEmailAddress.IconLeft = IconChar.Envelope.ToBitmap(Color.FromArgb(68, 88, 150));
            txtPhoneNumber.IconLeft = IconChar.Phone.ToBitmap(Color.FromArgb(68, 88, 150));


            CONTACTLOCATIONDETAILS.Image = IconChar.Phone.ToBitmap(Color.DodgerBlue);
            PictCountryIcone.Image = IconChar.Globe.ToBitmap(Color.DodgerBlue);
            PictCityIcone.Image = IconChar.Bank.ToBitmap(Color.DodgerBlue);
            PictBaranchIcone.Image = IconChar.LocationPin.ToBitmap(Color.DodgerBlue);
            PictAccountTypeIcone.Image = IconChar.Wallet.ToBitmap(Color.DodgerBlue);
            PictInitialDepositIcone.Image  = IconChar.MoneyBill.ToBitmap(Color.DodgerBlue);
            PictIconeCamera.Image = Properties.Resources.Camera;//IconChar.CameraAlt.ToBitmap(Color.White  );
            PictCustomerPhoto.Image = Properties.Resources.DefaultImage;   // PictCustomerPhoto.Image = Properties.Resources.DefaultMaleAvatar;

            btnUploadPhoto.Image = IconChar.FolderOpen.ToBitmap(Color.Gold, 20);//IconChar.Upload.ToBitmap(Color.White, 20);
            btnRemovePhoto.Image = IconChar.Trash.ToBitmap(Color.Red, 15);
            btnCopyAccountNumber.Image = IconChar.Copy.ToBitmap(Color.CornflowerBlue);
            btnSaveClient.Image = IconChar.Save.ToBitmap(Color.DodgerBlue);
            btnCancel.Image = IconChar.Cancel.ToBitmap(Color.Red);


            CbCountries.MaxDropDownItems = 6;
            CbCountries.DropDownHeight = 200;

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

        private void CheckActiveAccount_CheckedChanged(object sender, EventArgs e)
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

        private void CheckInActiveAccount_CheckedChanged(object sender, EventArgs e)
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

        private void UploadPhotoFromFile(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @"C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage";


                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                openFileDialog.RestoreDirectory = true; //


                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Customer Photo";


                if (openFileDialog.ShowDialog() == DialogResult.OK)

                {

                    _SelectedImagePath = openFileDialog.FileName;

                    PictCustomerPhoto.Tag = _SelectedImagePath;


                    //if (_Client != null && _Client.PersonInfo != null)
                    //{
                    //    _Client.PersonInfo.ImagePath = _SelectedImagePath;
                    //}

                    if (PictCustomerPhoto.Image != null)
                    {
                        PictCustomerPhoto.Image.Dispose();
                    }

                    using (var tempImage = Image.FromFile(_SelectedImagePath))
                    {
                        PictCustomerPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        PictCustomerPhoto.Image = new Bitmap(tempImage);
                    }
                }
            }

        }

        private void btnRemovePhoto_Click(object sender, EventArgs e)
        {

            PictCustomerPhoto.Image.Dispose();
            PictCustomerPhoto.Image = null;
            PictCustomerPhoto.Image = Properties.Resources.DefaultMaleAvatar;

        }

        private IconChar _GetIconForControl(string controlName)
        {
            switch (controlName)
            {
                case "txtFirstName":
                case "txtSecondName":
                case "txtLastName":
                    return IconChar.UserAlt;

                case "txtPhoneNumber":
                    return IconChar.Phone;

                case "txtEmailAddress":
                    return IconChar.Envelope;

                case "txtNationalID":
                    return IconChar.IdCard;

                default:
                    return IconChar.Pen; 
            }
        }

        private void txtInput_TextChange(object sender, EventArgs e)
        {

            if (sender is Guna2TextBox txt)
            {

                IconChar icon = _GetIconForControl(txt.Name);


                bool hasText = !string.IsNullOrEmpty(txt.Text.Trim());
                Color iconColor = hasText ? Color.DodgerBlue : Color.FromArgb(68, 88, 112);


                Image oldImage = txt.IconLeft;
                txt.IconLeft = icon.ToBitmap(iconColor, 20);
                oldImage?.Dispose();
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

        private bool _ValidateRadioGroup(Guna2CustomRadioButton radio1, Guna2CustomRadioButton radio2, string errorMessage)
        {
            bool isInvalid = !(radio1.Checked || radio2.Checked);

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

          
            isValid &= _ValidateControl(txtFirstName, "Please enter first name");
            isValid &= _ValidateControl(txtSecondName, "Please enter second name");
            isValid &= _ValidateControl(txtLastName, "Please enter last name");
            isValid &= _ValidateControl(txtNationalID, "Please enter national ID");
            isValid &= _ValidateControl(txtPhoneNumber, "Please enter phone number");
            isValid &= _ValidateControl(txtEmailAddress, "Please enter email address");
            isValid &= _ValidateControl(txtInitialDepositBalance, "Please enter Initial deposit amount");
            isValid &= _ValidateRadioGroup(Gender_Male, Gender_Female, "Please select gender");
            isValid &= _ValidateRadioGroup(Check_ActiveAccount, Check_InActiveAccount, "Please select account status");

            isValid &= _ValidateControl(txtInitialDepositBalance, "Please enter an initial deposit amount greater than zero");

            return isValid;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void btnCopyAccountNumber_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(btnCopyAccountNumber.Text.Trim()))
            {
                Clipboard.SetText(btnCopyAccountNumber.Text.Trim());

                ClsBankingNotification.ShowBankingNotification("Success", "Copied to clipboard successfully", ClsBankingNotification.NotificationType.Success);
            }
            else
            {
                MessageBox.Show("There is no text to copy!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void _GenerateNationalID()

        {

            Random random = new Random();
           
            txtNationalID.Text = random.Next(100000000, 1000000000).ToString();

        }

        private void _GenerateCustomerID()

        {

            Random random = new Random();

   //         btnCopyAccountNumber.Text = "CUST-2026-" + random.Next(1000, 10000).ToString();
        }

        private void _FillCountriesComboBox()
        {
            string ErrorMessage = string.Empty;

            DataTable dtCountries = ClsCountry.GetAllCountries(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))
            {

                ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                return;
            }

            CbCountries.DataSource = dtCountries;
            CbCountries.DisplayMember = "CountryName";
            CbCountries.ValueMember = "CountryID";

            
            CbCountries.SelectedIndex = -1;
        }

        private void CbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CbCountries.SelectedValue != null && int.TryParse(CbCountries.SelectedValue.ToString(), out int CountryID))
            {
                string ErrorMessage = string.Empty;

                DataTable dtCities = ClsCities.GetCitiesByCountryID(CountryID, ref ErrorMessage);

                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                    return;
                }

               

                CbCities.DisplayMember = "CityName";
                CbCities.ValueMember = "CityID";
                CbCities.DataSource = dtCities;
                CbCities.SelectedIndex = -1;

                
                CbBranches.DataSource = null;
            }
        }

        private void CbCities_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CbCities.SelectedValue != null && int.TryParse(CbCities.SelectedValue.ToString(), out int CityID ))
            {
                string ErrorMessage = string.Empty;

                DataTable dtBranches = ClsBranch.GetBranchesByCityID(CityID, ref ErrorMessage);

                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage);
                    return;
                }

                CbBranches.DisplayMember = "BranchName";
                CbBranches.ValueMember = "BranchID";
                CbBranches.DataSource = dtBranches;
                CbBranches.SelectedIndex = -1;
            }

        }

        private void _LoadAccountTypes()
        {
            string ErrorMessage = string.Empty;
            DataTable dtAccountTypes = ClsAccount.GetAccountType(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage);
                return;
            }

            if (dtAccountTypes != null && dtAccountTypes.Rows.Count > 0)
            {
                CbAccountType.DisplayMember = "TypeName";
                CbAccountType.ValueMember = "AccountTypeID";
                CbAccountType.DataSource = dtAccountTypes;
                CbAccountType.SelectedIndex = -1;
            }
        }

        private void _SaveCustomer()
        {

            if (_Mode == enMode.AddNew)
            {
                _Client.PersonInfo = new ClsPerson();
            }

          

            if (PictCustomerPhoto.Tag != null)
            {
                _Client.PersonInfo.ImagePath = PictCustomerPhoto.Tag.ToString();
            }
            else
            {
                _Client.PersonInfo.ImagePath = "";
            }
            _Client.PersonInfo.FirstName = txtFirstName.Text.Trim();
            _Client.PersonInfo.LastName = txtLastName.Text.Trim();
            _Client.PersonInfo.NationalID = txtNationalID.Text.Trim();
            _Client.PersonInfo.DateOFBirth = txtDateOfBirth.Value;
            _Client.PersonInfo.Phone = txtPhoneNumber.Text.Trim();
            _Client.PersonInfo.Email = txtEmailAddress.Text.Trim();
            _Client.PersonInfo.Gender = Gender_Male.Checked ? ClsPerson.enGender.Male : ClsPerson.enGender.Female;
            _Client.PersonInfo.CityID = Convert.ToInt32(CbCities.SelectedValue ?? -1);

           
            _Client.ClientType = (byte)ClsClient.enClientType.Standard;
            _Client.Status = (byte)(Check_ActiveAccount.Checked ? 1 : 0);


            if (_Client.Save())
            {


                if (_Mode == enMode.AddNew)
                {

                    ClsAccount account = new ClsAccount();
                    account.ClientID = _Client.ClientID;


                    account.AccountNumber = "ACC-" + DateTime.Now.Ticks.ToString().Substring(10);
                    account.IBAN = "YE93BANK" + DateTime.Now.Ticks.ToString().Substring(8);
                    account.AccountTypeID = Convert.ToInt32(CbAccountType.SelectedValue ?? 1);
                    account.BranchID = Convert.ToInt32(CbBranches.SelectedValue ?? 1);
                    account.CurrencyID = 1; // USD default
                    account.Balance = Convert.ToDecimal(txtInitialDepositBalance.Text.Trim());
                    account.Status = 1;

                    if (account.Save())
                    {





                        MessageBox.Show($"Customer and Bank Account created successfully!\n\n" +
                                        $"Client ID: {_Client.ClientID}\n" +
                                        $"Account ID: {account.AccountID}",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Customer saved, but failed to create Bank Account:\n{account.ErrorMessage}",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    _Mode = enMode.Update;
                    _ClientID = _Client.ClientID;

                }
                else
                {
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show($"Failed to save customer data:\n{_Client.ErrorMessage}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void _LoadData()

        {

            string ErrorMessage = string.Empty;
            if(_Mode == enMode.AddNew)
            {
                _Client = new ClsClient();
                _ResetDefaultValues();
                return;
            }

            _Client = ClsClient.Find(_ClientID, ref ErrorMessage);

            if (_Client == null)
            {
                MessageBox.Show("This client was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFirstName.Text = _Client.PersonInfo.FirstName;
            txtSecondName.Text = ""; // _Client.PersonInfo.SecondName;
            txtLastName.Text = _Client.PersonInfo.LastName;
            txtNationalID.Text = _Client.PersonInfo.NationalID;
            txtEmailAddress.Text = _Client.PersonInfo.Email;
            txtPhoneNumber.Text = _Client.PersonInfo.Phone;
        //    txtDateOfBirth.Value = _Client.PersonInfo.DateOFBirth;

            if (_Client.PersonInfo.Gender == 0) Gender_Female.Checked = true;
            else Gender_Male.Checked = true;

            if (_Client.Status == 0) Check_InActiveAccount.Checked = true;
            else Check_ActiveAccount.Checked = true;

            int CountryID = ClsCountry.GetCountryIdByCityID(_Client.PersonInfo.CityID, ref ErrorMessage);
            int BranchID = ClsBranch.GetBranchIDByCityID(_Client.PersonInfo.CityID,ref ErrorMessage);

            CbCountries.SelectedValue = CountryID;
            CbCities.SelectedValue = _Client.PersonInfo.CityID;
            CbBranches.SelectedValue = BranchID;

            if (!string.IsNullOrEmpty(_Client.PersonInfo.ImagePath) && System.IO.File.Exists(_Client.PersonInfo.ImagePath))
            {
                PictCustomerPhoto.ImageLocation = _Client.PersonInfo.ImagePath;
            }

            else
            {
                PictCustomerPhoto.Image = _Client.PersonInfo.Gender == 0 ? Properties.Resources.DefaultMaleAvatar : Properties.Resources.DefaultFemaleAvatar;
            }

          
            btnCopyAccountNumber.Text = $"CUST-2026-{_Client.ClientID:D5}";
        }

        private void _ResetDefaultValues()
        {
            
            txtFirstName.Clear();
            txtSecondName.Clear();
            txtLastName.Clear();
            txtNationalID.Clear();
            txtEmailAddress.Clear();
            txtPhoneNumber.Clear();
         

          
            txtDateOfBirth.Value = DateTime.Now;
            Gender_Male.Checked = false;            
            Gender_Female.Checked = false;
            Check_ActiveAccount.Checked = false;
            Check_InActiveAccount.Checked = false;




            if (CbCountries.Items.Count > 0) CbCountries.SelectedIndex = 0;
            if (CbCities.Items.Count > 0) CbCities.SelectedIndex = 0;
            if (CbBranches.Items.Count > 0) CbBranches.SelectedIndex = 0;
            if (CbAccountType.Items.Count > 0) CbAccountType.SelectedIndex = 0;

            PictCustomerPhoto.Image = Properties.Resources.DefaultImage;
            PictCustomerPhoto.Tag = null;
            _SelectedImagePath = string.Empty;

           
            _Client = new ClsClient();
            btnCopyAccountNumber.Text = $"CUST-2026-{ClsClient.GetNextClientID(""):D4}";
        }
        
        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            if (_ValidateForm())
            {

                string title = _Mode == enMode.AddNew ? "Are you sure you want to create this client?" : "Are you sure you want to update this client?";

                if (MessageBox.Show(title, "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _SaveCustomer();
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to cancel? Any unsaved data will be lost.",
                        "Confirm Cancel",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                _ResetDefaultValues();

                ((FrmMain)this.FindForm()).LoadUserControl(new UC_CustomersManagement());
                //this.Parent?.Controls.Remove(this);
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

