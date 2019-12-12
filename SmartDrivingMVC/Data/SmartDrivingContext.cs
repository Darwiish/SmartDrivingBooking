using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using System;

namespace SmartDrivingMVCDAL.Data
{
    public class SmartDrivingContext : IdentityDbContext
    {

        public SmartDrivingContext(DbContextOptions<SmartDrivingContext> options)
           : base(options)
        {
        }

        public DbSet<BookingLog> BookingLog { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<PostalDistrict> PostalDistrict { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>().HasData(new Staff()
            {
                StaffId = 1,
                FirstName = "Hashi",
                LastName = "Booba",
                EmailAddress = "has@ertr.dk",
                MobilePhone = "52634175",
                Street = "Langkærevej 78"
            });

            /////////////////////// Staff //////////////////////////////////////////

            modelBuilder.Entity<Staff>().HasData(new Staff()
            {
                StaffId = 2,
                FirstName = "Jens",
                LastName = "Rasmussen",
                EmailAddress = "YTR@ertr.dk",
                MobilePhone = "63524174",
                Street = "Sønderhøj Alle 4"
            });
            modelBuilder.Entity<Staff>().HasData(new Staff()
            {
                StaffId = 3,
                FirstName = "Louis",
                LastName = "Jacobson",
                EmailAddress = "ljs@ljk.dk",
                MobilePhone = "25454175",
                Street = "Louisvej 45"
            });
            ///////////////////////////// Vehicle ///////////////////////////////////////

            //modelBuilder.Entity<Vehicle>().HasData(new Vehicle() { VehicleId = 1, VehicleModel = "BMW", RegistrationDtl = "123" });
            //modelBuilder.Entity<Vehicle>().HasData(new Vehicle() { VehicleId = 2, VehicleModel = "Mercedes", RegistrationDtl = "456" });

            //modelBuilder.Entity<Activity>().HasData(new Activity()
            //{
            //    ActivityId = 1,
            //    StartDate = new DateTime(2019, 11, 30),
            //    EndDate = new DateTime(2019, 11, 30),
            //    Price = 499,
            //    VehicleId = 2
            //});

            //modelBuilder.Entity<Activity>().HasData(new Activity()
            //{
            //    ActivityId = 2,
            //    StartDate = new DateTime(2019, 12, 12),
            //    EndDate = new DateTime(2019, 12, 12),
            //    Price = 499,
            //    VehicleId = 1
            //});
        }
    }
}
