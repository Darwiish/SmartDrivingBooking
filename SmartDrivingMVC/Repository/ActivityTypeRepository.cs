using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVC.Repository
{

    public class ActivityTypeRepository : IRepository<ActivityType>
    {
        private SmartDrivingContext smartDrivingContext;

        public ActivityTypeRepository(SmartDrivingContext sdc)
        {
            this.smartDrivingContext = sdc;
        }

        public IEnumerable<ActivityType> ReadAll()
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.ActivityType.ToList();
            }
        }

        public ActivityType Get(int id)
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.ActivityType.FirstOrDefault();
            }
        }

        public void Add(ActivityType activityType)
        {
            using (smartDrivingContext)
            {
                smartDrivingContext.ActivityType.Add(activityType);
                smartDrivingContext.SaveChanges();
            }
        }

        public void Update(ActivityType activityType)
        {
            if (activityType.ActivityTypeId == 0)
            {
                smartDrivingContext.ActivityType.Add(activityType);
                smartDrivingContext.SaveChanges();
            }
            else
            {
                smartDrivingContext.Entry(activityType).State = EntityState.Modified;
                smartDrivingContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (smartDrivingContext)
            {
                ActivityType a = smartDrivingContext.ActivityType.Where(x => x.ActivityTypeId == id).FirstOrDefault();
                if (a != null)
                {
                    smartDrivingContext.ActivityType.Attach(a);
                    smartDrivingContext.ActivityType.Remove(a);
                    smartDrivingContext.SaveChanges();
                }
            }
        }

    }
}

