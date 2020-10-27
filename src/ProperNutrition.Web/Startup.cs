using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.BLL.Managers;
using ProperNutrition.BLL.Repository;
using ProperNutrition.Common.Interfaces;
using ProperNutrition.DAL.Context;
using ProperNutrition.DAL.Entities;
using Serilog;

namespace ProperNutrition.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Repositoy pattern services.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Managers services.
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IIngridientManager, IngridientManager>();

            // Db context services.
            services.AddDbContext<ProperNutritionContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProperNutritionConnection")));

            //Identity add services.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ProperNutritionContext>();

            //AddControllersWithViews Microsoft services.
            services.AddControllersWithViews();
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "TeachMeSkills.Cookie";
                config.LoginPath = "/Account/SignIn";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSerilogRequestLogging(); // add serilog

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // подключение аутентификации
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
