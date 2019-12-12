using Microsoft.EntityFrameworkCore;
using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVCDAL
{
    public class BookingRepository : IRepository<Booking>
    {

        public IEnumerable<Booking> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Bookings.Include(x => x.Activity)
                    .Include(x => x.Customer).ToList();

            }
        }
        public Booking Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Bookings.Include(x => x.Activity)
                    .Include(x => x.Customer).FirstOrDefault();
            }
        }

        public void Add(Booking booking)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.Bookings.Add(booking);
                ctx.SaveChanges();
            }
        }

        public void Update(Booking booking)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Booking b = ctx.Bookings.Where(x => x.BookingId == booking.BookingId).First();

                b.Customer = booking.Customer;
                b.Staff = booking.Staff;
                b.Vehicle = booking.Vehicle;
                b.CreatedDate = booking.CreatedDate;
                b.CreatedBy = booking.CreatedBy;
                b.LastModifiedDate = booking.LastModifiedDate;
                b.LastModifiedBy = booking.LastModifiedBy;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Booking b = ctx.Bookings.Where(x => x.BookingId == id).First();
                if (b != null)
                {
                    ctx.Bookings.Attach(b);
                    ctx.Bookings.Remove(b);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
