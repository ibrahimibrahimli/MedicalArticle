using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult Add(BlogCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(BlogUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IDataResult<List<Blog>> GetAll();
        IDataResult<List<Blog>> GetAllDeleted();
        IDataResult<Blog> GetById(int id);
        IDataResult<BlogDto> GetDtoById(int id, string lang);
        IResult HardDelete(int id);
        IResult SoftDelete(int id);
        IResult ReturnDeleted(int id);
        IDataResult<List<BlogDto>> GetDataByLanguage(string lang);
    }
}
