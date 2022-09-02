using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concret.EntityFramework;
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
builder.Services.AddScoped<IProjectManager, ProjectManager>();
builder.Services.AddScoped<IProjectDal, ProjectDal>();
builder.Services.AddScoped<IPacketManager, PacketManager>();
builder.Services.AddScoped<IPacketDal, PacketDal>();
builder.Services.AddScoped<IPacketCategoryManager, PacketCategoryManager>();
builder.Services.AddScoped<IPacketCategoryDal, PacketCategoryDal>();
builder.Services.AddScoped<IRoleManager, RoleManager>();
builder.Services.AddScoped<IRoleDal, RoleDal>(); 
builder.Services.AddScoped<ITeamManager, TeamManager>(); 
builder.Services.AddScoped<ITeamDal, TeamDal>();
builder.Services.AddScoped<IClientManager, ClientManager>();
builder.Services.AddScoped<IClientDal, ClientDal>();
builder.Services.AddScoped<ILocationManager, LocationManager>();
builder.Services.AddScoped<ILocationDal, LocationDal>();
builder.Services.AddScoped<IContactManager, ContactManager>();
builder.Services.AddScoped<IContactDal, ContactDal>();

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
