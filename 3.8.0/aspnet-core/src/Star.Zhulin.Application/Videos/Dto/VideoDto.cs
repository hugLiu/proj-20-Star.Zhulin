using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star.Zhulin.Videos.Dto
{
    [AutoMapFrom(typeof(Video))]
    public class VideoDto : EntityDto<Guid>
    { 
        public Guid? Pid { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public string Url { get; set; }

        public int? FieldIndex { get; set; }
    }
}
