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
    public class WhyChooseUsItemsManager : IWhyChooseUsItemsService
    {
        private readonly IWhyChooseUsItemsDal _whyChooseUsItemsDal;
        private readonly IValidator<WhyChooseUsItems> _validator;

        public WhyChooseUsItemsManager(IWhyChooseUsItemsDal whyChooseUsItemsDal, IValidator<WhyChooseUsItems> validator)
        {
            _whyChooseUsItemsDal = whyChooseUsItemsDal;
            _validator = validator;
        }

        public IResult Add(WhyChooseUsItemsCreateDto dto)
        {
            WhyChooseUsItems model = WhyChooseUsItemsCreateDto.ToWhyChooseUsItems(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";

            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
                return new ErrorResult(errorMessage);

            _whyChooseUsItemsDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage($"{model.Id}"));
        }

        public IDataResult<List<WhyChooseUsItems>> GetAll()
        {
            return new SuccessDataResult<List<WhyChooseUsItems>>(_whyChooseUsItemsDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<WhyChooseUsItems>> GetAllDeleted()
        {
            return new SuccessDataResult<List<WhyChooseUsItems>>(_whyChooseUsItemsDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<WhyChooseUsItems> GetById(int id)
        {
            return new SuccessDataResult<WhyChooseUsItems>(_whyChooseUsItemsDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            WhyChooseUsItems model = _whyChooseUsItemsDal.GetById(id);
            _whyChooseUsItemsDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage($"{model.Id}"));
        }

        public IResult ReturnDeleted(int id)
        {
            WhyChooseUsItems data = GetById(id).Data;
            data.Deleted = 0;
            _whyChooseUsItemsDal.Update(data);

            return new SuccessResult(UiMessages.SuccessReturnTrashMessage(data.Title)); 
        }

        public IResult SoftDelete(int id)
        {
            WhyChooseUsItems model = _whyChooseUsItemsDal.GetById(id);
            model.Deleted = id;
            _whyChooseUsItemsDal.Update(model);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage($"{model.Id}"));
        }

        public IResult Update(WhyChooseUsItemsUpdateDto dto)
        {
            WhyChooseUsItems model = WhyChooseUsItemsUpdateDto.ToWhyChooseUsItems(dto);
            WhyChooseUsItems existData = GetById(model.Id).Data;

            model.UpdatedDate = DateTime.Now;
            _whyChooseUsItemsDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage($"{model.Id}"));
        }
    }
}
