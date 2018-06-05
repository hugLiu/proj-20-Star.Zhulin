using System.Threading.Tasks;
using Abp.Application.Services;
using Star.Zhulin.Authorization.Accounts.Dto;

namespace Star.Zhulin.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
