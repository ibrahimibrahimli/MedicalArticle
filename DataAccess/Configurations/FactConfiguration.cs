using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class FactConfiguration : IEntityTypeConfiguration<Fact>
    {
        public void Configure(EntityTypeBuilder<Fact> builder)
        {
            builder.ToTable("Facts");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.IconUrl)
           .HasMaxLength(100);
        }
    }
}
