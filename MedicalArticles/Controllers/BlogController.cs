using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ISosialService _sosialService;

        public BlogController(IBlogService blogService, ISosialService sosialService)
        {
            _blogService = blogService;
            _sosialService = sosialService;
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
    }
}
