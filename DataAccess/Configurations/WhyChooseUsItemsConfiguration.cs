using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class WhyChooseUsItemsConfiguration : IEntityTypeConfiguration<WhyChooseUsItems>
    {
        public void Configure(EntityTypeBuilder<WhyChooseUsItems> builder)
        {
            builder.ToTable("WhyChooseUsItems");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(3000);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(3000);

            builder.HasOne(x => x.WhyChooseUs)
               .WithMany(x => x.WhyChooseUsItems)
               .HasForeignKey(x => x.WhyChooseUsId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
