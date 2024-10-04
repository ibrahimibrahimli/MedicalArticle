using Business.Abstract;
using Core.Results.Abstract;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IValidator<Category> _validator;
        public IResult Add(CategoryCreateDto dto)
        {
            //Category model = CategoryCreateDto.ToCategory(dto);
            //var validator = _validator.Validate(model);

            //string errorMessage = "";

            //foreach (var error in validator.Errors) 
            //{

            //}

            throw new NotImplementedException();

        }

        public IDataResult<List<CategoryDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryDto>> GetAllDeleted()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CategoryDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult HardDelete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CategoryUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
