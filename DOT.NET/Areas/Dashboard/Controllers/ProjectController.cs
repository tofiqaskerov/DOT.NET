using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class ProjectController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly ICategoryManager _categoryManager;

        public ProjectController(IProjectManager projectManager, ICategoryManager categoryManager)
        {
            _projectManager = projectManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var projects = _projectManager.GetAllProjects();
          
            return View(projects);
        }

        public IActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = _categoryManager.GetAll();
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]

        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]

        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
