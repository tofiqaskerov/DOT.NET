using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamManager _teamManager;

        public TeamController(ITeamManager teamManager)
        {
            _teamManager = teamManager;
        }

        public IActionResult Index()
        {
            var teams = _teamManager.GetTeams();
            return View(teams);
        }
    }
}
