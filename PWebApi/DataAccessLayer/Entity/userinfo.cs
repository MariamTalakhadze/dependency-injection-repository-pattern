namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("userinfo")]
    public partial class userinfo : BEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public userinfo()
        {
            POrders = new HashSet<POrder>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string NameSurname { get; set; }

        public long PN { get; set; }

        [Required]
        [StringLength(10)]
        public string MobileNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POrder> POrders { get; set; }
    }
}
