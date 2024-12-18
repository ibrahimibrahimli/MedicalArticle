using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class WhyChooseUsController : Controller
    {
        private readonly IWhyChooseUsService _whyChooseUsService;
        private readonly IWebHostEnvironment _env;
        private readonly ILanguageService _languageService;

        public WhyChooseUsController(IWhyChooseUsService whyChooseUsService, IWebHostEnvironment env, ILanguageService languageService)
        {
            _whyChooseUsService = whyChooseUsService;
            _env = env;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _whyChooseUsService.GetWhyUsWithItems(currentLanguage).Data;
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
        public IActionResult Create(WhyChooseUsCreateDto dto, IFormFile photoUrl)
        {
            var result = _whyChooseUsService.Add(dto, photoUrl, _env.WebRootPath);

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
            var data = _whyChooseUsService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(WhyChooseUsUpdateDto dto, IFormFile photoUrl)
        {
            var result = _whyChooseUsService.Update(dto, photoUrl, _env.WebRootPath);

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
            var result = _whyChooseUsService.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _whyChooseUsService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _whyChooseUsService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _whyChooseUsService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
