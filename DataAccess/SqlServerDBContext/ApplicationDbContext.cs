
using Entities.Concrete.TableModels.Membership;
using Entities.TableModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.SqlServerDBContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = LAPTOP-JBUKPKDJ;
                                         Initial Catalog = MedicalArticlesDB;
                                         Integrated Security= true;Encrypt = false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<HealtTip> HealtTips { get; set; }
        public DbSet<HealtTipItems> HealtTipsItems { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceAbout> ServiceAbouts { get; set; }
        public DbSet<ServiceAboutItemDto> ServiceAboutItems { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Sosial> Sosials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<TeamBoard> TeamBoards { get; set; }
        public DbSet<WhyChooseUs> whyChooseUs { get; set; }
        public DbSet<WhyChooseUsItems> whyChooseUsItems { get; set; }
    }
}
