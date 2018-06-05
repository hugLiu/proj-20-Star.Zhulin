using Microsoft.AspNetCore.Mvc; 
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Web.Portal.Controllers
{
    public class LeftController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}