    using Business.Abstract;
using MedicalArticles.Services;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlideService _slideService;
        private readonly IServiceAboutService _serviceAbout;
        private readonly IServiceService _serviceService;
        private readonly IHealtTipService _healtTipService;
        private readonly ITeamBoardService _teamBoardService;

        public HomeController(ISlideService slideService, IServiceAboutItemsService aboutItemsService, IServiceService serviceService, ITeamBoardService teamBoardService, IServiceAboutService serviceAbout, IHealtTipService healtTipService)
        {
            _slideService = slideService;
            _serviceService = serviceService;
            _teamBoardService = teamBoardService;
            _serviceAbout = serviceAbout;
            _healtTipService = healtTipService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;

            var slideData = _slideService.GetAll(currentLanguage).Data;
            var aboutData = _serviceAbout.GetServiceAboutWithItems().Data;
            var serviceData = _serviceService.GetServicesWithCategory().Data;
            var healtTipData = _healtTipService.GetHealtTipsWithItems().Data;
            var teamboardData = _teamBoardService.GetAll().Data;

            HomeViewModel viewModel = new HomeViewModel()
            {
                Slides = slideData,
                ServiceAbout = aboutData,
                Services = serviceData,
                HealtTip = healtTipData,
                Teamboard = teamboardData
            };

            return View(viewModel);
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
