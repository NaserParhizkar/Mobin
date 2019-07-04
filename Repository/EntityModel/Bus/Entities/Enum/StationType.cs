using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KendoBus.Repository
{
    public enum StationType
    {
        [Display(Name="بین راهی")]
        Street = 1,
        [Display(Name="ترمینالی")]
        Terminal = 2,
        [Display(Name="برونشهری")]
        CityOuter = 3
    }
}