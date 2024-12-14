using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IServiceDal : IBaseRepository<Service>
    {
        List<ServiceDto> GetServicesWithCategory();
        List<Service> GetDataByLanguage(string lang);
    }
}
