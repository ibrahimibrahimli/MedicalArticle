using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class HealtTipDal : IBaseRepository<HealtTip, ApplicationDbContext>, IHealtTipDal
    {
        private readonly ApplicationDbContext? _context;

        public HealtTipDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<HealtTipDto> GetHealtTipsWithItems(string lang)
        {
            var result = from healtTip in _context.HealtTips
                         .Include(r => r.Language)
                         .Where(r => r.Language.Key == lang)
                         .Where(r => r.Deleted == 0)
                         join healtTipItems in _context.HealtTipsItems on healtTip.Id equals healtTipItems.HealtTipId
                         into healtTipItemGroup
                         select new HealtTipDto
                         {
                             Id = healtTip.Id,
                             Name = healtTip.Name,
                             Surname = healtTip.Surname,
                             Header = healtTip.Header,
                             Title = healtTip.Title,
                             Description = healtTip.Description,
                             SubTitle = healtTip.SubTitle,
                             PhotoUrl = healtTip.PhotoUrl,
                             HealtTipItems = healtTipItemGroup
                             .Select(item => new HealtTipItemsDto
                             {
                                 Id = item.Id,
                                 Text = item.Text,
                             }).ToList()
                         };
            return [..result];
        }
    }
}
