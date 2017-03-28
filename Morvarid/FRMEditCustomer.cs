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
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using System.Drawing.Imaging;

namespace Morvarid
{
    public partial class FRMEditCustomer : DevExpress.XtraEditors.XtraForm
    {
        #region Values
        public bool PictureLoading = false;

        private bool PictureAvailable = false;
        public bool CustomerExists = false;
        private int PictureCount = 0;
        private List<string> lstPicturePaths = new List<string>();
        private string ConnectionString;

        private int ZoomValue = 5;

        CLS.CLSDBHandler dbHandler = new CLS.CLSDBHandler();
        CLS.CLSPriceToStringClass PriceToString = new CLS.CLSPriceToStringClass();

        private List<int> lstPictureNumber = new List<int>();
        private List<Image> lstPictures = new List<Image>();
        private List<Image> lstTempPictures = new List<Image>();
        private List<string> lstStorePicturesAtDate = new List<string>();

        GalleryItemGroup glcPicgroupNow = new GalleryItemGroup();
        GalleryItemGroup glcPicgroupLast = new GalleryItemGroup();

        FRMAddCustomer AddCustomer = new FRMAddCustomer();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable CustomerDataTable = new DataTable();
        DataTable PictureDataTable = new DataTable();

        #endregion
        public FRMEditCustomer()
        {
            InitializeComponent();
            ConnectionString = CLS.CLSDBHandler.GetConnectionString();
        }
        //مقادیر جدول تصاویر را از بانک فراخوانی کرده و در داخل یک جدول داده ای قرار میدهد
        public void SendPictureToDataTable(string CustomerCode)
        {
            try
            {
                PictureLoading = true;

                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    if (PictureLoading)
                    {
                        using (SqlCommand SqlCommand = new SqlCommand(CLS.CLSDBHandler.GetCustomerPicturesQuery(CustomerCode), thisConnection))
                        {

                            PictureDataTable.Clear();
                            thisConnection.Open();
                            DataAdapter.SelectCommand = SqlCommand;
                            DataAdapter.Fill(PictureDataTable);
                            RetrivePicture(PictureDataTable);
                            thisConnection.Close();

                        }
                        PictureLoading = false;
                    }
                    

                }

            }
            catch (Exception ec)
            {
                MessageBox.Show("<<<<<<<<<<<<DisplayPictureView>>>>>>>>>>>>>>>>" + ec.Message);

            }

        }

        private void RetrivePicture(DataTable DTStorePicture)
        {
        
            GalleryInitializeMethod(glcPicgroupLast);

            glcPicgroupLast.Caption = txtFirstName.Text+" "+txtLastName.Text+" ("+txtCustomerCode.Text+")";
                glcPictureViewer.Gallery.Groups.Add(glcPicgroupLast);
            foreach (DataRow ROW in DTStorePicture.Rows)
            {
                lstPictureNumber.Add(ROW.Field<int>(0));
                lstPictures.Add(BinaryToImage(ROW.Field<byte[]>(1)));

                lstTempPictures.Add(BinaryToImage(ROW.Field<byte[]>(2)));
                lstStorePicturesAtDate.Add(ROW.Field<string>(3));

                glcPicgroupLast.Items.Add(new GalleryItem(BinaryToImage(ROW.Field<byte[]>(2)),""+ ROW.Field<int>(0), ROW.Field<string>(3) ));

            }


        }
        private Image BinaryToImage(byte[] Binary)
        {
            Image newImage = null;
            try
            {
                byte[] imageData = Binary;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    newImage = Image.FromStream(ms, true, true);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BinaryToImage" + ex.ToString());
            }
            return newImage;
        }
       
        #region Method is here



