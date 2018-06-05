using System;

namespace Star.Zhulin.Albums
{
    using Abp.Domain.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AppAlbum")]
    public class Album : Entity<Guid>
    {
        public const int MaxPidLength = 200;
        public const int MaxNameLength = 200;
        public const int MaxUrlLength = 200;
        public const int MaxTotalLength = 10;

        public Guid? Pid { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } 

        [MaxLength(MaxUrlLength)]
        public string Url { get; set; }

        [MaxLength(MaxTotalLength)]
        public string Total { get; set; }

        public int? FieldIndex { get; set; }
    }
}
