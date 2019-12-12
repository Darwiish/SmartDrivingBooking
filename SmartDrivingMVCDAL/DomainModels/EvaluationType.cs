using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class EvaluationType
    {
        [DataMember]
        public int EvaluationTypeId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
