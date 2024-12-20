using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class AboutController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IWhyChooseUsService _whyUsService;
        private readonly ITeamBoardService _teeamBoardService;

        public AboutController(IServiceService serviceService, IWhyChooseUsService whyUsService, ITeamBoardService teeamBoardService)
        {
            _serviceService = serviceService;
            _whyUsService = whyUsService;
            _teeamBoardService = teeamBoardService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;

            var serviceData = _serviceService.GetDataByLanguage(currentLanguage).Data;
            var whyUsData = _whyUsService.GetWhyUsWithItems(currentLanguage).Data;
            var teamboardData = _teeamBoardService.GetDataByLanguage(currentLanguage).Data;

            AboutViewModel aboutData = new AboutViewModel()
            {
                Services = serviceData,
                WhyChooseUS = whyUsData,
                Teamboards = teamboardData
            };
            return View(aboutData);
        }
    }
}
