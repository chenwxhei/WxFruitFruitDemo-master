namespace WeFruit.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        [StringLength(50)]
        public string code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
