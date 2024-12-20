using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IWhyChooseUsService _whyChooseUsService;
        private readonly IFaqService _faqService;

        public ServiceController(IServiceService serviceService, IWhyChooseUsService whyChooseUsService, IFaqService faqService)
        {
            _serviceService = serviceService;
            _whyChooseUsService = whyChooseUsService;
            _faqService = faqService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;

            var serviceData = _serviceService.GetDataByLanguage(currentLanguage).Data;
            var whyChooseUsData = _whyChooseUsService.GetWhyUsWithItems(currentLanguage).Data;
            var faqData = _faqService.GetDataByLanguage(currentLanguage).Data;

            ServiceViewModel viewModel = new ServiceViewModel()
            {
                Services = serviceData,
                WhyChoseUs = whyChooseUsData,
                Faqs = faqData
            };
            return View(viewModel);
        }
    }
}
