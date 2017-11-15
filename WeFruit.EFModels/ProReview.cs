namespace WeFruit.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProReview")]
    public partial class ProReview
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProCode { get; set; }

        [StringLength(50)]
        public string CusId { get; set; }

        [StringLength(50)]
        public string Body { get; set; }

        public bool? State { get; set; }

        public int? Rate { get; set; }

        public DateTime? CreateTime { get; set; }

        public virtual Product Product { get; set; }
    }
}
