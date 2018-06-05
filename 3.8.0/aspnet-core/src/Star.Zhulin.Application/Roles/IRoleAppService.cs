using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Star.Zhulin.Roles.Dto;

namespace Star.Zhulin.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
