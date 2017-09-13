using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Morvarid.CLS
{
    class SendPictureToFullScreen
    {
        public static List<Image> lstTempPictures = new List<Image>();

        public string SCC;
        public string SPN;

        //    PictureCount= lstTempPictures.Count;
        CLS.ImageHandler ImageHandler = new CLS.ImageHandler();
        public void StartSendPicturesToFullScreen()
        {
        string qry = CLS.DBHandler.GetCustomerPicturesQuery(SCC);
        RetrievePicture(ImageHandler.SPTDT(qry));
        }

        public void StartSendOnePitureToFullScreen()
        {
            string qry = CLS.DBHandler.GetCustomerSelectedPicturesQuery(SCC,SPN);
            RetrievePicture(ImageHandler.SPTDT(qry));
        }
        
        public void RetrievePicture(DataTable DTStorePicture)
        {


            foreach (DataRow ROW in DTStorePicture.Rows)
            {

                lstTempPictures.Add(ImageHandler.BTI(ROW.Field<byte[]>(1)));
            }

        }

    }
}
