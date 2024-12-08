using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Concrete
{
    public class HealtTipDal : BaseRepository<HealtTip, ApplicationDbContext>, IHealtTipDal
    {
        private readonly ApplicationDbContext? _context;

        public HealtTipDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<HealtTipDto> GetHealtTipsWithItems()
        {
            var result = from healtTip in _context.HealtTips
                         where healtTip.Deleted == 0
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
