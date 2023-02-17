using Northwind.Repository.EntityModel.Northwind.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Repository
{
    [Table("Order Details")]
    public partial class OrderDetail : NorthwindBaseEntity
    {
        [Column("OrderID")]
        public int OrderId { get; set; }

        [Column("ProductID")]
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        [Display(Name = "فی")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "تعداد")]
        public short Quantity { get; set; }

        [Display(Name = "تخفیف")]
        public float Discount { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("OrderDetails")]
        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("OrderDetails")]
        public Product Product { get; set; }
    }
}
