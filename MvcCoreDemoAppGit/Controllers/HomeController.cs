using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcCoreDemoAppGit.Models;
using System.Diagnostics;

namespace MvcCoreDemoAppGit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _iconfigurtion;
        public HomeController(ILogger<HomeController> logger,IConfiguration iconfigurtion)
        {
            _logger = logger;
            _iconfigurtion = iconfigurtion;
        }

        public IActionResult Index()
        {
            ViewBag.Test = _iconfigurtion.GetValue<string>("Test");
            ViewBag.OracleString = _iconfigurtion.GetValue<string>("ConnectionStrings:OracleConstr");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}