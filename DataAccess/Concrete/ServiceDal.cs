using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Concrete
{
    public class ServiceDal : IBaseRepository<Service, ApplicationDbContext>, IServiceDal
    {
        private readonly ApplicationDbContext _context;

        public ServiceDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ServiceDto> GetServicesWithCategory()
        {
            var result = from service in _context.Services
                         where service.Deleted == 0
                         join category in _context.Categories on service.CategoryId equals category.Id
                         where category.Deleted == 0
                         select new ServiceDto
                         {
                             Id = service.Id,
                             Title = service.Title,
                             Description = service.Description,
                             PhotoUrl = service.PhotoUrl,
                             CategoryName = category.Name,
                             CategoryIconName = category.IconName,
                         };
            return [..result];
        }
        public List<Service> GetDataByLanguage(string lang)
        {
            var data = _context.Services
                .Include(d => d.Language)
                .Where(d => d.Language.Key == lang)
                .Where(d => d.Deleted == 0);

            return [.. data];
        }
    }
}
