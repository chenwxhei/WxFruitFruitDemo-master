namespace WeFruit.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBillFath")]
    public partial class OrderBillFath
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderBillFath()
        {
            OrederBillChis = new HashSet<OrederBillChi>();
        }

        [Key]
        [StringLength(50)]
        public string Code { get; set; }

        public long? CusId { get; set; }

        public byte? State { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OrderPrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExpressPrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SumPrice { get; set; }

        public long? Payment { get; set; }

        [StringLength(50)]
        public string Memo { get; set; }

        public long? CheckUser { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? PayTime { get; set; }

        public DateTime? PostTime { get; set; }

        public DateTime? ReceTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Payment Payment1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrederBillChi> OrederBillChis { get; set; }
    }
}
