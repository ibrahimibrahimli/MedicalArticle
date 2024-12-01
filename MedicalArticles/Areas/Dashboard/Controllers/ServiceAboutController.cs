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

        public ServiceAboutController(IServiceAboutService serviceAboutService, IWebHostEnvironment env)
        {
            _serviceAboutService = serviceAboutService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _serviceAboutService.GetAll().Data;
            ViewBag.ShowButton = data.Count == 0;
            return View(data);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceAboutCreateDto dto, IFormFile photoUrl)
        {
            var result = _serviceAboutService.Add(dto, photoUrl, _env.WebRootPath);

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
