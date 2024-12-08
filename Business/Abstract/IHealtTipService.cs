using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IHealtTipService
    {
        IResult Add(HealtTipCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(HealtTipUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<HealtTip>> GetAll();
        IDataResult<List<HealtTip>> GetAllDeleted();
        IDataResult<HealtTip> GetById(int id);
        IResult ReturnDeleted (int id);
        IDataResult<List<HealtTipDto>> GetHealtTipsWithItems();
    }
}
