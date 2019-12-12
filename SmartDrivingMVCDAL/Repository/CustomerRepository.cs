using Microsoft.EntityFrameworkCore;
using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;


namespace SmartDrivingMVCDAL
{

    public class CustomerRepository : IRepository<Customer>
    {

        public IEnumerable<Customer> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Customers.Include(x => x.Bookings).ToList();
            }
        }

        public Customer Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Customers.Include(x => x.Bookings).FirstOrDefault();
            }
        }

        public void Add(Customer customer)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
        }

        public void Update(Customer customer)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Customer c = ctx.Customers.Where(x => x.CustomerId == customer.CustomerId).First();

                c.FirstName = customer.FirstName;
                c.LastName = customer.LastName;
                c.Street = customer.Street;
                c.EmailAddress = customer.EmailAddress;
                c.MobilePhone = customer.MobilePhone;
                c.DateBirth = customer.DateBirth;
                c.PostalDistrict = customer.PostalDistrict;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Customer c = ctx.Customers.Where(x => x.CustomerId == id).First();
                if (c != null)
                {
                    ctx.Customers.Attach(c);
                    ctx.Customers.Remove(c);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
