using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KendoBus.Repository
{
    public enum ShiftPeriod
    {
        [Description("بر حسب ماه")]
        PerMonth = 1,
        [Description("بر حسب روز")]
        PerDay = 2,
        [Description("بر حسب هفته")]
        PerWeek = 3,
        [Description("بر حسب")]
        PerCustomPeriod = 4
    }
}