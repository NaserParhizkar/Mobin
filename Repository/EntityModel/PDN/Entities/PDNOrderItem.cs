using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDN.Repository
{
    [Table("PDNOrderItems")]
    public class PDNOrderItem
    {
        [Column("PDNOrderItemId")]
        public int PDNOrderItemId { get; set; }

        [Column("PDNOrderId")]
        public int PDNOrderId { get; set; }

        [Column("PDNProductId")]
        public int PDNProductId { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        [Required(ErrorMessage = "لطفا فی را وارد نمایید")]
        [Display(Name = "فی")]
        public decimal PDNUnitPrice { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا تعداد را وارد نمایید")]
        public short PDNQuantity { get; set; }

        [Display(Name = "تخفیف")]
        [Required(ErrorMessage = "لطفا تخیف را وارد نمایید")]
        public float PDNDiscount { get; set; }

        [ForeignKey("PDNOrderId")]
        [InverseProperty("PDNOrderItems")]
        public PDNOrder PDNOrder { get; set; }

        [ForeignKey("PDNProductId")]
        [InverseProperty("PDNOrderItems")]
        public PDNProduct PDNProduct { get; set; }
    }
}

