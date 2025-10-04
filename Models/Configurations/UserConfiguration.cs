using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;
using System.Reflection.Emit;

namespace Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Guid);

            // Id nie jest generowane automatycznie bo będziemy przypisywać je z keycloaka
            builder.Property(u => u.Guid)
                   .ValueGeneratedNever();

            builder.HasOne(u => u.Organization)
                .WithOne() 
                .HasForeignKey<User>(u => u.OrganizationGuid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(u => u.School)
                .WithOne()
                .HasForeignKey<User>(u => u.SchoolGuid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.UserEvents)
                   .WithOne(ue => ue.User)
                   .HasForeignKey(ue => ue.UserGuid);


            builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Surname).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
        }
    }
}
