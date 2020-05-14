using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDN.Repository
{
    public partial class PDNProduct
    {
        public PDNProduct()
        {
            PDNOrderItems = new HashSet<PDNOrderItem>();
        }

        [Column("PDNProductID")]
        public int PDNProductId { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "نام محصول")]
        public string PDNProductName { get; set; }

        [Required()]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal PDNUnitPrice { get; set; }

        [InverseProperty("PDNProduct")]
        public ICollection<PDNOrderItem> PDNOrderItems { get; set; }
    }
}
