using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ServiceAboutDal : BaseRepository<ServiceAbout, ApplicationDbContext>, IServiceAboutDal
    {
        private readonly ApplicationDbContext? _context;

        public ServiceAboutDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<ServiceAboutDto> GetServiceAboutWithItems()
        {
            var result = from serviceAbout in _context.ServiceAbouts
                         where serviceAbout.Deleted == 0
                         join serviceAboutItems in _context.ServiceAboutItems
                         on serviceAbout.Id equals serviceAboutItems.ServiceAboutId into serviceAboutItemGroup
                         select new ServiceAboutDto
                         {
                             Id = serviceAbout.Id,
                             Description = serviceAbout.Description,
                             Title = serviceAbout.Title,
                             PhotoUrl = serviceAbout.PhotoUrl,
                             ServiceAboutItems = serviceAboutItemGroup
                                 .Select(item => new ServiceAboutItemDto
                                 {
                                     Id = item.Id,
                                     Text = item.Text,

                                 })
                                 .ToList()
                         };

            return [.. result];
        }


        public List<ServiceAbout> GetDataByLanguage(string lang)
        {
            var data = _context.ServiceAbouts
                .Include(d => d.Language)
                .Where(d => d.Language.Key == lang)
                .Where(d => d.Deleted == 0);

            return [.. data];
        }

    }
}
