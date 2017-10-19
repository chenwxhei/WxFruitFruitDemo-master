namespace WeFruit.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public long Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string BillCode { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
