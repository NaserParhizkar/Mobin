using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    [Description("ایستگاه")]
    public class Station  : BaseEntity<int> 
    {

        [Required(ErrorMessage = "شماره ایستگاه نمی تواند خالی باشد")]
        [Display(Name = "شماره ی ایستگاه")]
        public int StationId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "لطفاً نام ایستگاه را وارد نمایید")]
        [Display(Name = "نام ایستگاه")]
        public string Name { get; set; }


        [Required(ErrorMessage = "لطفاً نوع ایستگاه را انتخاب نمایید")]
        [Display(Name = "نوع ایستگاه")]
        public StationType Type { get; set; }

        public virtual ICollection<PathDetail> PathDetails { get; set; }
    }
}