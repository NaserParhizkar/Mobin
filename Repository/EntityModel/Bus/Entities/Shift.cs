using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    [Description("نوبت")]
    public class Shift
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ID { get; set; }

        [DisplayName("کد شیفت")]
        [Required(ErrorMessage="لطفاً کد شیفت را وارد نمایید")]
        public int ShiftId { get; set; }

        [DisplayName("ساعت شروع")]
        [Required(ErrorMessage = "لطفاً ساعت شروع را وارد نمایید")]
        public DateTime BeginTime { get; set; }
        
        [DisplayName("ساعت پایان")]
        [Required(ErrorMessage = "لطفاً ساعت پایان را وارد نمایید")]
        public DateTime EndTime { get; set; }

        [DisplayName("نوع شیفت")]
        [Required(ErrorMessage = "لطفاً نوع شیفت را وارد نمایید")]
        public ShiftType ShiftType
        {
            get;
            set;
        }
        public virtual ICollection<WorksOn> WorksOnShift { get; set; }
    }

    public enum ShiftType
    {
        [Display(Name = "صبح")]
        Morning = 1,
        [Display(Name = "بعدازظهر")]
        Afternoon = 2
    }
}