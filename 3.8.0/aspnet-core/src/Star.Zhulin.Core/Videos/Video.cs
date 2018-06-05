using System;
using System.Collections.Generic;
using System.Text;

namespace Star.Zhulin.Videos
{
    using Abp.Domain.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AppVideo")]
    public class Video :  Entity<Guid>
    {
        public const int MaxPidLength = 200;
        public const int MaxNameLength = 200;
        public const int MaxLinkLength = 200;
        public const int MaxUrlLength = 200;

        public Guid? Pid { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxLinkLength)]
        public string Link { get; set; }

        [MaxLength(MaxUrlLength)]
        public string Url { get; set; }

        public int? FieldIndex { get; set; } 
    }
}
