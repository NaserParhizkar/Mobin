using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KendoBus.Repository
{
    public enum BusType
    {
        [Display(Name="تندرو")]
        BRT = 1,
        [Display(Name="برقی")]
        Electricy = 2,
        [Display(Name="برونشهری")]
        OutOfCity = 3,
        [Display(Name="معمولی")]
        Ordinary = 4
    }
}