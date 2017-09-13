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
using Morvarid.CLS;

namespace Morvarid
{
    public partial class FRMEditCustomer : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Start
        /// CLS is here
        /// </summary>
        CLS.ImageHandler ImageHandler =new CLS.ImageHandler();
        CLS.PriceToStringClass PriceToString = new CLS.PriceToStringClass();
        CLS.GetShamsiDate DATE =new CLS.GetShamsiDate();
        CLS.AccessLayer AccessLayer = new CLS.AccessLayer();
        CLS.SendPictureToFullScreen FullScreenPicture = new CLS.SendPictureToFullScreen();
        /// <summary>
        /// end
        /// CLS is here
        /// </summary>
        #region Values






        public bool PictureLoading = false;

        private bool PictureAvailable = false;
        public bool CustomerExists = false;
        private int PictureCount = 0;
        private List<string> lstPicturePaths = new List<string>();

        private int ZoomValue = 5;

       // CLS.CLSDBHandler dbHandler = new CLS.CLSDBHandler();

        public List<int> lstPictureNumber = new List<int>();
        public List<Image> lstPictures = new List<Image>();
        public List<Image> lstTempPictures = new List<Image>();
        public List<string> lstStorePicturesAtDate = new List<string>();
        public List<string> lstPictureSelected = new List<string>();

        GalleryItemGroup glcPicgroupNow = new GalleryItemGroup();
        GalleryItemGroup glcPicgroupLast = new GalleryItemGroup();

        FRMAddCustomer AddCustomer = new FRMAddCustomer();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable CustomerDataTable = new DataTable();
        
        #endregion
        public FRMEditCustomer()
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



        private void RetrievePicture(DataTable DTStorePicture)
        {

            GalleryInitializeMethod(glcPicgroupLast);

            glcPicgroupLast.Caption = txtFirstName.Text + " " + txtLastName.Text + " (" + txtCustomerCode.Text + ")";
            glcPictureViewer.Gallery.Groups.Add(glcPicgroupLast);
            foreach (DataRow ROW in DTStorePicture.Rows)
            {

                lstPictureNumber.Add(ROW.Field<int>(0));
                lstPictures.Add(ImageHandler.BTI(ROW.Field<byte[]>(1)));
                lstTempPictures.Add(ImageHandler.BTI(ROW.Field<byte[]>(2)));

                lstStorePicturesAtDate.Add(ROW.Field<string>(3));

                glcPicgroupLast.Items.Add(new GalleryItem(ImageHandler.BTI(ROW.Field<byte[]>(2)), "" + ROW.Field<int>(0), ROW.Field<string>(3)));

            }
            

        }




        #region Method is here


        private void StorePicture()
        {
            string SCC = txtCustomerCode.Text.Trim();
            string SCSC = txtCustomerSecurityCode.Text.Trim();
            for (int i = 1; i <= PictureCount; ++i)
            {
                AccessLayer.SID  = AccessLayer.MSID();
                AccessLayer.SCC  = SCC;
                AccessLayer.SCSC = SCSC;
                AccessLayer.SPN  = AccessLayer.PicturenNumberMethod(SCC);
                AccessLayer.SAD  = DATE.ToDay;
                AccessLayer.SBP  = ImageHandler.ITB(lstPicturePaths[i - 1]);
                AccessLayer.STP  = ImageHandler.ITB(ImageHandler.RI(lstPicturePaths[i - 1]));
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



       

        //Reset all of values for after saving pictures.
        private void ResetValues()
        {
            


        }


       
        #endregion
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

        private void Item_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            
        }

     

        #region Buttons code here

        private void BtnAddImages_Click(object sender, EventArgs e)
        {
            GalleryInitializeMethod(glcPicgroupNow);

             glcPicgroupNow.Caption = ":الان اضافه شده" + PictureCount.ToString();
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PictureAvailable = true;

                foreach (string file in myDialog.FileNames)
                {

                    if (PictureExists(file) == null)
                    {
                        lstPicturePaths.Add(file);
                        PictureCount = lstPicturePaths.Count();

                        lblCount.Text =AccessLayer.MPC(txtCustomerCode.Text.Trim())+"+"+PictureCount;
                        Image img = Image.FromFile(file);


                        glcPicgroupNow.Items.Add(new GalleryItem(img,  PictureCount.ToString(),DATE. ToDay));

                        
                    }
                    else
                    {
                        DialogResult Result = FRMMessageBox.Show(PictureExists(file), "تکرار تصویر", "!هشدار", enumMessageIcon.Question, enumMessageButton.OK);
                    }
                }
            }
            else
            {

            }
        }
        public void UpdateCutomerMethod()
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
            AccessLayer.CG = Gender;
            AccessLayer.CC = txtCustomerCode.Text.Trim();
            AccessLayer.CFN = txtFirstName.Text.Trim();
            AccessLayer.CLN = txtLastName.Text.Trim();
            AccessLayer.CFFN = txtFatherName.Text.Trim();
            AccessLayer.CPN = txtPhoneNumber.Text.Trim();
            AccessLayer.CNC = txtNationalCode.Text.Trim();
            AccessLayer.CBD = txtBirthDay.Text.Trim();
            AccessLayer.CA = txtAddress.Text.Trim();
            AccessLayer.CE = txtEmail.Text.Trim();
            AccessLayer.CPA = PictureAvailable.ToString();
            AccessLayer.MUC();

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
                        StorePicture();
                        UpdateCutomerMethod();
                         FRMMessageBox.Show(".ویرایش با موفقیت انجام شد", " ویرایش اطلاعات مشتری", "!هشدار", enumMessageIcon.Question, enumMessageButton.OK);

