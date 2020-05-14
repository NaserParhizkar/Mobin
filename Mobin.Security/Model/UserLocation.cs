using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Model
{
    public class Location
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        // Orgion
        [Column(TypeName = "decimal(9,6)"), Required]
        public decimal OrgionLongitude { get; set; }

        [Column(TypeName = "decimal(9,6)"), Required]
        public decimal OrgionLatitude { get; set; }

        // Destination
        [Column(TypeName = "decimal(9,6)"), Required]
        public decimal DestinationLongitude { get; set; }

        [Column(TypeName = "decimal(9,6)"), Required]
        public decimal DestinationLatitude { get; set; }


        // Distance from orgion to destination
        [Column(TypeName = "decimal(9,6)"), Required]
        public double Distance { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Locations")]
        public User User { get; set; }
    }
}