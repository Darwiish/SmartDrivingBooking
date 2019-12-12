using SmartDrivingMVCDAL.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class Evaluation
    {
        [DataMember]
        public int EvaluationId { get; set; }
        [DataMember]
        public string Resulte { get; set; }
        [DataMember]
        public int ActivityId { get; set; }
        [DataMember]
        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }
        [DataMember]
        public int EvaluationTypeId { get; set; }
        [DataMember]
        [ForeignKey("EvaluationTypeId")]
        public virtual EvaluationType EvaluationType { get; set; }
    }
}