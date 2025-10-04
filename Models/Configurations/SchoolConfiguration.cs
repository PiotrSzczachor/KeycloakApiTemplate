using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;

namespace Models.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(u => u.Guid);

            builder.Property(u => u.Guid)
                   .ValueGeneratedNever();

            builder.HasMany(u => u.Users)
               .WithOne(ue => ue.School)
               .HasForeignKey(ue => ue.SchoolGuid);

            builder.HasOne(u => u.Address)
                .WithOne()
                .HasForeignKey<School>(u => u.AddressGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}