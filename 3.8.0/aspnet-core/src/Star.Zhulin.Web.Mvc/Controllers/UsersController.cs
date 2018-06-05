using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Star.Zhulin.Authorization;
using Star.Zhulin.Controllers;
using Star.Zhulin.Users;
using Star.Zhulin.Web.Models.Users;

namespace Star.Zhulin.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : ZhulinControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var users = (await _userAppService.GetAll(new PagedResultRequestDto {MaxResultCount = int.MaxValue})).Items; // Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Users = users,
                Roles = roles
            };
            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View("_EditUserModal", model);
        }
    }
}
