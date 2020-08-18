using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mobin.TestConsoleApplication.Model
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerCustomerDemos = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Order>();
        }

        [Column("CustomerID")]
        [StringLength(5)]
        public string CustomerId { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [StringLength(30)]
        public string ContactName { get; set; }
        [StringLength(30)]
        public string ContactTitle { get; set; }
        [StringLength(60)]
        public string Address { get; set; }
        [StringLength(15)]

        [Display(Name = " City manam ")]
        public string City { get; set; }
        [StringLength(15)]
        public string Region { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [StringLength(15)]
        public string Country { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        public bool? Bool { get; set; }

        [InverseProperty("Customer")]
        public ICollection<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Order> Orders { get; set; }
    }
}
