using Northwind.Repository.EntityModel.Northwind.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Repository
{
    [Display(Name = "مشتری")]
    public partial class Customer : NorthwindBaseEntity
    {
        public Customer()
        {
            CustomerCustomerDemos = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Order>();
        }

        [Display(Name = "شماره")]
        [Column("CustomerID")]
        [StringLength(5)]
        public string CustomerId { get; set; }

        [Display(Name = "شرکت")]
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [Display(Name = "نام تماس")]
        [StringLength(30)]
        public string ContactName { get; set; }

        [Display(Name = "عنوان تماس")]
        [StringLength(30)]
        public string ContactTitle { get; set; }

        [Display(Name = "آدرس")]
        [StringLength(60)]
        public string Address { get; set; }

        [Display(Name = "شهر")]
        [StringLength(15)]
        public string City { get; set; }

        [Display(Name = "منطقه")]
        [StringLength(15)]
        public string Region { get; set; }

        [Display(Name = "کدپستی")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Display(Name = "کشور")]
        [StringLength(15)]
        public string Country { get; set; }

        [Display(Name = "تلفن")]
        [StringLength(24)]
        public string Phone { get; set; }

        [Display(Name = "فکس")]
        [StringLength(24)]
        public string Fax { get; set; }

        public bool? Bool { get; set; }

        [InverseProperty("Customer")]
        public ICollection<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Order> Orders { get; set; }
    }
}
