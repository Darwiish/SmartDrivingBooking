using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDrivingMVC.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string LastName { get; set; }
        [StringLength(100)]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [StringLength(100)]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime DateBirth { get; set; }
        [StringLength(100)]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }


        public int? PostalDistrictId { get; set; }
        [ForeignKey("PostalDistrictId")]
        public virtual PostalDistrict PostalDistrict { get; set; }

        public virtual ICollection<BookingLog> BookingLogs { get; set; }

        public string AspNetUserId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}