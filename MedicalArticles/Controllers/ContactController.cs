using Business.Abstract;
using Entities.Dtos;
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
            var data = _adressService.GetDataByLanguage(currentLanguage).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Create( ContactCreateDto dto)
        {
            _contactService.Add(dto);
            return RedirectToAction("Index");
        }
    }
}
