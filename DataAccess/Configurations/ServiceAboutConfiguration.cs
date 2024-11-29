using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ServiceAboutCOnfiguration : IEntityTypeConfiguration<ServiceAbout>
    {
        public void Configure(EntityTypeBuilder<ServiceAbout> builder)
        {
            builder.ToTable("ServiceAbouts");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(3000);
        }
    }
}
