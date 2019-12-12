using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class ActivityType
    {
        [DataMember]
        public int ActivityTypeId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}