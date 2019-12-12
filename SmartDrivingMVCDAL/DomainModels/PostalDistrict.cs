using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class PostalDistrict
    {
        [DataMember]
        public int PostalDistrictId { get; set; }
        [Required]
        [DataMember]
        public string City { get; set; }
        [Required]
        [DataMember]
        public string Zipcode { get; set; }
    }
}