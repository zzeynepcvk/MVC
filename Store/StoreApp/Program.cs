using System.Net;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepositoryContext>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b => b.MigrationsAssembly("StoreApp"));

});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "StoreApp.Session";
    options.IdleTimeout= TimeSpan.FromMinutes(10); //10 dk bilgileri tut yeni istek gelmezse oturumu düşür  
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IServicesManager, ServiceManager>();
builder.Services.AddScoped<IProductServices, ProductManager>();
builder.Services.AddScoped<ICategoryServices, CategoryManager>();

builder.Services.AddSingleton<Cart>(c => SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));

/*repository contex nesnesinin new lenmesini sağlar.
bu işlem ihtiyaç duyduğu bağlantı 
dizesini appsetting.json page inden alarak uygulamaya dönüyor */

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute("Admin","Admin","Admin/{controller=Dashboard}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}" );

    endpoints.MapRazorPages();
});



app.Run();
