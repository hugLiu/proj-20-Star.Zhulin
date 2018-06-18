using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star.Zhulin.Videos
{
    public interface IVideoRepository : IRepository<Video, Guid>
    {
        //string GetTask2(int id);

       // IEnumerable<Video> GetVideoInfo(Video model);
    }
}
