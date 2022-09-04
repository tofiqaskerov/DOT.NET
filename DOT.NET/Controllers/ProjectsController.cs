using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly ICategoryManager _categoryManager;
        public ProjectsController(IProjectManager projectManager, ICategoryManager categoryManager)
        {
            _projectManager = projectManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var projects = _projectManager.GetAllProjects();
            var categories = _categoryManager.GetAll();
            ViewData["Category"] = categories;
            return View(projects);
        }
    }
}
