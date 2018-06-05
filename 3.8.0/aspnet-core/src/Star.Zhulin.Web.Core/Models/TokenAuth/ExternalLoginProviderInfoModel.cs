using Abp.AutoMapper;
using Star.Zhulin.Authentication.External;

namespace Star.Zhulin.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
