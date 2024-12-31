using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class WhyChooseUsDal : IBaseRepository<WhyChooseUs, ApplicationDbContext>, IWhyChooseUsDal
    {
        private readonly ApplicationDbContext? _context;

        public WhyChooseUsDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<WhyChooseUsDto> GetWhyUsWithItems(string lang)
        {
            var result = from whyUs in _context.whyChooseUs
                         .Include(r => r.Language)
                         .Where(r => r.Language.Key == lang)
                         .Where(r => r.Deleted == 0)
                         join WhyChooseUsItems in _context.whyChooseUsItems
                         on whyUs.Id equals WhyChooseUsItems.WhyChooseUsId
                         into whyChooesUsItemGroup

                         select new WhyChooseUsDto
                         {
                             Id = whyUs.Id,
                             Description = whyUs.Description,
                             PhotoUrl = whyUs.PhotoUrl,
                             LanguageId = whyUs.LanguageId,
                             WhyChooseUsItems = whyChooesUsItemGroup
                                 .Where(item => item.Deleted == 0)
                                 .Select(item => new WhyChooseUsItems
                                 {
                                     Id = item.Id,
                                     Title = item.Title,
                                     Description = item.Description,

                                 }).ToList()
                         };

            return [.. result];
        }
    }
}
