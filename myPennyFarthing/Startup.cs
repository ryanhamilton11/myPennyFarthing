using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using myPennyFarthing.Models;

namespace myPennyFarthing
{
    public class Startup
    {
        //   F I E L D S   &   P R O P E R T I E S
        public IConfiguration Configuration { get; }



        //  C O N S T R U C T O R S
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //   M E T H O D S
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBikeRepository, EfBikeRepository>();
            services.AddScoped<IMXRepository, EfMXRepository>();
            services.AddScoped<IRideRepository, EfRideRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();

            services.AddControllersWithViews();

            services.AddHttpContextAccessor();

            services.AddMemoryCache();

            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
