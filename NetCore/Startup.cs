using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"config.{_env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets("aspnet-DreamsPart-716a052e-4235-4e5f-93bf-ba57ba6934b9");

            }

            _config = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton(_config);

            // Declare MVC Services
            services.AddMvc();

            //  services.AddDbContext<DreamsPartReg_Context>(
            //options => options.UseSqlServer(_config["ConnectionStrings:DreamPartRegContextConnection"],
            //b => b.MigrationsAssembly("DreamsPart"))
            //);


            // services.AddEntityFrameworkSqlServer().AddDbContext<DreamsPart_RegContext>();

            //services.AddScoped<IRegRepository, RegRepo>();
            //services.AddScoped<IAuthRepository, AuthRepository>();

            // add logging:
            // services.AddLogging();
            // end

            #region'Health Check

          //  services.AddHealthChecks();
            //services.AddHealthChecks()
            //    .AddCheck("sql", () =>
            //    {

            //        using (var connection = new SqlConnection(_config["ConnectionStrings:DreamPartRegContextConnection"]))
            //        {
            //            try
            //            {
            //                connection.Open();
            //            }
            //            catch (SqlException)
            //            {
            //                return HealthCheckResult.Unhealthy();
            //            }
            //        }
            //        return HealthCheckResult.Healthy();

            //    });

            // services.AddHealthChecksUI();
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });

            #region Health-Check
            //app.UseRouting();  // enable routing
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapHealthChecks("/health");
            //});

            //   app.UseHealthChecksUI();
            #endregion

        }
    }
}
