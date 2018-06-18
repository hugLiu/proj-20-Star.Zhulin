using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Star.Zhulin.Configuration;

namespace Star.Zhulin.Portal.Startup
{
    [DependsOn(typeof(ZhulinWebCoreModule))]
    public class PortalWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PortalWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalWebCoreModule).GetAssembly());
        }
    }
}
