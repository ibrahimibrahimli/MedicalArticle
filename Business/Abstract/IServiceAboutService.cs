using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IServiceAboutService
    {
        IResult Add(ServiceAboutCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(ServiceAboutUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<ServiceAbout>> GetAll();
        IDataResult<List<ServiceAbout>> GetAllDeleted();
        IDataResult<ServiceAbout> GetById(int id);
        IResult ReturnDeleted (int id);
        IDataResult<List<ServiceAboutDto>> GetServiceAboutWithItems();
    }
}
