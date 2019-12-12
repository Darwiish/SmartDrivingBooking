using System.Collections.Generic;

namespace SmartDrivingMVC.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleModel { get; set; }
        public string RegistrationDtl { get; set; }
        public virtual ICollection<ActivityType> ActivityType { get; set; }
    }
}