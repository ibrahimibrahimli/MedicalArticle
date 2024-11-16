using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    public class SlideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
