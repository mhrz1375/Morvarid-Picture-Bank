using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

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

        private int CtrlWidth;
        private int CtrlHeight;
        private int PanelPictureWidth = 100;
        private int PanelPictureHeight = 133;
        private const int ConstXLocation = 8;
        private const int ConstYLocation = 8;
        public bool CustomerExists = false;
        public bool PictureLoading = false;
        private int XLocation = 8;
        private int YLocation = 8;
        private int PictureCount = 0;


        private List<int> lstPictureCount = new List<int>();
        private List<Image> lstPictures = new List<Image>();
        private List<string> lstStorePicturesAtDate = new List<string>();

        private List<string> lstPicturePaths = new List<string>();


        FRMAddCustomer AddCustomer = new FRMAddCustomer();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable CustomerDataTable = new DataTable();
        DataTable PictureDataTable = new DataTable();

         public string ConnectionString;
        
                CLS.CLSGetShamsiDate GetToDay = new CLS.CLSGetShamsiDate();


        public FRMCustomerList()
        {
            InitializeComponent();
            //     displayDataGridView();
            //   displayPictureView();
            ConnectionString = CLS.CLSDBHandler.GetConnectionString();

            SearchResult(CLS.CLSDBHandler.GetCustomerListQuery());

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

        #region PictureBox Create Code here
        private int btnXLocation;
        private int btnYLocation;

        private void DrawPictureBoxFromDB(Image _filename, string _displayname)
        {
            PictureBox Pic1 = new PictureBox();
            Button btn = new Button();
            Panel pnl = new Panel();
            CtrlHeight = pnlPictureViewer.Height;
            CtrlWidth = pnlPictureViewer.Width;
            btnXLocation = XLocation;
            btnYLocation = YLocation;
            for (int i = 0; i < 1; i++)
            {
                //  buttonX1.Location = new System.Drawing.Point(XLocation, YLocation);
                pnl.Location = new System.Drawing.Point(XLocation, YLocation);
                Pic1.Location = new System.Drawing.Point(XLocation + 7, YLocation + 7);
                btn.Location = new System.Drawing.Point(XLocation + 20, YLocation + 20);
                XLocation = XLocation + PanelPictureWidth + 10;
                if (XLocation + PanelPictureWidth >= CtrlWidth)
                {
                    XLocation = 10;
                    YLocation = YLocation + PanelPictureHeight + 18;
                }
                pnl.Name = "panel" + i;
                Pic1.Name = "PictureBox" + i;
                btn.Name = "BtnRemove" + i;
                i += 1;
                pnl.Size = new System.Drawing.Size(PanelPictureWidth, PanelPictureHeight + 4);
                Pic1.Size = new System.Drawing.Size(PanelPictureWidth - 12, PanelPictureHeight - 12);
                btn.Size = new System.Drawing.Size(20, 20);
                Pic1.TabIndex = 0;
                btn.TabIndex = 1;
                pnl.TabIndex = 2;

                Pic1.TabStop = false;
                btn.TabStop = false;
                pnl.TabStop = false;
                Pic1.BorderStyle = BorderStyle.None;
                this.ttpImages.SetToolTip(Pic1, _displayname);
                //  Pic1.MouseEnter += Pic1_MouseEnter;
                // Pic1.MouseLeave += Pic1_MouseLeave;
                //  this.Controls.Add(Pic1);

                Pic1.Image = _filename;
                //Pic1.BackColor = Color.Red;
                Pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pnl.BackColor = System.Drawing.Color.Transparent;
                pnl.BorderStyle = BorderStyle.FixedSingle;
                btn.BackColor = System.Drawing.Color.Red;

                pnlPictureViewer.Controls.Add(pnl);
                pnlPictureViewer.Controls.Add(btn);

                pnlPictureViewer.Controls.Add(Pic1);
                pnl.BringToFront();

                Pic1.BringToFront();

                btn.BringToFront();

                btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseClick);
                pnl.MouseEnter += new System.EventHandler(this.pnl_MouseEnter);
                pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseDown);
                pnl.MouseLeave += new System.EventHandler(this.pnl_MouseLeave);
                Pic1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Pic1_MouseClick);
            }
        }

        private void btn_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = default(Button);
            btn = (Button)sender;
            MessageBox.Show(btn.Name);
        }

        private void pnl_MouseEnter(System.Object sender, System.EventArgs e)
        {
            Panel pnl = default(Panel);
            pnl = (Panel)sender;
            pnl.BackColor = System.Drawing.Color.LightSkyBlue;

        }
        private void pnl_MouseLeave(System.Object sender, System.EventArgs e)
        {

            Panel pnl = default(Panel);
            pnl = (Panel)sender;

            pnl.BackColor = System.Drawing.Color.LightSkyBlue;

        }
        private void pnl_MouseDown(System.Object sender, System.EventArgs e)
        {
            Panel pnl = default(Panel);
            pnl = (Panel)sender;

            pnl.BackColor = System.Drawing.Color.LightBlue;
        }

        private void Pic1_MouseClick(Object sender, MouseEventArgs e)
        {
            PictureBox Pic = default(PictureBox);
            Pic = (PictureBox)sender;
            ///  pictureBox1.Image = Pic.Image;

            //MessageBox.Show("MouseClick Event");
            Random rnd = new Random();
            int RanNumber = rnd.Next(1, 1000);
            //     string SavePath = @"E:\GhasedakTempPicture" + RanNumber.ToString() + ".jpg";
            string SavePath = @"D:\GhasedakTempPicture" + RanNumber.ToString() + ".jpg";

            try
            {

                Bitmap b = new Bitmap(Pic.Image);
                b.Save(SavePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //   MessageBox.Show();
            Process PhotoShop = new Process();
            ///  PhotoShop.StartInfo.FileName = @"C:\Program Files\Adobe\Adobe Photoshop CC 2015.5\Photoshop.exe";

            PhotoShop.StartInfo.FileName = @"C:\Program Files\Adobe\Adobe Photoshop CS6\Photoshop.exe"
;
            PhotoShop.StartInfo.Arguments = SavePath;
            PhotoShop.Start();



        }

        #endregion

        #region Method Here
        private void SelectedRow()
        {
            try
            {
                if (!SwitchSelectedRow)
                {
                    dgCustomerList.Rows[0].Selected = true;


                    SwitchSelectedRow = true;
                }
                if (dgCustomerList.SelectedRows.Count > 0) // make sure user select at least 1 row 
                {
                   

                    strCustomerCode = dgCustomerList.SelectedRows[0].Cells[1].Value + string.Empty;
                    strCustomerSecurityCode = dgCustomerList.SelectedRows[0].Cells[2].Value + string.Empty;
                    strCustomerFirstName = dgCustomerList.SelectedRows[0].Cells[3].Value + string.Empty;
                    strCustomerLastName = dgCustomerList.SelectedRows[0].Cells[4].Value + string.Empty;
                    strCustomerFatherName = dgCustomerList.SelectedRows[0].Cells[5].Value + string.Empty;
                    strCustomerPhoneNumber = dgCustomerList.SelectedRows[0].Cells[6].Value + string.Empty;
                    strCustomerNationalCode = dgCustomerList.SelectedRows[0].Cells[7].Value + string.Empty;
                    strCustomerBirthDay = dgCustomerList.SelectedRows[0].Cells[8].Value + string.Empty;
                    strCustomerGender = dgCustomerList.SelectedRows[0].Cells[9].Value + string.Empty;
                    strCustomerAddress = dgCustomerList.SelectedRows[0].Cells[10].Value + string.Empty;
                    strCustomerEmail = dgCustomerList.SelectedRows[0].Cells[11].Value + string.Empty;
                    strCutomerCreatedAtDate = dgCustomerList.SelectedRows[0].Cells[12].Value + string.Empty;
                    strCustomerEditedAtDate = dgCustomerList.SelectedRows[0].Cells[13].Value + string.Empty;
                    strCustomerPictureCheck = dgCustomerList.SelectedRows[0].Cells[14].Value + string.Empty;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


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
                            SqlCommand.Parameters.Add(new SqlParameter("@Customer_Code", (object)strCustomerCode));
                            SqlCommand.Parameters.Add(new SqlParameter("@Customer_SecurityCode", (object)strCustomerSecurityCode));
                            SqlCommand.Parameters.Add(new SqlParameter("@Store_PictureCount", (object)i));
                            SqlCommand.Parameters.Add(new SqlParameter("@Store_PicturePath", (object)lstPicturePaths[i - 1]));
                            SqlCommand.Parameters.Add(new SqlParameter("@Store_PictureBinary", (object)ReadFileMethod(lstPicturePaths[i - 1])));
                            SqlCommand.Parameters.Add(new SqlParameter("@Store_AtDate", (object)/*GetToDay.CRShamsiDate*/"1396/01/07"));

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
                    cmdCount.Parameters.AddWithValue("@Customer_Code", strCustomerCode);
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

            pnlPictureViewer.Controls.Clear();

            lstPictureCount.Clear();
            lstPictures.Clear();
            lstStorePicturesAtDate.Clear();

        }














        private void ShowPictures()
        {
            lblCountImage.Text = lstPictureCount.Count.ToString();
            for (int i = 0; lstPictureCount.Count - 1 > 0; i++)
            {
                DrawPictureBoxFromDB(lstPictures[i], lstStorePicturesAtDate[i]);
            }
        }













        public void displayPictureView(string CustomerCode)
        {
            try
            {
                PictureLoading = true;

                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
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
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show("displayPictureView" + ec.Message);
                PictureLoading = false;

            }

        }
        private void RetrivePicture(DataTable DTStorePicture)
        {
            foreach (DataRow ROW in DTStorePicture.Rows)
            {
                lstPictureCount.Add(ROW.Field<int>(0));
                lstPictures.Add(BinaryToImage(ROW.Field<byte[]>(1)));
                lstStorePicturesAtDate.Add(ROW.Field<string>(2));
            }

            ShowPictures();

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
































        public void SearchResult(string Query)
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
                        dgCustomerList.DataSource = CustomerDataTable;
                        SqlCommand.ExecuteNonQuery();
                        thisConnection.Close();

                    }
                }
                InitializeDgCustomerListColor();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }


        private void SearchCustomer(string txtSearch)
        {

            if (txtSearchBox.Text != "")
            {
                if (rdBtnPictureNumber.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetAllCustomerSearchCodeQuery(txtSearch));

                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetManCustomersSearchCodeQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetWoManCustomersSearchCodeQuery(txtSearch));
                    }
                }
                else if (rdBtnFName.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetAllCustomerSearchFirstNameQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetManCustomersSearchFirstNameQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetWoManCustomersSearchFirstNameQuery(txtSearch));
                    }
                }
                else if (rdBtnLName.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetAllCustomerSearchLastNameQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetManCustomersSearchLastNameQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetWoManCustomersSearchLastNameQuery(txtSearch));
                    }
                }
                else if (rdBtnDName.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetAllCustomerSearchFatherNameQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetManCustomersSearchFatherNameQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetWoManCustomersSearchFatherNameQuery(txtSearch));
                    }
                }

                else if (rdBtnCeatedAtDate.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetAllCustomerSearchCreatedAtDateQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetManCustomersSearchCreatedAtDateQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetWoManCustomersSearchCreatedAtDateQuery(txtSearch));
                    }
                }
                else if (rdBtnEditedAtDate.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetAllCustomerSearchEditedAtDateQuery(txtSearch));
                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetManCustomersSearchEditedAtDateQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetWoManCustomersSearchEditedAtDateQuery(txtSearch));
                    }
                }
                else if (rdBtnPhoneNumber.Checked)
                {
                    if (chbxMan.Checked && chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetAllCustomerSearchPhoneNumberQuery(txtSearch));

                    }
                    else if (chbxMan.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetManCustomersSearchPhoneNumberQuery(txtSearch));

                    }
                    else if (chbxWoman.Checked)
                    {
                        SearchResult(CLS.CLSDBHandler.GetWoManCustomersSearchPhoneNumberQuery(txtSearch));
                    }
                }

                SelectedRow();
            }
            else
            {
                SearchResult(CLS.CLSDBHandler.GetCustomerListQuery());
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
            SearchCustomer(txtSearchBox.Text);

            ResetValueMethod();
            SelectedRow();

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            InitializeDgCustomerListColor();

        }



        private void dgCustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ResetValueMethod();
            SelectedRow();
            displayPictureView(strCustomerCode);
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearchBox.Text);

        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            DeleteCustomerMethod();
            
            SearchResult(CLS.CLSDBHandler.GetCustomerListQuery());
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
        private void EnableEditing()
        {
         /*   if (SwitchEditing)
            {
                SwitchEditing = false;
                btnAddCustomer.Enabled = false;
                gbGender.Enabled = true;
                txtEditedAtDate.Text = GetToDay.CRShamsiDate;
                BtnAddImages.Enabled = true;
                gbStorePictureTools.Enabled = true;
                chbStorePicture.Enabled = true;
                btnSelectBirthDay.Enabled = true;
                txtCustomerCode.ReadOnly = false;
                txtFirstName.ReadOnly = false;
                txtLastName.ReadOnly = false;
                txtFatherName.ReadOnly = false;
                txtPhoneNumber.ReadOnly = false;
                txtNationalCode.ReadOnly = false;
                txtBirthDay.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtCreatedAtDate.ReadOnly = false;
                txtEditedAtDate.ReadOnly = false;
                gbEditingTool.Visible = true;
                dgCustomerList.Enabled = false;
            }
            else
            {
                SwitchEditing = true;
                gbGender.Enabled = false;
                btnAddCustomer.Enabled = true;
                BtnAddImages.Enabled = false;
                gbStorePictureTools.Enabled = false;
                chbStorePicture.Enabled = false;
                btnSelectBirthDay.Enabled = false;
                txtCustomerCode.ReadOnly = true;
                txtFirstName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                txtFatherName.ReadOnly = true;
                txtPhoneNumber.ReadOnly = true;
                txtNationalCode.ReadOnly = true;
                txtBirthDay.ReadOnly = true;
                txtAddress.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtCreatedAtDate.ReadOnly = true;
                txtEditedAtDate.ReadOnly = true;
                gbEditingTool.Visible = false;
                dgCustomerList.Enabled = true;
            }*/

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
            InitializeDgCustomerListColor();

            ConnectionString = CLS.CLSDBHandler.GetConnectionString();
            SearchResult(CLS.CLSDBHandler.GetCustomerListQuery());
            SelectedRow();
        }
        FRMEditCustomer EditCustomer = new FRMEditCustomer();

        private void btnEnableEditing_Click(object sender, EventArgs e)
        {
          
            

                EditCustomer.ShowDialog();
            
        
        }

        private void btnSaveEdited_Click(object sender, EventArgs e)
        {
            EnableEditing();
            SearchResult(CLS.CLSDBHandler.GetCustomerListQuery());
        }
        

        public void DeleteCustomerMethod()
        {
            try
            {
                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    string Query = CLS.CLSDBHandler.GetDeleteCustomerQuery(strCustomerCode);
                    using (SqlCommand SqlCommand = new SqlCommand(Query, thisConnection))
                    {                       
                        thisConnection.Open();
                        SqlCommand.ExecuteNonQuery();
                        thisConnection.Close();
                    }
                }
                DeletePictureCustomerMethod();
                FRMMessageBox.Show("مشتری حذف شد","!هشدار");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "!خطا در حذف اطلاعات");
            }
        }
        public void DeletePictureCustomerMethod()
        {
            try
            {
                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    string Query = CLS.CLSDBHandler.GetDeleteAllPictureCustomerQuery(strCustomerCode);
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
                MessageBox.Show(ex.ToString(), "خطا در حذف تصاویر");
            }
        }
      
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
                        //   DrawPictureBox(file, "displayname" + PictureCount);
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

        private void txtSearchBox_EditValueChanged(object sender, EventArgs e)
        {
            ResetValueMethod();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            /*    if (PictureLoading)
                {
                    prgbPicturesLoading.Visible = true;

                }
                else
                {
                    prgbPicturesLoading.Visible = false;

                }
                */
        }

        private void btnCancelEdited_Click(object sender, EventArgs e)
        {
             EnableEditing();
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
            SearchResult(CLS.CLSDBHandler.GetCustomerListQuery());

        }
    }
}