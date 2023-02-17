using Northwind.Repository.EntityModel.Northwind.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Repository
{
    public partial class EmployeeTerritory : NorthwindBaseEntity
    {
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Column("TerritoryID")]
        [StringLength(20)]
        public string TerritoryId { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("EmployeeTerritories")]
        public Employee Employee { get; set; }
        [ForeignKey("TerritoryId")]
        [InverseProperty("EmployeeTerritories")]
        public Territory Territory { get; set; }
    }
}
