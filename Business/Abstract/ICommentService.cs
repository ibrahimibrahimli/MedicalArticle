using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace Business.Abstract
{
    public interface ICommentService
    {
        
        IDataResult<List<Comment>> GetCommentsByBlogId(int blogId);
        Task<IDataResult<Comment>> Add(Comment model);
        IResult Delete(int id);
        IDataResult<Comment> GetById(int id);
    }
}
