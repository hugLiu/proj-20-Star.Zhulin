using System.Collections.Generic;
using Star.Zhulin.Roles.Dto;
using Star.Zhulin.Users.Dto;

namespace Star.Zhulin.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
