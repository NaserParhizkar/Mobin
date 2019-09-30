using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Mobin.Common.ComponentModel.DataAnnotations;

namespace KendoBus.Repository
{
    [Description("شخص")]
    public class Person
    {

        public Person() { }

        public Person(string id, string firstname, string lastname)
        {
            this.NationalCode = id;
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        [Key]
        public int ID { get; set; }

        //[Kendo.Mvc.Infrastructure.Attributes.UniqueSingleProperty]
        //[RegularExpression(@"[0-9]{10}",ErrorMessage = "لطفاً کد ملی را به صورت عددی و با 10 کاراکتر وارد نمایید")]
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا کد ملی را وارد نمایید")]
        [NationalCode(ErrorMessage = "کد ملی وارد شده نامعتبر می باشد")]
        public string NationalCode { get; set; }

        [Display(Name="نام"),Required(ErrorMessage="لطفا نام را وارد نمایید")]
        public string FirstName { get; set; }

        [Display(Name="نام خانوادگی"),Required(ErrorMessage="لطفا نام خانوادگی را وارد نمایید")]
        public string LastName { get; set; }

        [Display(Name="آدرس الکترونیکی")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ تولد را وارد نمایید")]
        [Display(Name="تاریخ تولد")]
        [DataType(DataType.Date,ErrorMessage = "تاریخ وارد شده معتبر نمی باشد")]
        public DateTime BirthDate { get; set; }

        [Display(Name="شماره تلفن")]
        public string PhoneNumber { get; set; }

        [Display(Name="حقوق")]
        [Required(ErrorMessage = "لطفا حقوق را وارد نمایید")]
        public decimal Salary { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}