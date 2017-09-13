namespace Morvarid
{
    partial class FRMSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMSetting));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xpgDataBase = new DevExpress.XtraTab.XtraTabPage();
            this.sbtnApplay = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnSaveSettingAndRestart = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCreateDataBase = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnTestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnOpenFile = new DevExpress.XtraEditors.SimpleButton();
            this.txtboxDataBasePath = new System.Windows.Forms.TextBox();
            this.lblSetDataBasePath = new DevExpress.XtraEditors.LabelControl();
            this.xtabExternalApps = new DevExpress.XtraTab.XtraTabPage();
            this.sbtnTestOpennigPhotoshop = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnSetPhotoshopPath = new DevExpress.XtraEditors.SimpleButton();
            this.txtboxPhotoshopPath = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sbtnSetTempOfImagePath = new DevExpress.XtraEditors.SimpleButton();
            this.txtboxTempOfImagespath = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xpgDataBase.SuspendLayout();
            this.xtabExternalApps.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.xtraTabControl1.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.PageClient.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.xtraTabControl1.AppearancePage.PageClient.Options.UseFont = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xtraTabControl1.SelectedTabPage = this.xpgDataBase;
            this.xtraTabControl1.Size = new System.Drawing.Size(472, 518);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xpgDataBase,
            this.xtabExternalApps});
            // 
            // xpgDataBase
            // 
            this.xpgDataBase.Controls.Add(this.sbtnCreateDataBase);
            this.xpgDataBase.Controls.Add(this.sbtnTestConnection);
            this.xpgDataBase.Controls.Add(this.sbtnOpenFile);
            this.xpgDataBase.Controls.Add(this.txtboxDataBasePath);
            this.xpgDataBase.Controls.Add(this.lblSetDataBasePath);
            this.xpgDataBase.Name = "xpgDataBase";
            this.xpgDataBase.Size = new System.Drawing.Size(465, 471);
            this.xpgDataBase.Text = "بانک اطلاعاتی";
            // 
            // sbtnApplay
            // 
            this.sbtnApplay.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.sbtnApplay.Appearance.Options.UseFont = true;
            this.sbtnApplay.Location = new System.Drawing.Point(267, 524);
            this.sbtnApplay.Name = "sbtnApplay";
            this.sbtnApplay.Size = new System.Drawing.Size(184, 37);
            this.sbtnApplay.TabIndex = 6;
            this.sbtnApplay.Text = "اعمال تنظیمات";
            this.sbtnApplay.Click += new System.EventHandler(this.sbtnApplay_Click);
            // 
            // sbtnSaveSettingAndRestart
            // 
            this.sbtnSaveSettingAndRestart.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.sbtnSaveSettingAndRestart.Appearance.Options.UseFont = true;
            this.sbtnSaveSettingAndRestart.Location = new System.Drawing.Point(12, 524);
            this.sbtnSaveSettingAndRestart.Name = "sbtnSaveSettingAndRestart";
            this.sbtnSaveSettingAndRestart.Size = new System.Drawing.Size(184, 37);
            this.sbtnSaveSettingAndRestart.TabIndex = 5;
            this.sbtnSaveSettingAndRestart.Text = "ذخیره تنظیمات";
            this.sbtnSaveSettingAndRestart.Click += new System.EventHandler(this.sbtnSaveSettingAndRestart_Click);
            // 
            // sbtnCreateDataBase
            // 
            this.sbtnCreateDataBase.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.sbtnCreateDataBase.Appearance.Options.UseFont = true;
            this.sbtnCreateDataBase.Location = new System.Drawing.Point(46, 89);
            this.sbtnCreateDataBase.Name = "sbtnCreateDataBase";
            this.sbtnCreateDataBase.Size = new System.Drawing.Size(184, 37);
            this.sbtnCreateDataBase.TabIndex = 4;
            this.sbtnCreateDataBase.Text = "ایحاد بانک اطلاعاتی جدید";
            this.sbtnCreateDataBase.Click += new System.EventHandler(this.sbtnCreateDataBase_Click);
            // 
            // sbtnTestConnection
            // 
            this.sbtnTestConnection.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.sbtnTestConnection.Appearance.Options.UseFont = true;
            this.sbtnTestConnection.Location = new System.Drawing.Point(236, 89);
            this.sbtnTestConnection.Name = "sbtnTestConnection";
            this.sbtnTestConnection.Size = new System.Drawing.Size(184, 37);
            this.sbtnTestConnection.TabIndex = 3;
            this.sbtnTestConnection.Text = "تست اتصال بانک";
            this.sbtnTestConnection.Click += new System.EventHandler(this.sbtnTestConnection_Click);
            // 
            // sbtnOpenFile
            // 
            this.sbtnOpenFile.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.sbtnOpenFile.Appearance.Options.UseFont = true;
            this.sbtnOpenFile.Location = new System.Drawing.Point(11, 23);
            this.sbtnOpenFile.Name = "sbtnOpenFile";
            this.sbtnOpenFile.Size = new System.Drawing.Size(46, 37);
            this.sbtnOpenFile.TabIndex = 2;
            this.sbtnOpenFile.Text = "...";
            this.sbtnOpenFile.Click += new System.EventHandler(this.sbtnOpenFile_Click);
            // 
            // txtboxDataBasePath
            // 
            this.txtboxDataBasePath.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.txtboxDataBasePath.Location = new System.Drawing.Point(63, 23);
            this.txtboxDataBasePath.Name = "txtboxDataBasePath";
            this.txtboxDataBasePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtboxDataBasePath.Size = new System.Drawing.Size(248, 37);
            this.txtboxDataBasePath.TabIndex = 1;
            // 
            // lblSetDataBasePath
            // 
            this.lblSetDataBasePath.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.lblSetDataBasePath.Appearance.Options.UseFont = true;
            this.lblSetDataBasePath.Location = new System.Drawing.Point(328, 23);
            this.lblSetDataBasePath.Name = "lblSetDataBasePath";
            this.lblSetDataBasePath.Size = new System.Drawing.Size(122, 29);
            this.lblSetDataBasePath.TabIndex = 0;
            this.lblSetDataBasePath.Text = "مسیر بانک اطلاعاتی";
            // 
            // xtabExternalApps
            // 
            this.xtabExternalApps.Controls.Add(this.sbtnSetTempOfImagePath);
            this.xtabExternalApps.Controls.Add(this.txtboxTempOfImagespath);
            this.xtabExternalApps.Controls.Add(this.labelControl2);
            this.xtabExternalApps.Controls.Add(this.sbtnTestOpennigPhotoshop);
            this.xtabExternalApps.Controls.Add(this.sbtnSetPhotoshopPath);
            this.xtabExternalApps.Controls.Add(this.txtboxPhotoshopPath);
            this.xtabExternalApps.Controls.Add(this.labelControl1);
            this.xtabExternalApps.Name = "xtabExternalApps";
            this.xtabExternalApps.Size = new System.Drawing.Size(465, 471);
            this.xtabExternalApps.Text = "برنامه های خارجی";
            // 
            // sbtnTestOpennigPhotoshop
            // 
            this.sbtnTestOpennigPhotoshop.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.sbtnTestOpennigPhotoshop.Appearance.Options.UseFont = true;
            this.sbtnTestOpennigPhotoshop.Location = new System.Drawing.Point(136, 74);
            this.sbtnTestOpennigPhotoshop.Name = "sbtnTestOpennigPhotoshop";
            this.sbtnTestOpennigPhotoshop.Size = new System.Drawing.Size(184, 37);
            this.sbtnTestOpennigPhotoshop.TabIndex = 8;
            this.sbtnTestOpennigPhotoshop.Text = "تست اتصال فتوشاپ";
            this.sbtnTestOpennigPhotoshop.Click += new System.EventHandler(this.sbtnTestOpennigPhotoshop_Click);
            // 
            // sbtnSetPhotoshopPath
            // 
            this.sbtnSetPhotoshopPath.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.sbtnSetPhotoshopPath.Appearance.Options.UseFont = true;
            this.sbtnSetPhotoshopPath.Location = new System.Drawing.Point(20, 20);
            this.sbtnSetPhotoshopPath.Name = "sbtnSetPhotoshopPath";
            this.sbtnSetPhotoshopPath.Size = new System.Drawing.Size(46, 37);
            this.sbtnSetPhotoshopPath.TabIndex = 7;
            this.sbtnSetPhotoshopPath.Text = "...";
            this.sbtnSetPhotoshopPath.Click += new System.EventHandler(this.sbtnSetPhotoshopPath_Click);
            // 
            // txtboxPhotoshopPath
            // 
            this.txtboxPhotoshopPath.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.txtboxPhotoshopPath.Location = new System.Drawing.Point(72, 20);
            this.txtboxPhotoshopPath.Name = "txtboxPhotoshopPath";
            this.txtboxPhotoshopPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtboxPhotoshopPath.Size = new System.Drawing.Size(248, 37);
            this.txtboxPhotoshopPath.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(327, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 29);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "مسیر فتوشاپ";
            // 
            // sbtnSetTempOfImagePath
            // 
            this.sbtnSetTempOfImagePath.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.sbtnSetTempOfImagePath.Appearance.Options.UseFont = true;
            this.sbtnSetTempOfImagePath.Location = new System.Drawing.Point(20, 131);
            this.sbtnSetTempOfImagePath.Name = "sbtnSetTempOfImagePath";
            this.sbtnSetTempOfImagePath.Size = new System.Drawing.Size(46, 37);
            this.sbtnSetTempOfImagePath.TabIndex = 11;
            this.sbtnSetTempOfImagePath.Text = "...";
            this.sbtnSetTempOfImagePath.Click += new System.EventHandler(this.sbtnSetTempOfImagePath_Click);
            // 
            // txtboxTempOfImagespath
            // 
            this.txtboxTempOfImagespath.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.txtboxTempOfImagespath.Location = new System.Drawing.Point(72, 131);
            this.txtboxTempOfImagespath.Name = "txtboxTempOfImagespath";
            this.txtboxTempOfImagespath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtboxTempOfImagespath.Size = new System.Drawing.Size(248, 37);
            this.txtboxTempOfImagespath.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(327, 131);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(123, 29);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "مسیر فایلهای اضافی";
            // 
            // FRMSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 573);
            this.Controls.Add(this.sbtnApplay);
            this.Controls.Add(this.sbtnSaveSettingAndRestart);
            this.Controls.Add(this.xtraTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 620);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 620);
            this.Name = "FRMSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات";
            this.Load += new System.EventHandler(this.FRMSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xpgDataBase.ResumeLayout(false);
            this.xpgDataBase.PerformLayout();
            this.xtabExternalApps.ResumeLayout(false);
            this.xtabExternalApps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xpgDataBase;
        private DevExpress.XtraEditors.SimpleButton sbtnCreateDataBase;
        private DevExpress.XtraEditors.SimpleButton sbtnTestConnection;
        private DevExpress.XtraEditors.SimpleButton sbtnOpenFile;
        private System.Windows.Forms.TextBox txtboxDataBasePath;
        private DevExpress.XtraEditors.LabelControl lblSetDataBasePath;
        private DevExpress.XtraEditors.SimpleButton sbtnSaveSettingAndRestart;
        private DevExpress.XtraEditors.SimpleButton sbtnApplay;
        private DevExpress.XtraTab.XtraTabPage xtabExternalApps;
        private DevExpress.XtraEditors.SimpleButton sbtnTestOpennigPhotoshop;
        private DevExpress.XtraEditors.SimpleButton sbtnSetPhotoshopPath;
        private System.Windows.Forms.TextBox txtboxPhotoshopPath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sbtnSetTempOfImagePath;
        private System.Windows.Forms.TextBox txtboxTempOfImagespath;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}