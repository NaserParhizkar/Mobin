﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mobin.TestConsoleApplication.Model
{
    public partial class EmployeeTerritory
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
