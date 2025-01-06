


using Divar.Db;
using Divar.Interfaces;
using Divar.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DivarContext>();

builder.Services.AddScoped<IDirLocalozation, DirLocalozation>();

//builder.Services.AddRazorPages().AddViewLocalization();

builder.Services.AddLocalization(options => options.ResourcesPath = "Localization");
var supportedCultures = new[]
{
    new CultureInfo("en-US"),new CultureInfo("fa-IR")
};
var requestLocalizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("fa-IR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = [
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider()
    ]
};
// /?culture=fa-IR&ui-culture=fa-IR



var app = builder.Build();

app.UseRequestLocalization(requestLocalizationOptions);

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

