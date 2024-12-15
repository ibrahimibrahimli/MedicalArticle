using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly IAdressService _adressService;

        public NavigationViewComponent(IAdressService adressService)
        {
            _adressService = adressService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;

            NavigationViewModel viewModel = new NavigationViewModel()
            {
                Adresses = _adressService.GetDataByLanguage(currentLanguage).Data,
            };
            return View(viewModel);
        }
    }
}
