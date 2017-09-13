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
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.Utils.Drawing;
using Morvarid.CLS;

namespace Morvarid
{
    public partial class FRMAddCustomer : DevExpress.XtraEditors.XtraForm




    {
        /// <summary>
        /// Start
        /// CLS is here
        /// </summary>
        CLS.ImageHandler ImageHandler = new CLS.ImageHandler();
        CLS.PriceToStringClass PriceToString = new CLS.PriceToStringClass();
        CLS.GetShamsiDate DATE = new CLS.GetShamsiDate();
        CLS.AccessLayer AccessLayer = new CLS.AccessLayer();
        CLS.SendPictureToFullScreen FullScreenPicture = new CLS.SendPictureToFullScreen();
        /// <summary>
        /// end
        /// CLS is here
        /// </summary>
        /// 



        private bool PictureAvailable = false;
        public bool CustomerExists = false;
        private int PictureCount = 0;
        private List<string> lstPicturePaths = new List<string>();
        private string ConnectionString;

        private int ZoomValue = 5;


        public List<int> lstPictureNumber = new List<int>();
        public List<Image> lstPictures = new List<Image>();
        public List<Image> lstTempPictures = new List<Image>();
        public List<string> lstStorePicturesAtDate = new List<string>();
        public List<string> lstPictureSelected = new List<string>();

        GalleryItemGroup glcPicgroupNow = new GalleryItemGroup();
        GalleryItemGroup glcPicgroupLast = new GalleryItemGroup();

        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable CustomerDataTable = new DataTable();


        public FRMAddCustomer()
        {
            InitializeComponent();
            _form_resize = new FormResizer(this);
            this.Load += _Load;
            this.Resize += _Resize;

           

        }
        FormResizer _form_resize;

 private void _Load(object sender, EventArgs e)
            {
                _form_resize._get_initial_size();
            }

            private void _Resize(object sender, EventArgs e)
            {
                _form_resize._resize();
            }
        private void StorePicture()
        {
            string SCC = txtCustomerCode.Text.Trim();
            string SCSC = txtCustomerSecurityCode.Text.Trim();
            for (int i = 1; i <= PictureCount; ++i)
            {
                AccessLayer.SID = AccessLayer.MSID();
                AccessLayer.SCC = SCC;
                AccessLayer.SCSC = SCSC;
                AccessLayer.SPN = AccessLayer.PicturenNumberMethod(SCC);
                AccessLayer.SAD = DATE.ToDay;
                AccessLayer.SBP = ImageHandler.ITB(lstPicturePaths[i - 1]);
                AccessLayer.STP = ImageHandler.ITB(ImageHandler.RI(lstPicturePaths[i - 1]));
                AccessLayer.StorePictureMethod();
            }
        }

        // Make sure the picture exists in picture list
        public string PictureExists(string path)
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
        

       
        private void GalleryInitializeMethod(GalleryItemGroup g)
        {
            glcPictureViewer.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            ZoomInGallery(ZoomValue);
            glcPictureViewer.Gallery.ShowItemText = true;
            glcPictureViewer.Gallery.Groups.Add(g);
            glcPictureViewer.Click += GlcPictureViewer_Click;
        }

        private void GlcPictureViewer_Click(object sender, EventArgs e)
        {
            Point point = glcPictureViewer.PointToClient(Control.MousePosition);

            RibbonHitInfo hitInfo = glcPictureViewer.CalcHitInfo(point);

            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
                item = hitInfo.GalleryItem;
            if (Form.ModifierKeys == Keys.Control)
            {

                if (item != null)
                    if (item.Checked)
                    {
                        item.Checked = false;
                        lstPictureSelected.Remove(item.Caption);

                    }
                    else
                    {
                        item.Checked = true;
                        lstPictureSelected.Add(item.Caption);

                    }
            }
        }

