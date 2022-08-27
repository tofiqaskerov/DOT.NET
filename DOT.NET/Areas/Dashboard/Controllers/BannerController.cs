using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]

    public class BannerController : Controller
    {

        private readonly IBannerManager _bannerManager;

        public BannerController(IBannerManager bannerManager)
        {
            _bannerManager = bannerManager;
        }

        public IActionResult Index()
        {
            var banner = _bannerManager.GetFirst();
            return View(banner);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var banner = _bannerManager.GetFirst();
            if (banner != null)
                return RedirectToAction("Index");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Banner banner, IFormFile NewPhoto)
        {
            var fileExtation = Path.GetExtension(NewPhoto.FileName);
            if(fileExtation != ".jpg" || fileExtation != ".png")
            {
                ViewBag.PhotoError = "Yalniz .jpg ve .png  formati qebul olunur";
                return View();
            }
            string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", myPhoto);
            using(var stream = new FileStream(path, FileMode.Create))
            {
                NewPhoto.CopyTo(stream);
            }
            banner.PhotoURL = "Img/" + myPhoto;
            _bannerManager.Add(banner);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null) return RedirectToAction("Index");
            var banner = _bannerManager.Get(id);
            if (banner == null) return RedirectToAction("Index");
            return View(banner);
        }
        [HttpPost]
        public IActionResult Edit(Banner banner,IFormFile NewPhoto, string? oldPhoto  )
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
                banner.PhotoURL = "admin/Img/" + myPhoto;
            }
            else banner.PhotoURL = oldPhoto;

            _bannerManager.Update(banner);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var banner = _bannerManager.Get(id);
            if (banner == null) return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        public IActionResult Delete(Banner banner)
        {
            if(banner == null) return RedirectToAction("Index");
            _bannerManager.Remove(banner);
                
            return RedirectToAction("Index");
        }

    }
}
