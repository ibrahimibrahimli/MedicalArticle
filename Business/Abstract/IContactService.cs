using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace Business.Abstract
{
    public interface IContactService 
    {
        IResult Add(ContactCreateDto dto);
        IResult Update(ContactUpdateDto dto);
        IDataResult<List<Contact>> GetAll();
        IDataResult<List<Contact>> GetAllDeleted();
        IDataResult<Contact> GetById(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
    }
}
