using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    public class LogOnModel
    {
        [Required(ErrorMessage = "لطفاً نام کاربری را وارد نمایید")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفاً گذرواژه را وارد نمایید")]
        [DataType(DataType.Password)]
        [Display(Name = "گذرواژه")]
        public string Password { get; set; }

        public bool CheckIsValid(string PassCheck)
        {
            if (UserName == "Administrator" && Password == PassCheck)
            {
                return true;
            }
            return false;
        }
    }
}