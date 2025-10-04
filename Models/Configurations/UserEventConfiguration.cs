using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;
using System.Reflection.Emit;

namespace Models.Configurations
{
    public class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
    {
        public void Configure(EntityTypeBuilder<UserEvent> builder)
        {
            builder.HasKey(ue => new { ue.UserGuid, ue.EventGuid});

            builder.HasOne(ue => ue.User)
                   .WithMany(u => u.UserEvents)
                   .HasForeignKey(ue => ue.UserGuid);

            builder.HasOne(ue => ue.Event)
                   .WithMany(e => e.UserEvents)
                   .HasForeignKey(ue => ue.EventGuid);
        }
    }
}
