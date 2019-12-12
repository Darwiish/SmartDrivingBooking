using SmartDrivingMVCDAL.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SmartDrivingMVCDAL.Data
{
    public class SmartDrivingContext : IdentityDbContext
    {

        public SmartDrivingContext(DbContextOptions<SmartDrivingContext> options)
           : base(options)
        {
        }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<BookingEvaluation> BookingEvaluations { get; set; }
        public DbSet<Activity> Activitys { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationType> EvaluationTypes { get; set; }
        public DbSet<PostalDistrict> PostalDistricts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBooking> VehicleBookings { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
