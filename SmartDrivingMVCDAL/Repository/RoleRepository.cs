using Microsoft.EntityFrameworkCore;
using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;


namespace SmartDrivingMVCDAL
{

    public class RoleRepository : IRepository<Role>
    {

        public IEnumerable<Role> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Roles.Include(x => x.Staffs).ToList();

            }
        }
        public Role Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Roles.Include(x => x.Staffs).FirstOrDefault();
            }
        }

        public void Add(Role booking)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.Roles.Add(booking);
                ctx.SaveChanges();
            }
        }

        public void Update(Role booking)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Role r = ctx.Roles.Where(x => x.RoleId == booking.RoleId).First();

                r.RoleName = booking.RoleName;


                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Role r = ctx.Roles.Where(x => x.RoleId == id).First();
                if (r != null)
                {
                    ctx.Roles.Attach(r);
                    ctx.Roles.Remove(r);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
