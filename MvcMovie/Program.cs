var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MvcMovieContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext")));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

SeedData.Initialize(services);

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