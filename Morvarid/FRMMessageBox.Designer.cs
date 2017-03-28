namespace Morvarid
{
    partial class FRMMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMMessageBox));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlMessageButton = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblTitleMessageText = new DevComponents.DotNetBar.LabelX();
            this.lblMessageText = new DevComponents.DotNetBar.LabelX();
            this.pbAlertMessage = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessageButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlertMessage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlMessageButton
            // 
            this.pnlMessageButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessageButton.Location = new System.Drawing.Point(0, 152);
            this.pnlMessageButton.Name = "pnlMessageButton";
            this.pnlMessageButton.Size = new System.Drawing.Size(424, 54);
            this.pnlMessageButton.TabIndex = 7;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblTitleMessageText);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(424, 54);
            this.panelControl1.TabIndex = 10;
            // 
            // lblTitleMessageText
            // 
            // 
            // 
            // 
            this.lblTitleMessageText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTitleMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleMessageText.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitleMessageText.Location = new System.Drawing.Point(2, 2);
            this.lblTitleMessageText.Name = "lblTitleMessageText";
            this.lblTitleMessageText.Size = new System.Drawing.Size(420, 50);
            this.lblTitleMessageText.TabIndex = 0;
            this.lblTitleMessageText.Text = "عنوان";
            this.lblTitleMessageText.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblMessageText
            // 
            // 
            // 
            // 
            this.lblMessageText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMessageText.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMessageText.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMessageText.Location = new System.Drawing.Point(0, 54);
            this.lblMessageText.Margin = new System.Windows.Forms.Padding(5);
            this.lblMessageText.Name = "lblMessageText";
            this.lblMessageText.PaddingBottom = 10;
            this.lblMessageText.PaddingLeft = 10;
            this.lblMessageText.PaddingRight = 10;
            this.lblMessageText.PaddingTop = 10;
            this.lblMessageText.Size = new System.Drawing.Size(303, 98);
            this.lblMessageText.TabIndex = 11;
            this.lblMessageText.Text = "متن پیام";
            this.lblMessageText.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblMessageText.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.lblMessageText.WordWrap = true;
            // 
            // pbAlertMessage
            // 
            this.pbAlertMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbAlertMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbAlertMessage.EditValue = ((object)(resources.GetObject("pbAlertMessage.EditValue")));
            this.pbAlertMessage.Location = new System.Drawing.Point(303, 54);
            this.pbAlertMessage.Name = "pbAlertMessage";
            this.pbAlertMessage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbAlertMessage.Properties.Appearance.Options.UseBackColor = true;
            this.pbAlertMessage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbAlertMessage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbAlertMessage.Properties.ZoomAccelerationFactor = 1D;
            this.pbAlertMessage.Size = new System.Drawing.Size(121, 98);
            this.pbAlertMessage.TabIndex = 12;
            // 
            // frmMessageBox
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 206);
            this.Controls.Add(this.pbAlertMessage);
            this.Controls.Add(this.lblMessageText);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlMessageButton);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWarningPictureExsist";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessageButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAlertMessage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.PanelControl pnlMessageButton;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevComponents.DotNetBar.LabelX lblTitleMessageText;
        private DevComponents.DotNetBar.LabelX lblMessageText;
        private DevExpress.XtraEditors.PictureEdit pbAlertMessage;
    }
}