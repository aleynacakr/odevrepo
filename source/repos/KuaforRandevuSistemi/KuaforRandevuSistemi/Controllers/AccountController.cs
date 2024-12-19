using Microsoft.AspNetCore.Mvc;

namespace KuaforRandevuSistemi.Controllers
{
    public class AccountController : Controller
    {
        // Giriş Sayfası
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == "admin@sakarya.edu.tr" && password == "sau")
            {
                return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendir
            }

            ViewBag.Error = "Kullanıcı adı veya şifre yanlış.";
            return View();
        }

        // Kayıt Sayfası
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, string email, string password)
        {
            // Burada veritabanına kullanıcı kaydı eklenir
            return RedirectToAction("Login");
        }

        // Çıkış
        public IActionResult Logout()
        {
            // Kullanıcı çıkışı için oturum sonlandırılır
            return RedirectToAction("Login");
        }
    }
}
