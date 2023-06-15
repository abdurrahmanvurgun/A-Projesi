using ArmutProjesi.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArmutProjesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }


        public IActionResult Yardim()
        {
            return View();
        }

        public IActionResult Kategoriler()
        {
            return View();
        }
        public IActionResult Temizlik()
        {
            return View();
        }
        public IActionResult Tadilat()
        {
            return View();
        }

        public IActionResult OzelDers()
        {
            return View();
        }

        public IActionResult Saglik()
        {
            return View();
        }

        public IActionResult Diger()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }
        public IActionResult HizmetVer()
        {
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