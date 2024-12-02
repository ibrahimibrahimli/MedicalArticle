using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ServiceAboutItemsConfiguration : IEntityTypeConfiguration<ServiceAboutItemDto>
    {
        public void Configure(EntityTypeBuilder<ServiceAboutItemDto> builder)
        {
            builder.ToTable("ServiceAboutItems");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(3000);
        }
    }
}
