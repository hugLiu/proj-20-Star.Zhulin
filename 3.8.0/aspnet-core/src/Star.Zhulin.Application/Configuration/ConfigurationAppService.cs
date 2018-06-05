using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Star.Zhulin.Configuration.Dto;

namespace Star.Zhulin.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ZhulinAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
