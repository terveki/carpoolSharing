﻿// <auto-generated />
using System;
using CarpoolSharing.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarpoolSharing.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CarpoolSharing.API.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarType");

                    b.Property<string>("Color");

                    b.Property<string>("Name");

                    b.Property<int>("NoOfSeats");

                    b.Property<string>("Plates");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarpoolSharing.API.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDriver");

                    b.Property<string>("Name");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CarpoolSharing.API.Models.EmployeeRide", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("RideId");

                    b.HasKey("EmployeeId", "RideId");

                    b.HasIndex("RideId");

                    b.ToTable("EmployeeRide");
                });

            modelBuilder.Entity("CarpoolSharing.API.Models.Ride", b =>
                {
                    b.Property<int>("RideId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("EndLocation");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("StartLocation");

                    b.HasKey("RideId");

                    b.HasIndex("CarId");

                    b.ToTable("Rides");
                });

            modelBuilder.Entity("CarpoolSharing.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("CarpoolSharing.API.Models.EmployeeRide", b =>
                {
                    b.HasOne("CarpoolSharing.API.Models.Employee", "Employee")
                        .WithMany("EmployeeRides")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarpoolSharing.API.Models.Ride", "Ride")
                        .WithMany("EmployeeRides")
                        .HasForeignKey("RideId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarpoolSharing.API.Models.Ride", b =>
                {
                    b.HasOne("CarpoolSharing.API.Models.Car", "Car")
                        .WithMany("Rides")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
