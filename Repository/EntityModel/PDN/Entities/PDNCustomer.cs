using Mobin.Common.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDN.Repository
{
    public class PDNCustomer
    {
        [Display(AutoGenerateField = false)]
        public int PDNCustomerId { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا کد ملی را وارد نمایید")]
        [NationalCode(ErrorMessage = "کد ملی وارد شده نامعتبر می باشد")]
        public string NationalCode { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفاً نام را وارد نمایید")]
        public string PDNFirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفاً نام خانوادگی را وارد نمایید")]
        public string PDNLastName { get; set; }

        [Display(Name = "اولویت تراکنش")]
        [Required(ErrorMessage = "لطفاً اولویت تراکنش را وارد نمایید")]
        public int Priority { get; set; }

        [Display(Name = "شهر")]
        [StringLength(15)]
        public string PDNCity { get; set; }

        [Display(Name = "کدپستی")]
        [StringLength(10)]
        public string PDNPostalCode { get; set; }


        [InverseProperty("PDNCustomer")]
        public ICollection<PDNOrder> PDNOrders { get; set; }

    }
}
