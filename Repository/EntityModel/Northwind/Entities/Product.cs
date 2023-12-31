﻿using Northwind.Repository.EntityModel.Northwind.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Repository
{
    public partial class Product : NorthwindBaseEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Column("ProductID")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "نام محصول")]
        public string ProductName { get; set; }

        [Column("SupplierID")]
        public int? SupplierId { get; set; }

        [Column("CategoryID")]
        public int? CategoryId { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public Category Category { get; set; }

        [ForeignKey("SupplierId")]
        [InverseProperty("Products")]
        public Supplier Supplier { get; set; }

        [InverseProperty("Product")]
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
