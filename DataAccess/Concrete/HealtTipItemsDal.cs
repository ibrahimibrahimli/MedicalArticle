using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Concrete
{
    public class HealtTipItemsDal : BaseRepository<HealtTipItems, ApplicationDbContext>, IHealtTipItemsDal
    {
        private readonly ApplicationDbContext? _context;

        public HealtTipItemsDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<HealtTipItemsDto> GetHealtTipItemsWithHealtTip()
        {
            var result = from healtTipItems in _context.HealtTipsItems
                         where healtTipItems.Deleted == 0
                         join healtTip in _context.HealtTips on healtTipItems.HealtTipId equals healtTip.Id
                         where healtTip.Deleted == 0
                         select new HealtTipItemsDto
                         {
                             Id = healtTipItems.Id,
                             Text = healtTipItems.Text,
                             Name = healtTip.Name,
                             Surname = healtTip.Surname,
                             Header = healtTip.Header,
                             Title = healtTip.Title,
                             Description = healtTip.Description,
                             SubTitle = healtTip.SubTitle,
                             PhotoUrl = healtTip.PhotoUrl,
                         };
            return [.. result];
        }
    }
}
