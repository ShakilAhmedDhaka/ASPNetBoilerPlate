using Entities.Models;
using Entities.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    class UCredentialConfiguration : IEntityTypeConfiguration<UCredential>
    {
        public void Configure(EntityTypeBuilder<UCredential> builder)
        {
            // One-to-One Relation between UCredential and UProfile
            builder.ToTable("UCredential");
            builder.HasOne(a => a.Uprofile)
                .WithOne(b => b.Ucredential)
                .HasForeignKey<UProfile>(b => b.UserId);

            // Getting seed data for UCredential Table
            builder.HasData(UCredentialSeeds.GetCredSeeds());
        }
    }
}
