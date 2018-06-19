using Abp.Application.Services.Dto;
using Star.Zhulin.Albums.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Star.Zhulin.Albums
{
    public interface IAlbumService
    { 
        //string GetAlbum();

        /// <summary>获取相册信息</summary>
        Task<ListResultDto<AlbumDto>> GetAlbumInfo(AlbumInput input);

        Task<ListResultDto<AlbumDto>> GetAll();

        ///<summary>获取相册pid=null信息</summary> 
        Task<ListResultDto<AlbumDto>> GetAlbumParentInfo();
        /// <summary>
        /// 获取相册pid=null信息
        /// </summary> 
        //IEnumerable<RECP_AlbumModel> GetAlbumParentInfo();

        ///// <summary>
        ///// 获取相册信息
        ///// </summary>
        //IEnumerable<RECP_AlbumModel> GetAlbumInfo(RECP_AlbumModel model);

        ///// <summary>
        ///// 保存相册信息
        ///// </summary>
        //void SaveAlbumInfo(RECP_AlbumModel model);

        ///// <summary>
        ///// 保存相册文件信息
        ///// </summary>
        //void SaveAlbumSubInfo(IList<RECP_AlbumModel> model);

        ///// <summary>
        ///// 添加
        ///// </summary> 
        //void AddAlbumInfo(RECP_AlbumModel model);

        ///// <summary>
        ///// 更新
        ///// </summary> 
        //void UpdateAlbumInfo(RECP_AlbumModel model);

        ///// <summary>
        ///// 处理相册信息
        ///// </summary>
        //void ModifyAlbumInfoByTree(RECP_AlbumModel model);
    }
}
