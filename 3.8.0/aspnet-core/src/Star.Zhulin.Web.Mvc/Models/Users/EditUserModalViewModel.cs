using System.Collections.Generic;
using System.Linq;
using Star.Zhulin.Roles.Dto;
using Star.Zhulin.Users.Dto;

namespace Star.Zhulin.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
