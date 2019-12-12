using SmartDrivingMVCDAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDrivingMVCDAL.Data
{
    public class SmartDrivingContextInitializer : DropCreateDatabaseAlways<SmartDrivingContext>
    {
        protected override void Seed(SmartDrivingContext context)
        {
            IList<Booking> bookings = new List<Booking>();


     
            Customer customer1 = context.Customers.Add(new Customer() { CustomerId = 1, FirstName = "Kim Cormen", EmailAddress = "Google@google.tinfoil",});
            Customer customer2 = context.Customers.Add(new Customer() { CustomerId = 2, FirstName = "Ivan Gayman", EmailAddress = "Gay@fagcity.ana" });
            Customer customer3 = context.Customers.Add(new Customer()
            {
                CustomerId = 3,
                FirstName = "Yusuf",
                EmailAddress = "yus@gmail.com",
            });
            bookings.Add(new Booking()
            {
                Title = "Night Driving",
            });
          
            foreach (Booking boo in bookings)
                context.Bookings.Add(boo);



            base.Seed(context);
        }
    }
}

