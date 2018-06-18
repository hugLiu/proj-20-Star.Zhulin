using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Star.Zhulin.Controllers;
using Star.Zhulin.Portal.Models;
using Star.Zhulin.Videos;

namespace Star.Zhulin.Portal.Controllers
{
    public class HomeController : ZhulinControllerBase
    {
        private readonly IVideoService _videoService;

        public HomeController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public IActionResult Index()
        {
            var a = _videoService.GetAll();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
