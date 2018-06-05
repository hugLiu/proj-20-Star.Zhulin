using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Star.Zhulin.Controllers
{
    public abstract class ZhulinControllerBase: AbpController
    {
        protected ZhulinControllerBase()
        {
            LocalizationSourceName = ZhulinConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
