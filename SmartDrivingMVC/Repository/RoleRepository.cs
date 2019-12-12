//using Microsoft.EntityFrameworkCore;
//using SmartDrivingMVC.Models;
//using SmartDrivingMVCDAL.Data;
//using System.Collections.Generic;
//using System.Linq;


//namespace SmartDrivingMVC.Repository
//{

//    public class RoleRepository : IRepository<Role>
//    {
//        private SmartDrivingContext smartDrivingContext;

//        public RoleRepository(SmartDrivingContext sdc)
//        {
//            this.smartDrivingContext = sdc;
//        }

//        public IEnumerable<Role> ReadAll()
//        {
//            using (smartDrivingContext)
//            {
//                return smartDrivingContext.Role.Include(x => x.Staffs).ToList();

//            }
//        }
//        public Role Get(int id)
//        {
//            using (smartDrivingContext)
//            {
//                return smartDrivingContext.Role.Include(x => x.Staffs).FirstOrDefault();
//            }
//        }

//        public void Add(Role bookingLog)
//        {
//            using (smartDrivingContext)
//            {
//                smartDrivingContext.Role.Add(bookingLog);
//                smartDrivingContext.SaveChanges();
//            }
//        }

//        public void Update(Role role)
//        {
//            if (role.RoleId == 0)
//            {
//                smartDrivingContext.Role.Add(role);
//                smartDrivingContext.SaveChanges();
//            }
//            else
//            {
//                smartDrivingContext.Entry(role).State = EntityState.Modified;
//                smartDrivingContext.SaveChanges();
//            }
//        }

//        public void Delete(int id)
//        {
//            using (smartDrivingContext)
//            {
//                Role r = smartDrivingContext.Role.Where(x => x.RoleId == id).First();
//                if (r != null)
//                {
//                    smartDrivingContext.Role.Attach(r);
//                    smartDrivingContext.Role.Remove(r);
//                    smartDrivingContext.SaveChanges();
//                }
//            }
//        }
//    }
//}
