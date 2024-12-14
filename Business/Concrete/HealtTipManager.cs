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
    public class HealtTipManager : IHealtTipService
    {
        private readonly IHealtTipDal _healtTipDal;
        private readonly IValidator<HealtTip> _validator;

        public HealtTipManager(IValidator<HealtTip> validator, IHealtTipDal healtTipDal)
        {
            _validator = validator;
            _healtTipDal = healtTipDal;
        }

        public IResult Add(HealtTipCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            HealtTip model = HealtTipCreateDto.ToHealtTip(dto);
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

            _healtTipDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }

        public IDataResult<List<HealtTip>> GetAll()
        {
            return new SuccessDataResult<List<HealtTip>>(_healtTipDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<HealtTip>> GetAllDeleted()
        {
            return new SuccessDataResult<List<HealtTip>>(_healtTipDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<HealtTip> GetById(int id)
        {
            return new SuccessDataResult<HealtTip>(_healtTipDal.GetById(id));
        }

        public IDataResult<List<HealtTip>> GetDataByLanguage(string lang)
        {
            return new SuccessDataResult<List<HealtTip>>(_healtTipDal.GetDataByLanguage(lang));
        }

        public IDataResult<List<HealtTipDto>> GetHealtTipsWithItems()
        {
            return new SuccessDataResult<List<HealtTipDto>>(_healtTipDal.GetHealtTipsWithItems());
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _healtTipDal.Delete(data);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Title));
        }

        public IResult ReturnDeleted(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _healtTipDal.Update(data);
            return  new SuccessResult(UiMessages.SuccessReturnTrashMessage(data.Title));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _healtTipDal.Update(data);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Title));
        }

        public IResult Update(HealtTipUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            HealtTip model = HealtTipUpdateDto.ToHealtTip(dto);
            HealtTip existData = GetById(model.Id).Data;

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);


            model.UpdatedDate = DateTime.Now;
            _healtTipDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));
        }
    }
}
