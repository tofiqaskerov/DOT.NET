using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var categoryCount = _categoryManager.GetAll().Count();
            ViewBag.CategoryCount = categoryCount;
            var category = _categoryManager.GetAll(); 
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categoryCount = _categoryManager.GetAll().Count();
            if (categoryCount > 5) return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null)  return RedirectToAction("Index");
            _categoryManager.Add(category);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryManager.Get(id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _categoryManager.Update(category);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categoryManager.Get(id);
            if(category == null) return RedirectToAction("Index");  
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            try
            {
                _categoryManager.Remove(category);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

    }
}
