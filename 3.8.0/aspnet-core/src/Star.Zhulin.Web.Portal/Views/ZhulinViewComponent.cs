using Abp.AspNetCore.Mvc.ViewComponents;

namespace Star.Zhulin.Web.Views
{
    public abstract class ZhulinViewComponent : AbpViewComponent
    {
        protected ZhulinViewComponent()
        {
            LocalizationSourceName = ZhulinConsts.LocalizationSourceName;
        }
    }
}
