using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class Staff
    {
        public Staff()
        {
            Bookings = new List<Booking>();
        }

        [DataMember]
        public int StaffId { get; set; }
        [Required]
        [DataMember]
        public string FirstName { get; set; }
        [Required]
        [DataMember]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        [DataMember]
        public string EmailAddress { get; set; }
        [Required]
        [DataMember]
        public string Street { get; set; }
        [Required]
        [DataMember]
        public string MobilePhone { get; set; }
        [DataMember]
        public string ZipcodeId { get; set; }
        [DataMember]
        [ForeignKey("ZipcodeId")]
        public virtual PostalDistrict PostalDistrict { get; set; }
        [DataMember]
        public virtual ICollection<Booking> Bookings { get; set; }




    }
}