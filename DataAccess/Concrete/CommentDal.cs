using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;

namespace DataAccess.Concrete
{
    public class CommentDal : IBaseRepository<Comment, ApplicationDbContext>, ICommentDal
    {
    }
}
