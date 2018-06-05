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
    public class AlbumEditController : BaseController
    {
        /// <summary>
        /// 服务层接口
        /// </summary>
        private IAlbumService albumService { get; set; }

        /// <summary>
        /// 构造函数注入
        /// </summary> 
        public AlbumEditController(IAlbumService _albumService)
        {
            albumService = _albumService;
        }

        /// <summary>
        /// 相册目录编辑
        /// </summary> 
        [LoginAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取相册信息
        /// </summary>
        public JsonResult GetAlbumTree()
        {
            var list = albumService.GetAlbumInfo(null);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取 name 在album中同名数量
        /// </summary>
        public JsonResult GetNameCount(string name, string pid)
        {
            name = HttpUtility.UrlDecode(name);
            pid = HttpUtility.UrlDecode(pid);
            var list = albumService.GetAlbumInfo(new RECP_AlbumModel { name = name, pid = pid }).ToList();
            return Json(list.Count, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 通过ID获取album信息
        /// </summary>
        public JsonResult GetAlbumInfoById(string id)
        {
            id = HttpUtility.UrlDecode(id);
            var list = albumService.GetAlbumInfo(new RECP_AlbumModel { id = id }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增相册目录树
        /// </summary>
        public string AddAlbumTree(string nodeParams)
        {
            nodeParams = HttpUtility.UrlDecode(nodeParams);
            List<RECP_AlbumModel> models = JsonUtil.JsonToObject(nodeParams, typeof(List<RECP_AlbumModel>)) as List<RECP_AlbumModel>;
            if (models != null && models.Count > 0)
            {
                var id = Guid.NewGuid().ToString();
                foreach (var m in models)
                {
                    m.id = id;
                }
                albumService.ModifyAlbumInfoByTree(models[0]);
                return id;
            }
            return "";
        }

        /// <summary>
        /// 编辑相册目录树
        /// </summary>
        public void UpdateAlbumTree(string nodeParams)
        {
            nodeParams = HttpUtility.UrlDecode(nodeParams);
            List<RECP_AlbumModel> models = JsonUtil.JsonToObject(nodeParams, typeof(List<RECP_AlbumModel>)) as List<RECP_AlbumModel>;
            if (models != null && models.Count > 0)
            {
                albumService.ModifyAlbumInfoByTree(models[0]);
            }
        }

        /// <summary>
        /// 保存相册节点信息
        /// </summary>
        /// <param name="nodeParams"></param>
        public void SaveAlbumInfo(string nodeParams)
        {
            nodeParams = HttpUtility.UrlDecode(nodeParams);
            RECP_AlbumModel model = JsonUtil.JsonToObject(nodeParams, typeof(RECP_AlbumModel)) as RECP_AlbumModel;
            if (model != null)
            {
                albumService.SaveAlbumInfo(model);
            }
        }

        /// <summary>
        /// 缩略图上传
        /// </summary>
        public JsonResult ImgUpload(string iUrl, string iName, string parentName)
        {
            if (string.IsNullOrEmpty(iName)) return Json("error");
            var file = Request.Files["album-input-img"];
            var physicalPath = Request.PhysicalApplicationPath.TrimEnd('\\');
            if (file == null) return Json("null");
            var name = file.FileName;
            var folderPath = "\\Upload\\Album\\";
            if (string.IsNullOrEmpty(parentName))
            {
                folderPath += iName + "\\";
            }
            else
            {
                folderPath += parentName + "\\Sub\\";
            }
            var fileUrl = physicalPath + folderPath + name;
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
            if (!string.IsNullOrEmpty(iUrl)&& System.IO.File.Exists(iFileUrl))
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