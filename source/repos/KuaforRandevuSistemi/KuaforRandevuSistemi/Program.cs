using Microsoft.EntityFrameworkCore;
using KuaforRandevuSistemi.Models;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantýsýný yapýlandýr
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC hizmetlerini ekle (Controller ve View'ler)
builder.Services.AddControllersWithViews();

// Uygulama yapýlandýrmasý
var app = builder.Build();

// Uygulamanýn geliþtirme ortamý kontrolü
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Hata sayfasý
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Üretim ortamýnda genel hata iþleme
    app.UseHsts(); // HTTP Strict Transport Security
}

// HTTP isteklerine yönlendirme
app.UseHttpsRedirection();  // HTTPS yönlendirmesi
app.UseStaticFiles();  // Statik dosya (CSS, JS, görseller vb.) desteði

// Routing iþlemi
app.UseRouting();

// Yetkilendirme iþlemi
app.UseAuthorization();

// Rotalarýn belirlenmesi
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Ana sayfa HomeController ile açýlacak

// Uygulama baþlatma
app.Run();
