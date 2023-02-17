using Mobin.Repository.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    [Description("مسیر")]
    public class Path : MobinBaseEntity<int>
    {
        [UIHint("Integer")]
        [Display(Name = "کد")]
        [Required(ErrorMessage = "لطفاً شماره ی شناسه ی مسیر را وارد نمایید")]
        public int PathId { get; set; }

        [UIHint("String")]
        [Display(Name = "نام مسیر")]
        [StringLength(300)]
        [Required(ErrorMessage = "لطفاً نام مسیر را به شکل صحیح وارد نمایید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفاً طول مسیر را وارد نمایید")]
        [UIHint("Integer")]
        [Display(Name = "طول (متر)")]
        public int Distance { get; set; }

        [UIHint("Currency")]
        [Required(ErrorMessage = "لطفاً کرایه مسیر را وارد نمایید")]
        [Display(Name = "کرایه")]
        public decimal Rent
        {
            get;
            set;
        }


        public virtual ICollection<PathDetail> PathDetails { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
    }
}