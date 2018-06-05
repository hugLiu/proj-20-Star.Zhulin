using Abp.AutoMapper;
using Star.Zhulin.Sessions.Dto;

namespace Star.Zhulin.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
