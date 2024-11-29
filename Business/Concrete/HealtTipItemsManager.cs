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
    public class HealtTipItemsManager : IHealtTipItemsService
    {
        private readonly IHealtTipItemsDal _healtTipItemsDal;
        private readonly IValidator<HealtTipItems> _validator;

        public HealtTipItemsManager(IHealtTipItemsDal healtTipItemsDal, IValidator<HealtTipItems> validator)
        {
            _healtTipItemsDal = healtTipItemsDal;
            _validator = validator;
        }

        public IResult Add(HealtTipItemsCreateDto dto)
        {
            HealtTipItems model = HealtTipItemsCreateDto.ToHealtTipItems(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";

            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
                return new ErrorResult(errorMessage);

            _healtTipItemsDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Text));
        }

        public IDataResult<List<HealtTipItems>> GetAll()
        {
            return new SuccessDataResult<List<HealtTipItems>>(_healtTipItemsDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<HealtTipItems>> GetAllDeleted()
        {
            return new SuccessDataResult<List<HealtTipItems>>(_healtTipItemsDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<HealtTipItems> GetById(int id)
        {
            return new SuccessDataResult<HealtTipItems>(_healtTipItemsDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            HealtTipItems model = _healtTipItemsDal.GetById(id);
            _healtTipItemsDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(model.Text));
        }

        public IResult SoftDelete(int id)
        {
            HealtTipItems model = _healtTipItemsDal.GetById(id);
            model.Deleted = id;
            _healtTipItemsDal.Update(model);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(model.Text));
        }

        public IResult Update(HealtTipItemsUpdateDto dto)
        {
            HealtTipItems model = HealtTipItemsUpdateDto.ToHealtTipItems(dto);
            HealtTipItems existData = GetById(model.Id).Data;

            model.UpdatedDate = DateTime.Now;
            _healtTipItemsDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(existData.Text));
        }
    }
}
