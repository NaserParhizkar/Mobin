using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    public enum BusType
    {
        [Display(Name = "تندرو")]
        BRT = 1,
        [Display(Name = "برقی")]
        Electricy = 2,
        [Display(Name = "برونشهری")]
        OutOfCity = 3,
        [Display(Name = "معمولی")]
        Ordinary = 4
    }
}