using SmartDrivingMVCDAL.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class BookingEvaluation
    {
        [DataMember]
        public int BookingEvaluationId { get; set; }
        [DataMember]
        public int EvaluationId { get; set; }
        [DataMember]
        public string EvaluationResulte { get; set; }
        [DataMember]
        [ForeignKey("EvaluationId")]
        public virtual Evaluation Evaluation { get; set; }
        [DataMember]
        public int BookingId { get; set; }
        [DataMember]
        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; }
    }
}
