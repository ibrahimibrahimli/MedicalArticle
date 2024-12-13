using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class FactDal : BaseRepository<Fact, ApplicationDbContext>, IFactDal
    {
        private readonly ApplicationDbContext? _context;

        public FactDal(ApplicationDbContext? context)
        {
            _context = context;
        }
        public List<Fact> GetDataByLanguage(string lang)
        {
            var data = _context.Facts
                .Include(d => d.Language)
                .Where(d => d.Language.Key == lang)
                .Where(d => d.Deleted == 0);

            return [.. data];
        }
    }
}
