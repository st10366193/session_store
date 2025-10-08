using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using session_store.Models;

namespace session_store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {                                 //variable name ; value
            HttpContext.Session.SetString( "pm_name","Jameson");
            return View();
        }

        public IActionResult Privacy()
        {
            // getting the name of the PM from the session 
            //the ? annotation is used to avoid session when it is null , and the auto cast the datatype of the session 
            string? name = HttpContext.Session.GetString("pm_name");
            ViewBag.name = name;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
