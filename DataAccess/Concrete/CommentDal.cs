using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class CommentDal : IBaseRepository<Comment, ApplicationDbContext>, ICommentDal
    {
        private readonly ApplicationDbContext _context;

        public CommentDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Comment> GetCommentsByBlogId(int blogId)
        {
            return  _context.Comments
                .Where(c => c.BlogId == blogId && c.ParentCommentId == null)
                .Include(c => c.Replies)
                .ThenInclude(r => r.Replies).ToList();
        }
    }
}
