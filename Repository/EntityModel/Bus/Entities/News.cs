using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    [Description("اخبار")]
    public class News
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage="لطفاً کد خبر را وارد نمایید."),Display(Name="کد")]
        public int NewsId { get; set; }

        [Required(ErrorMessage = "لطفاً عنوان خبر را وارد نمایید."), 
        Display(Name = "عنوان خبر")]
        public string Title { get; set; }

        [Required(ErrorMessage = "لطفاً تاریخ خبر را وارد نمایید."), Display(Name = "تاریخ خبر")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage="لطفاً متن خبر را وارد نمایید."),Display(Name = "متن خبر")]
        public string Text { get; set; }

        [Required]
        public virtual Employee RegisteredBy { get; set; }
    }
}