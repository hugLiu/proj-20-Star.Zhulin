using Microsoft.AspNetCore.Mvc;
using Star.Zhulin.Controllers;
using Star.Zhulin.Videos;

namespace Star.Zhulin.Portal.Controllers
{
    public class VideoController : ZhulinControllerBase
    {
        /// <summary>服务层接口</summary> 
        private readonly IVideoService _videoService;

        /// <summary>构造函数注入</summary> 
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public ActionResult Index()
        {
            ViewBag.ActiveTab = "video";
            return View();
        }

        /// <summary>获取全部信息</summary> 
        public JsonResult GetVideoInfo()
        {
            var list = _videoService.GetAll(); 
            return Json(list?.Result?.Items);
        }
    }
}