using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;

namespace DataAccess.Concrete
{
    public class BlogDal : BaseRepository<Blog, ApplicationDbContext>, IBlogDal
    {
        private readonly ApplicationDbContext? _context;

        public BlogDal(ApplicationDbContext? context)
        {
            _context = context;
        }

        public List<BlogDto> GetBlogWithAuthor()
        {
            var result = from blog in _context.Blogs
                         where blog.Deleted == 0
                         join teamboard in _context.TeamBoards on blog.TeamboardId equals teamboard.Id
                         where teamboard.Deleted == 0
                         select new BlogDto
                         {
                             Id = blog.Id,
                             Title = blog.Title,
                             Text = blog.Text,
                             PhotoUrl = blog.PhotoUrl,
                             IsHomePage = blog.IsHomePage,
                             TeamboardName = teamboard.Name,
                             TeamboardSurname = teamboard.Surname,
                         };
            return [.. result];
        }
    }
}
