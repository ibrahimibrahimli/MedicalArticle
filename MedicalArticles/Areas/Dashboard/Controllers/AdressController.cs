using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AdressController : Controller
    {
        private readonly IAdressService _adressService;
        private readonly ILanguageService _languageService;

        public AdressController(IAdressService adressService, ILanguageService languageService)
        {
            _adressService = adressService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _adressService.GetDataByLanguage(currentLanguage).Data;
            ViewBag.ShowButton = data.Count == 0;
            return View(data);
        }

        [HttpGet]

        public IActionResult Create()
        {

            ViewData["Languages"] = _languageService.GetAll().Data;
            return View();
        }

        [HttpPost]

        public IActionResult Create(AdressCreateDto dto) 
        {

            ViewData["Languages"] = _languageService.GetAll().Data;
            var result = _adressService.Add(dto);
            if (!result.IsSuccess)
            {
               ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;
            var data = _adressService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(AdressUpdateDto dto)
        {
            var result = _adressService.Update(dto);

            if (!result.IsSuccess) 
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var result = _adressService.SoftDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
