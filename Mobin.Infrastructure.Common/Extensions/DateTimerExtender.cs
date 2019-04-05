using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

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

        public static string GetJavascriptPDateType(this DateTime dateTime, string format = "yyyy/MM/dd")
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int pYear, pMonth, pDay;

            pYear = persianCalendar.GetYear(dateTime);
            pMonth = persianCalendar.GetMonth(dateTime);
            pDay = persianCalendar.GetDayOfMonth(dateTime);

            return $"new pDate({pYear},{pMonth},{pDay})";
        }
    }
}
