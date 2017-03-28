using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Morvarid.CLS
{
    class CLSDBHandler
    {

        public static string SrvName = @"DBSERVER"; //Your SQL Server Name
        public static string DbName = @"PictureDB";//Your Database Name
        public static string UsrName = "us";//Your SQL Server User Name
        public static string Pasword = "xxxx";//Your SQL Server Password
        public static string Query;
        public static string ToDay;

        CLS.CLSGetShamsiDate DATE = new CLSGetShamsiDate();
        /// <summary>
        /// Public static method to access connection string throw out the project 
        /// </summary>
        /// <returns>return database connection string</returns>
        public static string GetConnectionString()
        {
            string DataSource = "";
            // return "Data Source=" + SrvName + "; initial catalog=" + DbName + "; user id=" + UsrName + "; password=" + Pasword + ";";//Build Connection String and Return
            try
            {
                DataSource = "Data Source=EVOLATION;Initial Catalog=MorvaridDB;Integrated Security=True";
            }
            catch
            {
                DataSource = @"Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Application.StartupPath + "\\MorvaridDB.mdf;Integrated Security=True;Connect Timeout=30;";
            }

            return DataSource;

        }
        public static string GetToDay()
        {
            string toDay = "";
            toDay = CLS.CLSGetShamsiDate.ToDay;

            return toDay;
        }
        public static string GetCustomerListQuery()
        {
            return "SELECT * FROM dbo.TBLCustomer ";
        }
        //تمامی مقادیر جدول تصاویر مربوط به هر شخص را برمی گرداند
        public static string GetCustomerPicturesQuery(string CustomerCode)
        {
            return "SELECT StorePicture_Number,StorePicture_BinaryPic,StorePicture_TempPic,StorePicture_AtDate FROM dbo.TBLStorePicture WHERE Customer_Code LIKE N'" + CustomerCode + "'";
        }
        public static string GetUpdateCustomerQuery(string CustomerCode , string CustomerFirstName , string CustomerLastName , string CustomerFatherName ,
            string CustomerPhoneNumber, string CustomerNationalCode, string CustomerBirthDay, string CustomerGender, string CustomerAddress, string CustomerEmail
            , string CustomerPictureCheck)
        {
          return  "UPDATE dbo.TBLCustomer SET " +
                   "Customer_FirstName     =N'" + CustomerFirstName + "'," +
                   "Customer_LastName      =N'" + CustomerLastName + "'," +
                   "Customer_FatherName    =N'" + CustomerFatherName + "'," +
                   "Customer_PhoneNumber   =N'" + CustomerPhoneNumber + "'," +
                   "Customer_NationalCode  =N'" + CustomerNationalCode + "'," +
                   "Customer_BirthDay      =N'" + CustomerBirthDay + "'," +
                   "Customer_Gender        =N'" + CustomerGender + "'," +
                   "Customer_Address       =N'" + CustomerAddress + "'," +
                   "Customer_Email         =N'" + CustomerEmail + "'," +
                   "Customer_EditedAtDate  =N'" + GetToDay() + "'," +
                   "Customer_PictureCheck  =N'" + CustomerPictureCheck + "'" +
                   "WHERE Customer_Code = N'" + CustomerCode + "'";
        }

        public static string GetDeleteCustomerQuery(string CustomerCode)
        {
            return "DELETE FROM dbo.TBLCustomer WHERE Customer_Code = " + CustomerCode;
        }

         public static string GetDeleteAllPictureCustomerQuery(string CustomerCode)
        {
            return "DELETE FROM dbo.TBLStorePicture WHERE Customer_Code = " + CustomerCode;
        }

       public static string GetDeletePictureCustomerQuery(string CustomerCode,string PictureNumber)
        {
            return "DELETE FROM dbo.TBLStorePicture WHERE Customer_Code = " + CustomerCode+ "AND StorePicture_Number = "+PictureNumber;
        }

        public static string GetCustomerCodeQuery()
        {
            return "SELECT TOP 1 Customer_Code FROM dbo.TBLCustomer ORDER BY Customer_Code DESC";
        }
        public static string GetStoreIdQuery()
        {
            return "SELECT TOP 1 StorePicture_Id FROM dbo.TBLStorePicture ORDER BY StorePicture_Id DESC";
        }
        public static string GetPictureCountQuery(string CustomerCode)
        {
            return "SELECT COUNT(*) FROM dbo.TBLStorePicture WHERE Customer_Code = " + CustomerCode ;
        }

        public static string GetPictureNumberQuery(string CustomerCode)
        {
            return "SELECT TOP 1 StorePicture_Number FROM dbo.TBLStorePicture WHERE Customer_Code = " + CustomerCode;
        }
        public static string GetCustomerIdQuery()
        {
            return "SELECT TOP 1 Customer_Id FROM dbo.TBLCustomer ORDER BY Customer_Id DESC";
        }
        public static string GetCustomerExistsQuery()
        {
            return "SELECT COUNT(Customer_Code) FROM dbo.TBLCustomer where Customer_Code = @Customer_Code";
        }

        public static string GetPictureExistsQuery()
        {
            return "SELECT Store_PicturePath FROM dbo.TBLStorePicture where Store_PicturePath = @Store_PicturePath";
        }
        public static string GetAddCustomerQuery()
        {
            return "INSERT INTO TBLCustomer (Customer_Id,Customer_Code,Customer_SecurityCode,Customer_FirstName,Customer_LastName,Customer_FatherName,Customer_PhoneNumber,Customer_NationalCode,Customer_BirthDay,Customer_Gender,Customer_Address,Customer_Email,Customer_CreatedAtDate,Customer_PictureCheck) " +
                       "values(@Customer_Id,@Customer_Code,@Customer_SecurityCode,@Customer_FirstName,@Customer_LastName,@Customer_FatherName,@Customer_PhoneNumber,@Customer_NationalCode,@Customer_BirthDay,@Customer_Gender,@Customer_Address,@Customer_Email,@Customer_CreatedAtDate,@Customer_PictureCheck)";
        }

        public static string GetStorePictureQuery()
        {
            return "INSERT INTO TBLStorePicture (StorePicture_Id,Customer_Code,StorePicture_Number,"+
                   "StorePicture_BinaryPic,StorePicture_TempPic,StorePicture_AtDate) " +

                   "values(@StorePicture_Id,@Customer_Code,@StorePicture_Number,@StorePicture_BinaryPic," +
                   "@StorePicture_TempPic,@StorePicture_AtDate)";
        }




        public static string GetAllCustomerSearchCodeQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Code like N'" + Search + "%'";
            return Query;
        }
        public static string GetManCustomersSearchCodeQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'مرد' AND Customer_Code like N'" + Search + "%'";
            return Query;
        }
        public static string GetWoManCustomersSearchCodeQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'زن' AND Customer_Code like N'" + Search + "%'";
            return Query;
        }
        //FirstName search
        public static string GetAllCustomerSearchFirstNameQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_FirstName like N'" + Search + "%'";
            return Query;
        }
        public static string GetManCustomersSearchFirstNameQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'مرد' AND Customer_FirstName like N'" + Search + "%'";
            return Query;
        }
        public static string GetWoManCustomersSearchFirstNameQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'زن' AND Customer_FirstName like N'" + Search + "%'";
            return Query;
        }

        //LastName search
        public static string GetAllCustomerSearchLastNameQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_LastName like N'" + Search + "%'";
            return Query;
        }
        public static string GetManCustomersSearchLastNameQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'مرد' AND Customer_LastName like N'" + Search + "%'";
            return Query;
        }
        public static string GetWoManCustomersSearchLastNameQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'زن' AND Customer_LastName like N'" + Search + "%'";
            return Query;
        }

        //FatherName search
        public static string GetAllCustomerSearchFatherNameQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_FatherName like N'" + Search + "%'";
            return Query;
        }
        public static string GetManCustomersSearchFatherNameQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'مرد' AND Customer_FatherName like N'" + Search + "%'";
            return Query;
        }
        public static string GetWoManCustomersSearchFatherNameQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'زن' AND Customer_FatherName like N'" + Search + "%'";
            return Query;
        }

        //CreatedAtDate search
        public static string GetAllCustomerSearchCreatedAtDateQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_CreatedAtDate like N'" + Search + "%'";
            return Query;
        }
        public static string GetManCustomersSearchCreatedAtDateQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'مرد' AND Customer_CreatedAtDate like N'" + Search + "%'";
            return Query;
        }
        public static string GetWoManCustomersSearchCreatedAtDateQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'زن' AND Customer_CreatedAtDate like N'" + Search + "%'";
            return Query;
        }


        //EditedAtDate search
        public static string GetAllCustomerSearchEditedAtDateQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_EditedAtDate like N'" + Search + "%'";
            return Query;
        }
        public static string GetManCustomersSearchEditedAtDateQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'مرد' AND Customer_EditedAtDate like N'" + Search + "%'";
            return Query;
        }
        public static string GetWoManCustomersSearchEditedAtDateQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'زن' AND Customer_EditedAtDate like N'" + Search + "%'";
            return Query;
        }


        //PhoneNumber search
        public static string GetAllCustomerSearchPhoneNumberQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_PhoneNumber like N'" + Search + "%'";
            return Query;
        }
        public static string GetManCustomersSearchPhoneNumberQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'مرد' AND Customer_PhoneNumber like N'" + Search + "%'";
            return Query;
        }
        public static string GetWoManCustomersSearchPhoneNumberQuery(string Search)
        {
            Query = "SELECT * FROM dbo.TBLCustomer  WHERE Customer_Gender LIKE N'زن' AND Customer_PhoneNumber like N'" + Search + "%'";
            return Query;
        }
    }
}
