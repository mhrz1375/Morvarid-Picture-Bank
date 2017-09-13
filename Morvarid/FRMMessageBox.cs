using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Morvarid
{
    public partial class FRMMessageBox : DevExpress.XtraEditors.XtraForm
    {
        public FRMMessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// setMessage method is used to display message
        /// on form and it's height adjust automatically.
        /// I am displaying message in a Label control.
        /// </summary>
        /// <param name="messageText">Message which needs to be displayed to user.</param>
        private void setMessage(string MessageTitleText, string MessageText)
        {
            int number = Math.Abs(MessageText.Length / 30);
            if (number != 0)
                this.lblMessageText.Height = number * 25;
            this.lblTitleMessageText.Text = MessageText;
            this.lblMessageText.Text = MessageTitleText;

        }

        /// <summary>
        /// This method is used to add button on message box.
        /// </summary>
        /// <param name="MessageButton">MessageButton is type of enumMessageButton
        /// through which I get type of button which needs to be displayed.</param>
        private void addButton(enumMessageButton MessageButton)
        {
            switch (MessageButton)
            {
                case enumMessageButton.OK:
                    {
                        //If type of enumButton is OK then we add OK button only.
                        SimpleButton btnOk = new SimpleButton();  //Create object of Button.
                        btnOk.Text = "تایید";  //Here we set text of Button.
                        btnOk.DialogResult = DialogResult.OK;      //Set DialogResult 
                        btnOk.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

                        btnOk.SetBounds(pnlMessageButton.ClientSize.Width - 260, 8, 100, 40);  // Set bounds of button.
                        pnlMessageButton.Controls.Add(btnOk);  //Finally Add button control
                                                               // on panel.
                    }
                    break;
                case enumMessageButton.OKCancel:
                    {
                        SimpleButton btnOk = new SimpleButton();
                        btnOk.Text = "تایید";
                        btnOk.DialogResult = DialogResult.OK;
                        btnOk.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

                        btnOk.SetBounds(pnlMessageButton.ClientSize.Width - 220, 8, 100, 40);  // Set bounds of button.
                        pnlMessageButton.Controls.Add(btnOk);

                        SimpleButton btnCancel = new SimpleButton();
                        btnCancel.Text = "لغو";
                        btnCancel.DialogResult = DialogResult.Cancel;
                        btnCancel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

                        btnCancel.SetBounds(pnlMessageButton.ClientSize.Width - 328, 8, 100, 40);  // Set bounds of button.
                        pnlMessageButton.Controls.Add(btnCancel);

                    }
                    break;
                case enumMessageButton.YesNo:
                    {
                        SimpleButton btnNo = new SimpleButton();
                        btnNo.Text = "خیر";
                        btnNo.DialogResult = DialogResult.No;
                        btnNo.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

                        btnNo.SetBounds(pnlMessageButton.ClientSize.Width - 328, 8, 100, 40);  // Set bounds of button.
                        pnlMessageButton.Controls.Add(btnNo);

                        SimpleButton btnYes = new SimpleButton();
                        btnYes.Text = "بله";
                        btnYes.DialogResult = DialogResult.Yes;
                        btnYes.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

                        btnYes.SetBounds(pnlMessageButton.ClientSize.Width - 220, 8, 100, 40);  // Set bounds of button.
                        pnlMessageButton.Controls.Add(btnYes);
                    }
                    break;
                case enumMessageButton.YesNoCancel:
                    {
                        SimpleButton btnYes = new SimpleButton();
                        btnYes.Text = "بله";
                        btnYes.DialogResult = DialogResult.Yes;
                        btnYes.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

                        btnYes.SetBounds(pnlMessageButton.ClientSize.Width - 155, 8, 100, 40);  // Set bounds of button.
                        pnlMessageButton.Controls.Add(btnYes);

                        SimpleButton btnNo = new SimpleButton();
                        btnNo.Text = "خیر";
                        btnNo.DialogResult = DialogResult.No;
                        btnNo.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

                        btnNo.SetBounds(pnlMessageButton.ClientSize.Width - 263, 8, 100, 40);  // Set bounds of button.
                        pnlMessageButton.Controls.Add(btnNo);

                        SimpleButton btnCancel = new SimpleButton();
                        btnCancel.Text = "لغو";
                        btnCancel.DialogResult = DialogResult.Cancel;
                        btnCancel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

                        btnCancel.SetBounds(pnlMessageButton.ClientSize.Width - 371, 8, 100, 40);  // Set bounds of button.
                        pnlMessageButton.Controls.Add(btnCancel);

                    }
                    break;
            }
        }

        /// <summary>
        /// We can use this method to add image on message box.
        /// I had taken all images in ImageList control so that
        /// I can easily add images. Image is displayed in 
        /// PictureBox control.
        /// </summary>
        /// <param name="MessageIcon">Type of image to be displayed.</param>
        private void addIconImage(enumMessageIcon MessageIcon)
        {
            switch (MessageIcon)
            {
                case enumMessageIcon.Error:
                    pbAlertMessage.Image = imageList1.Images["Information"];  //Error is key 
                                                                              //name in imagelist control which uniquely identified images 
                                                                              //in ImageList control.
                    break;
                case enumMessageIcon.Information:
                    pbAlertMessage.Image = imageList1.Images["Information"];
                    break;
                case enumMessageIcon.Question:
                    pbAlertMessage.Image = imageList1.Images["Information"];
                    break;
                case enumMessageIcon.Warning:
                    pbAlertMessage.Image = imageList1.Images["Information"];
                    break;
            }
        }

        #region Overloaded Show message to display message box.

        /// <summary>
        /// Show method is overloaded which is used to display message
        /// and this is static method so that we don't need to create 
        /// object of this class to call this method.
        /// </summary>
        /// <param name="messageText"></param>
        internal static DialogResult Show(string MessageTitleText, string MessageText)
        {
            FRMMessageBox frmMessage = new FRMMessageBox();
            frmMessage.setMessage(MessageTitleText, MessageText);
            frmMessage.addIconImage(enumMessageIcon.Information);
            frmMessage.addButton(enumMessageButton.OK);
            frmMessage.ShowDialog();
            DialogResult dialog = frmMessage.ShowDialog();

            return dialog;
        }

        internal static DialogResult Show(string CaptionForm, string TitleMessage, string MessageText)
        {
            FRMMessageBox frmMessage = new FRMMessageBox();
            frmMessage.Text = CaptionForm;
            frmMessage.setMessage(MessageText,TitleMessage);
            frmMessage.addIconImage(enumMessageIcon.Information);
            frmMessage.addButton(enumMessageButton.OK);
            frmMessage.ShowDialog();
            DialogResult dialog = frmMessage.ShowDialog();

            return dialog;
        }

        internal static DialogResult Show(string CaptionForm, string TitleMessage, string MessageText,
        enumMessageIcon messageIcon, enumMessageButton messageButton)
        {
            FRMMessageBox frmMessage = new FRMMessageBox();
            frmMessage.setMessage( MessageText,TitleMessage);
            frmMessage.Text = CaptionForm;
            frmMessage.addIconImage(messageIcon);
            frmMessage.addButton(messageButton);
            DialogResult dialog = frmMessage.ShowDialog();

            return dialog;
        }

        #endregion
    }

    #region constant defined in form of enumeration which is used in showMessage class.

    internal enum enumMessageIcon
    {
        Error,
        Warning,
        Information,
        Question,
    }

    internal enum enumMessageButton
    {
        OK,
        YesNo,
        YesNoCancel,
        OKCancel
    }

    #endregion
}
