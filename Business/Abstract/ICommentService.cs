using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult Add(CommentCreateDto dto);
        IDataResult<Comment> GetById(int id);
    }
}
