using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IBaseRepository<Comment>
    {
        List<Comment> GetCommentsByBlogId(int blogId);
    }
}
