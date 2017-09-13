using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using System.Diagnostics;
using Morvarid.CLS;

namespace Morvarid
{
    public partial class FRMSearchAndPrint : DevExpress.XtraEditors.XtraForm
    {
        //Strings for customers value
        public static string strCustomerCode;
        public static string strCustomerSecurityCode;
        public static string strCustomerFirstName;
        public static string strCustomerLastName;
        public static string strCustomerFatherName;
        public static string strCustomerPhoneNumber;
        public static string strCustomerNationalCode;
        public static string strCustomerGender;
        public static string strCustomerAddress;
        public static string strCustomerEmail;
        public static string strCutomerCreatedAtDate;
        public static string strCustomerEditedAtDate;
        public static string strCustomerBirthDay;
        public static string strCustomerPictureCheck = "false";
        /// </summary>
        private bool SwitchSelectedRow = false;

        public bool CustomerExists = false;
        public bool PictureLoading = false;

        /// <summary>
        /// Start
        /// CLS is here
        /// </summary>
        CLS.SendPictureToFullScreen FullScreenPicture = new CLS.SendPictureToFullScreen();
        /// <summary>
        /// end
        /// CLS is here
        /// </summary>







        private List<string> lstPicturePaths = new List<string>();

        private int ZoomValue = 5;

        // CLS.CLSDBHandler dbHandler = new CLS.CLSDBHandler();

        public List<int> lstPictureNumber = new List<int>();
        public List<Image> lstPictures = new List<Image>();
        public List<Image> lstTempPictures = new List<Image>();
        public List<string> lstStorePicturesAtDate = new List<string>();
        public List<string> lstPictureSelected = new List<string>();


        FRMAddCustomer ShowAddCustomer = new FRMAddCustomer();
        DataTable CustomerDataTable = new DataTable();

        FRMCustomerList ShowCustomerList = new FRMCustomerList();



        /// <summary>
        /// Start
        /// CLS is here
        /// </summary>
        CLS.ImageHandler ImageHandler = new CLS.ImageHandler();
        CLS.AccessLayer AccessLayer = new CLS.AccessLayer();
        /// <summary>
        /// end
        /// CLS is here
        /// </summary>
        public string ConnectionString;
        GalleryItemGroup glcPicgroupLast = new GalleryItemGroup();


        public FRMSearchAndPrint()
        {
            InitializeComponent();
            ConnectionString = CLS.DBHandler.GetConnectionString();

            Result(CLS.DBHandler.GetCustomerListQuery());
           ChangeLanguage();
        }


        private InputLanguage GetFarsiLanguage()
        {
            //Enumerate through InstalledInputLanguages which contains
            //all the keyboard layout you’ve installed in your windows.
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.LayoutName.ToLower() == "persian" || lang.LayoutName.ToLower() == "farsi")
                    return lang;
            }

