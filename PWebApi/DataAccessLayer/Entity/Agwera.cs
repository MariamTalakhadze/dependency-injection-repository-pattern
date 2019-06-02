namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Agwera")]
    public partial class Agwera : BEntity
    {
       
        public int AgweraID { get; set; }

        [Required]
        [StringLength(900)]
        public string Dasaxeleba { get; set; }

        public double Pasi { get; set; }
    }
}
