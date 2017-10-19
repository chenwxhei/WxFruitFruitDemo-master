namespace WeFruit.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrederBillChi")]
    public partial class OrederBillChi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UnitPrice { get; set; }

        public int? Qty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SumPrice { get; set; }

        [StringLength(50)]
        public string IsReview { get; set; }

        public virtual OrderBillFath OrderBillFath { get; set; }

        public virtual Product Product { get; set; }
    }
}
