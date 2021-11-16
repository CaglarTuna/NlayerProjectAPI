using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AutoMapper;
using NLayerProject.Web.CategoryApiService;
using NLayerProject.Web.Filters;
using NLayerProject.Web.ApiServices;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace NLayerProject.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<CategoryApiServiceCs>(o =>
            {
                o.BaseAddress = new Uri(Configuration["baseUrl"]);
            });
            services.AddHttpClient<PersonApiService>(o =>
            {
                o.BaseAddress = new Uri(Configuration["baseUrl"]);
            });
            services.AddHttpClient<ProductApiService>(o =>
            {
                o.BaseAddress = new Uri(Configuration["baseUrl"]);
            });
            services.AddHttpClient<BasketApiService>(o =>
            {
                o.BaseAddress = new Uri(Configuration["baseUrl"]);
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddAuthorization();
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{quantity?}/{mail?}");
            });
        }
    }
}
