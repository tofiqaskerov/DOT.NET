using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{   
    [Area("dashboard")]
    public class ContactController : Controller
    {
        private readonly IContactManager _contactManager;

        public ContactController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        public IActionResult Index()
        {
           
            var contacts = _contactManager.GetAll();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();   
        }
        [HttpPost]
        public IActionResult Edit(int id)
        {
            var contact = _contactManager.Get(id);
            contact.IsRead = true;
            _contactManager.Update(contact);
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var contact = _contactManager.Get(id);
            return View(contact);
        }
      
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = _contactManager.Get(id);
            if (contact == null) RedirectToAction("Index");
            return View();
        }

  
        [HttpPost]
        public IActionResult Delete(Contact contact )
        {
            try
            {
                _contactManager.Remove(contact);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
