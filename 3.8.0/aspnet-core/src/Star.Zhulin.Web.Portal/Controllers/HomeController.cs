using Microsoft.AspNetCore.Mvc; 
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Web.Portal.Controllers
{
    public class HomeController : ZhulinControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
