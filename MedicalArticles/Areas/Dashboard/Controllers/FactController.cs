using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FactController : Controller
    {
        private readonly IFactService _factService;
        private readonly ILanguageService _languageService;

        public FactController(IFactService factService, ILanguageService languageService)
        {
            _factService = factService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _factService.GetDataByLanguage(currentLanguage).Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(FacTCreateDto dto)
        {
            var result = _factService.Add(dto);
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
            var data = _factService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(FactUpdateDto dto)
        {
            var result = _factService.Update(dto);
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
            var result = _factService.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _factService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _factService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _factService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
