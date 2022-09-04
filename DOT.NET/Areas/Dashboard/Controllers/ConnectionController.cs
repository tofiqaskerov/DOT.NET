using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class ConnectionController : Controller
    {
        private readonly IConnectionManager _connectionManager;

        public ConnectionController(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IActionResult Index()
        {
            var connections = _connectionManager.GetAll();
            ViewBag.ConnectionLimit = connections.Count();
            return View(connections);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var connections = _connectionManager.GetAll();
            if (connections.Count() > 2) return RedirectToAction("Index");
            ViewBag.ConnectionLimit = connections;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Connection connection)
        {
            try
            {
                _connectionManager.Add(connection);
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
            var connection = _connectionManager.Get(id);
            if(connection == null) return RedirectToAction("Index");
            return View(connection);
        }

        [HttpPost]
        public IActionResult Edit(Connection connection)
        {
            try
            {
                _connectionManager.Update(connection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Delete(int id)
        {
            var connection = _connectionManager.Get(id);
            if (connection == null) return RedirectToAction("Index");
            return View();
        }



        [HttpPost]
        public IActionResult Delete(Connection connection)
        {
            try
            {
                _connectionManager.Remove(connection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
