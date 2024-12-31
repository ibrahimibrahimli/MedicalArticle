using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ServiceAboutDal : IBaseRepository<ServiceAbout, ApplicationDbContext>, IServiceAboutDal
    {
        private readonly ApplicationDbContext? _context;

        public ServiceAboutDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<ServiceAboutDto> GetServiceAboutWithItems(string lang)
        {
            var result = from serviceAbout in _context.ServiceAbouts
                         .Include(r => r.Language)
                         .Where(r => r.Language.Key == lang)
                         .Where(r => r.Deleted == 0)
                         join serviceAboutItems in _context.ServiceAboutItems
                         on serviceAbout.Id equals serviceAboutItems.ServiceAboutId 
                         into serviceAboutItemGroup
                         
                         select new ServiceAboutDto
                         {
                             Id = serviceAbout.Id,
                             Description = serviceAbout.Description,
                             Title = serviceAbout.Title,
                             PhotoUrl = serviceAbout.PhotoUrl,
                             LanguageId = serviceAbout.LanguageId,
                             ServiceAboutItems = serviceAboutItemGroup
                                 .Where(item => item.Deleted ==0)
                                 .Select(item => new ServiceAboutItems
                                 {
                                     Id = item.Id,
                                     Text = item.Text,

                                 }).ToList()
                         };

            return [..result];
        }

    }
}
