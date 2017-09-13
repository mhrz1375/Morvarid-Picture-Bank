using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Morvarid.CLS
{
    class AccessLayer
    {
        public string ConnectionString=CLS.DBHandler.GetConnectionString();

        //Get store id for saving picture in database.
        /// <summary>
        /// SID==>>StoreID()
        /// </summary>
        /// <returns></returns>
        public int MSID()
        {
            int Id = 1;
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.DBHandler.GetStoreIdQuery(), thisConnection))
                {
                    thisConnection.Open();
                    try
                    {
                        Result = (int)cmdCount.ExecuteScalar();
                        Id = Result + 1;
                    }
                    catch
                    {
                        Id = 1;
                    }

                    thisConnection.Close();
                }
            }

            return Id;
        }
        //Get picture count from database for saving picture in it.
        /// <summary>
        /// PC==>>PictureCount()
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <returns></returns>
        public int MPC(string CustomerCode)
        {
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.DBHandler.GetPictureCountQuery(CustomerCode), thisConnection))
                {
                    thisConnection.Open();
                    try
                    {
                        Result = (int)cmdCount.ExecuteScalar();
                    }
                    catch
                    {
                    }

                    thisConnection.Close();
                }
            }
            return Result;
        }

        public string CC;  //Customer Code
        public string CSC; //Customer Security Code
        public string CFN; //Customer First Name
        public string CLN; //Customer Last Name
        public string CFFN;//Customer Father Name
        public string CPN; //Customer Phone Number
        public string CNC; //Customer National Code
        public string CBD; //Customer Birth Day
        public string CG;  //Gender of customer
        public string CA;  //Customer Address  
        public string CE;  //Customer Email
        public string CCAD;//Customer Created At Date
        public string CPA; //Customer Picture Available or not
        //MAC==>AddCustomer() method
        public void MAC()
        {
            try
            {
                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand SqlCommand = new SqlCommand(CLS.DBHandler.GetAddCustomerQuery(), thisConnection))
                    {
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Id", (object)MCI()));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Code", (object)CC));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_SecurityCode", (object)CSC));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_FirstName", (object)CFN));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_LastName", (object)CLN));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_FatherName", (object)CFFN));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_PhoneNumber", (object)CPN));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_NationalCode", (object)CNC));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_BirthDay", (object)CBD));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Gender", (object)CG));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Address", (object)CA));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Email", (object)CE));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_CreatedAtDate", (object)CCAD));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_PictureCheck", (object)CPA));

                        thisConnection.Open();
                        SqlCommand.ExecuteNonQuery();
                        thisConnection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                FRMMessageBox.Show(ex.ToString(), "!خطا در ذخیره اطلاعات");
            }
        }

        // MUC==>UpdateCustomer() method
        public void MUC()
        {
            try
            {
                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    string Query = CLS.DBHandler.GetUpdateCustomerQuery(CC, CFN, CLN, CFFN,
                        CPN, CNC, CBD, CG, CA, CE,
                         CPA);
                    using (SqlCommand SqlCommand = new SqlCommand(Query, thisConnection))
                    {
                        thisConnection.Open();
                        SqlCommand.ExecuteNonQuery();
                        thisConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CLSAccessLayer=>(UC)UpdateCutomer=>" + ex.ToString());
            }
        }
        //MCC==>>CustomerCode() Method
        public int MCC()
        {

            int Code = 1;
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.DBHandler.GetCustomerCodeQuery(), thisConnection))
                {
                    thisConnection.Open();
                    try
                    {
                        Result = (int)cmdCount.ExecuteScalar();
                        Code = Result + 1;
                    }
                    catch
                    {
                        Code = 1;
                    }
                    thisConnection.Close();
                }
            }

            return Code;
        }

        //MCI==>>CustomerID() method
        public int MCI()
        {
            int Id = 1;
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.DBHandler.GetCustomerIdQuery(), thisConnection))
                {
                    thisConnection.Open();
                    try
                    {
                        Result = (int)cmdCount.ExecuteScalar();
                        Id = Result + 1;
                    }
                    catch
                    {
                        Id = 1;
                    }

                    thisConnection.Close();
                }
            }

            return Id;
        }
        public int PicturenNumberMethod(string CustomerCode)
        {
            int Id = 1;
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.DBHandler.GetPictureNumberQuery(CustomerCode), thisConnection))
                {
                    thisConnection.Open();
                    try
                    {
                        Result = (int)cmdCount.ExecuteScalar();
                        Id = Result + 1;
                    }
                    catch
                    {
                        Id = 1;
                    }

                    thisConnection.Close();
                }
            }

            return Id;
        }
        public int SID;//SID=>StoreId
        public string SCC;//SCC=>StoreCustomerCode
        public string SCSC;//SCSC=>StoreCustomerSecurityCode
        public int SPN;//SPN=>StorePictureNumber
        public byte[] SBP;//SBP=>StoreBinaryPicture
        public byte[] STP;//STP=>StoreTempPicture
        public string SAD;//SD=>StoreAtDate

        public void StorePictureMethod()
        {
            try
            {

                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand SqlCommand = new SqlCommand(CLS.DBHandler.GetStorePictureQuery(), thisConnection))
                    {
                        SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_Id", (object)SID));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Code",   (object)SCC));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_SecurityCode", (object)SCSC));
                        SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_Number",   (object)SPN));
                        SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_BinaryPic",(object)SBP));
                        SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_TempPic",  (object)STP));
                        SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_AtDate",   (object)SAD));

                        thisConnection.Open();
                        SqlCommand.ExecuteNonQuery();
                        thisConnection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("CLSAccessLayer=>(SP)StorePicture=>" + ex.ToString());
            }
        }

        public void DeletePicture(string CustomerCode,string PictureNumber)
        {
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand(CLS.DBHandler.GetDeletePictureCustomerQuery(CustomerCode, PictureNumber), thisConnection))
                {

                    thisConnection.Open();
                    SqlCommand.ExecuteNonQuery();
                    thisConnection.Close();
                }
            }
        }
        //DC==>>DeleteCustomerWithPictures()
        public void DC(string CustomerCode)
        {
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand(CLS.DBHandler.GetDeleteCustomerQuery(CustomerCode), thisConnection))
                {

                    thisConnection.Open();
                    SqlCommand.ExecuteNonQuery();
                    thisConnection.Close();
                }
                using (SqlCommand SqlCommand = new SqlCommand(CLS.DBHandler.GetDeleteAllPictureCustomerQuery(CustomerCode), thisConnection))
                {

                    thisConnection.Open();
                    SqlCommand.ExecuteNonQuery();
                    thisConnection.Close();
                }
            }
        }

        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable CustomerDataTable = new DataTable();
        DataTable PictureDataTable = new DataTable();
        public DataTable SearchResult(string Query)
        {
            try
            {
                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand SqlCommand = new SqlCommand(Query, thisConnection))
                    {
                        CustomerDataTable.Clear();

                        thisConnection.Open();
                        DataAdapter.SelectCommand = SqlCommand;
                        DataAdapter.Fill(CustomerDataTable);
                        SqlCommand.ExecuteNonQuery();
                        thisConnection.Close();

                    }
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return             CustomerDataTable;

        }
    }
}
