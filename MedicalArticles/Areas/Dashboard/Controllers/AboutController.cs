using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IWebHostEnvironment _env;

        public AboutController(IAboutService aboutService, IWebHostEnvironment env)
        {
            _aboutService = aboutService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _aboutService.GetAll().Data;
            ViewBag.ShowButton = data.Count == 0;
            return View(data);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
         public IActionResult Create(AboutCreateDto dto, IFormFile photoUrl)
        {
            var result = _aboutService.Add(dto, photoUrl, _env.WebRootPath);

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
            var data = _aboutService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(AboutUpdateDto dto, IFormFile photoUrl) 
        {
           var result = _aboutService.Update(dto, photoUrl, _env.WebRootPath);

            if (!result.IsSuccess) 
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");

        }
    }
}
