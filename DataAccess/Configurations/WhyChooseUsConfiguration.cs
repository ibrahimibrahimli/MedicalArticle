using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class WHyChooseUsConfiguration : IEntityTypeConfiguration<WhyChooseUs>
    {
        public void Configure(EntityTypeBuilder<WhyChooseUs> builder)
        {
            builder.ToTable("WhyChooseUs");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(3000);

            builder.HasOne(x => x.Language)
                .WithMany()
                .HasForeignKey(x => x.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
