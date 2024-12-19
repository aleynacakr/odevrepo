using KuaforRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include namespace eklenmeli

public class RandevuController : Controller
{
    private readonly ApplicationDbContext _context;

    public RandevuController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Randevu oluşturma sayfası
    public IActionResult Create()
    {
        return View();
    }

    // Randevu listeleme sayfası
    public IActionResult Index()
    {
        var randevular = _context.Randevular.Include(r => r.Calisan).ToList();
        return View(randevular);
    }
}
