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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IValidator<Comment> _validator;

        public CommentManager(ICommentDal commentDal, IValidator<Comment> validator)
        {
            _commentDal = commentDal;
            _validator = validator;
        }

        public IResult Add(CommentCreateDto dto)
        {
            Comment model = CommentCreateDto.ToComment(dto);
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
            _commentDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Content));
        }

        public IResult Delete(int id)
        {
            var data = _commentDal.GetById(id);
            data.Deleted = id;
            _commentDal.Update(data);
            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Content));
        }

        public IDataResult<Comment> GetById(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.GetById(id));
        }

        public IDataResult<List<CommentDto>> GetCommentsByBlogId(int blogId)
        {
            return new SuccessDataResult<List<CommentDto>>(_commentDal.GetCommentsByBlogId(blogId));
        }
    }
}
