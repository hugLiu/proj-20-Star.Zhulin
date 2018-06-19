using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Star.Zhulin.Albums;
using Star.Zhulin.Albums.Dto;
using Star.Zhulin.Controllers;

namespace Star.Zhulin.Portal.Controllers
{
    public class AlbumManageController : ZhulinControllerBase
    {
        /// <summary>服务层接口</summary> 
        private readonly IAlbumService _albumService;

        /// <summary>构造函数注入</summary> 
        public AlbumManageController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        //[LoginAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取相册文件夹
        /// </summary>
        public JsonResult GetAlbumFolder()
        {
            var list = _albumService.GetAlbumParentInfo();
            return Json(list?.Result?.Items);
        }

        /// <summary>
        /// 相册上传
        /// </summary>
        public JsonResult ImgUpload(string folder)
        {
            if (string.IsNullOrEmpty(folder)) return Json("error"); 
            var file = Request.Form.Files["album-input-imgs"];
            var physicalPath = Request.Path;// .PhysicalApplicationPath;
            if (file == null) return Json("null");
            var name = file.FileName;
            var folderPath = "\\Upload\\Album\\" + folder + "\\Sub";
            var filePath = folderPath + "\\" + name;
            var fileUrl = physicalPath + filePath;
            if (!Directory.Exists(fileUrl))
            {
                Directory.CreateDirectory(fileUrl.Substring(0, fileUrl.LastIndexOf("\\")));
            }
            else
            {
                System.IO.File.Delete(fileUrl);
                Directory.CreateDirectory(fileUrl.Substring(0, fileUrl.LastIndexOf("\\")));
            }
            using (FileStream fs = System.IO.File.Create(name))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            //file.SaveAs(fileUrl);
            return Json(new { path = folderPath, name = name });
        }

        /// <summary>
        /// 保存相册文件夹信息
        /// </summary>
        //public void SaveAlbumFolderInfo(string nodeParams)
        //{
        //    nodeParams = HttpUtility.UrlDecode(nodeParams);
        //    RECP_AlbumModel m = JsonUtil.JsonToObject(nodeParams, typeof(RECP_AlbumModel)) as RECP_AlbumModel;
        //    var id = string.IsNullOrEmpty(m.id) ? Guid.NewGuid().ToString() : m.id;
        //    var folderName = m.name;
        //    var total = 0;

        //    #region 子文件信息保存
        //    if (!string.IsNullOrEmpty(m.url))
        //    {
        //        var physicalPath = Request.PhysicalApplicationPath;
        //        var path = physicalPath + m.url;
        //        var dir = new DirectoryInfo(path);
        //        var fileInfo = dir.GetFileSystemInfos();
        //        var list = new List<RECP_AlbumModel>();
        //        foreach (var f in fileInfo)
        //        {
        //            var model = new RECP_AlbumModel();
        //            model.id = Guid.NewGuid().ToString();
        //            model.pid = id;
        //            model.name = (folderName.Length > 3 ? folderName.Substring(0, 3) + "..." : folderName) + ++total;
        //            model.url = m.url + "\\" + f;
        //            model.fieldIndex = total; //临时排序
        //            list.Add(model);
        //        }
        //        albumService.SaveAlbumSubInfo(list);
        //    }
        //    #endregion



        //    #region 文件夹信息保存
        //    m.total = total.ToString();
        //    //文件夹url这里不负责
        //    if (string.IsNullOrEmpty(m.id))
        //    {
        //        m.id = id;
        //        albumService.AddAlbumInfo(m);
        //    }
        //    else
        //    {
        //        albumService.UpdateAlbumInfo(m);
        //    }
        //    #endregion
        //}

        #region 图片转64位字符串
        //private string ImgToBase64String(string file)
        //{
        //    try
        //    {
        //        Bitmap bmp = new Bitmap(file);
        //        MemoryStream ms = new MemoryStream();
        //        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        byte[] arr = new byte[ms.Length];
        //        ms.Position = 0;
        //        ms.Read(arr, 0, (int)ms.Length);
        //        ms.Close();
        //        return Convert.ToBase64String(arr);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion

        /// <summary>
        /// 通过ID获取相册信息
        /// </summary> 
        //public JsonResult GetAlbumInfoById(string id)
        //{
        //    id = HttpUtility.UrlDecode(id);
        //    var list = albumService.GetAlbumInfo(new RECP_AlbumModel { id = id }).ToList();
        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// 通过PID获取相册信息
        /// </summary> 
        public JsonResult GetAlbumInfoByPId(string pid)

        {
            pid = HttpUtility.UrlDecode(pid);
            var list = _albumService.GetAlbumInfo(new AlbumInput { Pid = new Guid(pid) });
            return Json(list?.Result?.Items);
        }
    }
}