using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star.Zhulin.Albums.Dto
{
    [AutoMapFrom(typeof(Album))]
    public class AlbumDto : EntityDto<Guid>
    { 
        public Guid? Pid { get; set; }

        public string Name { get; set; } 

        public string Url { get; set; }

        public string Total { get; set; }

        public int? FieldIndex { get; set; } 
    }
}
