using Microsoft.EntityFrameworkCore;
using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartDrivingMVCDAL
{

    public class PostalDistrictRepository : IRepository<PostalDistrict>
    {

        public IEnumerable<PostalDistrict> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.PostalDistricts.ToList();
            }
        }

        public PostalDistrict Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.PostalDistricts.FirstOrDefault();
            }
        }

        public void Add(PostalDistrict postalDistrict)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.PostalDistricts.Add(postalDistrict);
                ctx.SaveChanges();
            }
        }

        public void Update(PostalDistrict postalDistrict)
        {
            using (var ctx = new SmartDrivingContext())
            {
                PostalDistrict p = ctx.PostalDistricts.Where(x => x.PostalDistrictId == postalDistrict.PostalDistrictId).First();

                p.City = postalDistrict.City;
                p.Zipcode = postalDistrict.Zipcode;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                PostalDistrict p = ctx.PostalDistricts.Where(x => x.PostalDistrictId == id).FirstOrDefault();
                if (p != null)
                {
                    ctx.PostalDistricts.Attach(p);
                    ctx.PostalDistricts.Remove(p);
                    ctx.SaveChanges();
                }
            }
        }
    }
}