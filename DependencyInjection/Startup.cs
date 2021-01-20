using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //TypeBroker.SetRepositoryType<AlternateRepository>();
            //services.AddTransient<IRepository, MemoryRepository>();
            //services.AddScoped<IRepository, MemoryRepository>();
            services.AddSingleton<IRepository, MemoryRepository>();
            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddTransient<ProductTotalizer>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(null, "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
