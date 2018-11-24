﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Repository.EntityModels
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        [Column("TerritoryID")]
        [StringLength(20)]
        public string TerritoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }
        [Column("RegionID")]
        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("Territories")]
        public Region Region { get; set; }
        [InverseProperty("Territory")]
        public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}