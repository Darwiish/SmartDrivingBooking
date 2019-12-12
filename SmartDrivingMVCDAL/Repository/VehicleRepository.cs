using Microsoft.EntityFrameworkCore;
using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVCDAL
{
    public class VehicleRepository : IRepository<Vehicle>
    {

        public IEnumerable< Vehicle> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Vehicles.Include(x => x.Bookings).ToList();
            }
        }

        public  Vehicle Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Vehicles.Include(x => x.Bookings).FirstOrDefault();
            }
        }

        public void Add( Vehicle vehicle)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.Vehicles.Add(vehicle);
                ctx.SaveChanges();
            }
        }

        public void Update( Vehicle vehicle)
        {
            using (var ctx = new SmartDrivingContext())
            {
                 Vehicle v = ctx.Vehicles.Where(x => x.VehicleId == vehicle.VehicleId).First();

                v.RegistrationDtl = vehicle.RegistrationDtl;
             
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                 Vehicle v = ctx.Vehicles.Where(x => x.VehicleId == id).FirstOrDefault();
                if (v != null)
                {
                    ctx.Vehicles.Attach(v);
                    ctx.Vehicles.Remove(v);
                    ctx.SaveChanges();
                }
            }
        }

    }
}