        //Get store id for saving picture in database.
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
        //Get picture count from database for saving picture in it.
        public int PictureCountMethod()
        {
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.CLSDBHandler.GetPictureCountQuery(txtCustomerCode.Text), thisConnection))
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



        public int PicturenNumberMethod()
        {
            int Id = 1;
            int Result = 0;
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(CLS.CLSDBHandler.GetPictureNumberQuery(txtCustomerCode.Text), thisConnection))
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
        // store pictures and datiles in database.
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
                            SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_Id", (object)StoreIDMethod()));
                            SqlCommand.Parameters.Add(new SqlParameter("@Customer_Code", (object)txtCustomerCode.Text.Trim()));
                            SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_Number", (object)PicturenNumberMethod()));
                            SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_BinaryPic", (object)ReadFileMethod(ResizeImage(533, 400,lstPicturePaths[i - 1]))));
                            SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_TempPic", (object)ReadFileMethod(imageFromString(lstPicturePaths[i - 1]))));
                            SqlCommand.Parameters.Add(new SqlParameter("@StorePicture_AtDate", (object)CLS.CLSGetShamsiDate.ToDay));

                            thisConnection.Open();
                            SqlCommand.ExecuteNonQuery();
                            thisConnection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public Image imageFromString(string path)
        {
            Image img = Image.FromFile(path);
            return img;
        }
        public Image ResizeImage(int newWidth, int newHeight, string strPicturePath)
        {
            Image imgPhoto = null;
            Bitmap bmPhoto = null;
            try
            {
                imgPhoto = Image.FromFile(strPicturePath);
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;

                //Consider vertical pics
                if (sourceWidth < sourceHeight)
                {
                    int buff = newWidth;

                    newWidth = newHeight;
                    newHeight = buff;
                }

                int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
                float nPercent = 0, nPercentW = 0, nPercentH = 0;

                nPercentW = ((float)newWidth / (float)sourceWidth);
                nPercentH = ((float)newHeight / (float)sourceHeight);
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = System.Convert.ToInt16((newWidth -
                              (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = System.Convert.ToInt16((newHeight -
                              (sourceHeight * nPercent)) / 2);
                }

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);


                bmPhoto = new Bitmap(newWidth, newHeight,
                              PixelFormat.Format24bppRgb);

                bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.Clear(Color.WhiteSmoke);
                grPhoto.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();
                imgPhoto.Dispose();
                return bmPhoto;

            }
            catch (Exception ex)
            {
                MessageBox.Show("error ==" + ex);
            }

            return bmPhoto;

        }
        // Make sure the picture exists in picture list
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



        //Read the picture paths and converting to binary data for storing in database
        public byte[] ReadFileMethod(Image img)
        {

            
            if (img != null)
            {

                MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
               /* byte[] data = null;

                FileInfo fInfo = new FileInfo(img);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(img, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);
                return data;*/
            }
            return null;
        }

        //Reset all of values for after saving pictures.
        private void ResetValueMethod()
        {
            PictureCount = 0;// Count of customer picturs.
            lstPicturePaths.Clear();// cleaning list of picture paths for store.
            lblCount.Text = "0";// Show count of customer picturs.
            PictureAvailable = false; // Checked the picture exsist in list.
            


         //   lstPictureCount.Clear();
            lstPictures.Clear();
            lstStorePicturesAtDate.Clear();
            glcPicgroupLast.Dispose();
            glcPicgroupNow.Dispose();


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
        private void GalleryInitializeMethod(GalleryItemGroup g)
        {
            glcPictureViewer.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            ZoomInGalleryMethod(ZoomValue);
            glcPictureViewer.Gallery.ShowItemText = true;
            glcPictureViewer.Gallery.Groups.Add(g);
        }

        #region Buttons code here

        private void BtnAddImages_Click(object sender, EventArgs e)
        {
            PictureAvailable = true;
            GalleryInitializeMethod(glcPicgroupNow);

             glcPicgroupNow.Caption = txtFirstName.Text + " " + txtLastName.Text;
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
                        PictureCount += 1;
                        Image img = Image.FromFile(file);


                        glcPicgroupNow.Items.Add(new GalleryItem(img, txtCustomerCode.Text + "-" + PictureCount, CLS.CLSGetShamsiDate.ToDay));

                        
                    }
                    else
                    {
                        DialogResult Result = FRMMessageBox.Show(PictureExistsMethod(file), "تکرار تصویر", "!هشدار", enumMessageIcon.Question, enumMessageButton.OK);
                    }
                }
            }
            lblCount.Text = PictureCount.ToString();
        }
        public void UpdateCutomerMethod()
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

                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    string strCustomerPictureCheck = "";
                    string Query = CLS.CLSDBHandler.GetUpdateCustomerQuery(txtCustomerCode.Text, txtFirstName.Text, txtLastName.Text, txtFatherName.Text,
                        txtPhoneNumber.Text, txtNationalCode.Text, txtBirthDay.Text, Gender, txtAddress.Text, txtEmail.Text,
                         strCustomerPictureCheck);
                    using (SqlCommand SqlCommand = new SqlCommand(Query, thisConnection))
                    {
                        thisConnection.Open();
                        SqlCommand.ExecuteNonQuery();
                        thisConnection.Close();
                    }
                }
                FRMMessageBox.Show("!هشدار ویرایش", ".ویرایش با موفقیت انجام شد ");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "!خطا در ذخیره اطلاعات");
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (PictureAvailable)
            {
                DialogResult Result = FRMMessageBox.Show("آیا مایل به ذخیره تغییرات هستید؟", " ثبت اطلاعات مشتری", "!هشدار", enumMessageIcon.Question, enumMessageButton.YesNo);

                if (Result == DialogResult.Yes)
                {

                    if (PictureCount != 0)
                    {
                        StorePictureMethod();
                        UpdateCutomerMethod();
                        ResetValueMethod();
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
                    UpdateCutomerMethod();
                }
            }
        }


    


        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
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
        private void FRMEditCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result = FRMMessageBox.Show("آیا از بستن این فرم مطمئن هستید؟", "ویرایش اطلاعات", "خروج", enumMessageIcon.Question, enumMessageButton.YesNo);

            if (Result == DialogResult.No)
            {
                e.Cancel = true;
            }

            ResetValueMethod();

        }
        #endregion
        private void FRMEditCustomer_Load(object sender, EventArgs e)
        {

            txtCustomerCode.Text = FRMCustomerList.strCustomerCode;
            txtSecurityCode.Text = FRMCustomerList.strCustomerSecurityCode;
            txtFirstName.Text = FRMCustomerList.strCustomerFirstName;
            txtLastName.Text = FRMCustomerList.strCustomerLastName;
            txtFatherName.Text = FRMCustomerList.strCustomerFatherName;
            txtPhoneNumber.Text = FRMCustomerList.strCustomerPhoneNumber;
            txtNationalCode.Text = FRMCustomerList.strCustomerNationalCode;
            txtBirthDay.Text = FRMCustomerList.strCustomerBirthDay;
            txtAddress.Text = FRMCustomerList.strCustomerAddress;
            txtEmail.Text = FRMCustomerList.strCustomerEmail;
            if (FRMCustomerList.strCustomerPictureCheck == "true")
            {
            }
            SendPictureToDataTable(txtCustomerCode.Text);

            if (FRMCustomerList.strCustomerGender == "مرد")
            {
                rdBtnMen.Checked = true;
            }
            else
            {
                rdBtnWomen.Checked = true;
            }


            txtSecurityCode.Text = CLS.CLSRandomPassword.Generate(4, 6);
                txtRegistryDate.Text = PersianCalenderRegistryDate.GetSelectedDateInPersianDateTime().ToShortDateString();


        }

        private void btnRemoveSelectedPicture_Click(object sender, EventArgs e)
        {
            
        }

        private void zoomTrackBarControl_EditValueChanged(object sender, EventArgs e)
        {
            int value=zoomTrackBarControl.Value;

            ZoomInGalleryMethod(value);






        }


        private void ZoomInGalleryMethod(int Value)
        {
            ZoomValue = Value;
            switch (Value)
            {
                case 0:
                    glcPictureViewer.Gallery.ImageSize = new Size(51, 68);
                    break;
                case 1:
                    glcPictureViewer.Gallery.ImageSize = new Size(58, 77);
                    break;
                case 2:
                    glcPictureViewer.Gallery.ImageSize = new Size(66, 88);
                    break;
                case 3:
                    glcPictureViewer.Gallery.ImageSize = new Size(77, 103);
                    break;
                case 4:
                    glcPictureViewer.Gallery.ImageSize = new Size(90, 120);
                    break;
                case 5:

                    glcPictureViewer.Gallery.ImageSize = new Size(108, 144);
                    break;
                case 6:
                    glcPictureViewer.Gallery.ImageSize = new Size(133, 177);
                    break;
                case 7:
                    glcPictureViewer.Gallery.ImageSize = new Size(170, 227);
                    break;
                case 8:
                    glcPictureViewer.Gallery.ImageSize = new Size(235, 313);
                    break;
                case 9:
                    glcPictureViewer.Gallery.ImageSize = new Size(361, 481);
                    break;
                case 10:
                    glcPictureViewer.Gallery.ImageSize = new Size(739, 985);
                    break;

                default:
                    glcPictureViewer.Gallery.ImageSize = new Size(108, 144);
                    break;
            }
        }

        private void brbtnShowFullScreen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (item != null)
                Text = item.Caption; MessageBox.Show("oniu");
        }

        private void brbtnDeletePicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (item != null)
                item.GalleryGroup.Items.Remove(item);
            MessageBox.Show(item.Caption);
            using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand SqlCommand = new SqlCommand(CLS.CLSDBHandler.GetDeletePictureCustomerQuery(txtCustomerCode.Text, item.Caption), thisConnection))
                {
                    
                    thisConnection.Open();
                    SqlCommand.ExecuteNonQuery();
                    thisConnection.Close();
                }
            }
        }
        GalleryItem item = null;


        private void popmManagrGallery_Popup(object sender, EventArgs e)
        {
            Point point = glcPictureViewer.PointToClient(Control.MousePosition);

            RibbonHitInfo hitInfo = glcPictureViewer.CalcHitInfo(point);

            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
                item = hitInfo.GalleryItem;
        }

        private void popmManagrGallery_CloseUp(object sender, EventArgs e)
        {
            item = null;
        }

     
    }
}
















