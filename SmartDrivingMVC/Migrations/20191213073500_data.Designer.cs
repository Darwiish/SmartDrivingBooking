﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartDrivingMVCDAL.Data;

namespace SmartDrivingMVC.Migrations
{
    [DbContext(typeof(SmartDrivingContext))]
    [Migration("20191213073500_data")]
    partial class data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.ActivityType", b =>
                {
                    b.Property<int>("ActivityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("Price");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.Property<int?>("VehicleId");

                    b.HasKey("ActivityTypeId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ActivityType");
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.BookingLog", b =>
                {
                    b.Property<int>("BookingLogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityTypeId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int?>("StaffId");

                    b.HasKey("BookingLogId");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.ToTable("BookingLog");
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AspNetUserId");

                    b.Property<DateTime>("DateBirth");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(100);

                    b.Property<int?>("PostalDistrictId");

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.HasKey("CustomerId");

                    b.HasIndex("PostalDistrictId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.Evaluation", b =>
                {
                    b.Property<int>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityTypeId");

                    b.Property<string>("Description");

                    b.Property<string>("Resulte");

                    b.Property<string>("Title");

                    b.HasKey("EvaluationId");

                    b.HasIndex("ActivityTypeId");

                    b.ToTable("Evaluation");
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.PostalDistrict", b =>
                {
                    b.Property<int>("PostalDistrictId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int>("Zipcode");

                    b.HasKey("PostalDistrictId");

                    b.ToTable("PostalDistrict");
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MobilePhone");

                    b.Property<int?>("PostalDistrictId");

                    b.Property<string>("Street");

                    b.HasKey("StaffId");

                    b.HasIndex("PostalDistrictId");

                    b.ToTable("Staff");

                    b.HasData(
                        new { StaffId = 1, EmailAddress = "has@ertr.dk", FirstName = "Hashi", LastName = "Booba", MobilePhone = "52634175", Street = "Langkærevej 78" },
                        new { StaffId = 2, EmailAddress = "YTR@ertr.dk", FirstName = "Jens", LastName = "Rasmussen", MobilePhone = "63524174", Street = "Sønderhøj Alle 4" },
                        new { StaffId = 3, EmailAddress = "ljs@ljk.dk", FirstName = "Louis", LastName = "Jacobson", MobilePhone = "25454175", Street = "Louisvej 45" }
                    );
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RegistrationDtl");

                    b.Property<string>("VehicleModel");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.ActivityType", b =>
                {
                    b.HasOne("SmartDrivingMVC.Models.Vehicle", "Vehicle")
                        .WithMany("ActivityType")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.BookingLog", b =>
                {
                    b.HasOne("SmartDrivingMVC.Models.ActivityType", "ActivityType")
                        .WithMany("BookingLog")
                        .HasForeignKey("ActivityTypeId");

                    b.HasOne("SmartDrivingMVC.Models.Customer", "Customer")
                        .WithMany("BookingLogs")
                        .HasForeignKey("CustomerId");

                    b.HasOne("SmartDrivingMVC.Models.Staff", "Staff")
                        .WithMany("BookingLogs")
                        .HasForeignKey("StaffId");
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.Customer", b =>
                {
                    b.HasOne("SmartDrivingMVC.Models.PostalDistrict", "PostalDistrict")
                        .WithMany("Customers")
                        .HasForeignKey("PostalDistrictId");
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.Evaluation", b =>
                {
                    b.HasOne("SmartDrivingMVC.Models.ActivityType", "ActivityType")
                        .WithMany()
                        .HasForeignKey("ActivityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartDrivingMVC.Models.Staff", b =>
                {
                    b.HasOne("SmartDrivingMVC.Models.PostalDistrict", "PostalDistrict")
                        .WithMany()
                        .HasForeignKey("PostalDistrictId");
                });
#pragma warning restore 612, 618
        }
    }
}
