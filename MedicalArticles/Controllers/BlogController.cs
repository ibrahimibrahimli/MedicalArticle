using Business.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ISosialService _sosialService;
        private readonly ICommentService _commentService;

        public BlogController(IBlogService blogService, ISosialService sosialService, ICommentService commentService)
        {
            _blogService = blogService;
            _sosialService = sosialService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var sosialData = _sosialService.GetAll().Data;
            var blogData = _blogService.GetDataByLanguage(currentLanguage).Data;
            blogData.Reverse();
            BlogViewModel blogViewModel = new BlogViewModel
            {
                Blogs = blogData,
                Sosials = sosialData
            };
            return View(blogViewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;

            var blogData = _blogService.GetDtoById(id, currentLanguage).Data;
            var sosialdata = _sosialService.GetAll().Data;
            var blogsData = _blogService.GetDataByLanguage(currentLanguage).Data;
            var comments = _commentService.GetCommentsByBlogId(id).Data;
            blogsData.Reverse();

            BlogDetailsViewModel viewModel = new BlogDetailsViewModel
            {
                Blog = blogData,
                Sosials = sosialdata,
                Blogs = blogsData,
                Comments = comments
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] Comment comment)
        {
            
                // Yorum kaydetme işlemi
                var newComment = await _commentService.Add(comment);

                // Yeni yorumun partial view olarak dönülmesi
                return PartialView("_CommentPartial", newComment.Data);
        }

    }
}
