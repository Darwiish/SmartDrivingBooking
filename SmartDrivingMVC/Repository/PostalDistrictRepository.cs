using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVC.Repository
{

    public class PostalDistrictRepository : IRepository<PostalDistrict>
    {
        private SmartDrivingContext smartDrivingContext;

        public PostalDistrictRepository(SmartDrivingContext sdc)
        {
            this.smartDrivingContext = sdc;
        }

        public IEnumerable<PostalDistrict> ReadAll()
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.PostalDistrict.ToList();
            }
        }

        public PostalDistrict Get(int id)
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.PostalDistrict.FirstOrDefault();
            }
        }

        public void Add(PostalDistrict postalDistrict)
        {
            using (smartDrivingContext)
            {
                smartDrivingContext.PostalDistrict.Add(postalDistrict);
                smartDrivingContext.SaveChanges();
            }
        }

        public void Update(PostalDistrict postalDistrict)
        {
            if (postalDistrict.PostalDistrictId == 0)
            {
                smartDrivingContext.PostalDistrict.Add(postalDistrict);
                smartDrivingContext.SaveChanges();
            }
            else
            {
                smartDrivingContext.Entry(postalDistrict).State = EntityState.Modified;
                smartDrivingContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (smartDrivingContext)
            {
                PostalDistrict p = smartDrivingContext.PostalDistrict.Where(x => x.PostalDistrictId == id).FirstOrDefault();
                if (p != null)
                {
                    smartDrivingContext.PostalDistrict.Attach(p);
                    smartDrivingContext.PostalDistrict.Remove(p);
                    smartDrivingContext.SaveChanges();
                }
            }
        }
    }
}