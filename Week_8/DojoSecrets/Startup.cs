using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using DojoSecrets.Models;

namespace DojoSecrets
{
    public class Startup
    {
        private IConfiguration Configuration {get;set;}
        public Startup (IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(options => options.UseNpgsql(Configuration["DBInfo:ConnectionString"]));
            // Add framework services.
            services.AddRouting(options => options.LowercaseUrls=true);
            services.AddMvc();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes => {
                routes.MapRoute(name:"default", template:"{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name:"secrets", template:"{controller=Secret}/{action=Index}/{id?}");
            });
        }
    }
}
