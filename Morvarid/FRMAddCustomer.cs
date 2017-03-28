using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using System.Diagnostics;

namespace Morvarid
{
    public partial class FRMAddCustomer : DevExpress.XtraEditors.XtraForm
    {
        #region Values
        private int CtrlWidth;
        private int CtrlHeight;
        private int PicWidth = 100;
        private int PicHeight = 133;
        private const int ConstXLocation = 10;
        private const int ConstYLocation = 10;
        private bool PictureAvailable = false;
        public bool CustomerExists = false;
        private int XLocation = 10;
        private int YLocation = 10;
        private int PictureCount = 0;
        private List<string> lstPicturePaths = new List<string>();
        private string ConnectionString;

        CLS.CLSDBHandler dbHandler = new CLS.CLSDBHandler();
        CLS.CLSGetShamsiDate GetToDay = new CLS.CLSGetShamsiDate();
        CLS.CLSPriceToStringClass PriceToString = new CLS.CLSPriceToStringClass();



        #endregion
        public FRMAddCustomer()
        {
            InitializeComponent();
            
        }

        #region PictureBox Create Code here
        private void DrawPictureBox(string _filename, string _displayname)
        {
            PictureBox Pic1 = new PictureBox();
            CtrlHeight = pnlPictureViewer.Height;
            CtrlWidth = pnlPictureViewer.Width;
            for (int i = 0; i < 1; i++)
            {
                //  buttonX1.Location = new System.Drawing.Point(XLocation, YLocation);
                Pic1.Location = new System.Drawing.Point(XLocation, YLocation);
                XLocation = XLocation + PicWidth + 10;
                if (XLocation + PicWidth >= CtrlWidth)
                {
                    XLocation = 15;
                    YLocation = YLocation + PicHeight + 10;
                }
                Pic1.Name = "PictureBox" + i;
                i += 1;
                Pic1.Size = new System.Drawing.Size(PicWidth, PicHeight);
                Pic1.TabIndex = 0;
                Pic1.TabStop = false;
                Pic1.BorderStyle = BorderStyle.Fixed3D;
                this.ttpImages.SetToolTip(Pic1, _filename + _displayname);
                //  Pic1.MouseEnter += Pic1_MouseEnter;
                // Pic1.MouseLeave += Pic1_MouseLeave;
                //  this.Controls.Add(Pic1);

                Pic1.ImageLocation = _filename;
                //Pic1.BackColor = Color.Red;
                Pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                Pic1.BringToFront();
                pnlPictureViewer.Controls.Add(Pic1);
                Pic1.MouseEnter += new System.EventHandler(this.Pic1_MouseEnter);
                //// Pic1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic1_MouseDown);
                Pic1.MouseLeave += new System.EventHandler(this.Pic1_MouseLeave);
                Pic1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Pic1_MouseClick);
            }
        }
        private void Pic1_MouseEnter(System.Object sender, System.EventArgs e)
        {
            PictureBox Pic = default(PictureBox);
            Pic = (PictureBox)sender;
            Pic.BorderStyle = BorderStyle.FixedSingle;
        }
        private void Pic1_MouseLeave(System.Object sender, System.EventArgs e)
        {
            PictureBox Pic = default(PictureBox);
            Pic = (PictureBox)sender;
            Pic.BorderStyle = BorderStyle.Fixed3D;
        }
        private void Pic1_MouseDown(System.Object sender, System.EventArgs e)
        {
            PictureBox Pic = default(PictureBox);
            Pic = (PictureBox)sender;
        }

        private void Pic1_MouseClick(Object sender, MouseEventArgs e)
        {
            PictureBox Pic = default(PictureBox);
            Pic = (PictureBox)sender;
            ///  pictureBox1.Image = Pic.Image;

            MessageBox.Show("MouseClick Event");



        }

        #endregion

