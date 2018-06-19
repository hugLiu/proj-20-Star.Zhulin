using Microsoft.AspNetCore.Mvc;
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Portal.Controllers
{
    public class WallpaperController : ZhulinControllerBase
    { 
        public IActionResult Index()
        {
            ViewBag.ActiveTab = "wallpaper";
            return View();
        }
    }
} 
