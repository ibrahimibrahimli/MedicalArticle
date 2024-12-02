using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class WhyChooseUsItemsController : Controller
    {
        private readonly IWhyChooseUsItemsService _whyChooseUsItemsService;
        private readonly IWhyChooseUsService _whyChooseUsService;

        public WhyChooseUsItemsController(IWhyChooseUsService whyChooseUsService, IWhyChooseUsItemsService whyChooseUsItemsService)
        {
            _whyChooseUsService = whyChooseUsService;
            _whyChooseUsItemsService = whyChooseUsItemsService;
        }

        public IActionResult Index()
        {
            var data = _whyChooseUsItemsService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["WhyChooseUs"] = _whyChooseUsService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(WhyChooseUsItemsCreateDto dto)
        {
            var result = _whyChooseUsItemsService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ViewData["WhyChooseUs"] = _whyChooseUsService.GetAll().Data;
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["WhyChooseUs"] = _whyChooseUsService.GetAll().Data;
            var data = _whyChooseUsItemsService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(WhyChooseUsItemsUpdateDto dto)
        {
            var result = _whyChooseUsItemsService.Update(dto);
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
            var result = _whyChooseUsItemsService.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _whyChooseUsItemsService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _whyChooseUsItemsService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _whyChooseUsItemsService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
