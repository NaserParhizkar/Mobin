using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    [Description("راننده")]
    public class Driver : Person
    {
        public int DrvID { get; set; }

        [Display(Name = "تاریخ استخدام")]
        [Required(ErrorMessage = "لطفا تاریخ استخدام را وارد نمایید")]
        public DateTime EmploymentDate { get; set; }

        public virtual ICollection<WorksOn> WorksOn { get; set; }
    }
}