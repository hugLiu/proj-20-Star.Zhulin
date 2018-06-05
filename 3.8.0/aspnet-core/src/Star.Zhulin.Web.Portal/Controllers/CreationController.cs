using System;
  using Microsoft.AspNetCore.Mvc;
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Web.Portal.Controllers
{
    public class CreationController : ZhulinControllerBase
    { 
        public IActionResult Index()
        {
            ViewBag.ActiveTab = "creation";
            return View();
        }
    }
} 
