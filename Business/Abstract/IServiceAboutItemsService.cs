using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IServiceAboutItemsService
    {
        IResult Add(ServiceAboutItemsCreateDto dto);
        IResult Update(ServiceAboutItemsUpdateDto dto);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<ServiceAboutItemDto>> GetAll();
        IDataResult<List<ServiceAboutItemDto>> GetAllDeleted();
        IDataResult<ServiceAboutItemDto> GetById(int id);
        IResult ReturnDeleted(int id);
        IDataResult<List<ServiceAboutItemsDto>> GetServiceAboutItemsWidthServiceAbout();
    }
}
