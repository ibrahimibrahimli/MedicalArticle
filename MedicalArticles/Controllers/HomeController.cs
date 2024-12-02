using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlideService _slideService;
        private readonly IServiceAboutItemsService _aboutItemsService;
        private readonly IServiceService _serviceService;
        private readonly IHealtTipItemsService _healtTipItemsService;
        private readonly ITeamBoardService _teamBoardService;

        public HomeController(ISlideService slideService, IServiceAboutItemsService aboutItemsService, IServiceService serviceService, IHealtTipItemsService healtTipItemsService, ITeamBoardService teamBoardService)
        {
            _slideService = slideService;
            _aboutItemsService = aboutItemsService;
            _serviceService = serviceService;
            _healtTipItemsService = healtTipItemsService;
            _teamBoardService = teamBoardService;
        }

        public IActionResult Index()
        {
            var slideData = _slideService.GetAll().Data;
            var aboutData = _aboutItemsService.GetServiceAboutItemsWidthServiceAbout().Data;
            var serviceData = _serviceService.GetServicesWithCategory().Data;
            var healtTipData = _healtTipItemsService.GetHealtTipItemsWithHealtTip().Data;
            var teamboardData = _teamBoardService.GetAll().Data;

            HomeViewModel viewModel = new HomeViewModel()
            {
                Slides = slideData,
                ServiceAboutItems = aboutData,
                Services = serviceData,
                HealtTipItems = healtTipData,
                Teamboard = teamboardData
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
