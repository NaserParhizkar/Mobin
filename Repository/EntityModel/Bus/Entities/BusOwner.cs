using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{

    [Description("مالک اتوبوس")]
    public class BusOwner : Person
    {
        [Display(Name="کد مالک اتوبوس")]
        public int BOID { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public virtual ICollection<Bus> Buses { get; set; }
    }
}