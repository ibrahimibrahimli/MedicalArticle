using Business.Abstract;
using Business.BaseMessages;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;
        private readonly IValidator<Service> _validator;

        public ServiceManager(IServiceDal serviceDal, IValidator<Service> validator)
        {
            _serviceDal = serviceDal;
            _validator = validator;
        }

        public IResult Add(ServiceCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            Service model = ServiceCreateDto.ToService(dto);
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

            _serviceDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage($"{model.Id} nömrəli servis"));
        }

        public IDataResult<List<Service>> GetAll()
        {
            return new SuccessDataResult<List<Service>>(_serviceDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Service>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Service>>(_serviceDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<Service> GetById(int id)
        {
            return new SuccessDataResult<Service>(_serviceDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            var model = GetById(id).Data;
            _serviceDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage($"{model.Id} nömrəli servis"));
        }

        public IResult ReturnDeleted(int id)
        {
            Service model = GetById(id).Data;
            model.Deleted = 0;
            _serviceDal.Update(model);

            return new SuccessResult(UiMessages.SuccessReturnTrashMessage(model.Title));
        }

        public IResult SoftDelete(int id)
        {
            var model = GetById(id).Data;
            model.Deleted = id;
            _serviceDal.Update(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage($"{model.Id} nömrəli servis"));
        }

        public IResult Update(ServiceUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            Service model = ServiceUpdateDto.ToService(dto);
            Service existData = GetById(model.Id).Data;

            if(photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _serviceDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage($"{model.Id} nömrəli servis"));

        }
    }
}
