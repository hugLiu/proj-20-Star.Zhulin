using Abp.EntityFrameworkCore;
using Star.Zhulin.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Star.Zhulin.EntityFrameworkCore.Repositories
{
    public class VideoRepository : ZhulinRepositoryBase<Video, Guid>, IVideoRepository
    {
        public VideoRepository(IDbContextProvider<ZhulinDbContext> dbContextProvider) : base(dbContextProvider)
        { }

        public string GetTask2(int id)
        {
            var query = GetAll();
            // query = query.Where(t => t.Id == id);
             var lists = query.ToList()[0].Name;

            return "";
        }
    }
}
