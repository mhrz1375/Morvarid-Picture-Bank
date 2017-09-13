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
    public partial class FRMFullScreenPics : DevExpress.XtraEditors.XtraForm
    {


        public FRMFullScreenPics()
        {
            InitializeComponent();
           

        }


      
       private void FRMFullScreenPics_FormClosing(object sender, EventArgs e)
        {
            CLS.SendPictureToFullScreen.lstTempPictures.Clear();
        }
        private void FRMFullScreenPics_Load(object sender, EventArgs e)
        {
            

             for (int i = 0; i < CLS.SendPictureToFullScreen.lstTempPictures.Count; ++i)
              {
                imgsldFullScreen.Images.Add(CLS.SendPictureToFullScreen.lstTempPictures[i]);
              }
          
        }
       

    }
}