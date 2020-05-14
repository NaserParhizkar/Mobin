using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Model
{
    public class User
    {
        public User()
        {
            Locations = new HashSet<Location>();
        }

        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }


        [InverseProperty("User")]
        public ICollection<Location> Locations { get; set; }
    }
}
