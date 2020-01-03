using System;
using System.Globalization;

namespace Mobin.Common
{
    public static class DateTimerExtender
    {
        public static string GetPersianDate(this DateTime dateTime, string format = "yyyy/MM/dd")
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int pYear, pMonth, pDay;

            pYear = persianCalendar.GetYear(dateTime);
            pMonth = persianCalendar.GetMonth(dateTime);
            pDay = persianCalendar.GetDayOfMonth(dateTime);

            return string.Format(format, pYear, pMonth, pDay);
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
