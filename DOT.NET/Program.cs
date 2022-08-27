using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBannerManager, BannerManager>();
builder.Services.AddScoped<IBannerDal, BannerDal>();
builder.Services.AddScoped<IAboutManager, AboutManager>();
builder.Services.AddScoped<IAboutDal, AboutDal>();
builder.Services.AddScoped<IServicesManager, ServicesManager>();
builder.Services.AddScoped<IServicesDal, ServicesDal>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<IProjectDal, ProjectDal>();


var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
