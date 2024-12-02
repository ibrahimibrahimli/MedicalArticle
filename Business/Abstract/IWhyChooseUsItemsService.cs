using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IWhyChooseUsItemsService
    {
        IResult Add(WhyChooseUsItemsCreateDto dto);
        IResult Update(WhyChooseUsItemsUpdateDto dto);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<WhyChooseUsItems>> GetAll();
        IDataResult<List<WhyChooseUsItems>> GetAllDeleted();
        IDataResult<WhyChooseUsItems> GetById(int id);
        IResult ReturnDeleted (int id);
    }
}
