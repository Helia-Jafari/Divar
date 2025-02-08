

using Azure.Core;
using Divar.Db;
using Divar.Interfaces;
using Divar.Mapper;
using Divar.Middlewares;
using Divar.Repositories;
using Divar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DivarContext>();
//builder.Services.AddDbContext<DivarContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(""));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ILocalizationService, LocalizationService>();
builder.Services.AddScoped<IViewDataService, ViewDataService>();
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<ISearchSpecification<Advertisement>, AdvertisementSearchSpecificationService>();

builder.Services.AddMemoryCache();

//builder.Services.AddDistributedMemoryCache(options =>
//{
//    options.Configuration = "";
//    options.InstanceName = "SampleInstance";
//});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "127.0.0.1:6379";
    options.InstanceName = "SampleInstance";
});


//builder.Services.AddSingleton<AdvertisementMapper>();

builder.Services.AddHttpContextAccessor();

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




// ?????? ????? ?? ??????? ??? ?? ????? ??????? RequestLocalization
//app.Use(async (context, next) =>
//{
//    var httpContextAccessor = context.RequestServices.GetRequiredService<IHttpContextAccessor>();
//    var cultureCookie = httpContextAccessor.HttpContext.Request.Cookies["culture"];
//    if (!string.IsNullOrEmpty(cultureCookie))
//    {
//        var culture = new CultureInfo(cultureCookie);
//        CultureInfo.CurrentCulture = culture;
//        CultureInfo.CurrentUICulture = culture;
//    }

//    // ????? ?????? ???????
//    await next.Invoke();
//});
//?????? ????? ?? ??????? ??? ?? ????? ??????? RequestLocalization
//app.Use(async (context, next) =>
//{
//    var cultureCookie = context.Request.Cookies["culture"];
//    if (!string.IsNullOrEmpty(cultureCookie))
//    {
//        var culture = new CultureInfo(cultureCookie);
//        CultureInfo.CurrentCulture = culture;
//        CultureInfo.CurrentUICulture = culture;
//    }

//    await next.Invoke();
//});



//app.UseMiddleware<LocalizationMiddleware>();

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

