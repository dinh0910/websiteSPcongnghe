using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using websiteSPcongnghe.Data;
using AspNetCoreHero.ToastNotification;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<websiteSPcongngheContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("websiteSPcongngheContext") ?? throw new InvalidOperationException("Connection string 'websiteSPcongngheContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddNotyf(config => { config.DurationInSeconds = 4; config.IsDismissable = true; config.Position = NotyfPosition.TopCenter; });

builder.Services.AddSession(options => {
    options.Cookie.Name = "WebsiteSPCongNghe";
    options.IdleTimeout = TimeSpan.FromDays(60);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
