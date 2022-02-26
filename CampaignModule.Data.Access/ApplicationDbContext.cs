using CampaignModule.Data.Access.Entity;
using Microsoft.EntityFrameworkCore;

namespace CampaignModule.Data.Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Campaigns>()
                .HasKey(x => new { x.Name, x.ProductCode });

            //base.OnModelCreating(builder);
        }

        public DbSet<Campaigns> Campaigns { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
