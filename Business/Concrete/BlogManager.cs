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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IValidator<Blog> _validator;

        public BlogManager(IBlogDal blogDal, IValidator<Blog> validator)
        {
            _blogDal = blogDal;
            _validator = validator;
        }

        public IResult Add(BlogCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            Blog model = BlogCreateDto.ToBlog(dto);
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

            _blogDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<List<Blog>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<Blog> GetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.GetById(id));
        }

        public IDataResult<List<Blog>> GetDataByLanguage(string lang)
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetDataByLanguage(lang));
        }

        public IDataResult<List<BlogDto>> GetServicesWithCategory()
        {
            return new SuccessDataResult<List<BlogDto>>(_blogDal.GetBlogWithAuthor());
        }

        public IResult HardDelete(int id)
        {
            var model = GetById(id).Data;
            _blogDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(model.Title));
        }

        public IResult ReturnDeleted(int id)
        {
            Blog model = GetById(id).Data;
            model.Deleted = 0;
            _blogDal.Update(model);

            return new SuccessResult(UiMessages.SuccessReturnTrashMessage(model.Title));
        }

        public IResult SoftDelete(int id)
        {
            Blog model = GetById(id).Data;
            model.Deleted = id;
            _blogDal.Update(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(model.Title));
        }

        public IResult Update(BlogUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            Blog model = BlogUpdateDto.ToBlog(dto);
            Blog existData = GetById(model.Id).Data;

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _blogDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));

        }
    }
}
