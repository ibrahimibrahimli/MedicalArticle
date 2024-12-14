using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ServiceAboutItemsConfiguration : IEntityTypeConfiguration<ServiceAboutItems>
    {
        public void Configure(EntityTypeBuilder<ServiceAboutItems> builder)
        {
            builder.ToTable("ServiceAboutItems");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(3000);

            builder.HasOne(x => x.ServiceAbout)
                .WithMany(x => x.ServiceAboutItems)
                .HasForeignKey(x => x.ServiceAboutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
