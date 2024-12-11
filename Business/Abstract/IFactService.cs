using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IFactService
    {
        IResult Add(FacTCreateDto dto);
        IResult Update(FactUpdateDto dto);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<Fact>> GetAll();
        IDataResult<List<Fact>> GetAllDeleted();
        IDataResult<Fact> GetById(int id);
        IResult ReturnDeleted(int id);
    }
}
