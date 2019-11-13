using FlightApp.Backend.Data.Mapping;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.Backend.Data
{
    public class FlightAppContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PassengerFlight> PassengerFlights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> FlightStaff { get; set; }

        public FlightAppContext(DbContextOptions<FlightAppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PassengerFlightConfiguration());
            builder.ApplyConfiguration(new StaffFlightConfiguration());
            builder.ApplyConfiguration(new OrderFoodConfiguration());
        }
    }
}
