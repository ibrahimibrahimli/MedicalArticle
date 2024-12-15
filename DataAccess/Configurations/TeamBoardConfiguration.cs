using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TeamBoardConfiguration : IEntityTypeConfiguration<TeamBoard>
    {
        public void Configure(EntityTypeBuilder<TeamBoard> builder)
        {
            builder.ToTable("TeamBoards");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Profession)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.FacebookUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.InstagramUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LinkedinUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(h => h.Language)
               .WithMany()
               .HasForeignKey(h => h.LanguageId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
