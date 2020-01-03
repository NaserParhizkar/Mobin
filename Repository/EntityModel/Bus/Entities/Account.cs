using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KendoBus.Repository
{
    [Description("حساب کاربری")]
    public class Account
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ID { get; set; }

        [Display(Name = "کد"), Required(ErrorMessage = "لطفاً کد را وارد نمایید.")]
        public int AccountId { get; set; }

        [Display(Name = "نام کاربری"), Required(ErrorMessage = "لطفاً نام کاربری را وارد نمایید.")]
        public string UserName { get; set; }

        [Display(Name = "گذرواژه"), Required(ErrorMessage = "لطفاً گذرواژه را وارد نمایید."),
        DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار گذرواژه"), Required(ErrorMessage = "لطفاً گذرواژه را وارد نمایید."),
        NotMapped, DataType(System.ComponentModel.DataAnnotations.DataType.Password),
        Compare("Password", ErrorMessage = "تکرار گذرواژه را مانند گذرواژه وارد نمایید")]
        public string ConfirmPassword { get; set; }

        public int AccountGroupId { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        public virtual AccountGroup AccountGroup { get; set; }
    }
}