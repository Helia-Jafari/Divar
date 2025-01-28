using System.Globalization;

namespace Divar.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // خواندن زبان از کوکی
            var cultureCookie = context.Request.Cookies["culture"];
            if (!string.IsNullOrEmpty(cultureCookie))
            {
                var culture = new CultureInfo(cultureCookie);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;

                // بررسی وجود culture در query string
                if (!context.Request.Query.ContainsKey("culture"))
                {
                    var queryString = context.Request.QueryString.HasValue ? context.Request.QueryString.ToString() : string.Empty;
                    var newQueryString = queryString.Contains("?") ? $"{queryString}&culture={culture.Name}" : $"?culture={culture.Name}";
                    var redirectUrl = context.Request.Path + newQueryString;

                    //context.Response.Cookies.Delete("culture");
                    context.Response.Redirect(redirectUrl);
                    return;
                }
            }


            //context.Response.Cookies.Delete("culture");
            // جلوگیری از تغییر زبان برای لینک‌های منو
            //if (context.Request.Path.HasValue && !context.Request.Path.Value.Contains("change-language"))
            //{
            //    await _next(context);
            //    return;
            //}

            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LocalizationMiddleware>();
        }
    }
}
