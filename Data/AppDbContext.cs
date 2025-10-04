using Microsoft.EntityFrameworkCore;
using Models.Configurations;
using Models.Domain;

namespace Data
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Event> Addresses { get; set; } = default!;
        public DbSet<Event> Schools { get; set; } = default!;
        public DbSet<Event> Organizations { get; set; } = default!;
        public DbSet<Event> UsersEvents { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserEventConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
