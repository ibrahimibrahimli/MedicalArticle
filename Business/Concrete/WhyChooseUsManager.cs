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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concrete
{
    public class WhyChooseUsManager : IWhyChooseUsService
    {
        private readonly IWhyChooseUsDal _whyChooseUsDal;
        private readonly IValidator<WhyChooseUs> _validator;

        public WhyChooseUsManager(IWhyChooseUsDal whyChooseUsDal, IValidator<WhyChooseUs> validator)
        {
            _whyChooseUsDal = whyChooseUsDal;
            _validator = validator;
        }

        public IResult Add(WhyChooseUsCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            WhyChooseUs model = WhyChooseUsCreateDto.ToWhyChooseUs(dto);
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

            _whyChooseUsDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage($"{model.Id}"));
        }

        public IDataResult<List<WhyChooseUs>> GetAll()
        {
            return new SuccessDataResult<List<WhyChooseUs>>(_whyChooseUsDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<WhyChooseUs>> GetAllDeleted()
        {
            return new SuccessDataResult<List<WhyChooseUs>>(_whyChooseUsDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<WhyChooseUs> GetById(int id)
        {
            return new SuccessDataResult<WhyChooseUs>(_whyChooseUsDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _whyChooseUsDal.Delete(data);

            return new SuccessResult(UiMessages.SuccessDeletedMessage($"{data.Id}"));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _whyChooseUsDal.Update(data);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage($"{data.Id}"));
        }

        public IResult Update(WhyChooseUsUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            WhyChooseUs model = WhyChooseUsUpdateDto.ToWhyChooseUs(dto);
            WhyChooseUs existData = GetById(model.Id).Data;

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);


            model.UpdatedDate = DateTime.Now;
            _whyChooseUsDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage($"{model.Id}"));
        }
    }
}
