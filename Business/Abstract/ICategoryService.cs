using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(CategoryCreateDto dto); 
        IResult Update(CategoryUpdateDto dto);
        IDataResult<List<Category>> GetAll();
        IDataResult<List<Category>> GetAllDeleted();
        IDataResult<Category> GetById(int id);
        IResult SoftDelete (int id);
        IResult HardDelete (int id);
    }
}
