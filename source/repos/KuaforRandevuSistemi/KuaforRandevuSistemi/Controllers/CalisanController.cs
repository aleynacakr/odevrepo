using Microsoft.AspNetCore.Mvc;
using KuaforRandevuSistemi.Models; // Model için
using System.Collections.Generic; // List için
using System.Linq; // LINQ sorguları için

namespace KuaforRandevuSistemi.Controllers
{
    public class CalisanController : Controller
    {
        // Geçici veri kaynağı (Veritabanı yerine kullanılabilir)
        private static List<Calisan> calisanlar = new List<Calisan>
        {
            new Calisan { Id = 1, AdSoyad = "Ali Yılmaz", UzmanlikAlani = "Saç Kesimi", UygunlukSaatleri = "09:00-12:00", SalonId = 1 },
            new Calisan { Id = 2, AdSoyad = "Ayşe Kaya", UzmanlikAlani = "Boya, Fön", UygunlukSaatleri = "13:00-18:00", SalonId = 1 }
        };

        // Çalışan Listeleme (Index)
        public IActionResult Index()
        {
            return View(calisanlar);
        }

        // Çalışan Detayları
        public IActionResult Details(int id)
        {
            var calisan = calisanlar.FirstOrDefault(c => c.Id == id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        // Yeni Çalışan Ekleme (GET)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Salonlar = GetSalonlar(); // Salon bilgilerini doldur
            return View();
        }

        // Yeni Çalışan Ekleme (POST)
        [HttpPost]
        public IActionResult Create(Calisan yeniCalisan)
        {
            if (ModelState.IsValid)
            {
                yeniCalisan.Id = calisanlar.Max(c => c.Id) + 1; // Yeni ID oluştur
                calisanlar.Add(yeniCalisan);
                return RedirectToAction("Index");
            }
            ViewBag.Salonlar = GetSalonlar(); // Hata durumunda tekrar salonları doldur
            return View(yeniCalisan);
        }

        // Çalışan Düzenleme (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var calisan = calisanlar.FirstOrDefault(c => c.Id == id);
            if (calisan == null)
            {
                return NotFound();
            }
            ViewBag.Salonlar = GetSalonlar(); // Salon bilgilerini doldur
            return View(calisan);
        }

        // Çalışan Düzenleme (POST)
        [HttpPost]
        public IActionResult Edit(Calisan guncellenenCalisan)
        {
            if (ModelState.IsValid)
            {
                var calisan = calisanlar.FirstOrDefault(c => c.Id == guncellenenCalisan.Id);
                if (calisan == null)
                {
                    return NotFound();
                }

                // Güncelleme işlemi
                calisan.AdSoyad = guncellenenCalisan.AdSoyad;
                calisan.UzmanlikAlani = guncellenenCalisan.UzmanlikAlani;
                calisan.UygunlukSaatleri = guncellenenCalisan.UygunlukSaatleri;
                calisan.SalonId = guncellenenCalisan.SalonId;

                return RedirectToAction("Index");
            }
            ViewBag.Salonlar = GetSalonlar(); // Hata durumunda tekrar salonları doldur
            return View(guncellenenCalisan);
        }

        // Çalışan Silme Onayı (GET)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var calisan = calisanlar.FirstOrDefault(c => c.Id == id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        // Çalışan Silme (POST)
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var calisan = calisanlar.FirstOrDefault(c => c.Id == id);
            if (calisan != null)
            {
                calisanlar.Remove(calisan);
            }
            return RedirectToAction("Index");
        }

        // Örnek Salonlar (Geçici veri kaynağı)
        private List<Salon> GetSalonlar()
        {
            return new List<Salon>
            {
                new Salon { Id = 1, Ad = "Şehir Kuaför" },
                new Salon { Id = 2, Ad = "Modern Berber" }
            };
        }
    }
}
