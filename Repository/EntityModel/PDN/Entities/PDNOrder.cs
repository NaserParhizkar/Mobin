using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDN.Repository
{

    public partial class PDNOrder
    {
        public PDNOrder()
        {
            PDNOrderItems = new HashSet<PDNOrderItem>();
        }

        [Column("PDNOrderID")]
        public int PDNOrderId { get; set; }

        [Column("PDNCustomerID")]
        public int PDNCustomerId { get; set; }

        [Display(Name = "تاریخ سفارش")]
        [Column(TypeName = "datetime")]
        public DateTime PDNOrderDate { get; set; }

        [ForeignKey("PDNCustomerId")]
        [InverseProperty("PDNOrders")]
        public PDNCustomer PDNCustomer { get; set; }

        [InverseProperty("PDNOrder")]
        public ICollection<PDNOrderItem> PDNOrderItems { get; set; }
    }
}