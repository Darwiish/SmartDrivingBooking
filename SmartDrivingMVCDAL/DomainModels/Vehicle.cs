using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class Vehicle
    {
        public Vehicle()
        {
            Bookings = new List<Booking>();
        }
        [DataMember]
        public int VehicleId { get; set; }
        [DataMember]
        public string VehicleModel { get; set; }
        [DataMember]
        public string RegistrationDtl { get; set; }
        [DataMember]
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}