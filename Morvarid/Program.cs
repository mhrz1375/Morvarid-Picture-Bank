using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data.SqlClient;

namespace Morvarid
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        public static bool IsServerConnected()
            {
            try
            {
             string ConnectionString = CLS.DBHandler.GetConnectionString();
using (var l_oConnection = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        l_oConnection.Open();
                        return true;
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(e.ToString());

                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            
            }
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new FRMSearchAndPrint());

            /*
                        if (IsServerConnected())
                        {
                            Application.Run(new FRMSearchAndPrint());
                        }
                        else
                        {
                            Application.Run(new FRMSetting());
                        }
                        */

        }
    }
}
