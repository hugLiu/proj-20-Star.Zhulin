using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Star.Zhulin.Web.Views
{
    public abstract class ZhulinRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ZhulinRazorPage()
        {
            LocalizationSourceName = ZhulinConsts.LocalizationSourceName;
        }
    }
}