            return null;
        }


        public void ChangeLanguage()
        {
            InputLanguage lang = GetFarsiLanguage();

            //Set the current language of the system to
            //the InputLanguage instance you need.
            InputLanguage.CurrentInputLanguage = lang ?? throw new NotSupportedException("Farsi Language keyboard is not installed.");
        }


        private void InitializeDgCustomerList()
        {
            dgCustomerList.Columns["Customer_Code"].HeaderText = "کد مشتری";
            dgCustomerList.Columns["Customer_FirstName"].HeaderText = "نام";
            dgCustomerList.Columns["Customer_LastName"].HeaderText = "نام خانوادگی";
            dgCustomerList.Columns["Customer_FatherName"].HeaderText = "نام پدر";
            dgCustomerList.Columns["Customer_PhoneNumber"].HeaderText = "شماره تلفن";
            dgCustomerList.Columns["Customer_Gender"].HeaderText = "جنسیت";
            dgCustomerList.Columns["Customer_NationalCode"].HeaderText = "کد ملی";
            dgCustomerList.Columns["Customer_Address"].HeaderText = "آدرس";
            dgCustomerList.Columns["Customer_Email"].HeaderText = "ایمیل";
            dgCustomerList.Columns["Customer_CreatedAtDate"].HeaderText = "تاریخ ثبت";
            dgCustomerList.Columns["Customer_EditedAtDate"].HeaderText = "تاریخ ویرایش";
            dgCustomerList.Columns["Customer_BirthDay"].HeaderText = "تاریخ تولد";
            dgCustomerList.Columns["Customer_Address"].HeaderText = "آدرس";

          dgCustomerList.Columns["Customer_Code"].Width = 75;
            dgCustomerList.Columns["Customer_FirstName"].Width = 115;
            dgCustomerList.Columns["Customer_LastName"].Width = 185;
            dgCustomerList.Columns["Customer_FatherName"].Width = 115;
            dgCustomerList.Columns["Customer_PhoneNumber"].Visible = false;
            dgCustomerList.Columns["Customer_Gender"].Visible = false;
            dgCustomerList.Columns["Customer_NationalCode"].Visible = false;
            dgCustomerList.Columns["Customer_Email"].Visible = false; ;
            dgCustomerList.Columns["Customer_CreatedAtDate"].Visible = false;
            dgCustomerList.Columns["Customer_BirthDay"].Visible = false;
            dgCustomerList.Columns["Customer_EditedAtDate"].Visible = false;
            dgCustomerList.Columns["Customer_Address"].Visible = false;
            dgCustomerList.Columns["Customer_Id"].Visible = false;
            dgCustomerList.Columns["Customer_SecurityCode"].Visible = false;
            dgCustomerList.Columns["Customer_PictureCheck"].Visible = false;
            dgCustomerList.RowTemplate.Height = 25;
            dgCustomerList.ColumnHeadersDefaultCellStyle.Font = new Font("B Nazanin", 12F, FontStyle.Bold);



        }
        private void InitializeDgCustomerListColor()
        {
            foreach (DataGridViewRow row in dgCustomerList.Rows)

                if (row.Index % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                }
        }
        private void RetrievePicture(DataTable DTStorePicture)
        {

            GalleryInitializeMethod(glcPicgroupLast);

            glcPicgroupLast.Caption = strCustomerFirstName + " " + strCustomerLastName + " (" + strCustomerCode + ")";
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

        private void brbtnShowFullScreen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (item != null)
            {
                FRMFullScreenPics ShowFullScreen = new FRMFullScreenPics();

                FullScreenPicture.SCC = strCustomerCode.Trim();
                FullScreenPicture.SPN = item.Caption;
                FullScreenPicture.StartSendOnePitureToFullScreen();
                ShowFullScreen.Show();
            }

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

        int nRow;
        #region Method Here
        private void SelectedRow()
        {

            ReloadValues();
            int Row;//= dgCustomerList.FirstDisplayedCell.RowIndex;

            Row = 0;
            try
            {
                if (!SwitchSelectedRow)
                {
                    dgCustomerList.Rows[0].Selected = true;


                    SwitchSelectedRow = true;
                }
                if (dgCustomerList.SelectedRows.Count > 0) // make sure user select at least 1 row 
                {


                    strCustomerCode = dgCustomerList.SelectedRows[Row].Cells[1].Value + string.Empty;
                    strCustomerSecurityCode = dgCustomerList.SelectedRows[Row].Cells[2].Value + string.Empty;
                    strCustomerFirstName = dgCustomerList.SelectedRows[Row].Cells[3].Value + string.Empty;
                    strCustomerLastName = dgCustomerList.SelectedRows[Row].Cells[4].Value + string.Empty;
                    strCustomerFatherName = dgCustomerList.SelectedRows[Row].Cells[5].Value + string.Empty;
                    strCustomerPhoneNumber = dgCustomerList.SelectedRows[Row].Cells[6].Value + string.Empty;
                    strCustomerNationalCode = dgCustomerList.SelectedRows[Row].Cells[7].Value + string.Empty;
                    strCustomerBirthDay = dgCustomerList.SelectedRows[Row].Cells[8].Value + string.Empty;
                    strCustomerGender = dgCustomerList.SelectedRows[Row].Cells[9].Value + string.Empty;
                    strCustomerAddress = dgCustomerList.SelectedRows[Row].Cells[10].Value + string.Empty;
                    strCustomerEmail = dgCustomerList.SelectedRows[Row].Cells[11].Value + string.Empty;
                    strCutomerCreatedAtDate = dgCustomerList.SelectedRows[Row].Cells[12].Value + string.Empty;
                    strCustomerEditedAtDate = dgCustomerList.SelectedRows[Row].Cells[13].Value + string.Empty;
                    strCustomerPictureCheck = dgCustomerList.SelectedRows[Row].Cells[14].Value + string.Empty;
                    if (strCustomerPictureCheck == "True")
                    {
                        string qry = CLS.DBHandler.GetCustomerPicturesQuery(strCustomerCode.Trim());
                        lstPictures.Clear();
                        RetrievePicture(ImageHandler.SPTDT(qry));

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            InitializeDgCustomerList();
            InitializeDgCustomerListColor();

        }
        private void ReloadValues()
        {
            glcPicgroupLast.Dispose();

            if (strCustomerCode != null)
                lblCount.Text = AccessLayer.MPC(strCustomerCode.Trim()).ToString();

        }

        public void Result(string Query)
        {

            dgCustomerList.DataSource = AccessLayer.SearchResult(Query);
            InitializeDgCustomerListColor();
            SelectedRow();
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
        private void barbtnOpenWithPhotoshop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                    TestDataBaseConnection photoshopPath = new TestDataBaseConnection();
            TestDataBaseConnection TempPath = new TestDataBaseConnection();

            if (item != null)
            {

                //w2480
                //h3307

                //MessageBox.Show("MouseClick Event");
                Random rnd = new Random();
                int RanNumber = rnd.Next(1, 1000);
                //     string SavePath = @"E:\GhasedakTempPicture" + RanNumber.ToString() + ".jpg";
                string SavePath = TempPath.ReadTempOfImagesPathFromFile()+"Image" + RanNumber.ToString() + ".jpg";
                int i = Convert.ToInt32(item.Caption);

                try
                {

                    Bitmap b = new Bitmap(lstPictures[--i]);
                    b.Save(SavePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //   MessageBox.Show();
                Process PhotoShop = new Process();
                 PhotoShop.StartInfo.FileName = photoshopPath.ReadPhotoshopPathFromFile();

               // PhotoShop.StartInfo.FileName = @"C:\Program Files\Adobe\Adobe Photoshop CS6\Photoshop.exe"
       ;
                PhotoShop.StartInfo.Arguments = SavePath;
                PhotoShop.Start();


                MessageBox.Show(SavePath.ToString());


            }
        }
        private void SearchCustomer(string txtSearch)
        {

            if (txtSearchBox.Text != string.Empty)
            {
                if (rdBtnPictureNumber.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetAllCustomerSearchCodeQuery(txtSearch));

                    }
                    else if (chbxMan.Checked)
                    {
                        Result(CLS.DBHandler.GetManCustomersSearchCodeQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetWoManCustomersSearchCodeQuery(txtSearch));
                    }
                }
                else if (rdBtnFName.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetAllCustomerSearchFirstNameQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        Result(CLS.DBHandler.GetManCustomersSearchFirstNameQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetWoManCustomersSearchFirstNameQuery(txtSearch));
                    }
                }
                else if (rdBtnLName.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetAllCustomerSearchLastNameQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        Result(CLS.DBHandler.GetManCustomersSearchLastNameQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetWoManCustomersSearchLastNameQuery(txtSearch));
                    }
                }
                else if (rdBtnDName.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetAllCustomerSearchFatherNameQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        Result(CLS.DBHandler.GetManCustomersSearchFatherNameQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetWoManCustomersSearchFatherNameQuery(txtSearch));
                    }
                }

                /*   else if (rdBtnCeatedAtDate.Checked)
                   {
                       if (chbxMan.Checked && chbxWoman.Checked)
                       {
                           SearchResult(CLS.DBHandler.GetAllCustomerSearchCreatedAtDateQuery(txtSearch));
                       }
                       else if (chbxMan.Checked)
                       {
                           SearchResult(CLS.DBHandler.GetManCustomersSearchCreatedAtDateQuery(txtSearch));

                       }
                       else if (chbxWoman.Checked)
                       {
                           SearchResult(CLS.DBHandler.GetWoManCustomersSearchCreatedAtDateQuery(txtSearch));
                       }
                   }
                   else if (rdBtnEditedAtDate.Checked)
                   {
                       if (chbxMan.Checked && chbxWoman.Checked)
                       {
                           SearchResult(CLS.DBHandler.GetAllCustomerSearchEditedAtDateQuery(txtSearch));
                       }
                       else if (chbxMan.Checked)
                       {
                           SearchResult(CLS.DBHandler.GetManCustomersSearchEditedAtDateQuery(txtSearch));

                       }
                       else if (chbxWoman.Checked)
                       {
                           SearchResult(CLS.DBHandler.GetWoManCustomersSearchEditedAtDateQuery(txtSearch));
                       }
                   }*/
                else if (rdBtnPhoneNumber.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetAllCustomerSearchPhoneNumberQuery(txtSearch));

                    }
                    else if (chbxMan.Checked)
                    {
                        Result(CLS.DBHandler.GetManCustomersSearchPhoneNumberQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        Result(CLS.DBHandler.GetWoManCustomersSearchPhoneNumberQuery(txtSearch));
                    }
                }

                SelectedRow();
            }
            else
            {
                Result(CLS.DBHandler.GetCustomerListQuery());
                SelectedRow();
            }
        }
        #endregion

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

            ShowAddCustomer.ShowDialog();

        }





        private void dgCustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }



        private void chbxMan_CheckedChanged(object sender, EventArgs e)
        {
            CHBTN_Man_Woman_Changed();
        }

        private void chbxWoman_CheckedChanged(object sender, EventArgs e)
        {
            CHBTN_Man_Woman_Changed();

        }



        private void CHBTN_Man_Woman_Changed()
        {
            if (chbxMan.Checked == false)
            {
                chbxWoman.Enabled = false;
            }
            if (chbxWoman.Checked == false)
            {
                chbxMan.Enabled = false;
            }
            if (chbxMan.Checked)
            {
                chbxWoman.Enabled = true;
            }
            if (chbxWoman.Checked)
            {
                chbxMan.Enabled = true;
            }
            SearchCustomer(txtSearchBox.Text);

        }

        private void rdBtnPictureNumber_CheckedChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }

        private void rdBtnFName_CheckedChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }

        private void rdBtnLName_CheckedChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }

        private void rdBtnDName_CheckedChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }

        private void rdBtnEditedAtDate_CheckedChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }

        private void rdBtnCeatedAtDate_CheckedChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }

        private void rdBtnPhoneNumber_CheckedChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }

        private void FRMCustomerList_Load(object sender, EventArgs e)
        {

            InitializeDgCustomerList();

            ConnectionString = CLS.DBHandler.GetConnectionString();
            Result(CLS.DBHandler.GetCustomerListQuery());

        }

        private void DgCustomerList_CurrentCellChanged(object sender, EventArgs e)
        {
            SelectedRow();

        }


        FRMEditCustomer EditCustomer = new FRMEditCustomer();

        private void btnEnableEditing_Click(object sender, EventArgs e)
        {



            EditCustomer.ShowDialog();


        }





        private void chbShow_HidePictures_CheckedChanged(object sender, EventArgs e)
        {

            /*  if (chbShow_HidePictures.Checked)
              {
                  chbShow_HidePictures.Text = "پنهان کردن تصاویر";
                  pnlPictureViewer.Visible = true;
                  CLS.CLSProgressSavePictures cPro = new CLS.CLSProgressSavePictures();
                  cPro.startProgress();
                  cPro.stopProgress();
              }
              else
              {
                  chbShow_HidePictures.Text = "نمایش";


                  pnlPictureViewer.Visible = false;

              }
              */

        }






        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Result(CLS.DBHandler.GetCustomerListQuery());

        }

        private void zoomTrackBarControl_EditValueChanged(object sender, EventArgs e)
        {
            int value = zoomTrackBarControl.Value;

            ZoomInGallery(value);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
        }



        private void btnEndOfRows_Click(object sender, EventArgs e)
        {
            dgCustomerList.Rows[nRow].Selected = false;
            dgCustomerList.Rows[dgCustomerList.RowCount - 1].Selected = true;
            SelectedRow();

        }
        private void btnNextRow_Click(object sender, EventArgs e)
        {
            if (nRow < dgCustomerList.RowCount)
            {
                dgCustomerList.Rows[nRow].Selected = false;
                if (nRow < dgCustomerList.RowCount - 1)
                {
                    dgCustomerList.Rows[++nRow].Selected = true;
                    SelectedRow();

                }
                else
                {
                    nRow = 0;
                    dgCustomerList.Rows[nRow].Selected = true;

                }

            }

        }

        private void btnBeiginOfRows_Click(object sender, EventArgs e)
        {
            dgCustomerList.Rows[nRow].Selected = false;
            dgCustomerList.Rows[dgCustomerList.RowCount - 1].Selected = true;
        }

        private void FRMSearchAndPrint_Load(object sender, EventArgs e)
        {
            ChangeLanguage();
            SelectedRow();
        }

        private void BarAddCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddCustomer.ShowDialog();

        }

        private void CustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowCustomerList.ShowDialog();

        }

        FRMSetting ShowSettin = new FRMSetting();
        private void brbtnSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowSettin.ShowDialog();
        }

       
    }
}