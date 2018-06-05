using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Star.Zhulin.Configuration;

namespace Star.Zhulin.Web.Host.Startup
{
    [DependsOn(
       typeof(ZhulinWebCoreModule))]
    public class ZhulinWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ZhulinWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZhulinWebHostModule).GetAssembly());
        }
    }
}
