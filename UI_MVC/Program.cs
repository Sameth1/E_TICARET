using UI_MVC.Models;
using UI_MVC.Data;
using BLL;
using UI_MVC.Factories;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddCustomServices(builder.Configuration);

builder.Services.AddDbContext<ShopContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("shop")));

builder.Services.AddIdentity<AppUser, AppUserRole>(options => {
 
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ShopContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IHomeIndexViewModelFactory, HomeIndexViewModelFactory>();
builder.Services.AddScoped<IHomeDetailViewModelFactory, HomeDetailViewModelFactory>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ürünlere gerçekçi başlık, açıklama ve görsel URL'leri uygula (her uygulama başlangıcında)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ShopContext>();
    var products = await db.Products.Where(p => !p.Deleted).OrderBy(p => p.Id).ToListAsync();
    for (var i = 0; i < products.Count; i++)
    {
        var (title, description, coverImageUrl) = ProductSeedData.GetItem(i);
        products[i].Title = title;
        products[i].Description = description;
        products[i].CoverImageURL = coverImageUrl;
    }
    await db.SaveChangesAsync();
}

app.Run();