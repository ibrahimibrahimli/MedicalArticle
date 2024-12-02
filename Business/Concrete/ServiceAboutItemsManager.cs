using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class ServiceAboutItemsManager : IServiceAboutItemsService
    {
        private readonly IServiceAboutItemsDal _serviceAboutItemsDal;
        private readonly IValidator<ServiceAboutItemDto> _validator;

        public ServiceAboutItemsManager(IValidator<ServiceAboutItemDto> validator, IServiceAboutItemsDal serviceAboutItemsDal)
        {
            _validator = validator;
            _serviceAboutItemsDal = serviceAboutItemsDal;
        }

        public IResult Add(ServiceAboutItemsCreateDto dto)
        {
            ServiceAboutItemDto model = ServiceAboutItemsCreateDto.ToServiceAboutItems(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";

            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
                return new ErrorResult(errorMessage);

            _serviceAboutItemsDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Text));
        }

        public IDataResult<List<ServiceAboutItemDto>> GetAll()
        {
            return new SuccessDataResult<List<ServiceAboutItemDto>>(_serviceAboutItemsDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<ServiceAboutItemDto>> GetAllDeleted()
        {
            return new SuccessDataResult<List<ServiceAboutItemDto>>(_serviceAboutItemsDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<ServiceAboutItemDto> GetById(int id)
        {
            return new SuccessDataResult<ServiceAboutItemDto>(_serviceAboutItemsDal.GetById(id));
        }

        public IDataResult<List<ServiceAboutItemsDto>> GetServiceAboutItemsWidthServiceAbout()
        {
            return new SuccessDataResult<List<ServiceAboutItemsDto>>(_serviceAboutItemsDal.GetServiceAboutItemsWidthServiceAbout());
        }

        public IResult HardDelete(int id)
        {
            ServiceAboutItemDto model = _serviceAboutItemsDal.GetById(id);
            _serviceAboutItemsDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(model.Text));
        }

        public IResult ReturnDeleted(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _serviceAboutItemsDal.Update(data);

            return new SuccessResult(UiMessages.SuccessReturnTrashMessage(data.Text));
        }

        public IResult SoftDelete(int id)
        {
            ServiceAboutItemDto model = _serviceAboutItemsDal.GetById(id);
            model.Deleted = id;
            _serviceAboutItemsDal.Update(model);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(model.Text));
        }

        public IResult Update(ServiceAboutItemsUpdateDto dto)
        {
            ServiceAboutItemDto model = ServiceAboutItemsUpdateDto.ToServiceAboutItems(dto);
            ServiceAboutItemDto existData = GetById(model.Id).Data;

            model.UpdatedDate = DateTime.Now;
            _serviceAboutItemsDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(existData.Text));
        }
    }
}
