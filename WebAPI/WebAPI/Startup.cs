using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Context;
using WebAPI.Services;
using WebAPI.Services.Interfaces;

namespace WebAPI
{
    public class Startup
    {
        // Configuration is nodig om de SQLServer in te stellen in de ConfigureServices-methode
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Zelfgemaakte services toevoegen
            services.AddScoped<IDeviceData, SqlDeviceData>();
            services.AddScoped<IDeviceTypeData, SqlDeviceTypeData>();
            services.AddScoped<IIncidentData, SqlIncidentData>();
            services.AddScoped<IOccurredIncidentData, SqlOccurredIncidentData>();
            services.AddScoped<IUserData, SqlUserData>();

            // SQLServer toevoegen
            services.AddDbContext<IMToolContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); // ConnectionString wordt uit appsettings.json gehaald
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });

            // Startpagina van API (wanneer geen route wordt ingegeven)
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Welcome to INCIDENT TOOL WEB API");
            });
        }
    }
}
