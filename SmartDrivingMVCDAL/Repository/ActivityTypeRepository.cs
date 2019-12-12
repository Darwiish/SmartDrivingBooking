using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVCDAL
{

    public class ActivityTypeRepository : IRepository<ActivityType>
    {

        public IEnumerable<ActivityType> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.ActivityTypes.ToList();
            }
        }

        public ActivityType Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.ActivityTypes.FirstOrDefault();
            }
        }

        public void Add(ActivityType activityType)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.ActivityTypes.Add(activityType);
                ctx.SaveChanges();
            }
        }

        public void Update(ActivityType activityType)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ActivityType a = ctx.ActivityTypes.Where(x => x.ActivityTypeId == activityType.ActivityTypeId).First();

                a.Title = activityType.Title;
                a.Description = activityType.Description;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ActivityType a = ctx.ActivityTypes.Where(x => x.ActivityTypeId == id).FirstOrDefault();
                if (a != null)
                {
                    ctx.ActivityTypes.Attach(a);
                    ctx.ActivityTypes.Remove(a);
                    ctx.SaveChanges();
                }
            }
        }

    }
}

