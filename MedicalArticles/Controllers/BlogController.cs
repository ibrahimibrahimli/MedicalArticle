using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _blogService.GetDataByLanguage(currentLanguage).Data;
            data.Reverse();
            return View(data);
        }
    }
}
