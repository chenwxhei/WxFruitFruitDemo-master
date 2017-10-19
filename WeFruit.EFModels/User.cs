namespace WeFruit.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long Id { get; set; }

        [Required]
        [StringLength(18)]
        public string Username { get; set; }

        [Required]
        [StringLength(18)]
        public string Password { get; set; }

        public int? Phone { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
