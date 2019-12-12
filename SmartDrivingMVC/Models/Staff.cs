using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SmartDrivingMVC.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Street { get; set; }
        public string MobilePhone { get; set; }
        [ForeignKey("PostalDistrictId")]
        public virtual PostalDistrict PostalDistrict { get; set; }
        [DataMember]
        public virtual ICollection<BookingLog> BookingLogs { get; set; }

    }
}