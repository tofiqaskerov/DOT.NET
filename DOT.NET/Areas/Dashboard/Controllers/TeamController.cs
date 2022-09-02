using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class TeamController : Controller
    {
        private readonly ITeamManager _teamManager;
        private readonly IRoleManager _roleManager;
        public TeamController(ITeamManager teamManager, IRoleManager roleManager)
        {
            _teamManager = teamManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var team = _teamManager.GetTeams();
            return View(team);
        }

      
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            var teamCount = _teamManager.GetTeams().Count();
            if (teamCount >= 6) return RedirectToAction("Index");
            var role = _roleManager.GetAll();
            ViewData["Role"] = role;
            return View();

        }

      
        [HttpPost]
        public IActionResult Create(Team team, IFormFile NewPhoto)
        {
            try
            {
                var fileExtation = Path.GetExtension(NewPhoto.FileName);
                string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", myPhoto);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    NewPhoto.CopyTo(stream);
                }
                team.PhotoURL = "Img/" + myPhoto;
                _teamManager.Add(team);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var team = _teamManager.GetTeam(id);
            if(team == null) return NotFound();
            var roles = _roleManager.GetAll();
            ViewData["Role"] = roles;
            return View(team);
        }


        [HttpPost]
        public IActionResult Edit(Team team, IFormFile NewPhoto, string? oldPhoto)
        {
            try
            {
                if (NewPhoto != null)
                {
                    var fileExtation = Path.GetExtension(NewPhoto.FileName);

                    string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", myPhoto);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        NewPhoto.CopyTo(stream);
                    };
                    team.PhotoURL = "Img/" + myPhoto;
                }
                else team.PhotoURL = oldPhoto;

                _teamManager.Update(team);
                return RedirectToAction("Index");
              
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var team = _teamManager.GetTeam(id);
            if (team == null) return NotFound();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Team team)
        {
            try
            {
                _teamManager.Remove(team);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
