namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Momxmarebeli")]
    public partial class Momxmarebeli : BEntity
    {
        public int MomxmarebeliID { get; set; }

        [Required]
        [StringLength(10)]
        public string Saxeli { get; set; }

        [Required]
        [StringLength(10)]
        public string Gvari { get; set; }

        [Required]
        [StringLength(10)]
        public string Nomeri { get; set; }

        [Required]
        [StringLength(10)]
        public string Statusi { get; set; }
    }
}
