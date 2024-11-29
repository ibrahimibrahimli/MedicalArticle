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
    public class ServiceAboutManager : IServiceAboutService
    {
        private readonly IServiceAboutDal _serviceAboutDal;
        private readonly IValidator<ServiceAbout> _validator;

        public ServiceAboutManager(IServiceAboutDal serviceAboutDal, IValidator<ServiceAbout> validator)
        {
            _serviceAboutDal = serviceAboutDal;
            _validator = validator;
        }

        public IResult Add(ServiceAboutCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            ServiceAbout model = ServiceAboutCreateDto.ToServiceAbout(dto);
            var validator = _validator.Validate(model);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            string errorMessage = "";

            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _serviceAboutDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }

        public IDataResult<List<ServiceAbout>> GetAll()
        {
            return new SuccessDataResult<List<ServiceAbout>>(_serviceAboutDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<ServiceAbout>> GetAllDeleted()
        {
            return new SuccessDataResult<List<ServiceAbout>>(_serviceAboutDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<ServiceAbout> GetById(int id)
        {
            return new SuccessDataResult<ServiceAbout>(_serviceAboutDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _serviceAboutDal.Delete(data);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Title));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _serviceAboutDal.Update(data);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Title));
        }

        public IResult Update(ServiceAboutUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            ServiceAbout model = ServiceAboutUpdateDto.ToServiceAbout(dto);
            ServiceAbout existData = GetById(model.Id).Data;

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);


            model.UpdatedDate = DateTime.Now;
            _serviceAboutDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));
        }
    }
}
