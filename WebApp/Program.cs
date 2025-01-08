using Microsoft.EntityFrameworkCore;
using WebApp;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("Test");
// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuracion de la base de datos
builder.Services.AddDbContext<Context>(
    cfg=>{
        cfg.UseSqlite(connection);
    }
);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
