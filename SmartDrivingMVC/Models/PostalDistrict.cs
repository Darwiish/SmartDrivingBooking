using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartDrivingMVC.Models
{
    public class PostalDistrict
    {
        public int PostalDistrictId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int Zipcode { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

    }
}