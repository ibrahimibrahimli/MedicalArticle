using Business.Abstract;
using Entities.Dtos;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IAdressService _adressService;

        public ContactController(IContactService contactService, IAdressService adressService)
        {
            _contactService = contactService;
            _adressService = adressService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var adressesData = _adressService.GetDataByLanguage(currentLanguage).Data;
            ContactViewModel viewModel = new ContactViewModel()
            {
                Adresses = adressesData,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ContactCreateDto dto, string comments)
       {
            dto.Message = comments;
            var result = _contactService.Add(dto);

            if (!result.IsSuccess)
            {
                return Json(new { isSuccess = false });

            }
            return Json(new { isSuccess = true });

        }
    }
}
