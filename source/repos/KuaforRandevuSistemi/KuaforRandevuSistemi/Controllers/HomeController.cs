using Microsoft.AspNetCore.Mvc;

namespace KuaforRandevuSistemi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Bu bir kuaför yönetim sistemidir.";
            return View();
        }
    }
}
