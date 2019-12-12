using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SmartDrivingMVCDAL.DomainModels
{
    public class Role
    {
        public Role()
        {
            Staffs = new List<Staff>();
        }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}