        private void BtnAddImages_Click(object sender, EventArgs e)
        {                PictureAvailable = true;

            GalleryInitializeMethod(glcPicgroupNow);

            glcPicgroupNow.Caption =   PictureCount.ToString()+":الان اضافه شده";
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                foreach (string file in myDialog.FileNames)
                {

                    if (PictureExists(file) == null)
                    {
                        lstPicturePaths.Add(file);
                        PictureCount = lstPicturePaths.Count();
                        lblCount.Text = AccessLayer.MPC(txtCustomerCode.Text.Trim()) + "+" + PictureCount;
                        Image img = Image.FromFile(file);


                        glcPicgroupNow.Items.Add(new GalleryItem(img, PictureCount.ToString(), DATE.ToDay));


                    }
                    else
                    {
                        DialogResult Result = FRMMessageBox.Show(PictureExists(file), "تکرار تصویر", "!هشدار", enumMessageIcon.Question, enumMessageButton.OK);
                    }
                }
            }
            else
            {
                FRMMessageBox.Show("!هشدار", "!هشدار انتخاب تصاویر", " !لطفا تصاویر مورد نظر را وارد نمایید", enumMessageIcon.Warning, enumMessageButton.OK);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (PictureAvailable)
            {
                DialogResult Result = FRMMessageBox.Show("!هشدار", " ثبت اطلاعات مشتری","آیا مایل به ذخیره اطلاعات هستید؟",  enumMessageIcon.Question, enumMessageButton.YesNo);

                if (Result == DialogResult.Yes)
                {

                    if (PictureCount != 0)
                    {
                        StorePicture();
                        FRMMessageBox.Show("!هشدار", " ثبت اطلاعات مشتری",".ثبت اطلاعات و تصاویر با موفقیت انجام شد",  enumMessageIcon.Question, enumMessageButton.OK);
                        AddCutomerMethod();

                        lblCount.Text = AccessLayer.MPC(txtCustomerCode.Text.Trim()).ToString();
                        ReloadValues();
                    }
                  
                }
            }
            else
            {
                DialogResult Result = FRMMessageBox.Show("!هشدار", " ثبت اطلاعات مشتری بدون تصاویر","آیا اطلاعات مشتری بدون تصاویر ثبت شود؟",  enumMessageIcon.Question, enumMessageButton.YesNo);

                if (Result == DialogResult.Yes)
                {
                    AddCutomerMethod();

                    FRMMessageBox.Show("!هشدار", "  ثبت اطلاعات مشتری","ثبت بدون تصاویر با موفقیت انجام شد",  enumMessageIcon.Question, enumMessageButton.OK);
                    ReloadValues();

                }
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        private void FRMEditCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result = FRMMessageBox.Show("مشتری جدید","خروج","آیا از بستن این فرم مطمئن هستید؟",   enumMessageIcon.Question, enumMessageButton.YesNo);

            if (Result == DialogResult.No)
            {
                e.Cancel = true;
            }

            ReloadValues();
        }

        private void FRMAddCustomer_Load(object sender, EventArgs e)
        {

           
try
            {
                ConnectionString = CLS.DBHandler.GetConnectionString();
            }
            catch { }
            ReloadValues();



        }
        private void ReloadValues()
        {
            PictureCount = 0;// Count of customer picturs.
            lstPicturePaths.Clear();// cleaning list of picture paths for store.
            PictureAvailable = false; // Checked the picture exsist in list.

            lstPictureSelected.Clear();


            //   lstPictureCount.Clear();
            lstPictures.Clear();
            lstStorePicturesAtDate.Clear();
            glcPicgroupLast.Dispose();
            glcPicgroupNow.Dispose();


            ConnectionString = CLS.DBHandler.GetConnectionString();

            txtCustomerCode.Text = AccessLayer.MCC().ToString();
            txtCustomerSecurityCode.Text = CLS.RandomPassword.Generate(4, 6);

        }
        private void ZoomInGallery(int Value)
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
            {
                FRMFullScreenPics ShowFullScreen = new FRMFullScreenPics();

                FullScreenPicture.SCC = txtCustomerCode.Text.Trim();
                FullScreenPicture.SPN = item.Caption;
                FullScreenPicture.StartSendOnePitureToFullScreen();
                ShowFullScreen.Show();
            }

        }

        private void brbtnDeletePicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (item != null)
            {
                item.GalleryGroup.Items.Remove(item);
             //   lstPicturePaths
              //  AccessLayer.DeletePicture(txtCustomerCode.Text.Trim(), item.Caption);
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
        private void brbtnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (item != null)
                if (item.Checked)
                {
                    item.Checked = false;
                    lstPictureSelected.Remove(item.Caption);

                }
                else
                {
                    item.Checked = true;
                    lstPictureSelected.Add(item.Caption);

                }

        }

        private void btnRemoveSelectedPicture_Click(object sender, EventArgs e)
        {
            DialogResult Result = FRMMessageBox.Show("!هشدار", "!حذف تصاویر", "آیا تصاویر انتخابی حذف شوند؟", enumMessageIcon.Error, enumMessageButton.YesNo);
            if (Result == DialogResult.Yes)
            {
                for (int i = 0; i <= lstPictureSelected.Count - 1; ++i)
                {
                }
                ReloadValues();
            }
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            FRMFullScreenPics ShowFullScreen = new FRMFullScreenPics();

            string SCC = txtCustomerCode.Text.Trim();

            FullScreenPicture.SCC = SCC;
            FullScreenPicture.StartSendPicturesToFullScreen();
            ShowFullScreen.ShowDialog();
        }

        private void zoomTrackBarControl_EditValueChanged(object sender, EventArgs e)
        {
            int value = zoomTrackBarControl.Value;

            ZoomInGallery(value);

        }


        public void AddCutomerMethod()
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

                AccessLayer.CC = txtCustomerCode.Text.Trim();
                AccessLayer.CSC = txtCustomerSecurityCode.Text.Trim();
                AccessLayer.CFN = txtFirstName.Text.Trim();
                AccessLayer.CLN = txtLastName.Text.Trim();
                AccessLayer.CFFN = txtFatherName.Text.Trim();
                AccessLayer.CPN = txtPhoneNumber.Text.Trim();
                AccessLayer.CNC = txtNationalCode.Text.Trim();
                AccessLayer.CBD = txtBirthDay.Text.Trim();
                AccessLayer.CG = Gender;
                AccessLayer.CA = txtAddress.Text.Trim();
                AccessLayer.CE = txtEmail.Text.Trim();
                AccessLayer.CCAD = DATE.ToDay;
                AccessLayer.CPA = PictureAvailable.ToString();
                AccessLayer.MAC();
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
                using (SqlCommand cmdCount = new SqlCommand(CLS.DBHandler.GetCustomerExistsQuery(), thisConnection))
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







        #endregion

        private void btnPrintPicture_Click(object sender, EventArgs e)
        {

        }

   
    }
}





















