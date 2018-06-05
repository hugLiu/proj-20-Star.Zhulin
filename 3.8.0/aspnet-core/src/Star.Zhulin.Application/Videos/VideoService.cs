using Microsoft.EntityFrameworkCore;
using Abp.Application.Services.Dto;
using Star.Zhulin.Videos.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;

namespace Star.Zhulin.Videos
{
    public class VideoService : ZhulinAppServiceBase, IVideoService
    {
        public readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public string GetTask(int id)
        {
            return _videoRepository.GetTask2(id);
        }

        public IEnumerable<string> GetVideoInfo()
        {
            return null;
        }

        public string GetVideo()
        {
            return _videoRepository.GetTask2(3);
        }

        public async Task<ListResultDto<VideoDto>> GetVideoInfo(VideoInput input)
        {
            var video = await _videoRepository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Id.ToString()), t => t.Id == input.Id)
                .WhereIf(!string.IsNullOrEmpty(input.Pid.ToString()), t => t.Pid == input.Pid)
                .WhereIf(!string.IsNullOrEmpty(input.Name), t => t.Name == input.Name)
                .OrderByDescending(t => t.FieldIndex)
                .ToListAsync();

            return new ListResultDto<VideoDto>
            (
                ObjectMapper.Map<List<VideoDto>>(video)
            );
            //return new VideoOutput
            //{
            //    Video = video.MapTo<List<VideoDto>>()
            //};

        }
        public async Task<ListResultDto<VideoDto>> GetAll()
        {
            var video = await _videoRepository
                .GetAll()
                .OrderByDescending(t => t.FieldIndex)
                .ToListAsync();
             
            return new ListResultDto<VideoDto>
            (
                ObjectMapper.Map<List<VideoDto>>(video)
            );
        }
    }
}
