using Business.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HealtTipItemsController : Controller
    {
        private readonly IHealtTipItemsService _healtTipItemsService;
        private readonly IHealtTipService _healtTipService;

        public HealtTipItemsController(IHealtTipItemsService healtTipItemsService, IHealtTipService healtTipService)
        {
            _healtTipItemsService = healtTipItemsService;
            _healtTipService = healtTipService;
        }

        public IActionResult Index()
        {
            var data = _healtTipItemsService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["HealtTips"] = _healtTipService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(HealtTipItemsCreateDto dto)
        {
            var result = _healtTipItemsService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ViewData["HealtTips"] = _healtTipService.GetAll().Data;
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["HealtTips"] = _healtTipService.GetAll().Data;
            var data = _healtTipItemsService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(HealtTipItemsUpdateDto dto)
        {
            var result = _healtTipItemsService.Update(dto);
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
            var result = _healtTipItemsService.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _healtTipItemsService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _healtTipItemsService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _healtTipItemsService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
