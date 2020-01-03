using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    [Description("مدیر")]
    public class Manager : Employee
    {
        [Display(Name = "تاریخ شروع مدیریت")]
        public DateTime ManagerDate { get; set; }
    }
}