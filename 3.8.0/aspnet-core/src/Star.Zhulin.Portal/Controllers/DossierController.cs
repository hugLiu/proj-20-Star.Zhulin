using Microsoft.AspNetCore.Mvc; 
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Portal.Controllers
{
    public class DossierController : ZhulinControllerBase
    { 
        public IActionResult Index()
        {
            ViewBag.ActiveTab = "dossier";
            return View();
        }
    }
}