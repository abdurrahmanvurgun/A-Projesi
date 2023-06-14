using ArmutProjesi.Models;
using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArmutProjesi.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _db;
        public AccountController(DatabaseContext db)
        {
            _db = db;
        }
        [HttpGet,AllowAnonymous]
        public IActionResult Login()//Giriş 
        {
            return View();
        }

        [HttpPost,AllowAnonymous]
		public IActionResult Login(LoginModel model)//Giriş 
		{
            if (ModelState.IsValid)
            {
				Kullanici response = _db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);
				if (response != null)
				{
                    if (!response.Aktif)
                    {
                        ModelState.AddModelError("", "Kullanıcı Aktif Değil");
                        return View(model);
                    }
					return RedirectToAction("Profile", "Account");

				}
				else
				{
					ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
				}
			}          

			return View(model);
		}
		public IActionResult Register()//Kayıt OL
        {
            return View();
        }
        public IActionResult UpdatePassword()//Şifre Yenileme ya da Şifremi Unuttum
        {
            return View();
        }

        public IActionResult Profile() // Profil sayfası
        {
            return View();
        }
        public IActionResult ProfileSetting() // Profil ayarları
        {
            return View();
        }
        public IActionResult ServiceSettings() // Service ayarları
        {
            return View();
        }
        public IActionResult Wallet() // Cüzdan  ayarları
        {
            return View();
        }
        public IActionResult Jobs() // işlerim
        {
            return View();
        }
        public IActionResult services() // servislerim
        {
            return View();
        }
    }
}
