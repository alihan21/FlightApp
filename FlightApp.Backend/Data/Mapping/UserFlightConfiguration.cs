using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightApp.Backend.Data.Mapping
{
  public class UserFlightConfiguration : IEntityTypeConfiguration<UserFlight>
  {
    public void Configure(EntityTypeBuilder<UserFlight> builder)
    {
      builder.HasKey(b => new { b.FlightId, b.UserId });
      builder.ToTable("UserFlight");
    }
  }
}
