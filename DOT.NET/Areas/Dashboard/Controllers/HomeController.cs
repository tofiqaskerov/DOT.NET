﻿using Microsoft.AspNetCore.Mvc;

namespace DOT.NET.Areas.Dashboard.Controllers
{
    [Area("dashboard")]

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
