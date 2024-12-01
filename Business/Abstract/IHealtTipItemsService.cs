using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IHealtTipItemsService
    {
        IResult Add(HealtTipItemsCreateDto dto);
        IResult Update(HealtTipItemsUpdateDto dto);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<HealtTipItems>> GetAll();
        IDataResult<List<HealtTipItems>> GetAllDeleted();
        IDataResult<HealtTipItems> GetById(int id);
        IResult ReturnDeleted (int id); 
    }
}
