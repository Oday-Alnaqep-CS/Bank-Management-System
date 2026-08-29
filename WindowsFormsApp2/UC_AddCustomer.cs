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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Bank_Managment_System
{
    public partial class UC_AddCustomer : UserControl
    {


     
        private string _SelectedImagePath = string.Empty;

        public UC_AddCustomer()
        {
            InitializeComponent();
        }

        private void UC_AddCustomer_Load(object sender, EventArgs e)
        {

            //guna2CheckBox4.UncheckedState.BorderRadius = 10;
            _ApplyRadioButtonStyle(Check_ActiveAccount);
            _ApplyRadioButtonStyle(Check_InActiveAccount);
            _GenerateNationalID();
            _GenerateCustomerID();
            _FillCountriesComboBox();
            _LoadAccountTypes();
            _Design();
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
            PictCustomerPhoto.Image = Properties.Resources.DefaultMaleAvatar;



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

        private void btnUploadPhoto_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {

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

        private void AddNewCustomer()
        {
            
            ClsClient client = new ClsClient();
            client.PersonInfo = new ClsPerson();

            
            client.PersonInfo.FirstName = txtFirstName.Text.Trim();
            client.PersonInfo.LastName = txtLastName.Text.Trim();
            client.PersonInfo.NationalID = txtNationalID.Text.Trim();
            client.PersonInfo.DateOFBirth = txtDateOfBirth.Value;
            client.PersonInfo.Phone = txtPhoneNumber.Text.Trim();
            client.PersonInfo.Email = txtEmailAddress.Text.Trim();
            client.PersonInfo.Gender = Gender_Male.Checked ? ClsPerson.enGender.Male : ClsPerson.enGender.Female;
            client.PersonInfo.CityID = Convert.ToInt32(CbCities.SelectedValue ?? -1);

           
            client.ClientType = (byte)ClsClient.enClientType.Standard;
            client.Status = (byte)(Check_ActiveAccount.Checked ? 1 : 0);

            
            if (client.Save())
            {
               
                ClsAccount account = new ClsAccount();
                account.ClientID = client.ClientID;


                account.AccountNumber = "ACC-" + DateTime.Now.Ticks.ToString().Substring(10);
                account.IBAN = "YE93BANK" + DateTime.Now.Ticks.ToString().Substring(8);
                account.AccountTypeID = Convert.ToInt32(CbAccountType.SelectedValue ?? 1);
                account.BranchID = Convert.ToInt32(CbBranches.SelectedValue ?? 1);
                account.CurrencyID = 1; // USD default
                account.Balance = Convert.ToDecimal(txtInitialDepositBalance.Text.Trim());
                account.Status = 1;

                if (account.Save())
                {

                    btnCopyAccountNumber.Text = $"CUST-2026-{client.ClientID:D5}";

                    MessageBox.Show($"Customer and Bank Account created successfully!\n\n" +
                                    $"Client ID: {client.ClientID}\n" +
                                    $"Account ID: {account.AccountID}",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Customer saved, but failed to create Bank Account:\n{account.ErrorMessage}",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show($"Failed to save customer data:\n{client.ErrorMessage}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            if (_ValidateForm())
            {
                AddNewCustomer();
            }
        }

        private void txtNationalID_TextChanged(object sender, EventArgs e)
        {

        }

    
    }
}
