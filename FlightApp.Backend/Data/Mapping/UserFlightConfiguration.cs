﻿using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlightApp.Backend.Data.Mapping
{
    public class UserFlightConfiguration : IEntityTypeConfiguration<UserFlight>
    {
        public void Configure(EntityTypeBuilder<UserFlight> builder)
        {
            builder.HasKey(b => new { b.FlightId, b.UserId });
        }
    }
}