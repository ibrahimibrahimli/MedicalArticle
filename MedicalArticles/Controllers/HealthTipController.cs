using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class HealthTipController : Controller
    {
        private readonly IHealtTipService? _healthTipService;

        public HealthTipController(IHealtTipService? healthTipService)
        {
            _healthTipService = healthTipService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _healthTipService.GetHealtTipsWithItems(currentLanguage).Data;
            return View(data);
        }
    }
}
