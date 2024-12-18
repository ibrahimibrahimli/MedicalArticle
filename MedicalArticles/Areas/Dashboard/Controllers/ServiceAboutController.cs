using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceAboutController : Controller
    {
        private readonly IServiceAboutService _serviceAboutService;
        private readonly IWebHostEnvironment _env;
        private readonly ILanguageService _languageService;

        public ServiceAboutController(IServiceAboutService serviceAboutService, IWebHostEnvironment env, ILanguageService languageService)
        {
            _serviceAboutService = serviceAboutService;
            _env = env;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _serviceAboutService.GetServiceAboutWithItems(currentLanguage).Data;
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
        public IActionResult Create(ServiceAboutCreateDto dto, IFormFile photoUrl)
        {
            var result = _serviceAboutService.Add(dto, photoUrl, _env.WebRootPath);

            if (!result.IsSuccess)
            {
                ViewData["Languages"] = _languageService.GetAll().Data;
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;
            var data = _serviceAboutService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(ServiceAboutUpdateDto dto, IFormFile photoUrl)
        {
            var result = _serviceAboutService.Update(dto, photoUrl, _env.WebRootPath);

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
            var result = _serviceAboutService.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _serviceAboutService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _serviceAboutService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _serviceAboutService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
