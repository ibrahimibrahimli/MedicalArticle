using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class HealtTipConfiguration : IEntityTypeConfiguration<HealtTip>
    {
        public void Configure(EntityTypeBuilder<HealtTip> builder)
        {
            builder.ToTable("HealtTips");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(3000);

            builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(x => x.Surname)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(x => x.Header)
               .IsRequired()
               .HasMaxLength(3000);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.SubTitle)
               .IsRequired()
               .HasMaxLength(1000);
        }
    }
}
