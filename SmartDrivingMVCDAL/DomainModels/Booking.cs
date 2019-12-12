using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class Booking
    {
        internal string Title;

        [DataMember]
        public int BookingId { get; set; }
        [DataMember]
        public DateTime CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime LastModifiedDate { get; set; }
        [DataMember]
        public string LastModifiedBy { get; set; }
        [DataMember]
        public int StaffId { get; set; }
        [DataMember]
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
        [DataMember]
        public int ActivityId { get; set; }
        [DataMember]
        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public int VehicleId { get; set; }
        [DataMember]
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
    }
}