using Business.Abstract;
using Entities.Concrete;
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
            var categories = _categoryManager.GetAll();
            return View(categories);
        }
        
        [HttpPost]
        public IActionResult Create(Projects project, IFormFile NewPhoto )
        {
            
                var fileExtation = Path.GetExtension(NewPhoto.FileName);

                string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", myPhoto);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    NewPhoto.CopyTo(stream);
                }
                project.PhotoURL = "Img/" + myPhoto;
                _projectManager.Add(project);
                return RedirectToAction("Index");
            
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var project = _projectManager.GetProjectsByCategory(id);
            if(project == null)return NotFound();
            ViewData["Category"] = _categoryManager.GetAll();
            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(Projects project, IFormFile NewPhoto, string? oldPhoto)
        {

            if (NewPhoto != null)
            {
                var fileExtation = Path.GetExtension(NewPhoto.FileName);

                string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/admin/Img", myPhoto);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    NewPhoto.CopyTo(stream);
                };
                project.PhotoURL = "admin/Img/" + myPhoto;
            }
            else project.PhotoURL = oldPhoto;

            _projectManager.Update(project);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var project = _projectManager.Get(id);
            if(project == null) return NotFound();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(Projects project)
        {
            try
            {
                _projectManager.Remove(project);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
