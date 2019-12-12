using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;
using System.Collections.Generic;
using System.Linq;


namespace SmartDrivingMVC.Repository
{

    public class CustomerRepository : IRepository<Customer>
    {
        private SmartDrivingContext smartDrivingContext;

        public CustomerRepository(SmartDrivingContext sdc)
        {
            this.smartDrivingContext = sdc;
        }

        public IEnumerable<Customer> ReadAll()
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.Customer.Include(x => x.BookingLogs).ToList();
            }
        }

        public Customer Get(int id)
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.Customer.Include(x => x.BookingLogs).Include(x => x.PostalDistrict.Zipcode).FirstOrDefault();
            }
        }

        public Customer GetCustomerWithBookingLogs(int id)
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.Customer.Include(x => x.BookingLogs).FirstOrDefault();
            }
        }

        public void Add(Customer customer)
        {
            using (smartDrivingContext)
            {
                smartDrivingContext.Customer.Add(customer);
                smartDrivingContext.SaveChanges();
            }
        }

        public void Update(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                smartDrivingContext.Customer.Add(customer);
                smartDrivingContext.SaveChanges();
            }
            else
            {
                smartDrivingContext.Entry(customer).State = EntityState.Modified;
                smartDrivingContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (smartDrivingContext)
            {
                Customer c = smartDrivingContext.Customer.Where(x => x.CustomerId == id).First();
                if (c != null)
                {
                    smartDrivingContext.Customer.Attach(c);
                    smartDrivingContext.Customer.Remove(c);
                    smartDrivingContext.SaveChanges();
                }
            }
        }
    }
}
