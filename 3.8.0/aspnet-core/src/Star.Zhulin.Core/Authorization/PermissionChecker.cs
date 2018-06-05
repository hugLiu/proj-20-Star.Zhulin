using Abp.Authorization;
using Star.Zhulin.Authorization.Roles;
using Star.Zhulin.Authorization.Users;

namespace Star.Zhulin.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
