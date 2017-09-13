using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Morvarid.CLS
{
    class ProgressSavePictures
    {
        private static Thread th = new Thread(new ThreadStart(showProgressForm));
        public void startProgress()
        {
            th = new Thread(new ThreadStart(showProgressForm));
            th.Name = "first";
            th.Start();
        }

        private static void showProgressForm()
        {
           /* frmProgress sForm = new frmProgress();
            sForm.ShowDialog();*/
        }

        public void stopProgress()
        {
            th.Abort();
            th = null;
        }
    }
}
