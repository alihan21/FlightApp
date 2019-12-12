﻿// <auto-generated />
using System;
using FlightApp.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightApp.Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destination");

                    b.Property<double>("FlightDuration");

                    b.Property<string>("Origin");

                    b.Property<int?>("PlaneId");

                    b.Property<DateTime>("TimeOfDepart");

                    b.HasKey("FlightId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PassengerUserId");

                    b.HasKey("OrderId");

                    b.HasIndex("PassengerUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.OrderFood", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("FoodId");

                    b.HasKey("OrderId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("OrderFood");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxSeats");

                    b.Property<string>("Name");

                    b.HasKey("PlaneId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PlaneId");

                    b.Property<string>("SeatNumber");

                    b.HasKey("SeatId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<int?>("SeatId");

                    b.HasKey("UserId");

                    b.HasIndex("SeatId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.UserFlight", b =>
                {
                    b.Property<int>("FlightId");

                    b.Property<int>("UserId");

                    b.HasKey("FlightId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PassengerFlights");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Passenger", b =>
                {
                    b.HasBaseType("FlightApp.Backend.Models.Domain.User");

                    b.HasDiscriminator().HasValue("Passenger");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Staff", b =>
                {
                    b.HasBaseType("FlightApp.Backend.Models.Domain.User");

                    b.Property<int>("LoginCode");

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Flight", b =>
                {
                    b.HasOne("FlightApp.Backend.Models.Domain.Plane", "Plane")
                        .WithMany("PlaneFlights")
                        .HasForeignKey("PlaneId");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Order", b =>
                {
                    b.HasOne("FlightApp.Backend.Models.Domain.Passenger")
                        .WithMany("Orders")
                        .HasForeignKey("PassengerUserId");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.OrderFood", b =>
                {
                    b.HasOne("FlightApp.Backend.Models.Domain.Food", "Food")
                        .WithMany("FoodHistory")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightApp.Backend.Models.Domain.Order", "Order")
                        .WithMany("Orders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.Seat", b =>
                {
                    b.HasOne("FlightApp.Backend.Models.Domain.Plane")
                        .WithMany("Seats")
                        .HasForeignKey("PlaneId");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.User", b =>
                {
                    b.HasOne("FlightApp.Backend.Models.Domain.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId");
                });

            modelBuilder.Entity("FlightApp.Backend.Models.Domain.UserFlight", b =>
                {
                    b.HasOne("FlightApp.Backend.Models.Domain.Flight", "Flight")
                        .WithMany("Attendances")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlightApp.Backend.Models.Domain.User", "User")
                        .WithMany("UserFlights")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
