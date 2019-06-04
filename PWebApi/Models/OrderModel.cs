using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int PriceId { get; set; }
        public int PID { get; set; }
        public int NOrders { get; set; }
        public string Descrip { get; set; }
        public double PriceTotal { get; set; }
    }
}