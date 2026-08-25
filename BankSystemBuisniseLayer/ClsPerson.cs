using BankSystemDataAccess.EntitiesData;
using System;
using System.Data;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace BankSystemBuisniseLayer
{
    public class ClsPerson
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enum enGender { Male = 1, Female = 2 }
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public enGender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CityID { get; set; }
        public string ErrorMessage { get; set; } = "";


        public ClsPerson()

        {
            this.PersonID = -1;
            this.NationalID = "";
            this.FirstName = "";
            this.LastName = "";
            this.Gender = enGender.Male;
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.CityID = -1;

            Mode = enMode.AddNew;
        }


        protected ClsPerson(int personID, string nationalID, string firstName, string lastName,
                            byte gender, string email, string phone, string address, int cityID)
        {
            this.PersonID = personID;
            this.NationalID = nationalID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = (enGender)gender;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
            this.CityID = cityID;

            Mode = enMode.Update;
        }



        private bool _AddNewPerson()
        {

            string ErrorMessage = "";

            this.PersonID = ClsPersonDataAccess.AddNewPerson(this.NationalID, this.FirstName, this.LastName,
                                                   (byte)this.Gender, this.Email, this.Phone,
                                                   this.Address, this.CityID, ref ErrorMessage);


            this.ErrorMessage = ErrorMessage;
            return (this.PersonID != 0);
          

        }

        private bool _UpdatePerson()
        {

            string ErrorMessage = "";

            bool IsUpdate = ClsPersonDataAccess.UpdatePerson(this.PersonID, this.NationalID,
                this.FirstName, this.LastName,
                                                   (byte)this.Gender, this.Email, this.Phone,
                                                   this.Address, this.CityID, ref ErrorMessage);

            this.ErrorMessage = ErrorMessage;
            return IsUpdate;


        }

        public bool Save()
        {

            bool IsSuccessed = false;

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        IsSuccessed = true;
                    }
                    else
                    {

                        IsSuccessed = false;
                    }
                    break;

                case enMode.Update:

                    return _UpdatePerson();


            }

            return IsSuccessed;
        }

        public static ClsPerson Find(int ID ,ref string ErrorMessage )
        {

            string NationalID = "", FirstName = "", LastName = "", Email = "", Phone = "", Address = "";
            byte Gender = 1;
            int CityID = -1;

            if (ClsPersonDataAccess.GetPersonByID(ID, ref NationalID, ref FirstName, ref LastName,
                                            ref Gender, ref Email, ref Phone, ref Address, ref
                                            CityID, ref ErrorMessage))
            {

                return new ClsPerson(ID, NationalID, FirstName, LastName, Gender, Email, Phone, Address, CityID);
            }

            return null;

        }

        public static ClsPerson FindByNationalID(string NationalID, ref string ErrorMessage)
        {

            int PersonID = -1;
            string  FirstName = "", LastName = "", Email = "", Phone = "", Address = "";
            byte Gender = 1;
            int CityID = -1;

            if (ClsPersonDataAccess.GetPersonByNationalID(NationalID, ref PersonID, ref FirstName, ref LastName,
                                            ref Gender, ref Email, ref Phone, ref Address, ref
                                            CityID, ref ErrorMessage))
            {

                return new ClsPerson(PersonID, NationalID, FirstName, LastName, Gender, Email, Phone, Address, CityID);
            }

            return null;


        }

        public static bool DeletePerson(int personID, ref string errorMessage)
        {
             return ClsPersonDataAccess.DeletePerson(personID, ref errorMessage);
        }

        public static DataTable GetAllPersons(ref string errorMessage)
        {
            return ClsPersonDataAccess.GetAllPersons(ref errorMessage);
        }

        public static bool IsPersonExist(int personID, ref string errorMessage)
        {
            return ClsPersonDataAccess.IsPersonExist(personID, ref errorMessage);
        }

        public static bool IsPersonExist(string nationalID, ref string errorMessage)
        {
            return ClsPersonDataAccess.IsPersonExist(nationalID, ref errorMessage);
        }



    }
}
