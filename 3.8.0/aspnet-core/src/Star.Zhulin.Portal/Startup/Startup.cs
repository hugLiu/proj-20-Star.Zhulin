using System;
using System.IO;
using Abp.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Star.Zhulin.Configuration;

namespace Star.Zhulin.Portal.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); 
            services.AddNodeServices();
            AuthConfigurer.Configure(services, _appConfiguration);
            return services.AddAbp<PortalWebCoreModule>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    //FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"HeroApp", @"dist-server")),
            //    //RequestPath = new PathString("/HeroApp/dist-server")
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapSpaFallbackRoute(name: "spa-fallback", defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
