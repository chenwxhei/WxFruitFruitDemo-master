namespace WeFruit.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notice")]
    public partial class Notice
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Body { get; set; }

        public long? PostUserId { get; set; }

        public DateTime? ModiTime { get; set; }
    }
}
