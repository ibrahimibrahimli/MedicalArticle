using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceAboutItemsController : Controller
    {
        private readonly IServiceAboutItemsService _serviceAboutItemsService;
        private readonly IServiceAboutService _serviceAboutService;

        public ServiceAboutItemsController(IServiceAboutItemsService serviceAboutItemsService, IServiceAboutService serviceAboutService)
        {
            _serviceAboutItemsService = serviceAboutItemsService;
            _serviceAboutService = serviceAboutService;
        }

        public IActionResult Insdex()
        {
            var data = _serviceAboutItemsService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ServiceAbout"] = _serviceAboutService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceAboutItemsCreateDto dto)
        {
            var result = _serviceAboutItemsService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ViewData["ServiceAbout"] = _serviceAboutService.GetAll().Data;
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["ServiceAbout"] = _serviceAboutService.GetAll().Data;
            var data = _serviceAboutItemsService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ServiceAboutItemsUpdateDto dto)
        {
            var result = _serviceAboutItemsService.Update(dto);
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
            var result = _serviceAboutItemsService.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _serviceAboutItemsService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _serviceAboutItemsService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _serviceAboutItemsService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
