using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class AboutController : Controller
    {
        private readonly IAboutManager _aboutManager;

        public AboutController(IAboutManager aboutManager)
        {
            _aboutManager = aboutManager;
        }

        public IActionResult Index()
        {
            var about = _aboutManager.GetFirst();
            return View(about);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var banner = _aboutManager.GetFirst();
            if (banner != null) return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public IActionResult Create(About about, IFormFile NewPhoto)
        {
            var fileExtation = Path.GetExtension(NewPhoto.FileName);
            
            string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", myPhoto);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                NewPhoto.CopyTo(stream);
            }
            about.PhotoURL = "Img/" + myPhoto;
            _aboutManager.Add(about);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null) return RedirectToAction("Index");
            var about = _aboutManager.Get(id);
            if (about == null) return RedirectToAction("Index");
            return View(about);
        }
        [HttpPost]
        public IActionResult Edit(About about, IFormFile NewPhoto, string? oldPhoto)
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
                about.PhotoURL = "admin/Img/" + myPhoto;
            }
            else about.PhotoURL = oldPhoto;

            _aboutManager.Update(about);
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var about = _aboutManager.Get(id);
            if (about == null) return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public IActionResult Delete(About about)
        {
            if(about == null) return RedirectToAction("Index");
            _aboutManager.Remove(about);
            return RedirectToAction("Index");
        }
    }
}
