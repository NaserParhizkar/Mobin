using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mobin.TestConsoleApplication.Model
{
    [Table("CustomerCustomerDemo")]
    public partial class CustomerCustomerDemo
    {
        [Column("CustomerID")]
        [StringLength(5)]
        public string CustomerId { get; set; }
        [Column("CustomerTypeID")]
        [StringLength(10)]
        public string CustomerTypeId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("CustomerCustomerDemos")]
        public Customer Customer { get; set; }
        [ForeignKey("CustomerTypeId")]
        [InverseProperty("CustomerCustomerDemos")]
        public CustomerDemographic CustomerType { get; set; }
    }
}
