using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Web.Portal.Controllers
{ 
    public class AboutController : ZhulinControllerBase
    {
        public IActionResult Index()
        {
            ViewBag.ActiveTab = "aboutus";
            return View();
        }
    }
}