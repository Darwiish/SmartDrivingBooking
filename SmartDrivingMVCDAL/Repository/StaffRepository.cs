using Microsoft.EntityFrameworkCore;
using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVCDAL
{

    public class StaffRepository : IRepository<Staff>
    {

        public IEnumerable<Staff> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Staffs.Include(x => x.Bookings).ToList();
            }
        }

        public Staff Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Staffs.Include(x => x.Bookings).FirstOrDefault();
            }
        }

        public void Add(Staff staff)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.Staffs.Add(staff);
                ctx.SaveChanges();
            }
        }

        public void Update(Staff staff)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Staff s = ctx.Staffs.Where(x => x.StaffId == staff.StaffId).First();

                s.FirstName = staff.FirstName;
                s.LastName = staff.LastName;
                s.EmailAddress = staff.EmailAddress;
                s.Street = staff.Street;
                s.MobilePhone = staff.MobilePhone;
                s.PostalDistrict = staff.PostalDistrict;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Staff s = ctx.Staffs.Where(x => x.StaffId == id).FirstOrDefault();
                if (s != null)
                {
                    ctx.Staffs.Attach(s);
                    ctx.Staffs.Remove(s);
                    ctx.SaveChanges();
                }
            }
        }

    }
}

