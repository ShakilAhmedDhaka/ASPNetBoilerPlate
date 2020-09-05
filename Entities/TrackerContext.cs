using Entities.Configurations;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> opt) : base(opt)
        {
            
        }

        public DbSet<UProfile> UProfiles { get; set; }
        public DbSet<UCredential> UCredentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UCredentialConfiguration());
            modelBuilder.ApplyConfiguration(new UProfileConfiguration());
        }

    }
}