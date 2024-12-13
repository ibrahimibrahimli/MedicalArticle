using Business.Abstract;
using Business.BaseMessages;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class FactManager : IFactService
    {
        private readonly IFactDal _factDal;
        private readonly IValidator<Fact> _validator;

        public FactManager(IFactDal factDal, IValidator<Fact> validator)
        {
            _factDal = factDal;
            _validator = validator;
        }

        public IResult Add(FacTCreateDto dto)
        {
            Fact model = FacTCreateDto.toFact(dto);
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
            _factDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }

        public IDataResult<List<Fact>> GetAll()
        {
            return new SuccessDataResult<List<Fact>>(_factDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Fact>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Fact>>(_factDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<Fact> GetById(int id)
        {
            return new SuccessDataResult<Fact>(_factDal.GetById(id));
        }
        public IDataResult<List<Fact>> GetDataByLanguage(string lang)
        {
            return new SuccessDataResult<List<Fact>>(_factDal.GetDataByLanguage(lang));
        }

        public IResult HardDelete(int id)
        {
            var model = GetById(id).Data;
            _factDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(model.Title));
        }

        public IResult ReturnDeleted(int id)
        {
            Fact model = GetById(id).Data;
            model.Deleted = 0;
            _factDal.Update(model);

            return new SuccessResult(UiMessages.SuccessReturnTrashMessage(model.Title));
        }

        public IResult SoftDelete(int id)
        {
            Fact model = GetById(id).Data;
            model.Deleted = id;
            _factDal.Update(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(model.Title));
        }

        public IResult Update(FactUpdateDto dto)
        {
            Fact model = FactUpdateDto.ToFact(dto);
            Fact existData = GetById(model.Id).Data;

            model.UpdatedDate = DateTime.Now;
            _factDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));

        }
    }
}