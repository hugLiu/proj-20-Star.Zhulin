using Microsoft.AspNetCore.Mvc;
using Star.Zhulin.Albums;
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Portal.Controllers
{
    public class AlbumController : ZhulinControllerBase
    {
        /// <summary>服务层接口</summary> 
        private readonly IAlbumService _albumService;

        /// <summary>构造函数注入</summary> 
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public ActionResult Index()
        {
            ViewBag.ActiveTab = "album";
            return View();
        }

        /// <summary>获取全部信息</summary> 
        public JsonResult GetAlbumInfo()
        {
            var list = _albumService.GetAll();
            return Json(list?.Result?.Items);
        }
    }
}