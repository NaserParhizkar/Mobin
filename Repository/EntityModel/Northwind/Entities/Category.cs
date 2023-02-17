using Northwind.Repository.EntityModel.Northwind.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Repository
{
    public partial class Category : NorthwindBaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Column("CategoryID")]
        public int CategoryId { get; set; }

        [Display(Name = "گروه محصولات")]
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Display(Name = "توضیحات")]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Display(Name = "تصویر گروه محصولات")]
        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [InverseProperty("Category")]
        public ICollection<Product> Products { get; set; }
    }
}
