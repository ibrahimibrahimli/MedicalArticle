using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IValidator<Category> _validator;

        public CategoryManager(ICategoryDal categoryDal, IValidator<Category> validator)
        {
            _categoryDal = categoryDal;
            _validator = validator;
        }

        public IResult Add(CategoryCreateDto dto)
        {
            Category model = CategoryCreateDto.ToCategory(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";

            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid) 
            {
                return new ErrorResult(errorMessage);
            }

            _categoryDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Name));

        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Category>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            Category data = _categoryDal.GetById(id);
            _categoryDal.Delete(data);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Name));
        }

        public IResult ReturnDeleted(int id)
        {
            Category data = _categoryDal.GetById(id);
            data.Deleted = 0;
            _categoryDal.Update(data);

            return new SuccessResult(UiMessages.SuccessReturnTrashMessage(data.Name));
        }

        public IResult SoftDelete(int id)
        {
            Category data = _categoryDal.GetById(id);
            data.Deleted = id;

            _categoryDal.Update(data);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(data.Name));
        }

        public IResult Update(CategoryUpdateDto dto)
        {
            Category model = CategoryUpdateDto.ToCategory(dto);
            Category existData = GetById(model.Id).Data;

            model.UpdatedDate = DateTime.Now;
            _categoryDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Name));
        }
    }
}