        #region Method is here
        public void AddCutomerMethod()
        {
            try
            {
                string Gender = "";
                bool isChecked = rdBtnMen.Checked;
                if (isChecked)
                {
                    Gender = rdBtnMen.Text;
                }
                else
                {
                    Gender = rdBtnWomen.Text;
                }

                string pictureChecked = null;
                if (chbStorePicture.Checked)
                {
                    pictureChecked = "true";
                }

                else
                {
                    pictureChecked = "false";
                }
                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand SqlCommand = new SqlCommand(CLS.CLSDBHandler.GetAddCustomerQuery(), thisConnection))
                    {
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Id", (object)CustomerIDMethod()));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Code", (object)txtCustomerCode.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_SecurityCode", (object)txtSecurityCode.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_FirstName", (object)txtFirstName.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_LastName", (object)txtLastName.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_FatherName", (object)txtFatherName.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_PhoneNumber", (object)txtPhoneNumber.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_NationalCode", (object)txtNationalCode.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_BirthDay", (object)txtBirthDay.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Gender", (object)Gender));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Address", (object)txtAddress.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_Email", (object)txtEmail.Text));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_CreatedAtDate", (object)GetToDay.CRShamsiDate));
                        SqlCommand.Parameters.Add(new SqlParameter("@Customer_PictureCheck", (object)pictureChecked));

                        thisConnection.Open();
                        SqlCommand.ExecuteNonQuery();
                        thisConnection.Close();
                    }
                }
                txtCustomerCode.Text = CustomerCodeMethod().ToString();
                txtSecurityCode.Text = CLS.CLSRandomPassword.Generate(4, 6);
                txtFirstName.Clear();
                txtLastName.Clear();
                txtFatherName.Clear();
                txtPhoneNumber.Clear();
                txtNationalCode.Clear();
                txtAddress.Clear();
                txtEmail.Clear();
                pictureChecked = "false";
                lstPicturePaths.Clear();
                PictureAvailable = false;
                PictureCount = 0;
                chbStorePicture.Checked = false;
            }
            catch (Exception ex)
            {
                FRMMessageBox.Show(ex.ToString(), "!خطا در ذخیره اطلاعات");
            }

        }

        public int CustomerCodeMethod()
        {

            int Code = 1;
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.CLSDBHandler.GetCustomerCodeQuery(), thisConnection))
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
        public int CustomerIDMethod()
        {
            int Id = 1;
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.CLSDBHandler.GetCustomerIdQuery(), thisConnection))
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
        public int StoreIDMethod()
        {
            int Id = 1;
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.CLSDBHandler.GetStoreIdQuery(), thisConnection))
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
        public void StorePictureMethod()
        {
            try
            {
                for (int i = 1; i <= PictureCount; ++i)
                {
                    using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                    {
                        using (SqlCommand SqlCommand = new SqlCommand(CLS.CLSDBHandler.GetStorePictureQuery(), thisConnection))
                        {
                            //   "values(Store_Id,Customer_Code,Customer_SecurityCode,Store_PictureCount,Store_PicturePath,Store_PictureBinary)";
                            SqlCommand.Parameters.Add(new SqlParameter("@Store_Id", (object)StoreIDMethod()));
                            SqlCommand.Parameters.Add(new SqlParameter("@Customer_Code", (object)txtCustomerCode.Text.Trim()));
                            SqlCommand.Parameters.Add(new SqlParameter("@Customer_SecurityCode", (object)txtSecurityCode.Text.Trim()));
                            SqlCommand.Parameters.Add(new SqlParameter("@Store_PictureCount", (object)i));
                            SqlCommand.Parameters.Add(new SqlParameter("@Store_PicturePath", (object)lstPicturePaths[i - 1]));
                            SqlCommand.Parameters.Add(new SqlParameter("@Store_PictureBinary", (object)ReadFileMethod(lstPicturePaths[i - 1])));
                            SqlCommand.Parameters.Add(new SqlParameter("@Store_AtDate", (object)GetToDay.CRShamsiDate));

                            thisConnection.Open();
                            SqlCommand.ExecuteNonQuery();
                            thisConnection.Close();
                        }
                    }
                }
                MessageBox.Show("تصاویر مشتری ثبت شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string PictureExistsMethod(string path)
        {
            string exists = null;
            for (int i = 0; i < PictureCount; ++i)
            {
                try
                {
                    if (lstPicturePaths[i] == path)
                    {
                        exists = " !تصویر مورد نظر در لیست موجود است" + "\n" + path;
                    }
                }
                catch
                {
                    exists = null;
                }
            }
            return exists;
        }


        public bool CustomerExistsMethod()
        {
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.CLSDBHandler.GetCustomerExistsQuery(), thisConnection))
                {
                    thisConnection.Open();
                    cmdCount.Parameters.AddWithValue("@Customer_Code", txtCustomerCode.Text);
                    object result = cmdCount.ExecuteScalar();
                    thisConnection.Close();
                    if ((int)result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public byte[] ReadFileMethod(string sPath)
        {
            if (sPath != null)
            {
                byte[] data = null;

                FileInfo fInfo = new FileInfo(sPath);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);
                return data;
            }
            return null;
        }
        private void ResetValueMethod()
        {
            YLocation = ConstYLocation;
            XLocation = ConstXLocation;
            PictureCount = 0;
            lstPicturePaths.Clear();
            lblCount.Text = "0";
            PictureAvailable = false;

        }
        private double CreditorPriceMethod()
        {
            if (lblCreditorPrice.Text == "0")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
            CreditorPrice = Payable - (CashPayment + MarkDown + Credit + Check + CardReader);
            return CreditorPrice;
        }
        #endregion


        #region Buttons code here

        private void BtnAddImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in myDialog.FileNames)
                {

                    if (PictureExistsMethod(file) == null)
                    {
                        lstPicturePaths.Add(file);
                        DrawPictureBox(file, "displayname" + PictureCount);
                        PictureCount += 1;
                    }
                    else
                    {
                        DialogResult Result = FRMMessageBox.Show(PictureExistsMethod(file), "تکرار تصویر", "!هشدار", enumMessageIcon.Question, enumMessageButton.OK);
                    }
                }
            }
            lblCount.Text = PictureCount.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CustomerExistsMethod() != true)
            {
                if (PictureAvailable)
                {
                    DialogResult Result = FRMMessageBox.Show("آیا اطلاعات مشتری ثبت شود؟", " ثبت اطلاعات مشتری", "!هشدار", enumMessageIcon.Question, enumMessageButton.YesNo);

                    if (Result == DialogResult.Yes)
                    {
                        if (PictureCount != 0)
                        {
                            StorePictureMethod();
                            AddCutomerMethod();
                            pnlPictureViewer.Controls.Clear();
                        }
                        else
                        {
                            FRMMessageBox.Show(" !لطفا تصاویر مورد نظر را وارد نمایید", "!هشدار انتخاب تصاویر", "!هشدار", enumMessageIcon.Warning, enumMessageButton.OK);
                        }
                    }
                }
                else
                {
                    DialogResult Result = FRMMessageBox.Show("آیا اطلاعات مشتری بدون تصاویر ثبت شود؟", " ثبت اطلاعات مشتری بدون تصاویر", "!هشدار", enumMessageIcon.Question, enumMessageButton.YesNo);

                    if (Result == DialogResult.Yes)
                    {
                        AddCutomerMethod();
                    }
                }
            }
            else
            {
                FRMMessageBox.Show(" !شماره وارد شده قبلا ثبت شده است", "!هشدار ذخیره اطلاعات", "!هشدار", enumMessageIcon.Warning, enumMessageButton.OK);
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult Result = FRMMessageBox.Show("آیا مایل به لغو ثبت مشتری هستید؟", "لغو ثبت مشتری", "!هشدار", enumMessageIcon.Question, enumMessageButton.YesNo);

            if (Result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion

        #region txtBoxes event here
        private void txtCustomerCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                txtCustomerCode.Border.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtCustomerCode.Border.BorderColor = System.Drawing.Color.Gray;
            }
        }






        private double Payable = 0;
        private double MarkDown = 0;
        private double Credit = 0;
        private double CashPayment = 0;
        private double CreditorPrice = 0;
        private double CardReader = 0;
        private double Check = 0;
        private double SumPayment = 0;

        private void chbgbPayable_CheckedChanged(object sender, EventArgs e)
        {
            if (chbgbPayable.Checked)
            {
                gbPayable.Enabled = true;
            }
            else
            {
                gbPayable.Enabled = false;
            }

        }

        private void Price()
        {
            if (txtPayable.Text == "")
            {
                txtPayable.Text = "0";
            }
            txtPayable.Text = Convert.ToDouble(txtPayable.Text.Replace(",", "")).ToString("n0");
            txtPayable.SelectionStart = txtPayable.Text.Length;
            Payable = Convert.ToDouble(txtPayable.Text.Replace(",", ""));


            if (txtCashPayment.Text == "")
            {
                txtCashPayment.Text = "0";
            }
            txtCashPayment.Text = Convert.ToDouble(txtCashPayment.Text.Replace(",", "")).ToString("n0");
            txtCashPayment.SelectionStart = txtCashPayment.Text.Length;
            CashPayment = Convert.ToDouble(txtCashPayment.Text.Replace(",", ""));


            if (txtCashPayment.Text == "")
            {
                txtMarkDown.Text = "0";
            }
            txtMarkDown.Text = Convert.ToDouble(txtMarkDown.Text.Replace(",", "")).ToString("n0");
            txtMarkDown.SelectionStart = txtMarkDown.Text.Length;
            MarkDown = Convert.ToDouble(txtMarkDown.Text.Replace(",", ""));


            if (txtCredit.Text == "")
            {
                txtCredit.Text = "0";
            }
            txtCredit.Text = Convert.ToDouble(txtCredit.Text.Replace(",", "")).ToString("n0");
            txtCredit.SelectionStart = txtCredit.Text.Length;
            Credit = Convert.ToDouble(txtCredit.Text.Replace(",", ""));

            if (txtCardReader.Text == "")
            {
                txtCardReader.Text = "0";
            }
            txtCardReader.Text = Convert.ToDouble(txtCardReader.Text.Replace(",", "")).ToString("n0");
            txtCardReader.SelectionStart = txtCardReader.Text.Length;
            CardReader = Convert.ToDouble(txtCardReader.Text.Replace(",", ""));

            if (txtCheck.Text == "")
            {
                txtCheck.Text = "0";
            }
            txtCheck.Text = Convert.ToDouble(txtCheck.Text.Replace(",", "")).ToString("n0");
            txtCheck.SelectionStart = txtCheck.Text.Length;
            Check = Convert.ToDouble(txtCheck.Text.Replace(",", ""));



            lblCreditorPrice.Text = CreditorPriceMethod().ToString();
            lblSumPrice.Text = SumPaymentMethod().ToString();
            txtAlphabetPrice.Text = PriceToString.PriceToString(SumPaymentMethod().ToString());
            lblSumPrice.Text = Convert.ToDouble(lblSumPrice.Text.Replace(",", "")).ToString("n0");


        }
        private void txtPayable_TextChanged(object sender, EventArgs e)
        {
            Price();
        }
        private void txtCashPayment_TextChanged(object sender, EventArgs e)
        {
            Price();
        }
        private void txtMarkDown_TextChanged(object sender, EventArgs e)
        {
            Price();
        }
        private void txtCredit_TextChanged(object sender, EventArgs e)
        {
            Price();
        }
        private void txtCardReader_TextChanged(object sender, EventArgs e)
        {
            Price();
        }
        private void txtCheck_TextChanged(object sender, EventArgs e)
        {
            Price();
        }
        private void txtPayable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                txtPayable.Border.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtPayable.Border.BorderColor = System.Drawing.Color.Gray;
            }
        }
        private void txtCashPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                txtCashPayment.Border.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtCashPayment.Border.BorderColor = System.Drawing.Color.Gray;
            }
        }
        private void txtMarkDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                txtMarkDown.Border.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtMarkDown.Border.BorderColor = System.Drawing.Color.Gray;
            }
        }
        private void txtCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                txtCredit.Border.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtCredit.Border.BorderColor = System.Drawing.Color.Gray;
            }
        }
        private void txtCardReader_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                txtCardReader.Border.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtCardReader.Border.BorderColor = System.Drawing.Color.Gray;
            }
        }
        private void txtCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                txtCheck.Border.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtCheck.Border.BorderColor = System.Drawing.Color.Gray;
            }
        }
        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                txtNationalCode.Border.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtNationalCode.Border.BorderColor = System.Drawing.Color.Gray;
            }
        }
        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                txtPhoneNumber.Border.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtPhoneNumber.Border.BorderColor = System.Drawing.Color.Gray;
            }
        }


        private double SumPaymentMethod()
        {
            SumPayment = CashPayment + MarkDown + Check + CardReader;
            return SumPayment;
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            lblCustomerCodeImage.Text = txtCustomerCode.Text;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(StoreIDMethod().ToString());
        }

        private void chbStorePicture_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbStorePicture.Checked)
            {
                gbPictureView.Enabled = false;
                gbStorePictureTools.Enabled = false;
                pnlPictureViewer.Controls.Clear();
                ResetValueMethod();
            }
            else
            {

                PictureAvailable = true;


                gbPictureView.Enabled = true;
                gbStorePictureTools.Enabled = true;

            }
        }




        private void btnSelectBirthDay_Click(object sender, EventArgs e)
        {
            PersianCalenderBirthDay.Visible = true;

        }
        private void PersianCalenderBirthDay_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            txtBirthDay.Text = PersianCalenderBirthDay.GetSelectedDateInPersianDateTime().ToShortDateString();
            PersianCalenderBirthDay.Visible = false;
        }


        private void btnSelectRegistryDate_Click(object sender, EventArgs e)
        {
            PersianCalenderRegistryDate.Visible = true;
        }

        private void PersianCalenderRegistryDate_Load(object sender, EventArgs e)
        {

        }
        private void PersianCalenderRegistryDate_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            txtRegistryDate.Text = PersianCalenderRegistryDate.GetSelectedDateInPersianDateTime().ToShortDateString();
            PersianCalenderRegistryDate.Visible = false;
        }
        #endregion

        private void FRMAddCustomer_Load(object sender, EventArgs e)
        {
                try
                {
                    ConnectionString = CLS.CLSDBHandler.GetConnectionString();
                }
                catch { }
                txtCustomerCode.Text = CustomerCodeMethod().ToString();
                txtSecurityCode.Text = CLS.CLSRandomPassword.Generate(4, 6);
                txtRegistryDate.Text = PersianCalenderRegistryDate.GetSelectedDateInPersianDateTime().ToShortDateString();

         

        }
    }
}








/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/*
        public string StorePictureExists(string path)
        {
            string exists = "";
            using (SqlConnection thisConnection = new SqlConnection(DBHandler.GetConnectionString()))
            {
                using (SqlCommand SqlCommand = new SqlCommand(DBHandler.GetPictureExistsQuery(), thisConnection))
                {
                    thisConnection.Open();
                    SqlCommand.Parameters.Add(new SqlParameter("@Store_PicturePath", (object)path));

                    exists = (string)SqlCommand.ExecuteScalar();

                    thisConnection.Close();
                }
            }
            if (exists == path)
            {
                exists ="! این تصویر قبلا ثبت شده است"+"\n"+ path;
            }
            return exists;
        }*/
/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>








