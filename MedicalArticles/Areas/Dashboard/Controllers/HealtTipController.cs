using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HealtTipController : Controller
    {
        private readonly IHealtTipService _healtTipService;
        private readonly IWebHostEnvironment _env;

        public HealtTipController(IHealtTipService healtTipService, IWebHostEnvironment env)
        {
            _healtTipService = healtTipService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _healtTipService.GetAll().Data;
           // ViewBag.ShowButton = data.Count == 0;
            return View(data);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HealtTipCreateDto dto, IFormFile photoUrl)
        {
            var result = _healtTipService.Add(dto, photoUrl, _env.WebRootPath);

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
            var data = _healtTipService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(HealtTipUpdateDto dto, IFormFile photoUrl)
        {
            var result = _healtTipService.Update(dto, photoUrl, _env.WebRootPath);

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
            var result = _healtTipService.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _healtTipService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _healtTipService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _healtTipService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
