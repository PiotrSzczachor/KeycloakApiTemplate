using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;

namespace Models.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(u => u.Guid);

            builder.HasOne(u => u.Organization)
                .WithOne()
                .HasForeignKey<Event>(u => u.OrganizationGuid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(u => u.Address)
                .WithOne()
                .HasForeignKey<Event>(u => u.AddressGuid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.UserEvents)
                   .WithOne(ue => ue.Event)
                   .HasForeignKey(ue => ue.EventGuid);

        }
    }
}
