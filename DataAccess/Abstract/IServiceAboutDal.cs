using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IServiceAboutDal : IBaseRepository<ServiceAbout>
    {
        List<ServiceAboutDto> GetServiceAboutWithItems();
        List<ServiceAbout> GetDataByLanguage(string lang);
    }
}
