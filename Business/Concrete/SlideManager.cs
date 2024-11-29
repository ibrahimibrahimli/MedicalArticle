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
    public class SlideManager : ISlideService
    {
        private readonly ISlideDal _slideDal;
        private readonly IValidator<Slide> _validator;

        public SlideManager(ISlideDal slide, IValidator<Slide> validator)
        {
            _slideDal = slide;
            _validator = validator;
        }

        public IResult Add(SlideCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            Slide model = SlideCreateDto.ToSlide(dto);
            var validator  = _validator.Validate(model);
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

            _slideDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }

        public IDataResult<List<Slide>> GetAll()
        {
            return new SuccessDataResult<List<Slide>>(_slideDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Slide>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Slide>>(_slideDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<Slide> GetById(int id)
        {
            return new SuccessDataResult<Slide>(_slideDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            Slide model = GetById(id).Data;
            _slideDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(model.Title));
        }

        public IResult ReturnDeleted(int id)
        {
            Slide model = GetById(id).Data;
            model.Deleted = 0;
            _slideDal.Update(model);
            return new SuccessResult(UiMessages.SuccessReturnTrashMessage(model.Title));
        }

        public IResult SoftDelete(int id)
        {
            Slide model = GetById(id).Data;
            model.Deleted = id;
            _slideDal.Update(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(model.Title));
        }

        public IResult Update(SlideUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            Slide model = SlideUpdateDto.ToSlide(dto);
            Slide existData = GetById(model.Id).Data;

            if(photoUrl is null) 
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _slideDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));
        }
    }
}
