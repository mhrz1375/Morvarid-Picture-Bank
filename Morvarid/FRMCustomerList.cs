﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils.Drawing;
using Morvarid.CLS;

namespace Morvarid
{

    public partial class FRMCustomerList : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
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





        FRMAddCustomer AddCustomer = new FRMAddCustomer();


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



        public FRMCustomerList()
        {
            InitializeComponent();
            ConnectionString = CLS.DBHandler.GetConnectionString();

            SearchResult(CLS.DBHandler.GetCustomerListQuery());

        
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
dgCustomerList.Columns["Customer_Id"].Visible = false;
            dgCustomerList.Columns["Customer_SecurityCode"].Visible = false;
            dgCustomerList.Columns["Customer_PictureCheck"].Visible = false;
            dgCustomerList.Columns["Customer_Code"].Width = 120;
            dgCustomerList.Columns["Customer_FirstName"].Width = 170;
            dgCustomerList.Columns["Customer_LastName"].Width = 220;
            dgCustomerList.Columns["Customer_FatherName"].Width = 170;
            dgCustomerList.Columns["Customer_PhoneNumber"].Width = 200;
            dgCustomerList.Columns["Customer_Gender"].Width = 80;
            dgCustomerList.Columns["Customer_NationalCode"].Width = 200;
            dgCustomerList.Columns["Customer_Email"].Width = 180;
            dgCustomerList.Columns["Customer_CreatedAtDate"].Width = 120;
            dgCustomerList.Columns["Customer_BirthDay"].Width = 120;
            dgCustomerList.Columns["Customer_EditedAtDate"].Width = 100;
            dgCustomerList.Columns["Customer_Address"].Width = 200;
            
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
                glcPicgroupLast.Items.Add(new GalleryItem(ImageHandler.BTI(ROW.Field<byte[]>(2)), "" + ROW.Field<int>(0), ROW.Field<string>(3)));
            }


        }

        private int ZoomValue = 5;

        private void GalleryInitializeMethod(GalleryItemGroup g)
        {
            glcPictureViewer.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            ZoomInGallery(ZoomValue);
            glcPictureViewer.Gallery.ShowItemText = true;
            glcPictureViewer.Gallery.Groups.Add(g);
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

         Row= 0;
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
                        RetrievePicture(ImageHandler.SPTDT(qry));

                    }
}
                InitializeDgCustomerList();
                InitializeDgCustomerListColor();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }
        private void ReloadValues()
        {
            glcPicgroupLast.Dispose();
           
            if(strCustomerCode!=null)
            lblCount.Text = AccessLayer.MPC(strCustomerCode.Trim()).ToString();

        }

        public void SearchResult(string Query)
        {
            
            dgCustomerList.DataSource = AccessLayer.SearchResult(Query);
            InitializeDgCustomerListColor();
            SelectedRow();
        }


        private void SearchCustomer(string txtSearch)
        {

            if (txtSearchBox.Text != "")
            {
                if (rdBtnPictureNumber.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetAllCustomerSearchCodeQuery(txtSearch));

                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetManCustomersSearchCodeQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetWoManCustomersSearchCodeQuery(txtSearch));
                    }
                }
                else if (rdBtnFName.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetAllCustomerSearchFirstNameQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetManCustomersSearchFirstNameQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetWoManCustomersSearchFirstNameQuery(txtSearch));
                    }
                }
                else if (rdBtnLName.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetAllCustomerSearchLastNameQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetManCustomersSearchLastNameQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetWoManCustomersSearchLastNameQuery(txtSearch));
                    }
                }
                else if (rdBtnDName.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetAllCustomerSearchFatherNameQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetManCustomersSearchFatherNameQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetWoManCustomersSearchFatherNameQuery(txtSearch));
                    }
                }

                else if (rdBtnCeatedAtDate.Checked)
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
                }
                else if (rdBtnPhoneNumber.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetAllCustomerSearchPhoneNumberQuery(txtSearch));

                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetManCustomersSearchPhoneNumberQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.DBHandler.GetWoManCustomersSearchPhoneNumberQuery(txtSearch));
                    }
                }

                SelectedRow();
            }
            else
            {
                SearchResult(CLS.DBHandler.GetCustomerListQuery());
                SelectedRow();
            }
        }
        #endregion

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chbStorePicture_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

            AddCustomer.ShowDialog();

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            InitializeDgCustomerListColor();

        }



        private void dgCustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            DeleteCustomerMethod();
            
            SearchResult(CLS.DBHandler.GetCustomerListQuery());
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

            ConnectionString = CLS.DBHandler.GetConnectionString();
            SearchResult(CLS.DBHandler.GetCustomerListQuery());
            SelectedRow();

            
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

     

        public void DeleteCustomerMethod()
        {
          DialogResult Result= FRMMessageBox.Show("!هشدار", "حذف اطلاعات","["+ strCustomerFirstName+strCustomerLastName+"]\n"+"آیا مشتری مورد نظر حذف شود؟", enumMessageIcon.Question, enumMessageButton.YesNo);
            if (Result == DialogResult.Yes)
            {
             /*   if ()
                {

                }
                else
                {

                }*/
             AccessLayer.DC(strCustomerCode);
             FRMMessageBox.Show("!توجه"," حذف مشتری",".حذف مشتری با موفقیت انجام شد",enumMessageIcon.Information,enumMessageButton.OK);

              //  FRMMessageBox.Show("!هشدار", "حذف مشتری", " !مشتری حذف نشد\n.ابتدا اقدام به بستن حساب های مشتری نمایید و مجددا تلاش کنید",enumMessageIcon.Information,enumMessageButton.OK);

                
            }
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
        private void PersianCalenderBirthDay_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
        /*    txtBirthDay.Text = PersianCalenderBirthDay.GetSelectedDateInPersianDateTime().ToShortDateString();
            PersianCalenderBirthDay.Visible = false;*/
        }
        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
        }

      
      
        

        private void chbShowPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowPicture.Checked == true)
            {
                pnlPicture.Visible = true;
            }
            else
            {
                pnlPicture.Visible = false;
            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            SearchResult(CLS.DBHandler.GetCustomerListQuery());

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
                if(nRow < dgCustomerList.RowCount-1)
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

     
    }
}