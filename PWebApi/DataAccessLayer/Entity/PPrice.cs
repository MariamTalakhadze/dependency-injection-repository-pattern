namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PPrice")]
    public partial class PPrice : BEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PPrice()
        {
            POrders = new HashSet<POrder>();
        }

        public int ID { get; set; }

        public int PKindID { get; set; }

        [Required]
        [StringLength(20)]
        public string Time { get; set; }

        public int IsCurrent { get; set; }

        public virtual pkind pkind { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POrder> POrders { get; set; }
    }
}
