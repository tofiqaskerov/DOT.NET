using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class ClientController : Controller
    {
        private readonly IClientManager _clientManager;

        public ClientController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        public IActionResult Index()
        {
            var clients = _clientManager.GetAll();
            return View(clients);
        }

      
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var clientCount = _clientManager.GetAll().Count();
            if (clientCount >= 6) return RedirectToAction("Index"); 
            return View();
            
        }

        [HttpPost]
        public IActionResult Create(Client client, IFormFile NewPhoto)
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
                client.PhotoURL = "Img/" + myPhoto;
                _clientManager.Add(client);
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
            var client = _clientManager.Get(id);
            if (client == null) return NotFound();
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(Client client, IFormFile NewPhoto, string? oldPhoto)
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
                    client.PhotoURL = "Img/" + myPhoto;
                }
                else client.PhotoURL = oldPhoto;

                _clientManager.Update(client);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

     
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var client = _clientManager.Get(id);
            if (client == null) return NotFound();
            return View();
        }

 
        [HttpPost]
        public IActionResult Delete(Client client)
        {
            try
            {
                _clientManager.Remove(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
