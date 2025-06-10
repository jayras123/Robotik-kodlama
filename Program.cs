using Microsoft.EntityFrameworkCore;
using UsluHayvanAlimSatim.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Servisleri ekliyoruz
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // ✅ Session servisi eklendi
builder.Services.AddDbContext<UsluContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsluDb")));

var app = builder.Build();

// 🔹 Ortam kontrolü
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 🔹 Pipeline yapılandırması
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // ✅ Session aktif edildi

app.UseAuthorization();

// 🔹 Varsayılan yönlendirme
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Giris}/{id?}");


app.MapControllerRoute(
    name: "bildirimler",
    pattern: "Bildirimler/{action=Index}/{id?}",
    defaults: new { controller = "Bildirimler", action = "Index" });




app.Run();

