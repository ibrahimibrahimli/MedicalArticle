using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FaqController : Controller
    {
        private readonly IFaqService _faqService;
        private readonly ILanguageService _languageService;
        public FaqController(IFaqService faqService, ILanguageService languageService)
        {
            _faqService = faqService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _faqService.GetDataByLanguage(currentLanguage).Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(FaqCreateDto dto)
        {
            var result = _faqService.Add(dto);
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
            var data = _faqService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(FaqUpdateDto dto)
        {
            var result = _faqService.Update(dto);
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
            var result = _faqService.SoftDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _faqService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _faqService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _faqService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
