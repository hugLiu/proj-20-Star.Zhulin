using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Star.Zhulin.Roles.Dto;
using Star.Zhulin.Users.Dto;

namespace Star.Zhulin.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
