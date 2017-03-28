using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Morvarid.CLS
{
    class CLSGetShamsiDate
    {

        private String DayName;
        private String MonthName;
        private String CompleteShamsiDate;
        private String ShamsiDate;
        public static string ToDay;
        DateTime dt = DateTime.Now;

        public CLSGetShamsiDate()
        {
            if (dt.DayOfWeek == DayOfWeek.Friday)
                DayName = "جمعه";
            if (dt.DayOfWeek == DayOfWeek.Saturday)
                DayName = "شنبه";
            if (dt.DayOfWeek == DayOfWeek.Sunday)
                DayName = "یکشنبه";
            if (dt.DayOfWeek == DayOfWeek.Monday)
                DayName = "دوشنبه";
            if (dt.DayOfWeek == DayOfWeek.Tuesday)
                DayName = "سه شنبه";
            if (dt.DayOfWeek == DayOfWeek.Wednesday)
                DayName = "چهار شنبه";
            if (dt.DayOfWeek == DayOfWeek.Thursday)
                DayName = "پنج شنبه";

            PersianCalendar pt = new PersianCalendar();
            int MoName = pt.GetMonth(dt);

            switch (MoName)
            {
                case 1:
                    MonthName = "فروردین";
                    break;
                case 2:
                    MonthName = "اردیبهشت";
                    break;
                case 3:
                    MonthName = "خرداد";
                    break;
                case 4:
                    MonthName = "تیر";
                    break;
                case 5:
                    MonthName = "مرداد";
                    break;
                case 6:
                    MonthName = "شهریور";
                    break;
                case 7:
                    MonthName = "مهر";
                    break;
                case 8:
                    MonthName = "آبان";
                    break;
                case 9:
                    MonthName = "آذر";
                    break;
                case 10:
                    MonthName = "دی";
                    break;
                case 11:
                    MonthName = "بهمن";
                    break;
                case 12:
                    MonthName = "اسفند";
                    break;
            }
            ShamsiDate = pt.GetYear(dt) + "/" + pt.GetMonth(dt) + "/" + pt.GetDayOfMonth(dt);
            ToDay = ShamsiDate;
            CompleteShamsiDate = DayName + " " + pt.GetDayOfMonth(dt) +
            " " + MonthName + " " + pt.GetYear(dt);
        }
        public String CRShamsiDate
        {
            
            get
            {
                return ShamsiDate;
            }
            set
            {
                ShamsiDate = value;
            }
        }
        public String CRDaysName
        {
            
            get
            {
                return DayName;
            }
            set
            {
                DayName = value;
            }
        }

        public String CRMotheName
        {
            
            get
            {
                return MonthName;
            }
            set
            {
                MonthName = value;
            }
        }

        public String CRCompleteShamsiDate
        {
            
            get
            {
                return CompleteShamsiDate;
            }
            set
            {
                CompleteShamsiDate = value;
            }
        }
    }
}
