using Microsoft.AspNetCore.Antiforgery;
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Web.Host.Controllers
{
    public class AntiForgeryController : ZhulinControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
