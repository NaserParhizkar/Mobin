using Northwind.Repository.EntityModel.Northwind.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Repository
{
    [Table("Region")]
    public partial class Region : NorthwindBaseEntity
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        [Column("RegionID")]
        public int RegionId { get; set; }
        [Required]
        [StringLength(50)]
        public string RegionDescription { get; set; }

        [InverseProperty("Region")]
        public ICollection<Territory> Territories { get; set; }
    }
}
