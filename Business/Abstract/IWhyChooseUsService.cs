using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IWhyChooseUsService
    {
        IResult Add(WhyChooseUsCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(WhyChooseUsUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<WhyChooseUs>> GetAll();
        IDataResult<List<WhyChooseUs>> GetAllDeleted();
        IDataResult<WhyChooseUs> GetById(int id);
        IResult ReturnDeleted (int id);
        IDataResult<List<WhyChooseUsDto>> GetWhyUsWithItems(string lang);
    }
}
