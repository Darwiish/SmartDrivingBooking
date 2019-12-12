using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVC.Repository
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        private SmartDrivingContext smartDrivingContext;

        public VehicleRepository(SmartDrivingContext sdc)
        {
            this.smartDrivingContext = sdc;
        }

        public IEnumerable<Vehicle> ReadAll()
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.Vehicle.ToList();
            }
        }

        public Vehicle Get(int id)
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.Vehicle.FirstOrDefault();
            }
        }

        public void Add(Vehicle vehicle)
        {
            using (smartDrivingContext)
            {
                smartDrivingContext.Vehicle.Add(vehicle);
                smartDrivingContext.SaveChanges();
            }
        }

        public void Update(Vehicle vehicle)
        {
            if (vehicle.VehicleId == 0)
            {
                smartDrivingContext.Vehicle.Add(vehicle);
                smartDrivingContext.SaveChanges();
            }
            else
            {
                smartDrivingContext.Entry(vehicle).State = EntityState.Modified;
                smartDrivingContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (smartDrivingContext)
            {
                Vehicle v = smartDrivingContext.Vehicle.Where(x => x.VehicleId == id).FirstOrDefault();
                if (v != null)
                {
                    smartDrivingContext.Vehicle.Attach(v);
                    smartDrivingContext.Vehicle.Remove(v);
                    smartDrivingContext.SaveChanges();
                }
            }
        }

    }
}

