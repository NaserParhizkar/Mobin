using System;
using System.Globalization;

namespace Mobin.Common
{
    public static class DateTimerExtender
    {
        public static string GetPersianDate(this DateTime dateTime, string format = "yyyy/MM/dd")
        {
            CultureInfo culture = new CultureInfo("fa-IR");
            return dateTime.ToString(format, culture);
        }

        public static string GetJavascriptPDate(this DateTime dateTime, string format = "yyyy/MM/dd")
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int pYear, pMonth, pDay;

            pYear = persianCalendar.GetYear(dateTime);
            pMonth = persianCalendar.GetMonth(dateTime);
            pDay = persianCalendar.GetDayOfMonth(dateTime);

            return $"new pDate(+(new Date({dateTime})))";
        }
    }
}
