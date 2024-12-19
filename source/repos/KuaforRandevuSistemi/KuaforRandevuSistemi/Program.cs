using Microsoft.EntityFrameworkCore;
using KuaforRandevuSistemi.Models;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lant�s�n� yap�land�r
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC hizmetlerini ekle (Controller ve View'ler)
builder.Services.AddControllersWithViews();

// Uygulama yap�land�rmas�
var app = builder.Build();

// Uygulaman�n geli�tirme ortam� kontrol�
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Hata sayfas�
}
else
{
    app.UseExceptionHandler("/Home/Error"); // �retim ortam�nda genel hata i�leme
    app.UseHsts(); // HTTP Strict Transport Security
}

// HTTP isteklerine y�nlendirme
app.UseHttpsRedirection();  // HTTPS y�nlendirmesi
app.UseStaticFiles();  // Statik dosya (CSS, JS, g�rseller vb.) deste�i

// Routing i�lemi
app.UseRouting();

// Yetkilendirme i�lemi
app.UseAuthorization();

// Rotalar�n belirlenmesi
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Ana sayfa HomeController ile a��lacak

// Uygulama ba�latma
app.Run();
