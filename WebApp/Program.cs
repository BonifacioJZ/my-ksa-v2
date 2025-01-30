using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp;
using WebApp.Data;
using WebApp.Filter;
using WebApp.Models;
using WebApp.Service;
using WebApp.Service.Interface;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("Test");
//AutoMapper Configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews(opt=>{
    opt.Filters.Add<VerifySession>();
});
//Configuracion de la base de datos
builder.Services.AddDbContext<Context>(
    cfg=>{
        cfg.UseSqlite(connection);
    }
);

// Registra el servicio ICategoryService con su implementación CategoryService en el contenedor de inyección de dependencias.
// AddScoped especifica que el servicio se crea una vez por solicitud dentro del alcance.
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService,PermissionService>();
//Authentication configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt=>{
        opt.LoginPath="/login";
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });
builder.Services.AddSession();

//Add User Identity
builder.Services.AddIdentity<User,Role>(
    opt=>{
        opt.Password.RequiredUniqueChars = 0;
        opt.Password.RequiredLength = 8;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireLowercase = false;
    }
)
    .AddRoles<Role>()
    .AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

builder.Services.AddAuthorization(policy=>{
    policy.AddPolicy("SuperUser",opt=>{
        opt.RequireRole(Roles.Root.ToString());
        opt.RequireClaim("SuperUser","Root");
    });
});
var app = builder.Build();

// Create migration when starting the application
using(var environment = app.Services.CreateScope()){
    var service = environment.ServiceProvider;

    try{
        var context = service.GetRequiredService<Context>();
        context.Database.Migrate();
    }catch(Exception e){
        var log = service.GetRequiredService<ILogger<Program>>();
        log.LogError(e, "Error in the migration");
    }


}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
