

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VT_Lab1.DAL.Data;
using VT_Lab1.DAL.Entities;
using VT_Lab1.Models;
using VT_Lab1.Services;
using Microsoft.Extensions.Logging;
using VT_Lab1.Extensions;

namespace VT_Lab1
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
            services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
            })
            //.AddDefaultUI(UIFramework.Bootstrap4)
            .AddEntityFrameworkStores <ApplicationDbContext>()
            .AddDefaultTokenProviders();
            
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(sp => CartService.GetCart(sp));

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<Cart>(sp => CartService.GetCart(sp));
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = $"/Identity/Account/Login";
                opt.LogoutPath = $"/Identity/Account/Logout";

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context,
                                UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILoggerFactory logger)
        {
            logger.AddFile("Logs/log-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseCors(policy =>
                //policy.AllowAnyOrigin()
                //.AllowAnyMethod()
                //.WithHeaders(HeaderNames.ContentType));
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            DbInitializer.Seed(context, userManager, roleManager).GetAwaiter().GetResult();
            app.UseAuthentication();
            app.UseSession();
            app.UseAuthorization();
           // app.UseFileLogging();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
