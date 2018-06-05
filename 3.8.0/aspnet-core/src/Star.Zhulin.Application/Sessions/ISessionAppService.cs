using System.Threading.Tasks;
using Abp.Application.Services;
using Star.Zhulin.Sessions.Dto;

namespace Star.Zhulin.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
