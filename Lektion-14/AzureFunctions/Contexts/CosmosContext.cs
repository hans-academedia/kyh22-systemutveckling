using AzureFunctions.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctions.Contexts
{
    public class CosmosContext : DbContext
    {
        public CosmosContext()
        {

        }

        public CosmosContext(DbContextOptions<CosmosContext> options) : base(options)
        {
        }

        public DbSet<DeviceItemMessage> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceItemMessage>(entity =>
            {
                entity.HasKey(k => k.DeviceId);
                entity.ToContainer("Messages");
                entity.HasPartitionKey(x => x.PartitionKey);
            });
        }
    }
}
