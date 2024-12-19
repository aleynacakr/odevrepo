using Microsoft.AspNetCore.Mvc;

namespace KuaforRandevuSistemi.Controllers
{
    public class SalonController : Controller
    {
        // Salonları Listeleme
        public IActionResult Index()
        {
            return View();
        }

        // Yeni Salon Ekleme
        [HttpGet]
        public IActionResult YeniSalon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniSalon(string salonAdi, string adres, string calismaSaatleri)
        {
            // Burada yeni salon bilgisi kaydedilir
            return RedirectToAction("Index");
        }
    }
}
