using System.Collections.Generic;
using Star.Zhulin.Roles.Dto;

namespace Star.Zhulin.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
