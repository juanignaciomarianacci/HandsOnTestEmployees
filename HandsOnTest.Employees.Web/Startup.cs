using HandsOnTest.Employees.Business;
using HandsOnTest.Employees.Business.Contract;
using HandsOnTest.Employees.DataAccess.Repository;
using HandsOnTest.Employees.DataAccess.Repository.Contract;
using HandsOnTest.Employees.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HandsOnTest.Employees.Web
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
            services.AddScoped<EmployeeService>();
            services.AddScoped<IEmployeeProvider, EmployeeProvider>();
            services.AddScoped<IEmployeeFactory, EmployeeFactory>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            // Change this configuration for using a different kind of repository
            services.AddScoped<IBaseRepository, HttpBaseRepository>();
            services.AddScoped<HourlySalaryCalculator>();
            services.AddScoped<MonthlySalaryCalculator>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
