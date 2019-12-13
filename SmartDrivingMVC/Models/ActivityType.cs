using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SmartDrivingMVC.Models
{
    public class ActivityType
    {
        public int ActivityTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public int? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<BookingLog> BookingLog { get; set; }
    }
}