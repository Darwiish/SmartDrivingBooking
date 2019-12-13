using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDrivingMVC.Models
{
    public class BookingLog
    {
        public int BookingLogId { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public int? StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public int? ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }
    }
}