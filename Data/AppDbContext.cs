using Microsoft.EntityFrameworkCore;
using Models.Configurations;
using Models.Domain;

namespace Data
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserEventConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
