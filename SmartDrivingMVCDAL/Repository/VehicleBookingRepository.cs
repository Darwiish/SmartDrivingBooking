using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVCDAL
{

    public class VehicleBookingRepository : IRepository<VehicleBooking>
    {

        public IEnumerable<VehicleBooking> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.VehicleBookings.ToList();
            }
        }

        public VehicleBooking Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.VehicleBookings.FirstOrDefault();
            }
        }

        public void Add(VehicleBooking vehicleBooking)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.VehicleBookings.Add(vehicleBooking);
                ctx.SaveChanges();
            }
        }

        public void Update(VehicleBooking vehicleBooking)
        {
            using (var ctx = new SmartDrivingContext())
            {
                VehicleBooking v = ctx.VehicleBookings.Where(x => x.VehicleBookingId == vehicleBooking.VehicleBookingId).First();

                v.BookingId = vehicleBooking.BookingId;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                VehicleBooking v = ctx.VehicleBookings.Where(x => x.VehicleBookingId == id).FirstOrDefault();
                if (v != null)
                {
                    ctx.VehicleBookings.Attach(v);
                    ctx.VehicleBookings.Remove(v);
                    ctx.SaveChanges();
                }
            }
        }

    }
}

