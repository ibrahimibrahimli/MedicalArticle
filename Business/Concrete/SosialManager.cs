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
    public class SosialManager : ISosialService
    {
        private readonly ISosialDal _sosialDal;
        private readonly IValidator<Sosial> _validator;

        public SosialManager(ISosialDal sosialDal, IValidator<Sosial> validator)
        {
            _sosialDal = sosialDal;
            _validator = validator;
        }

        public IResult Add(SosialCreateDto dto)
        {
            Sosial model = SosialCreateDto.ToSosial(dto);
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

            _sosialDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage($"{model.Id} nömrəli əlaqə"));
        }

        public IDataResult<List<Sosial>> GetAll()
        {
            return new SuccessDataResult<List<Sosial>>(_sosialDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Sosial>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Sosial>>(_sosialDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<Sosial> GetById(int id)
        {
            return new SuccessDataResult<Sosial>(_sosialDal.GetById(id));
        }
        public IResult HardDelete(int id)
        {
            Sosial model = GetById(id).Data;
            _sosialDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage($"{model.Id} nömrəli əlaqə"));
        }

        public IResult ReturnDeleted(int id)
        {
            Sosial model = GetById(id).Data;
            model.Deleted = 0;
            _sosialDal.Update(model);

            return new SuccessResult(UiMessages.SuccessReturnTrashMessage($"{model.Id} nömrəli əlaqə"));
        }

        public IResult SoftDelete(int id)
        {
            Sosial model = GetById(id).Data;
            model.Deleted = id;
            _sosialDal.Update(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage($"{model.Id} nömrəli əlaqə"));
        }

        public IResult Update(SosialUpdateDto dto)
        {
            Sosial model = SosialUpdateDto.ToSosial(dto);
            Sosial existData = GetById(model.Id).Data;
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

            model.UpdatedDate = DateTime.Now;
            _sosialDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage($"{model.Id} nömrəli əlaqə"));

        }
    }
}
