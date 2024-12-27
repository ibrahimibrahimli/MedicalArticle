using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class BlogDal : BaseRepository<Blog, ApplicationDbContext>, IBlogDal
    {
        private readonly ApplicationDbContext? _context;

        public BlogDal(ApplicationDbContext? context)
        {
            _context = context;
        }
        public List<BlogDto> GetDataByLanguage(string lang)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Database context is not initialized.");
            }

            var result = from blog in _context.Blogs
                         .Include(blog => blog.Language)
                         .Where(b => b.Language.Key == lang)
                         .Where(b => b.Deleted == 0)
                         join teamboard in _context.TeamBoards on blog.TeamboardId equals teamboard.Id
                         select new BlogDto
                         {
                             Id = blog.Id,
                             Title = blog.Title,
                             Text = blog.Text,
                             PhotoUrl = blog.PhotoUrl,
                             IsHomePage = blog.IsHomePage,
                             CreatedDate = blog.CreatedDate,
                             UpdatedDate = blog.UpdatedDate,
                             TeamboardName = teamboard.Name,
                             TeamboardSurname = teamboard.Surname,
                         };

            return result.ToList();
        }
    }
}
