using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(x => x.PhotoUrl)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
