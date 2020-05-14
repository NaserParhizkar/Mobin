using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    [Description("کارمند")]
    public class Employee : Person
    {
        [Display(Name = "کد کارمند")]
        [Required(ErrorMessage = "لطفاً کد کارمند وارد نمایید")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "لطفاً تاریخ استخدام وارد نمایید")]
        [Display(Name = "تاریخ استخدام")]
        public DateTime EmploymentDate { get; set; }

        public virtual ICollection<News> RegistersNews { get; set; }
    }
}