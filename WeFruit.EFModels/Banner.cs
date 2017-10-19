namespace WeFruit.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [StringLength(50)]
        public string Link { get; set; }

        [Required]
        [StringLength(50)]
        public string Memo { get; set; }

        public long? PostUserId { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
