using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class AdressDal : BaseRepository<Adress, ApplicationDbContext> ,IAdressDal
    {
        private readonly ApplicationDbContext? _context;

        public AdressDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<Adress> GetDataByLanguage(string lang)
        {
            var data = _context.Adresses
                .Include(d => d.Language)
                .Where(d => d.Language.Key == lang)
                .Where(d => d.Deleted == 0);

            return [.. data];
        }
    }
}
