using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        public IActionResult Index()
        {
            return View();
        }
    }
}