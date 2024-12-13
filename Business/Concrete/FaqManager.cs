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
    public class FaqManager : IFaqService
    {

        private readonly IFaqDal _faqDal;
        private readonly IValidator<Faq> _validator;

        public FaqManager(IFaqDal faqDal, IValidator<Faq> validator)
        {
            _faqDal = faqDal;
            _validator = validator;
        }

        public IResult Add(FaqCreateDto dto)
        {
            Faq model = FaqCreateDto.ToFaq(dto);
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

            _faqDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage($"{model.Id} nömrəli sual"));
        }

        public IDataResult<List<Faq>> GetAll()
        {
            return new SuccessDataResult<List<Faq>>(_faqDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Faq>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Faq>>(_faqDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<Faq> GetById(int id)
        {
            return new SuccessDataResult<Faq>(_faqDal.GetById(id));
        }

        public IDataResult<List<Faq>> GetDataByLanguage(string lang)
        {
            return new SuccessDataResult<List<Faq>>(_faqDal.GetDataByLanguage(lang));
        }

        public IResult HardDelete(int id)
        {
            Faq data = GetById(id).Data;
            _faqDal.Delete(data);
            return new SuccessResult(UiMessages.SuccessDeletedMessage($"{data.Id} nömrəli sual"));
        }

        public IResult ReturnDeleted(int id)
        {
            Faq model = GetById(id).Data;
            model.Deleted = 0;
            _faqDal.Update(model);
            return new SuccessResult(UiMessages.SuccessReturnTrashMessage($"{model.Id} nömrəli sual"));
        }

        public IResult SoftDelete(int id)
        {
            Faq model = GetById(id).Data;
            model.Deleted = id;
            _faqDal.Update(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage($"{model.Id} nömrəli sual"));
        }

        public IResult Update(FaqUpdateDto dto)
        {
            Faq model = FaqUpdateDto.ToFaq(dto);
            Faq existData = GetById(model.Id).Data;
            model.UpdatedDate = DateTime.Now;

            _faqDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage($"{model} nömrəli sual"));
        }
    }
}
