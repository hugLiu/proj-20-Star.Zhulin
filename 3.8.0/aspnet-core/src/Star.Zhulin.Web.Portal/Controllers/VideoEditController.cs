using Jurassic.RECP.DataService.Models;
using Jurassic.RECP.DataService.Service;
using Jurassic.RECP.DataService.Tool;
using Jurassic.WebFrame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace Star.Zhulin.Web.UI.Controllers
{
    public class VideoEditController : BaseController
    {
        /// <summary>
        /// 服务层接口
        /// </summary>
        private IVideoService videoService { get; set; }

        /// <summary>
        /// 构造函数注入
        /// </summary> 
        public VideoEditController(IVideoService _videoService)
        {
            videoService = _videoService;
        }

        /// <summary>
        /// 视频目录编辑页
        /// </summary> 
        [LoginAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取视频信息
        /// </summary>
        public JsonResult GetVideoTree()
        {
            var list = videoService.GetVideoInfo(null);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取 name 在video中同名数量
        /// </summary>
        public JsonResult GetNameCount(string name, string pid)
        {
            name = HttpUtility.UrlDecode(name);
            pid = HttpUtility.UrlDecode(pid);
            var list = videoService.GetVideoInfo(new RECP_VideoModel { name = name, pid = pid }).ToList();
            return Json(list.Count, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 通过ID获取video信息
        /// </summary>
        public JsonResult GetVideoInfoById(string id)
        {
            id = HttpUtility.UrlDecode(id);
            var list = videoService.GetVideoInfo(new RECP_VideoModel { id = id }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增视频目录树
        /// </summary>
        public string AddVideoTree(string nodeParams)
        {
            nodeParams = HttpUtility.UrlDecode(nodeParams);
            List<RECP_VideoModel> models = JsonUtil.JsonToObject(nodeParams, typeof(List<RECP_VideoModel>)) as List<RECP_VideoModel>;
            if (models != null && models.Count > 0)
            {
                var id = Guid.NewGuid().ToString();
                foreach (var m in models)
                {
                    m.id = id;
                }
                videoService.ModifyVideoInfoByTree(models[0]);
                return id;
            }
            return "";
        }

        /// <summary>
        /// 编辑视频目录树
        /// </summary>
        public void UpdateVideoTree(string nodeParams)
        {
            nodeParams = HttpUtility.UrlDecode(nodeParams);
            List<RECP_VideoModel> models = JsonUtil.JsonToObject(nodeParams, typeof(List<RECP_VideoModel>)) as List<RECP_VideoModel>;
            if (models != null && models.Count > 0)
            {
                videoService.ModifyVideoInfoByTree(models[0]);
            }
        }

        /// <summary>
        /// 保存视频节点信息
        /// </summary>
        /// <param name="nodeParams"></param>
        public void SaveVideoInfo(string nodeParams)
        {
            nodeParams = HttpUtility.UrlDecode(nodeParams);
            RECP_VideoModel model = JsonUtil.JsonToObject(nodeParams, typeof(RECP_VideoModel)) as RECP_VideoModel;
            if (model != null)
            {
                videoService.SaveVideoInfo(model);
            }
        }

        /// <summary>
        /// 缩略图上传
        /// </summary>
        public JsonResult ImgUpload(string iUrl, string folder)
        {
            if (string.IsNullOrEmpty(folder)) return Json("error");
            var file = Request.Files["video-input-img"];
            var physicalPath = Request.PhysicalApplicationPath.TrimEnd('\\');
            if (file == null) return Json("null");
            var name = file.FileName;
            var folderPath = "\\Upload\\Video\\" + folder;
            var fileUrl = physicalPath + folderPath + "\\" + name;
            if (!Directory.Exists(fileUrl))
            {
                Directory.CreateDirectory(fileUrl.Substring(0, fileUrl.LastIndexOf("\\")));
            }
            else
            {
                System.IO.File.Delete(fileUrl);
                Directory.CreateDirectory(fileUrl.Substring(0, fileUrl.LastIndexOf("\\")));
            }
            //删除当前被替换的图片
            var iFileUrl = physicalPath + iUrl;
            if (!string.IsNullOrEmpty(iUrl) && System.IO.File.Exists(iFileUrl))
            {
                System.IO.File.Delete(iFileUrl);
            }
            file.SaveAs(fileUrl);
            return Json(new { path = folderPath + name, name = name });
        }

        /// <summary>
        /// 删除文件夹子目录及文件
        /// </summary>
        public void DeleteFolder(string folderUrl)
        {
            try
            {
                var dir = new DirectoryInfo(folderUrl);
                var fileInfo = dir.GetFileSystemInfos();
                foreach (var i in fileInfo)
                {
                    if (i is DirectoryInfo)
                    {
                        var subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);
                    }
                    else
                    {
                        System.IO.File.Delete(i.FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}