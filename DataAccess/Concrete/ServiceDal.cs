using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete
{
    public class ServiceDal : BaseRepository<Service, ApplicationDbContext>, IServiceDal
    {
    }
}
