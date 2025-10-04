using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;

namespace Models.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(u => u.Guid);

            builder.Property(u => u.Guid)
                   .ValueGeneratedNever();

            builder.HasOne(u => u.User)
                .WithOne()
                .HasForeignKey<Organization>(u => u.UserGuid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(u => u.Address)
                .WithOne()
                .HasForeignKey<Organization>(u => u.AddressGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
