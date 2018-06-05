using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Star.Zhulin.Configuration;

namespace Star.Zhulin.Web.Startup
{
    [DependsOn(typeof(ZhulinWebCoreModule))]
    public class ZhulinWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ZhulinWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<ZhulinNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZhulinWebMvcModule).GetAssembly());
        }
    }
}