                        lblCount.Text = AccessLayer.MPC(txtCustomerCode.Text.Trim()).ToString();
                        ReloadValues();
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
                    FRMMessageBox.Show(".ویرایش با موفقیت انجام شد", " ویرایش اطلاعات مشتری", "!هشدار", enumMessageIcon.Question, enumMessageButton.OK);

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


 
        private void FRMEditCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result = FRMMessageBox.Show("آیا از بستن این فرم مطمئن هستید؟", "ویرایش اطلاعات", "خروج", enumMessageIcon.Question, enumMessageButton.YesNo);

            if (Result == DialogResult.No)
            {
                e.Cancel = true;
            }

            ResetValues();

        }
        #endregion
        private void FRMEditCustomer_Load(object sender, EventArgs e)
        {

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

            txtCustomerCode.Text = FRMCustomerList.strCustomerCode;
            txtCustomerSecurityCode.Text = FRMCustomerList.strCustomerSecurityCode;
            txtFirstName.Text    = FRMCustomerList.strCustomerFirstName;
            txtLastName.Text     = FRMCustomerList.strCustomerLastName;
            txtFatherName.Text   = FRMCustomerList.strCustomerFatherName;
            txtPhoneNumber.Text  = FRMCustomerList.strCustomerPhoneNumber;
            txtNationalCode.Text = FRMCustomerList.strCustomerNationalCode;
            txtBirthDay.Text     = FRMCustomerList.strCustomerBirthDay;
            txtAddress.Text      = FRMCustomerList.strCustomerAddress;
            txtEmail.Text        = FRMCustomerList.strCustomerEmail;
            if (FRMCustomerList.strCustomerPictureCheck == "True")
            {
               string qry= CLS.DBHandler.GetCustomerPicturesQuery(txtCustomerCode.Text.Trim());
                RetrievePicture(ImageHandler.SPTDT(qry));

            }
 
            if (FRMCustomerList.strCustomerGender == "مرد")
            {
                rdBtnMen.Checked = true;
            }
            else
            {
                rdBtnWomen.Checked = true;
            }


            lblCount.Text = AccessLayer.MPC(txtCustomerCode.Text.Trim()).ToString();

        }

       

        private void zoomTrackBarControl_EditValueChanged(object sender, EventArgs e)
        {
            int value=zoomTrackBarControl.Value;

            ZoomInGallery(value);






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
                AccessLayer.DeletePicture(txtCustomerCode.Text.Trim(), item.Caption);
            }
                
            ResetValues();
            ReloadValues();
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
            if(item!=null)
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
                    AccessLayer.DeletePicture(txtCustomerCode.Text.Trim(), lstPictureSelected[i]);
                }
                ResetValues();
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

   
    }
}
















