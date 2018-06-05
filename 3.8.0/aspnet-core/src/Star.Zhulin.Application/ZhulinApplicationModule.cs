using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Star.Zhulin.Authorization;

namespace Star.Zhulin
{
    [DependsOn(
        typeof(ZhulinCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ZhulinApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ZhulinAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ZhulinApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
