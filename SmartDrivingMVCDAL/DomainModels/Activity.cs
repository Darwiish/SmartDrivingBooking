using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class Activity
    {
        public Activity()
        {
            Bookings = new List<Booking>();
        }
        [DataMember]
        public int ActivityId { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public int ActivityTypeId { get; set; }
        [DataMember]
        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }
        [DataMember]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}