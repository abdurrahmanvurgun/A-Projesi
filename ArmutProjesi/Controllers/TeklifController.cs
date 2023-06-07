using Microsoft.AspNetCore.Mvc;

namespace ArmutProjesi.Controllers
{
    public class TeklifController : Controller
    {
        public IActionResult teklif()
        {
            return View();
        }
    }
}
