using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlightApp.Backend.Data.Mapping
{
    public class PassengerFlightConfiguration : IEntityTypeConfiguration<PassengerFlight>
    {
        public void Configure(EntityTypeBuilder<PassengerFlight> builder)
        {
            builder.HasKey(b => new { b.FlightId, b.PassengerId });
        }
    }
}
