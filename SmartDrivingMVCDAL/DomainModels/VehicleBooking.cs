using SmartDrivingMVCDAL.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class VehicleBooking
    {
        [DataMember]
        public int VehicleBookingId { get; set; }
        [DataMember]
        public int BookingId { get; set; }
        [DataMember]
        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
        [DataMember]
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
    }
}