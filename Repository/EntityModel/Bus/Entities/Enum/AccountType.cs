using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KendoBus.Repository
{
    public enum AccountType
    {
        [Display(Name= "مدیر")]
        Manager,
        [Display(Name = "کارمند")]
        Employee,
        [Display(Name = "راننده")]
        Driver
    }
}