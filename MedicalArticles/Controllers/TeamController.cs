using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamBoardService? _teamBoardService;

        public TeamController(ITeamBoardService? teamBoardService)
        {
            _teamBoardService = teamBoardService;
        }

        public IActionResult Index()
        {
            var currentLanguage = Thread.CurrentThread.CurrentCulture.Name;
            var data = _teamBoardService.GetDataByLanguage(currentLanguage).Data;
            return View(data);
        }
    }
}
