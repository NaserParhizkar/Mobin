using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KendoBus.Repository
{
    [Description("آدرس")]
    public class Address
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ID { get; set; }

        public int AddressId { get; set; }

        [ScaffoldColumn(false)]
        [ForeignKey(nameof(Address.Person))]
        [Required(ErrorMessage = "لطفاً شخصی را انتخاب نمایید")]
        public int PersonID { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string AddressDetails { get; set; }

        [Display(Name = "اطلاعات شخص")]
        public virtual Person Person { get; set; }

    }
}