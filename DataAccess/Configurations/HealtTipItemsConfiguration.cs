using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.Configurations
{
    public class HealtTipItemsConfiguration : IEntityTypeConfiguration<HealtTipItems>
    {
        public void Configure(EntityTypeBuilder<HealtTipItems> builder)
        {
            builder.ToTable("HealtTipItems");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Text)
               .IsRequired()
            .HasMaxLength(1000);



            builder.HasOne(x => x.HealtTip)
      .WithMany(x => x.HealtTipItems)
      .HasForeignKey(x => x.HealtTipId)
      .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
