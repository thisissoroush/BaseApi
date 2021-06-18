using System;
using System.Globalization;

namespace FrameWork.Util.Date
{
    public static class DateModifier
    {
        public static string Date2Number(this DateTime date)
        {
            return date.ToString("yyyy/MM/dd").Replace("/", "");
        }
        public static string Date2Number(this string date)
        {
            date = (date.Trim().Split("/")[0].Length == 4) ? date : ReverseDate(date);
            return date.Replace("/", "");
        }
        public static string Number2Date(this string date)
        {
            return $"{date.Substring(0,4)}/{date.Substring(5,2)}/{date.Substring(8,2)}";
        }
        public static string ReverseDate(this string date)
        {
            string[] tmp = date.Trim().Split("/");
            return $"{tmp[2]}/{tmp[1]}/{tmp[0]}";

        }
        public static string Miladi2Shamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", 
                pc.GetYear(date),
                (pc.GetMonth(date).ToString().Length == 2) ? pc.GetMonth(date).ToString() : $"0{pc.GetMonth(date).ToString()}",
                (pc.GetDayOfMonth(date).ToString().Length == 2) ? pc.GetDayOfMonth(date).ToString() : $"0{pc.GetDayOfMonth(date).ToString()}");
        }
        public static string Miladi2Shamsi(this string date)
        {
            date = (date.Trim().Split("/")[0].Length == 4) ? ReverseDate(date) : date;
            string[] temp = date.Trim().Split("/");
            string GregorianDate = $"{temp[1]}/{temp[0]}/{temp[2]}";
            DateTime d = DateTime.Parse(GregorianDate);
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", 
                pc.GetYear(d), 
                (pc.GetMonth(d).ToString().Length == 2) ? pc.GetMonth(d).ToString() : $"0{pc.GetMonth(d).ToString()}",
                (pc.GetDayOfMonth(d).ToString().Length == 2) ? pc.GetDayOfMonth(d).ToString() : $"0{pc.GetDayOfMonth(d).ToString()}");
        }
        public static string Shamsi2Miladi(this DateTime date)
        {
            string[] tmp = date.ToString("yyyy/MM/dd").Split("/");
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(Convert.ToInt32(tmp[0]), Convert.ToInt32(tmp[1]), Convert.ToInt32(tmp[2]), pc);
            return dt.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        }
        public static string Shamsi2Miladi(this string date)
        {
            date = (date.Trim().Split("/")[0].Length == 4) ? date : ReverseDate(date);
            string[] tmp = date.Split("/");
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(Convert.ToInt32(tmp[0]), Convert.ToInt32(tmp[1]), Convert.ToInt32(tmp[2]), pc);
            return dt.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        }

    }
}
