using Business.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SlideController : Controller
    {
        private readonly ISlideService _slideService;
        private readonly IWebHostEnvironment _env;
        private readonly ILanguageService _languageService;

        public SlideController(ISlideService slideService, IWebHostEnvironment env, ILanguageService languageService)
        {
            _slideService = slideService;
            _env = env;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _slideService.GetDataByLanguage(currentLanguage).Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(SlideCreateDto dto, IFormFile photoUrl)
        {

            ViewData["Languages"] = _languageService.GetAll().Data;
            var result = _slideService.Add(dto, photoUrl, _env.WebRootPath);
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
            var data = _slideService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(SlideUpdateDto dto, IFormFile photoUrl)
        {
            var result = _slideService.Update(dto, photoUrl, _env.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result?.Message);
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _slideService.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _slideService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _slideService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _slideService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
