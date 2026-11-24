using BloodLink.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC pages (Controllers + Views).
builder.Services.AddControllersWithViews();

// Database (SQL Server). Connection string is in appsettings.json → ConnectionStrings:DefaultConnection
builder.Services.AddDbContext<BloodLinkDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// TODO (backend): add authentication, API controllers (/api/...) and services here.

var app = builder.Build();

// Create / update the database and add the demo data on startup.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BloodLinkDbContext>();
    db.Database.Migrate();
    DbInitializer.Seed(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
