using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _service;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _categoryService;
        private readonly ILanguageService _languageService;
        public ServiceController(IServiceService service, IWebHostEnvironment webHostEnvironment, ICategoryService categoryService, ILanguageService languageService)
        {
            _service = service;
            _env = webHostEnvironment;
            _categoryService = categoryService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _service.GetDataByLanguage(currentLanguage).Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;
            ViewData["Categories"] = _categoryService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceCreateDto dto, IFormFile photoUrl)
        {
            var result = _service.Add(dto, photoUrl, _env.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ViewData["Languages"] = _languageService.GetAll().Data;
                ViewData["Categories"] = _categoryService.GetAll().Data;
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;
            ViewData["Categories"] = _categoryService.GetAll().Data;
            var data = _service.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ServiceUpdateDto dto, IFormFile photoUrl)
        {
            var result = _service.Update(dto, photoUrl, _env.WebRootPath);
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
            var result = _service.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _service.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _service.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _service.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
