using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KendoBus.Repository
{
    [Description("جزئیات نوبت کاری")]
    public class WorksOn
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ID { get; set; }

        public int WorksOnId { get; set; }

        public int BusId { get; set; }

        public int DrvId { get; set; }
        public int ShiftId { get; set; }

        [NotMapped]
        public ShiftPeriod Type 
        {
            get { return (ShiftPeriod)TypeOfShiftPeriod; }
            set { TypeOfShiftPeriod = (int)value; }
        }

        [ScaffoldColumn(false)]
        private int TypeOfShiftPeriod
        {
            get;
            set;
        }


        public virtual Bus Bus { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Shift Shift { get; set; }
    }
}