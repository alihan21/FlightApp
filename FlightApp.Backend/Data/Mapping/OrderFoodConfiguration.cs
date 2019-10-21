using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlightApp.Backend.Data.Mapping
{
    public class OrderFoodConfiguration : IEntityTypeConfiguration<OrderFood>
    {
        public void Configure(EntityTypeBuilder<OrderFood> builder)
        {
            builder.HasKey(b => new { b.OrderId, b.FoodId});
        }
    }
}
