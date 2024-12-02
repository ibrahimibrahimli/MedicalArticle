using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface IServiceAboutItemsDal : IBaseRepository<ServiceAboutItemDto>
    {
        List<ServiceAboutItemsDto> GetServiceAboutItemsWidthServiceAbout();
    }
}
