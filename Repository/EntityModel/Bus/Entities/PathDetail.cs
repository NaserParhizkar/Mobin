using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KendoBus.Repository
{
    [Description("جزئیات مسیر")]
    public class PathDetail
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ID { get; set; }

        [Display(Name = "کد جزئیات مسیر")]
        public int PathDetailId { get; set; }

        private bool _FirstStation;
        private bool _LastStation;

        [ScaffoldColumn(false)]
        [ForeignKey(nameof(PathDetail.Path))]
        [Required(ErrorMessage = "لطفاً مسیری را انتخاب نمایید")]
        public int PathID { get; set; }

        [ScaffoldColumn(false)]
        [ForeignKey(nameof(PathDetail.Station))]
        [Required(ErrorMessage = "لطفاً ایستگاهی را انتخاب نمایید")]
        public int StationID { get; set; }

        [Display(Name = "طول مسیر")]
        public float Distance { get; set; }

        [Display(Name = "ایستگاه مبدا")]
        public bool? FirstStation
        {
            get { return _FirstStation; }
            set
            {
                if (LastStation == true)
                {
                    if (_FirstStation == true)
                    {
                        _FirstStation = false;
                        throw new Exception("این ایستگاه از نوع ایستگاه مقصد است.");
                    }
                }
                else
                    _FirstStation = value ?? _FirstStation;
            }
        }


        [Display(Name = "ایستگاه مقصد")]
        public bool? LastStation
        {
            get { return _LastStation; }
            set
            {
                if (FirstStation == true)
                {
                    if (_LastStation == true)
                    {
                        _LastStation = false;
                        throw new Exception("این ایستگاه از نوع ایستگاه مبدا است.");
                    }
                }
                else
                    _LastStation = value ?? _FirstStation;
            }
        }

        [Display(Name = "مسیر")]
        public virtual Path Path { get; set; }

        [Display(Name = "مالک اتوبوس")]
        public virtual Station Station { get; set; }

    }
}