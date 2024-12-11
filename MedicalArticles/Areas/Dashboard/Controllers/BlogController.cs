using Business.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _env;
        private readonly ITeamBoardService _teamBoardService;

        public BlogController(IBlogService blogService, IWebHostEnvironment env, ITeamBoardService teamBoardService)
        {
            _blogService = blogService;
            _env = env;
            _teamBoardService = teamBoardService;
        }

        public IActionResult Index()
        {
            var data = _blogService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Teamboard"] = _teamBoardService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogCreateDto dto, IFormFile photoUrl)
        {
            var result = _blogService.Add(dto, photoUrl, _env.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ViewData["Teamboard"] = _teamBoardService.GetAll().Data;
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Teamboard"] = _teamBoardService.GetAll().Data;
            var data = _blogService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(BlogUpdateDto dto, IFormFile photoUrl)
        {
            var result = _blogService.Update(dto, photoUrl, _env.WebRootPath);
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
            var result = _blogService.SoftDelete(id);
            if (!result.IsSuccess)
                return View(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReturnFromTrash()
        {
            var data = _blogService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult ReturnFromTrash(int id)
        {
            var result = _blogService.ReturnDeleted(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return RedirectToAction("ReturnFromTrash");
        }

        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _blogService.HardDelete(id);
            if (result.IsSuccess)
                return RedirectToAction("ReturnFromTrash");

            return View(result);
        }
    }
}
