using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Morvarid.CLS;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;

namespace Morvarid
{
    public partial class FRMSetting : DevExpress.XtraEditors.XtraForm
    {
        public FRMSetting()
        {
            InitializeComponent();


        }

        //enumeration constructs specify textbox indices




        private StreamWriter FileWriter;
        OpenFileDialog choofdlog = new OpenFileDialog();

        string FileName = Application.StartupPath + "\\ConnctionFile.txt";
        private void sbtnOpenFile_Click(object sender, EventArgs e)
        {
            string selectedPath = "";
            var t = new Thread((ThreadStart)(() =>
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "Select MorvariDB.mdf File (*.mdf*)|*.mdf*";
                if (choofdlog.ShowDialog() == DialogResult.Cancel)
                    return;

                selectedPath = choofdlog.FileName;
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            txtboxDataBasePath.Text = selectedPath;
        }


        TestDataBaseConnection databasePath = new TestDataBaseConnection();
        TestDataBaseConnection photoshopPath = new TestDataBaseConnection();
        TestDataBaseConnection tempofimages = new TestDataBaseConnection();

        private void sbtnTestConnection_Click(object sender, EventArgs e)
        {

            if (IsServerConnected())
            {
                MessageBox.Show("conncted");
            }
        }



        private void sbtnCreateDataBase_Click(object sender, EventArgs e)
        {
            string s = databasePath.ReadDataBasePathFromFile();
            MessageBox.Show(s);
        }

        public string ConnectionString = CLS.DBHandler.GetConnectionString();

        public bool IsServerConnected()
        {
            try
            {
                using (var l_oConnection = new SqlConnection(ConnectionString))
                {

                    l_oConnection.Open();
                    return true;

                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());

                return false;
            }
        }

        private void FRMSetting_Load(object sender, EventArgs e)
        {
            txtboxPhotoshopPath.Text = photoshopPath.ReadPhotoshopPathFromFile();
            txtboxDataBasePath.Text = databasePath.ReadDataBasePathFromFile();
            txtboxTempOfImagespath.Text = tempofimages.ReadTempOfImagesPathFromFile();
        }

        private void sbtnApplay_Click(object sender, EventArgs e)
        {
            databasePath.SetDataBasePath(txtboxDataBasePath.Text);
            photoshopPath.SetPhotoshopPath(txtboxPhotoshopPath.Text);
            tempofimages.SetTempOfImagesPath(txtboxTempOfImagespath.Text);

        }

        private void sbtnSaveSettingAndRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void sbtnSetPhotoshopPath_Click(object sender, EventArgs e)
        {
            string selectedPath = "";
            var t = new Thread((ThreadStart)(() =>
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "Select Photoshop.exe File (*.exe*)|*.exe*";
                if (choofdlog.ShowDialog() == DialogResult.Cancel)
                    return;

                selectedPath = choofdlog.FileName;
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            txtboxPhotoshopPath.Text = selectedPath;
        }

        private void sbtnTestOpennigPhotoshop_Click(object sender, EventArgs e)
        {
            try
            {
                Process PhotoShop = new Process();

                PhotoShop.StartInfo.FileName = photoshopPath.ReadPhotoshopPathFromFile();

                PhotoShop.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void sbtnSetTempOfImagePath_Click(object sender, EventArgs e)
        {
            string selectedPath="";
            var t = new Thread((ThreadStart)(() => {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                    return;

                selectedPath = fbd.SelectedPath;
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            txtboxTempOfImagespath.Text = selectedPath;
        }
    }
}