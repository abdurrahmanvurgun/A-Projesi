using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace ArmutProjesi.Controllers
{
    public class KategoriController : Controller
    {
        KategoriManager km;
        EFKategoriRepository efkategorirepository;

        public KategoriController(KategoriManager km, EFKategoriRepository efkategorirepository)
        {
            this.km = km;
            this.efkategorirepository = efkategorirepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
