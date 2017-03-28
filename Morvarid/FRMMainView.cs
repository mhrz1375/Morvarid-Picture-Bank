using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Morvarid
{
    public partial class FRMMainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Morvarid.CLS.CLSGetShamsiDate ToDay = new Morvarid.CLS.CLSGetShamsiDate();
        FRMAddCustomer AddCustomer = new FRMAddCustomer();
        FRMCustomerList CustomerList = new FRMCustomerList();




        public FRMMainView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();

        }
        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<CLSMainViewModel>();
        }
        private void MainView_Load(object sender, EventArgs e)
        {
            //  ChangeLanguage();
            // labelControl1.Text = ToDay.CRCompleteShamsiDate.ToString();
            //   MessageBox.Show(ToDay.CRShamsiDate.ToString());
        }
        private InputLanguage GetFarsiLanguage()
        {
            //Enumerate through InstalledInputLanguages which contains
            //all the keyboard layout you’ve installed in your windows.
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.LayoutName.ToLower() == "persian")
                    return lang;
            }

            return null;
        }

        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                AddCustomer.ShowDialog();

            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.C))
            {
                AddCustomer.ShowDialog();
                return true;
            }
            else if (keyData == (Keys.Shift | Keys.C))
            {
                CustomerList.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void ChangeLanguage()
        {
            InputLanguage lang = GetFarsiLanguage();

            if (lang == null)
                throw new NotSupportedException("Farsi Language keyboard is not installed.");

            //Set the current language of the system to
            //the InputLanguage instance you need.
            InputLanguage.CurrentInputLanguage = lang;
        }


        private void barBtnAddCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddCustomer.Text = "ثبت مشتری";
            AddCustomer.ShowDialog();
        }

        private void barBtnAllCustomers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomerList.ShowDialog();

        }
    }
}