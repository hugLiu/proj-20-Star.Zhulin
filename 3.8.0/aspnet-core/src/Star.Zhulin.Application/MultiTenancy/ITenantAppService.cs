using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Star.Zhulin.MultiTenancy.Dto;

namespace Star.Zhulin.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
