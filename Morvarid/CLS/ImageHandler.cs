using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Morvarid.CLS
{
    class ImageHandler
    {


        public string ConnectionString= CLS.DBHandler.GetConnectionString();


    



        /// <summary>
        /// SPTDT===>SendPictureToDataTable()
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <returns DTPicture></returns>
        public DataTable DTPicture = new DataTable();
        public SqlDataAdapter DataAdapter = new SqlDataAdapter();
        //مقادیر جدول تصاویر را از بانک فراخوانی کرده و در داخل یک جدول داده ای قرار میدهد
        
        public DataTable SPTDT(string Query)
        {
            try
            {

                using (SqlConnection thisConnection = new SqlConnection(this.ConnectionString))
                {

                    using (SqlCommand SqlCommand = new SqlCommand(Query, thisConnection))
                    {

                        DTPicture.Clear();
                        thisConnection.Open();
                        DataAdapter.SelectCommand = SqlCommand;
                        DataAdapter.Fill(DTPicture);
                        thisConnection.Close();

                    }
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show("CLSImageHandler=>SendPictureToDataTable=>" + ec.Message);
            }
            return DTPicture;
        }

        /// <summary>
        /// BTI===>BinaryToImage()
        /// </summary>
        /// <param name="Binary"></param>
        /// <returns></returns>
        public Image BTI(byte[] Binary)
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
                MessageBox.Show("CLSImageHandler=>BinaryToImage=>" + ex.ToString());
            }
            return newImage;
        }

        /// <summary>
        /// IFP===>>ImageFromPath()
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Image IFP(string path)
        {
            Image img;
            try
            {
            img = Image.FromFile(path);

            }catch(Exception ex)
            {
                img = null;
                MessageBox.Show("CLSImageHandler=>ImageFromPath()=>" + ex.ToString());
            }
            return img ;
        }

       // The defualt new width and height for image.
        public int newPicWidth= 739, newPicHeight= 985;
        /// <summary>
        /// RI===>>ResizeImage()
        /// </summary>
        /// <param name="PicturePath"></param>
        /// <returns></returns>
        //Set new width and height for image.

        public Image RI(string PicturePath)
        {
            Image imgPhoto = null;
            Bitmap bmPhoto = null;
            try
            {
                imgPhoto = Image.FromFile(PicturePath);
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;

                //Consider vertical pics
                if (sourceWidth < sourceHeight)
                {
                    int buff = newPicWidth;

                    newPicWidth = newPicHeight;
                    newPicHeight = buff;
                }

                int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
                float nPercent = 0, nPercentW = 0, nPercentH = 0;

                nPercentW = ((float)newPicWidth / (float)sourceWidth);
                nPercentH = ((float)newPicHeight / (float)sourceHeight);
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = System.Convert.ToInt16((newPicWidth -
                              (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = System.Convert.ToInt16((newPicHeight -
                              (sourceHeight * nPercent)) / 2);
                }

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);


                bmPhoto = new Bitmap(newPicWidth, newPicHeight,
                              PixelFormat.Format24bppRgb);

                bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.Clear(Color.White);
                grPhoto.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();
                imgPhoto.Dispose();
                return bmPhoto;

            }
            catch (Exception ex)
            {
                MessageBox.Show("CLSImageHandler=>ResizeImage(path)=>" + ex);
            }

            return bmPhoto;

        }
        /// <summary>
        ///  RI===>>ResizeImage()
        /// </summary>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        //Set new width and height for image.
        public Image RI(int newWidth, int newHeight, Image image)
        {
            Image imgPhoto = null;
            Bitmap bmPhoto = null;
            try
            {
                imgPhoto = image;
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;

                //Consider vertical pics
                if (sourceWidth < sourceHeight)
                {
                    int buff = newWidth;

                    newWidth = newHeight;
                    newHeight = buff;
                }

                int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
                float nPercent = 0, nPercentW = 0, nPercentH = 0;

                nPercentW = ((float)newWidth / (float)sourceWidth);
                nPercentH = ((float)newHeight / (float)sourceHeight);
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = System.Convert.ToInt16((newWidth -
                              (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = System.Convert.ToInt16((newHeight -
                              (sourceHeight * nPercent)) / 2);
                }

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);


                bmPhoto = new Bitmap(newWidth, newHeight,
                              PixelFormat.Format24bppRgb);

                bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.Clear(Color.WhiteSmoke);
                grPhoto.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();
                imgPhoto.Dispose();
                return bmPhoto;

            }
            catch (Exception ex)
            {
                MessageBox.Show("CLSImageHandler=>ResizeImage(w,h,path)=>" + ex);
            }

            return bmPhoto;

        }

        /// <summary>
        /// ITB===>>ImageToBinary()
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        //Read the picture paths and converting to binary data for storing in database
        public byte[] ITB(string path)
        {
            Image img = null;
            img = IFP(path);
            if (img != null)
            {

                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();

            }
            return null;
        }
        /// <summary>
        /// ITB===>>ImageToBinary()
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        //Read the picture image type and converting to binary data for storing in database
        public byte[] ITB(Image img)
        {


            if (img != null)
            {

                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();

            }
            return null;
        }


        
    }
}


/*CLS.CLSPriceToStringClass PriceToString = new CLS.CLSPriceToStringClass();

        private List<int> lstPictureNumber = new List<int>();
        private List<Image> lstPictures = new List<Image>();
        private List<Image> lstTempPictures = new List<Image>();
        private List<string> lstStorePicturesAtDate = new List<string>();
        private List<string> lstPicturePaths = new List<string>();

        

        FRMAddCustomer AddCustomer = new FRMAddCustomer();
        DataTable CustomerDataTable = new DataTable();
        */