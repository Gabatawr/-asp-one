using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mvc.Data;
using mvc.Extensions;
using mvc.Middlewares;
using mvc.Options;
using System.Collections.Generic;
using System.Globalization;

namespace mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var _defaultLanguage = "en-US";
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo(_defaultLanguage),
                    new CultureInfo("ru-RU"),
                    new CultureInfo("uk-UA")
                };
                options.DefaultRequestCulture = new RequestCulture(_defaultLanguage, _defaultLanguage);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders
                       .Remove(typeof(AcceptLanguageHeaderRequestCultureProvider));
            });

            services.Configure<EmailOptions>(Configuration.GetSection("Email"));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();

            services.AddServerSideBlazor();

            services.AddRazorPages()
                    .AddViewLocalization();

            services.AddScoped<RequestLocalizationCookiesMiddleware>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRequestLocalization();
            app.UseRequestLocalizationCookies();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Blazor
                endpoints.MapBlazorHub();

                // Areas
                endpoints.MapAreaControllerRoute(
                    name: "Checkout",
                    areaName: "ShoppingCart",
                    pattern: "Checkout",
                    defaults: new { controller = "Checkout", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "Areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                // Privacy
                endpoints.MapControllerRoute(
                    name: "privacyInt",
                    pattern: "{controller=Home}/Privacy/{id:int}",
                    defaults: new { action = "PrivacyByInt" });

                endpoints.MapControllerRoute(
                    name: "privacyString",
                    pattern: "{controller=Home}/{action=Privacy}/{id:guid?}");

                // Default
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                // Razor
                endpoints.MapRazorPages();
            });
        }
    }
}
