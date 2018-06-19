using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star.Zhulin.Albums
{ 
    public interface IAlbumRepository : IRepository<Album, Guid>
    {
       // string GetTask2(int id);
    }
}
