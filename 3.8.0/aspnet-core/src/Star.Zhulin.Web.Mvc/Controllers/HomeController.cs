using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ZhulinControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
