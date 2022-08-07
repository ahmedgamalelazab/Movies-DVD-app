using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using App.Data;
using App.Repository;

namespace App
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        //ctor  
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration; // using dependency Injection
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); //for mvc 
            //services.AddControllers(); // for web services support 
            services.AddDbContext<SalatyDbContext>(instanceOptions=>{
                instanceOptions.UseSqlServer(_configuration.GetConnectionString("SalatyDbContext"));
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

            services.AddDistributedMemoryCache();

            services.AddSession(options=>{
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {               
                endpoints.MapControllerRoute(
                    name:"Default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );

                //fallback
                endpoints.MapFallback((context)=>{
                    context.Response.Redirect("/Error/NotFound");
                    return Task.CompletedTask;
                });
            });
        }
    }
}
