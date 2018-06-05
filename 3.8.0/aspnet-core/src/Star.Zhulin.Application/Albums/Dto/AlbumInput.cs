using System;
using System.Collections.Generic;
using System.Text;

namespace Star.Zhulin.Albums.Dto
{
    public class AlbumInput
    {
        public Guid Id { get; set; }

        public Guid Pid { get; set; }

        public string Name { get; set; }
    }
}
