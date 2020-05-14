using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KendoBus.Repository
{
    [Description("اتوبوس")]
    public class Bus
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ID { get; set; }

        [Display(Name = "شماره ی اتوبوس")]
        [Required(ErrorMessage = "لطفاً شماره ی اتوبوس را وارد نمایید")]
        public int BusId { get; set; }

        [ScaffoldColumn(false)]
        [ForeignKey(nameof(Bus.Path))]
        [Required(ErrorMessage = "لطفاً مسیری را انتخاب نمایید")]
        public int PathID { get; set; }

        [ScaffoldColumn(false)]
        [ForeignKey(nameof(Bus.BusOwner))]
        [Required(ErrorMessage = "لطفاً مالک اتوبوسی را انتخاب نمایید")]
        public int BusOwnerID { get; set; }

        //[NotMapped]
        [Required(ErrorMessage = "لطفاً نوع اتوبوس را وارد نمایید")]
        [Display(Name = "نوع اتوبوس")]
        public BusType TypeOfBus { get; set; }

        [Display(Name = "ظرفیت اتوبوس")]
        [Required(ErrorMessage = "لطفاً ظرفیت اتوبوس را وارد نمایید")]
        public int Capacity { get; set; }

        [Display(Name = "قیمت اتوبوس")]
        [Required(ErrorMessage = "لطفاً قیمت اتوبوس را وارد نمایید")]
        public decimal? Price { get; set; }


        [Display(Name = "سال ساخت")]
        [Required(ErrorMessage = "لطفاً سال ساخت را وارد نمایید")]
        public DateTime MakeUpYear { get; set; }

        [Display(Name = "مسیر")]
        public virtual Path Path { get; set; }

        [Display(Name = "مالک اتوبوس")]
        public virtual BusOwner BusOwner { get; set; }

        public virtual ICollection<WorksOn> WorksOnBuses { get; set; }

    }
}