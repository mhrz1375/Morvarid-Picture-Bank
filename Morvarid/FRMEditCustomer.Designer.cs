namespace Morvarid
{
    partial class FRMEditCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMEditCustomer));
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.tabfrmInfo = new DevExpress.XtraTab.XtraTabControl();
            this.tabInfoCustomer = new DevExpress.XtraTab.XtraTabPage();
            this.glcPictureViewer = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.gbStorePictureTools = new System.Windows.Forms.GroupBox();
            this.btnFullScreen = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintPicture = new DevExpress.XtraEditors.SimpleButton();
            this.zoomTrackBarControl = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.btnRemoveSelectedPicture = new DevExpress.XtraEditors.SimpleButton();
            this.lblCount = new DevComponents.DotNetBar.LabelX();
            this.BtnAddImages = new DevExpress.XtraEditors.SimpleButton();
            this.lblCountImage = new DevComponents.DotNetBar.LabelX();
            this.lblCustomerCodeImage = new DevComponents.DotNetBar.LabelX();
            this.lblCutomerCode1 = new DevComponents.DotNetBar.LabelX();
            this.gbAddCustomr = new System.Windows.Forms.GroupBox();
            this.btnSelectBirthDay = new DevExpress.XtraEditors.SimpleButton();
            this.txtBirthDay = new System.Windows.Forms.MaskedTextBox();
            this.PersianCalenderBirthDay = new BehComponents.MonthCalendarX();
            this.txtCustomerCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFirstName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblEmail = new DevComponents.DotNetBar.LabelX();
            this.txtEmail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblBirthDay = new DevComponents.DotNetBar.LabelX();
            this.lblFatherName = new DevComponents.DotNetBar.LabelX();
            this.lblSecurityCode = new DevComponents.DotNetBar.LabelX();
            this.txtCustomerSecurityCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblGender = new DevComponents.DotNetBar.LabelX();
            this.lblFirstName = new DevComponents.DotNetBar.LabelX();
            this.txtFatherName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblAddress = new DevComponents.DotNetBar.LabelX();
            this.lblPhoneNumber = new DevComponents.DotNetBar.LabelX();
            this.txtNationalCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNationalCode = new DevComponents.DotNetBar.LabelX();
            this.txtPhoneNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFName1 = new DevComponents.DotNetBar.LabelX();
            this.txtLastName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCustomerCode = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnMen = new System.Windows.Forms.RadioButton();
            this.rdBtnWomen = new System.Windows.Forms.RadioButton();
            this.ttpImages = new System.Windows.Forms.ToolTip(this.components);
            this.popmManagGallery = new DevExpress.XtraBars.PopupMenu(this.components);
            this.brbtnShowFullScreen = new DevExpress.XtraBars.BarButtonItem();
            this.brbtnDeletePicture = new DevExpress.XtraBars.BarButtonItem();
            this.brbtnSelect = new DevExpress.XtraBars.BarButtonItem();
            this.brmManagGallery = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabfrmInfo)).BeginInit();
            this.tabfrmInfo.SuspendLayout();
            this.tabInfoCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glcPictureViewer)).BeginInit();
            this.glcPictureViewer.SuspendLayout();
            this.gbStorePictureTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl.Properties)).BeginInit();
            this.gbAddCustomr.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popmManagGallery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brmManagGallery)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageUri.Uri = "Cancel;Office2013";
            this.btnCancel.Location = new System.Drawing.Point(180, 588);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 41);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "لغو";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageUri.Uri = "Apply;Office2013";
            this.btnSave.Location = new System.Drawing.Point(316, 588);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 41);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabfrmInfo
            // 
            this.tabfrmInfo.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabfrmInfo.Appearance.Options.UseFont = true;
            this.tabfrmInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabfrmInfo.Location = new System.Drawing.Point(0, 0);
            this.tabfrmInfo.Name = "tabfrmInfo";
            this.tabfrmInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabfrmInfo.RightToLeftLayout = DevExpress.Utils.DefaultBoolean.True;
            this.tabfrmInfo.SelectedTabPage = this.tabInfoCustomer;
            this.tabfrmInfo.Size = new System.Drawing.Size(1262, 681);
            this.tabfrmInfo.TabIndex = 24;
            this.tabfrmInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabInfoCustomer});
            // 
            // tabInfoCustomer
            // 
            this.tabInfoCustomer.Appearance.Header.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.tabInfoCustomer.Appearance.Header.Options.UseFont = true;
            this.tabInfoCustomer.Controls.Add(this.glcPictureViewer);
            this.tabInfoCustomer.Controls.Add(this.gbStorePictureTools);
            this.tabInfoCustomer.Controls.Add(this.gbAddCustomr);
            this.tabInfoCustomer.Name = "tabInfoCustomer";
            this.tabInfoCustomer.Size = new System.Drawing.Size(1255, 631);
            this.tabInfoCustomer.Text = "اطلاعات مشتری";
            // 
            // glcPictureViewer
            // 
            this.glcPictureViewer.Controls.Add(this.galleryControlClient1);
            this.glcPictureViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.glcPictureViewer.DesignGalleryGroupIndex = 0;
            this.glcPictureViewer.DesignGalleryItemIndex = 0;
            // 
            // 
            // 
            this.glcPictureViewer.Gallery.Appearance.FilterPanelCaption.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.glcPictureViewer.Gallery.Appearance.FilterPanelCaption.Options.UseFont = true;
            this.glcPictureViewer.Gallery.Appearance.GroupCaption.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.glcPictureViewer.Gallery.Appearance.GroupCaption.Options.UseFont = true;
            this.glcPictureViewer.Gallery.Appearance.ItemCaptionAppearance.Disabled.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.glcPictureViewer.Gallery.Appearance.ItemCaptionAppearance.Disabled.Options.UseFont = true;
            this.glcPictureViewer.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.glcPictureViewer.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            this.glcPictureViewer.Gallery.Appearance.ItemCaptionAppearance.Normal.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.glcPictureViewer.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.glcPictureViewer.Gallery.Appearance.ItemCaptionAppearance.Pressed.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.glcPictureViewer.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseFont = true;
            this.glcPictureViewer.Gallery.ImageSize = new System.Drawing.Size(51, 313);
            this.glcPictureViewer.Location = new System.Drawing.Point(8, 75);
            this.glcPictureViewer.Name = "glcPictureViewer";
            this.brmManagGallery.SetPopupContextMenu(this.glcPictureViewer, this.popmManagGallery);
            this.glcPictureViewer.Size = new System.Drawing.Size(785, 549);
            this.glcPictureViewer.TabIndex = 18;
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.glcPictureViewer;
            this.galleryControlClient1.Location = new System.Drawing.Point(23, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(760, 545);
            // 
            // gbStorePictureTools
            // 
            this.gbStorePictureTools.Controls.Add(this.btnFullScreen);
            this.gbStorePictureTools.Controls.Add(this.btnPrintPicture);
            this.gbStorePictureTools.Controls.Add(this.zoomTrackBarControl);
            this.gbStorePictureTools.Controls.Add(this.btnRemoveSelectedPicture);
            this.gbStorePictureTools.Controls.Add(this.lblCount);
            this.gbStorePictureTools.Controls.Add(this.BtnAddImages);
            this.gbStorePictureTools.Controls.Add(this.lblCountImage);
            this.gbStorePictureTools.Controls.Add(this.lblCustomerCodeImage);
            this.gbStorePictureTools.Controls.Add(this.lblCutomerCode1);
            this.gbStorePictureTools.Location = new System.Drawing.Point(10, -2);
            this.gbStorePictureTools.Name = "gbStorePictureTools";
            this.gbStorePictureTools.Size = new System.Drawing.Size(783, 71);
            this.gbStorePictureTools.TabIndex = 17;
            this.gbStorePictureTools.TabStop = false;
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnFullScreen.Appearance.Options.UseFont = true;
            this.btnFullScreen.ImageUri.Uri = "Zoom2;Size32x32;Office2013";
            this.btnFullScreen.Location = new System.Drawing.Point(587, 21);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(41, 41);
            this.btnFullScreen.TabIndex = 19;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // btnPrintPicture
            // 
            this.btnPrintPicture.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrintPicture.Appearance.Options.UseFont = true;
            this.btnPrintPicture.ImageUri.Uri = "Print;Office2013";
            this.btnPrintPicture.Location = new System.Drawing.Point(634, 21);
            this.btnPrintPicture.Name = "btnPrintPicture";
            this.btnPrintPicture.Size = new System.Drawing.Size(41, 41);
            this.btnPrintPicture.TabIndex = 18;
            // 
            // zoomTrackBarControl
            // 
            this.zoomTrackBarControl.EditValue = 5;
            this.zoomTrackBarControl.Location = new System.Drawing.Point(350, 25);
            this.zoomTrackBarControl.Name = "zoomTrackBarControl";
            this.zoomTrackBarControl.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.zoomTrackBarControl.Size = new System.Drawing.Size(104, 23);
            this.zoomTrackBarControl.TabIndex = 17;
            this.zoomTrackBarControl.Value = 5;
            // 
            // btnRemoveSelectedPicture
            // 
            this.btnRemoveSelectedPicture.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRemoveSelectedPicture.Appearance.Options.UseFont = true;
            this.btnRemoveSelectedPicture.ImageUri.Uri = "Cancel;Office2013";
            this.btnRemoveSelectedPicture.Location = new System.Drawing.Point(681, 21);
            this.btnRemoveSelectedPicture.Name = "btnRemoveSelectedPicture";
            this.btnRemoveSelectedPicture.Size = new System.Drawing.Size(41, 41);
            this.btnRemoveSelectedPicture.TabIndex = 16;
            this.btnRemoveSelectedPicture.Click += new System.EventHandler(this.btnRemoveSelectedPicture_Click);
            // 
            // lblCount
            // 
            // 
            // 
            // 
            this.lblCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCount.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(6, 19);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(58, 37);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "0";
            // 
            // BtnAddImages
            // 
            this.BtnAddImages.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.BtnAddImages.Appearance.Options.UseFont = true;
            this.BtnAddImages.ImageUri.Uri = "Add;Office2013";
            this.BtnAddImages.Location = new System.Drawing.Point(728, 21);
            this.BtnAddImages.Name = "BtnAddImages";
            this.BtnAddImages.Size = new System.Drawing.Size(41, 41);
            this.BtnAddImages.TabIndex = 0;
            this.BtnAddImages.Click += new System.EventHandler(this.BtnAddImages_Click);
            // 
            // lblCountImage
            // 
            // 
            // 
            // 
            this.lblCountImage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCountImage.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.lblCountImage.Location = new System.Drawing.Point(70, 19);
            this.lblCountImage.Name = "lblCountImage";
            this.lblCountImage.Size = new System.Drawing.Size(105, 37);
            this.lblCountImage.TabIndex = 13;
            this.lblCountImage.Text = "تعداد تصاویر";
            this.lblCountImage.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCustomerCodeImage
            // 
            // 
            // 
            // 
            this.lblCustomerCodeImage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCustomerCodeImage.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.lblCustomerCodeImage.Location = new System.Drawing.Point(152, 21);
            this.lblCustomerCodeImage.Name = "lblCustomerCodeImage";
            this.lblCustomerCodeImage.Size = new System.Drawing.Size(58, 37);
            this.lblCustomerCodeImage.TabIndex = 15;
            this.lblCustomerCodeImage.Text = "0";
            // 
            // lblCutomerCode1
            // 
            // 
            // 
            // 
            this.lblCutomerCode1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCutomerCode1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.lblCutomerCode1.Location = new System.Drawing.Point(216, 19);
            this.lblCutomerCode1.Name = "lblCutomerCode1";
            this.lblCutomerCode1.Size = new System.Drawing.Size(96, 37);
            this.lblCutomerCode1.TabIndex = 14;
            this.lblCutomerCode1.Text = "کد مشتری :";
            this.lblCutomerCode1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // gbAddCustomr
            // 
            this.gbAddCustomr.BackColor = System.Drawing.Color.Transparent;
            this.gbAddCustomr.Controls.Add(this.btnSelectBirthDay);
            this.gbAddCustomr.Controls.Add(this.btnCancel);
            this.gbAddCustomr.Controls.Add(this.txtBirthDay);
            this.gbAddCustomr.Controls.Add(this.btnSave);
            this.gbAddCustomr.Controls.Add(this.PersianCalenderBirthDay);
            this.gbAddCustomr.Controls.Add(this.txtCustomerCode);
            this.gbAddCustomr.Controls.Add(this.txtFirstName);
            this.gbAddCustomr.Controls.Add(this.txtAddress);
            this.gbAddCustomr.Controls.Add(this.lblEmail);
            this.gbAddCustomr.Controls.Add(this.txtEmail);
            this.gbAddCustomr.Controls.Add(this.lblBirthDay);
            this.gbAddCustomr.Controls.Add(this.lblFatherName);
            this.gbAddCustomr.Controls.Add(this.lblSecurityCode);
            this.gbAddCustomr.Controls.Add(this.txtCustomerSecurityCode);
            this.gbAddCustomr.Controls.Add(this.lblGender);
            this.gbAddCustomr.Controls.Add(this.lblFirstName);
            this.gbAddCustomr.Controls.Add(this.txtFatherName);
            this.gbAddCustomr.Controls.Add(this.lblAddress);
            this.gbAddCustomr.Controls.Add(this.lblPhoneNumber);
            this.gbAddCustomr.Controls.Add(this.txtNationalCode);
            this.gbAddCustomr.Controls.Add(this.lblNationalCode);
            this.gbAddCustomr.Controls.Add(this.txtPhoneNumber);
            this.gbAddCustomr.Controls.Add(this.lblFName1);
            this.gbAddCustomr.Controls.Add(this.txtLastName);
            this.gbAddCustomr.Controls.Add(this.lblCustomerCode);
            this.gbAddCustomr.Controls.Add(this.groupBox1);
            this.gbAddCustomr.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gbAddCustomr.Location = new System.Drawing.Point(800, -11);
            this.gbAddCustomr.Name = "gbAddCustomr";
            this.gbAddCustomr.Size = new System.Drawing.Size(452, 635);
            this.gbAddCustomr.TabIndex = 3;
            this.gbAddCustomr.TabStop = false;
            // 
            // btnSelectBirthDay
            // 
            this.btnSelectBirthDay.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnSelectBirthDay.ImageUri.Uri = "DayView";
            this.btnSelectBirthDay.Location = new System.Drawing.Point(185, 334);
            this.btnSelectBirthDay.Name = "btnSelectBirthDay";
            this.btnSelectBirthDay.Size = new System.Drawing.Size(32, 31);
            this.btnSelectBirthDay.TabIndex = 9;
            this.btnSelectBirthDay.Click += new System.EventHandler(this.btnSelectBirthDay_Click);
            // 
            // txtBirthDay
            // 
            this.txtBirthDay.Location = new System.Drawing.Point(8, 333);
            this.txtBirthDay.Name = "txtBirthDay";
            this.txtBirthDay.Size = new System.Drawing.Size(212, 39);
            this.txtBirthDay.TabIndex = 64;
            this.txtBirthDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PersianCalenderBirthDay
            // 
            this.PersianCalenderBirthDay.BoldedDayForeColor = System.Drawing.Color.LightSteelBlue;
            this.PersianCalenderBirthDay.BorderColor = System.Drawing.Color.CadetBlue;
            this.PersianCalenderBirthDay.CalendarType = BehComponents.CalendarTypes.Persian;
            this.PersianCalenderBirthDay.DayRectTickness = 2F;
            this.PersianCalenderBirthDay.DaysBackColor = System.Drawing.Color.White;
            this.PersianCalenderBirthDay.DaysFont = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersianCalenderBirthDay.DaysForeColor = System.Drawing.Color.Black;
            this.PersianCalenderBirthDay.EnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.PersianCalenderBirthDay.EnglishBoldedDates = new System.DateTime[0];
            this.PersianCalenderBirthDay.EnglishHolidayDates = new System.DateTime[0];
            this.PersianCalenderBirthDay.EnglishMonthlyBoldedDates = new System.DateTime[0];
            this.PersianCalenderBirthDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersianCalenderBirthDay.HolidayForeColor = System.Drawing.Color.Red;
            this.PersianCalenderBirthDay.HolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.PersianCalenderBirthDay.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.PersianCalenderBirthDay.LineWeekColor = System.Drawing.Color.Black;
            this.PersianCalenderBirthDay.Location = new System.Drawing.Point(8, 373);
            this.PersianCalenderBirthDay.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.PersianCalenderBirthDay.Name = "PersianCalenderBirthDay";
            this.PersianCalenderBirthDay.PersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.PersianCalenderBirthDay.PersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.PersianCalenderBirthDay.PersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.PersianCalenderBirthDay.PersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.PersianCalenderBirthDay.ShowToday = true;
            this.PersianCalenderBirthDay.ShowTodayRect = true;
            this.PersianCalenderBirthDay.ShowToolTips = false;
            this.PersianCalenderBirthDay.ShowTrailing = true;
            this.PersianCalenderBirthDay.Size = new System.Drawing.Size(211, 262);
            this.PersianCalenderBirthDay.Style_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.PersianCalenderBirthDay.Style_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.System;
            this.PersianCalenderBirthDay.Style_MonthButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.PersianCalenderBirthDay.Style_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.PersianCalenderBirthDay.Style_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.PersianCalenderBirthDay.Style_YearButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.PersianCalenderBirthDay.TabIndex = 63;
            this.PersianCalenderBirthDay.TitleBackColor = System.Drawing.Color.White;
            this.PersianCalenderBirthDay.TitleFont = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersianCalenderBirthDay.TitleForeColor = System.Drawing.Color.Black;
            this.PersianCalenderBirthDay.TodayBackColor = System.Drawing.Color.White;
            this.PersianCalenderBirthDay.TodayFont = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.PersianCalenderBirthDay.TodayForeColor = System.Drawing.Color.Brown;
            this.PersianCalenderBirthDay.TodayRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PersianCalenderBirthDay.TodayRectTickness = 2F;
            this.PersianCalenderBirthDay.TrailingForeColor = System.Drawing.Color.DarkGray;
            this.PersianCalenderBirthDay.Visible = false;
            this.PersianCalenderBirthDay.WeekDaysBackColor = System.Drawing.Color.White;
            this.PersianCalenderBirthDay.WeekDaysFont = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.PersianCalenderBirthDay.WeekDaysForeColor = System.Drawing.Color.Blue;
            this.PersianCalenderBirthDay.WeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.PersianCalenderBirthDay.SelectedDateChanged += new BehComponents.MonthCalendarX.OnSelectedDateChanged(this.PersianCalenderBirthDay_SelectedDateChanged);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCustomerCode.Border.Class = "TextBoxBorder";
            this.txtCustomerCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomerCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtCustomerCode.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCustomerCode.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerCode.Location = new System.Drawing.Point(234, 63);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(7);
            this.txtCustomerCode.MaxLength = 50;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerCode.Size = new System.Drawing.Size(212, 39);
            this.txtCustomerCode.TabIndex = 1;
            this.txtCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtCustomerCode_TextChanged);
            this.txtCustomerCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerCode_KeyPress);
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFirstName.Border.Class = "TextBoxBorder";
            this.txtFirstName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFirstName.DisabledBackColor = System.Drawing.Color.White;
            this.txtFirstName.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.Location = new System.Drawing.Point(8, 151);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(7);
            this.txtFirstName.MaxLength = 20;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFirstName.Size = new System.Drawing.Size(212, 39);
            this.txtFirstName.TabIndex = 5;
            this.txtFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddress.DisabledBackColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(-2, 505);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(7);
            this.txtAddress.MaxLength = 300;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(448, 39);
            this.txtAddress.TabIndex = 12;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEmail
            // 
            // 
            // 
            // 
            this.lblEmail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEmail.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblEmail.Location = new System.Drawing.Point(112, 379);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(7);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(108, 32);
            this.lblEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.lblEmail.TabIndex = 57;
            this.lblEmail.Text = "پست الکترونیک";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmail.DisabledBackColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(8, 425);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(7);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEmail.Size = new System.Drawing.Size(212, 39);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBirthDay
            // 
            // 
            // 
            // 
            this.lblBirthDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBirthDay.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBirthDay.Location = new System.Drawing.Point(137, 288);
            this.lblBirthDay.Margin = new System.Windows.Forms.Padding(7);
            this.lblBirthDay.Name = "lblBirthDay";
            this.lblBirthDay.Size = new System.Drawing.Size(83, 32);
            this.lblBirthDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.lblBirthDay.TabIndex = 55;
            this.lblBirthDay.Text = "تاریخ تولد";
            // 
            // lblFatherName
            // 
            // 
            // 
            // 
            this.lblFatherName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFatherName.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFatherName.Location = new System.Drawing.Point(137, 200);
            this.lblFatherName.Margin = new System.Windows.Forms.Padding(7);
            this.lblFatherName.Name = "lblFatherName";
            this.lblFatherName.Size = new System.Drawing.Size(83, 32);
            this.lblFatherName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.lblFatherName.TabIndex = 53;
            this.lblFatherName.Text = "نام پدر";
            // 
            // lblSecurityCode
            // 
            // 
            // 
            // 
            this.lblSecurityCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSecurityCode.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSecurityCode.Location = new System.Drawing.Point(57, 26);
            this.lblSecurityCode.Margin = new System.Windows.Forms.Padding(7);
            this.lblSecurityCode.Name = "lblSecurityCode";
            this.lblSecurityCode.Size = new System.Drawing.Size(163, 31);
            this.lblSecurityCode.TabIndex = 47;
            this.lblSecurityCode.Text = "کد امنیتی";
            // 
            // txtCustomerSecurityCode
            // 
            this.txtCustomerSecurityCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCustomerSecurityCode.Border.Class = "TextBoxBorder";
            this.txtCustomerSecurityCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomerSecurityCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtCustomerSecurityCode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerSecurityCode.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerSecurityCode.Location = new System.Drawing.Point(8, 63);
            this.txtCustomerSecurityCode.Margin = new System.Windows.Forms.Padding(7);
            this.txtCustomerSecurityCode.MaxLength = 50;
            this.txtCustomerSecurityCode.Name = "txtCustomerSecurityCode";
            this.txtCustomerSecurityCode.ReadOnly = true;
            this.txtCustomerSecurityCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerSecurityCode.Size = new System.Drawing.Size(212, 39);
            this.txtCustomerSecurityCode.TabIndex = 2;
            this.txtCustomerSecurityCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblGender
            // 
            // 
            // 
            // 
            this.lblGender.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGender.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGender.Location = new System.Drawing.Point(369, 108);
            this.lblGender.Margin = new System.Windows.Forms.Padding(7);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(77, 32);
            this.lblGender.TabIndex = 51;
            this.lblGender.Text = "جنسیت";
            // 
            // lblFirstName
            // 
            // 
            // 
            // 
            this.lblFirstName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFirstName.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFirstName.Location = new System.Drawing.Point(57, 108);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(7);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(163, 32);
            this.lblFirstName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.lblFirstName.TabIndex = 49;
            this.lblFirstName.Text = "نام";
            // 
            // txtFatherName
            // 
            this.txtFatherName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFatherName.Border.Class = "TextBoxBorder";
            this.txtFatherName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFatherName.DisabledBackColor = System.Drawing.Color.White;
            this.txtFatherName.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFatherName.ForeColor = System.Drawing.Color.Black;
            this.txtFatherName.Location = new System.Drawing.Point(8, 246);
            this.txtFatherName.Margin = new System.Windows.Forms.Padding(7);
            this.txtFatherName.MaxLength = 20;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFatherName.Size = new System.Drawing.Size(212, 39);
            this.txtFatherName.TabIndex = 7;
            this.txtFatherName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAddress
            // 
            // 
            // 
            // 
            this.lblAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAddress.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAddress.Location = new System.Drawing.Point(339, 472);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(7);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(107, 28);
            this.lblAddress.TabIndex = 24;
            this.lblAddress.Text = "آدرس";
            // 
            // lblPhoneNumber
            // 
            // 
            // 
            // 
            this.lblPhoneNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPhoneNumber.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(327, 381);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(7);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(119, 30);
            this.lblPhoneNumber.TabIndex = 22;
            this.lblPhoneNumber.Text = "تلفن همراه";
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNationalCode.Border.Class = "TextBoxBorder";
            this.txtNationalCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNationalCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtNationalCode.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNationalCode.ForeColor = System.Drawing.Color.Black;
            this.txtNationalCode.Location = new System.Drawing.Point(234, 334);
            this.txtNationalCode.Margin = new System.Windows.Forms.Padding(7);
            this.txtNationalCode.MaxLength = 10;
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNationalCode.Size = new System.Drawing.Size(212, 39);
            this.txtNationalCode.TabIndex = 8;
            this.txtNationalCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNationalCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNationalCode_KeyPress);
            // 
            // lblNationalCode
            // 
            // 
            // 
            // 
            this.lblNationalCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNationalCode.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNationalCode.Location = new System.Drawing.Point(369, 291);
            this.lblNationalCode.Margin = new System.Windows.Forms.Padding(7);
            this.lblNationalCode.Name = "lblNationalCode";
            this.lblNationalCode.Size = new System.Drawing.Size(77, 29);
            this.lblNationalCode.TabIndex = 20;
            this.lblNationalCode.Text = "کد ملی";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPhoneNumber.Border.Class = "TextBoxBorder";
            this.txtPhoneNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPhoneNumber.DisabledBackColor = System.Drawing.Color.White;
            this.txtPhoneNumber.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhoneNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNumber.Location = new System.Drawing.Point(234, 425);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(7);
            this.txtPhoneNumber.MaxLength = 11;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhoneNumber.Size = new System.Drawing.Size(212, 39);
            this.txtPhoneNumber.TabIndex = 10;
            this.txtPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // lblFName1
            // 
            // 
            // 
            // 
            this.lblFName1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFName1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFName1.Location = new System.Drawing.Point(327, 200);
            this.lblFName1.Margin = new System.Windows.Forms.Padding(7);
            this.lblFName1.Name = "lblFName1";
            this.lblFName1.Size = new System.Drawing.Size(119, 32);
            this.lblFName1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.lblFName1.TabIndex = 15;
            this.lblFName1.Text = "نام خانوادگی";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLastName.Border.Class = "TextBoxBorder";
            this.txtLastName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLastName.DisabledBackColor = System.Drawing.Color.White;
            this.txtLastName.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLastName.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.Location = new System.Drawing.Point(234, 244);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(7);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLastName.Size = new System.Drawing.Size(212, 39);
            this.txtLastName.TabIndex = 6;
            this.txtLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCustomerCode
            // 
            // 
            // 
            // 
            this.lblCustomerCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCustomerCode.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCustomerCode.Location = new System.Drawing.Point(369, 26);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(77, 31);
            this.lblCustomerCode.TabIndex = 1;
            this.lblCustomerCode.Text = "کد مشتری";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rdBtnMen);
            this.groupBox1.Controls.Add(this.rdBtnWomen);
            this.groupBox1.Location = new System.Drawing.Point(234, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 51);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // rdBtnMen
            // 
            this.rdBtnMen.AutoSize = true;
            this.rdBtnMen.Checked = true;
            this.rdBtnMen.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rdBtnMen.Location = new System.Drawing.Point(122, 17);
            this.rdBtnMen.Name = "rdBtnMen";
            this.rdBtnMen.Size = new System.Drawing.Size(61, 36);
            this.rdBtnMen.TabIndex = 3;
            this.rdBtnMen.TabStop = true;
            this.rdBtnMen.Text = "مرد";
            this.rdBtnMen.UseVisualStyleBackColor = true;
            // 
            // rdBtnWomen
            // 
            this.rdBtnWomen.AutoSize = true;
            this.rdBtnWomen.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rdBtnWomen.Location = new System.Drawing.Point(48, 17);
            this.rdBtnWomen.Name = "rdBtnWomen";
            this.rdBtnWomen.Size = new System.Drawing.Size(56, 36);
            this.rdBtnWomen.TabIndex = 4;
            this.rdBtnWomen.Text = "زن";
            this.rdBtnWomen.UseVisualStyleBackColor = true;
            // 
            // popmManagGallery
            // 
            this.popmManagGallery.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.brbtnShowFullScreen),
            new DevExpress.XtraBars.LinkPersistInfo(this.brbtnDeletePicture),
            new DevExpress.XtraBars.LinkPersistInfo(this.brbtnSelect)});
            this.popmManagGallery.Manager = this.brmManagGallery;
            this.popmManagGallery.Name = "popmManagGallery";
            this.popmManagGallery.CloseUp += new System.EventHandler(this.popmManagrGallery_CloseUp);
            this.popmManagGallery.Popup += new System.EventHandler(this.popmManagrGallery_Popup);
            // 
            // brbtnShowFullScreen
            // 
            this.brbtnShowFullScreen.Caption = "نمایش تمام صفحه";
            this.brbtnShowFullScreen.Id = 0;
            this.brbtnShowFullScreen.Name = "brbtnShowFullScreen";
            this.brbtnShowFullScreen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brbtnShowFullScreen_ItemClick);
            // 
            // brbtnDeletePicture
            // 
            this.brbtnDeletePicture.Caption = "حذف";
            this.brbtnDeletePicture.Id = 1;
            this.brbtnDeletePicture.Name = "brbtnDeletePicture";
            this.brbtnDeletePicture.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brbtnDeletePicture_ItemClick);
            // 
            // brbtnSelect
            // 
            this.brbtnSelect.Caption = "انتخاب تصویر";
            this.brbtnSelect.Id = 3;
            this.brbtnSelect.Name = "brbtnSelect";
            this.brbtnSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brbtnSelect_ItemClick);
            // 
            // brmManagGallery
            // 
            this.brmManagGallery.DockControls.Add(this.barDockControlTop);
            this.brmManagGallery.DockControls.Add(this.barDockControlBottom);
            this.brmManagGallery.DockControls.Add(this.barDockControlLeft);
            this.brmManagGallery.DockControls.Add(this.barDockControlRight);
            this.brmManagGallery.Form = this;
            this.brmManagGallery.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.brbtnShowFullScreen,
            this.brbtnDeletePicture,
            this.brbtnSelect});
            this.brmManagGallery.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.brmManagGallery;
            this.barDockControlTop.Size = new System.Drawing.Size(1262, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 673);
            this.barDockControlBottom.Manager = this.brmManagGallery;
            this.barDockControlBottom.Size = new System.Drawing.Size(1262, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.brmManagGallery;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 673);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1262, 0);
            this.barDockControlRight.Manager = this.brmManagGallery;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 673);
            // 
            // FRMEditCustomer
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.tabfrmInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FRMEditCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ویرایش اطلاعات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMEditCustomer_FormClosing);
            this.Load += new System.EventHandler(this.FRMEditCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabfrmInfo)).EndInit();
            this.tabfrmInfo.ResumeLayout(false);
            this.tabInfoCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.glcPictureViewer)).EndInit();
            this.glcPictureViewer.ResumeLayout(false);
            this.gbStorePictureTools.ResumeLayout(false);
            this.gbStorePictureTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl)).EndInit();
            this.gbAddCustomr.ResumeLayout(false);
            this.gbAddCustomr.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popmManagGallery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brmManagGallery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraTab.XtraTabControl tabfrmInfo;
        private DevExpress.XtraTab.XtraTabPage tabInfoCustomer;
        private System.Windows.Forms.GroupBox gbAddCustomr;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress;
        private DevComponents.DotNetBar.LabelX lblEmail;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEmail;
        private DevComponents.DotNetBar.LabelX lblBirthDay;
        private DevComponents.DotNetBar.LabelX lblFatherName;
        private DevComponents.DotNetBar.LabelX lblSecurityCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerSecurityCode;
        private DevComponents.DotNetBar.LabelX lblGender;
        private DevComponents.DotNetBar.LabelX lblFirstName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFatherName;
        private DevComponents.DotNetBar.LabelX lblAddress;
        private DevComponents.DotNetBar.LabelX lblPhoneNumber;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNationalCode;
        private DevComponents.DotNetBar.LabelX lblNationalCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPhoneNumber;
        private DevComponents.DotNetBar.LabelX lblFName1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLastName;
        private DevComponents.DotNetBar.LabelX lblCustomerCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBtnMen;
        private System.Windows.Forms.RadioButton rdBtnWomen;
        private System.Windows.Forms.ToolTip ttpImages;
        private DevExpress.XtraEditors.SimpleButton btnSelectBirthDay;
        private System.Windows.Forms.MaskedTextBox txtBirthDay;
        private BehComponents.MonthCalendarX PersianCalenderBirthDay;
        private DevExpress.XtraBars.PopupMenu popmManagGallery;
        private DevExpress.XtraBars.BarButtonItem brbtnShowFullScreen;
        private DevExpress.XtraBars.BarButtonItem brbtnDeletePicture;
        private DevExpress.XtraBars.BarManager brmManagGallery;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem brbtnSelect;
        private DevExpress.XtraBars.Ribbon.GalleryControl glcPictureViewer;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private System.Windows.Forms.GroupBox gbStorePictureTools;
        private DevExpress.XtraEditors.SimpleButton btnFullScreen;
        private DevExpress.XtraEditors.SimpleButton btnPrintPicture;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl;
        private DevExpress.XtraEditors.SimpleButton btnRemoveSelectedPicture;
        private DevComponents.DotNetBar.LabelX lblCount;
        private DevExpress.XtraEditors.SimpleButton BtnAddImages;
        private DevComponents.DotNetBar.LabelX lblCountImage;
        private DevComponents.DotNetBar.LabelX lblCustomerCodeImage;
        private DevComponents.DotNetBar.LabelX lblCutomerCode1;
    }
}