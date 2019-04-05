using System;
using System.Collections.Generic;
using System.Text;

namespace Mobin.Common
{
    public struct PersianDateTime
    {
        public PersianDateTime(int persianYear,int persianMonth,int persianDay)
        {
            //System.Globalization.CultureInfo.CurrentCulture.
        }

        public static string Now { get { return (new DateTime()).GetPersianDate(); } }
    }
}
