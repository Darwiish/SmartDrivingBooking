using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVC.Repository
{

    public class StaffRepository : IRepository<Staff>
    {
        private SmartDrivingContext smartDrivingContext;

        public StaffRepository(SmartDrivingContext sdc)
        {
            this.smartDrivingContext = sdc;
        }

        public IEnumerable<Staff> ReadAll()
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.Staff.Include(x => x.BookingLogs).ToList();
            }
        }

        public Staff Get(int id)
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.Staff.Include(x => x.BookingLogs).FirstOrDefault();
            }
        }

        public void Add(Staff staff)
        {
            using (smartDrivingContext)
            {
                smartDrivingContext.Staff.Add(staff);
                smartDrivingContext.SaveChanges();
            }
        }
        public void Update(Staff staff)
        {
            if (staff.StaffId == 0)
            {
                smartDrivingContext.Staff.Add(staff);
                smartDrivingContext.SaveChanges();
            }
            else
            {
                smartDrivingContext.Entry(staff).State = EntityState.Modified;
                smartDrivingContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (smartDrivingContext)
            {
                Staff s = smartDrivingContext.Staff.Where(x => x.StaffId == id).FirstOrDefault();
                if (s != null)
                {
                    smartDrivingContext.Staff.Attach(s);
                    smartDrivingContext.Staff.Remove(s);
                    smartDrivingContext.SaveChanges();
                }
            }
        }

    }
}

