using Entities.Models;
using Entities.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
namespace Entities.Configurations
{
    class UProfileConfiguration : IEntityTypeConfiguration<UProfile>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UProfile> builder)
        {
            builder.ToTable("UProfile");
            
            // Getting seed data for UProfile table.
            builder.HasData(UProfileSeeds.GetProfileSeeds());
        }
    }
}
