using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PriceModel
    {
        public int ID { get; set; }
        public int PKindID { get; set; }
        public string Time { get; set; }
        public int IsCurrent { get; set; }
    }
}