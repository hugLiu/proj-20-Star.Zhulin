using Abp.Application.Services.Dto;
using Star.Zhulin.Videos.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Star.Zhulin.Videos
{
    public interface IVideoService
    { 
        string GetVideo();

        /// <summary>获取视频信息</summary>
        Task<ListResultDto<VideoDto>> GetVideoInfo(VideoInput input);

        Task<ListResultDto<VideoDto>> GetAll();
    }
}
