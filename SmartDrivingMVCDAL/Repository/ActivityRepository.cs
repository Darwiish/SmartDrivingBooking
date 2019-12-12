using Microsoft.EntityFrameworkCore;
using SmartDrivingMVCDAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVCDAL.DomainModels
{

    public class ActivityRepository : IRepository<Activity>
    {

        public IEnumerable<Activity> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Activitys.Include(x => x.ActivityType).
                    Include(x => x.Bookings).ToList();
            }
        }

        public Activity Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Activitys.Include(x => x.ActivityType)
                    .Include(x => x.Bookings).FirstOrDefault();
            }
        }

        public void Add(Activity activity)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.Activitys.Add(activity);
                ctx.SaveChanges();
            }
        }

        public void Update(Activity activity)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Activity a = ctx.Activitys.Where(x => x.ActivityId == activity.ActivityId).First();

                a.Price = activity.Price;
                a.StartDate = activity.StartDate;
                a.EndDate = activity.EndDate;
                a.ActivityTypeId = activity.ActivityTypeId;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Activity a = ctx.Activitys.Where(x => x.ActivityId == id).FirstOrDefault();
                if (a != null)
                {
                    ctx.Activitys.Attach(a);
                    ctx.Activitys.Remove(a);
                    ctx.SaveChanges();
                }
            }
        }
    }
}

