using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    public enum AccountType
    {
        [Display(Name = "مدیر")]
        Manager,
        [Display(Name = "کارمند")]
        Employee,
        [Display(Name = "راننده")]
        Driver
    }
}