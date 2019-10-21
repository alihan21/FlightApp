using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlightApp.Backend.Data.Mapping
{
    public class StaffFlightConfiguration : IEntityTypeConfiguration<StaffFlight>
    {
        public void Configure(EntityTypeBuilder<StaffFlight> builder)
        {
            builder.HasKey(b => new { b.StaffId, b.FlightId});
        }
    }
}
