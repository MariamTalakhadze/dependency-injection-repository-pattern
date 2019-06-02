namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shekvetebi")]
    public partial class Shekvetebi :  BEntity
    {
        [Key]
        public int ShekvetaID { get; set; }

        [Required]
        [StringLength(10)]
        public string Shemkveti { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tarigi { get; set; }

        [Required]
        [StringLength(900)]
        public string dasaxeleba { get; set; }

        public int raodenoba { get; set; }

        public double FasiJamurad { get; set; }
    }
}
