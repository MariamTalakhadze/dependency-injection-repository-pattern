namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class POrder : BEntity
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int PriceId { get; set; }

        public int PID { get; set; }

        public int NOrders { get; set; }

        [StringLength(100)]
        public string Descrip { get; set; }

        public double PriceTotal { get; set; }

        public virtual pkind pkind { get; set; }

        public virtual PPrice PPrice { get; set; }

        public virtual userinfo userinfo { get; set; }
    }
}
