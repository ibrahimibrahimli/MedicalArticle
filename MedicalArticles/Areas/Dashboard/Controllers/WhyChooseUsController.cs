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

        public WhyChooseUsController(IWhyChooseUsService whyChooseUsService, IWebHostEnvironment env)
        {
            _whyChooseUsService = whyChooseUsService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _whyChooseUsService.GetAll().Data;
            ViewBag.ShowButton = data.Count == 0;
            return View(data);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WhyChooseUsCreateDto dto, IFormFile photoUrl)
        {
            var result = _whyChooseUsService.Add(dto, photoUrl, _env.WebRootPath);

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
