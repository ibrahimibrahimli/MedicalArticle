using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class AboutDal : IBaseRepository<About, ApplicationDbContext>, IAboutDal
    {
        private readonly ApplicationDbContext? _context;

        public AboutDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<About> GetDataByLanguage(string lang)
        {
            var data = _context.Abouts
                .Include(d => d.Language)
                .Where(d => d.Language.Key == lang)
                .Where(d => d.Deleted == 0);

            return [.. data];
        }
    }
}
