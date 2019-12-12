using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVC.Repository
{
    public class BookingLogRepository : IRepository<BookingLog>
    {
        private SmartDrivingContext smartDrivingContext;

        public BookingLogRepository(SmartDrivingContext sdc)
        {
            this.smartDrivingContext = sdc;
        }

        public IEnumerable<BookingLog> ReadAll()
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.BookingLog.Include(x => x.ActivityType)
                    .Include(x => x.Customer).ToList();

            }
        }
        public BookingLog Get(int id)
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.BookingLog.Include(x => x.ActivityType)
                    .Include(x => x.Customer).FirstOrDefault();
            }
        }

        public void Add(BookingLog bookingLog)
        {
            using (smartDrivingContext)
            {
                smartDrivingContext.BookingLog.Add(bookingLog);
                smartDrivingContext.SaveChanges();
            }
        }

        public void Update(BookingLog bookingLog)
        {
            if (bookingLog.BookingLogId == 0)
            {
                smartDrivingContext.BookingLog.Add(bookingLog);
                smartDrivingContext.SaveChanges();
            }
            else
            {
                smartDrivingContext.Entry(bookingLog).State = EntityState.Modified;
                smartDrivingContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (smartDrivingContext)
            {
                BookingLog b = smartDrivingContext.BookingLog.Where(x => x.BookingLogId == id).First();
                if (b != null)
                {
                    smartDrivingContext.BookingLog.Attach(b);
                    smartDrivingContext.BookingLog.Remove(b);
                    smartDrivingContext.SaveChanges();
                }
            }
        }
    }
}
