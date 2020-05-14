using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    public enum StationType
    {
        [Display(Name = "بین راهی")]
        Street = 1,
        [Display(Name = "ترمینالی")]
        Terminal = 2,
        [Display(Name = "برونشهری")]
        CityOuter = 3
    }
}