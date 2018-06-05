using System.Threading.Tasks;
using Star.Zhulin.Configuration.Dto;

namespace Star.Zhulin.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
