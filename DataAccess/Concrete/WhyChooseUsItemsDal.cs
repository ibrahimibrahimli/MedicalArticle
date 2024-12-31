using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Concrete
{
    public class WhyChooseUsItemsDal : IBaseRepository<WhyChooseUsItems, ApplicationDbContext>, IWhyChooseUsItemsDal
    {
        private readonly ApplicationDbContext? _context;

        public WhyChooseUsItemsDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<WhyChooseUsItemsDto> GetWhyUsItemsWidthWhyUs()
        {
            var result = from whyUsItems in _context.whyChooseUsItems
                         where whyUsItems.Deleted == 0
                         join whyUs in _context.whyChooseUs on whyUsItems.WhyChooseUsId equals whyUs.Id
                         where whyUs.Deleted == 0
                         select new WhyChooseUsItemsDto
                         {
                             Id = whyUsItems.Id,
                             Title = whyUsItems.Title,
                             Description = whyUsItems.Description,
                             WhyUsDescription = whyUs.Description,
                             WhyUsPhotoUrl = whyUs.PhotoUrl,
                         };
            return [..result];
        }
    }
}
