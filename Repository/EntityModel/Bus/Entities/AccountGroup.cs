using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    [Description("گروه حساب کاربری")]
    public class AccountGroup
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ID { get; set; }

        [Display(Name = "کد گروه حساب کاربری"),
        Required(ErrorMessage = "لطفاً کد گروه حساب کاربری را وارد نمایید.")]
        public int AccountGroupId { get; set; }


        [Display(Name = "نوع گروه حساب کاربری"),
        Required(ErrorMessage = "لطفاً نوع گروه حساب کاربری را وارد نمایید.")]
        [UIHint("EnumTemplate")]
        public AccountType Type { get; set; }



        public virtual ICollection<Account> Accounts { get; set; }
    }
}