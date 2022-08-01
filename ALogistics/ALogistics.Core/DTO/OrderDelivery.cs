using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALogistics.Core.DTO
{
    public class OrderDelivery
    {
        public int id { get; set; }
        public int ORDER_ID { get; set; }
        public short delivery_status { get; set; }
        public string delivery_plate { get; set; }
        public string delivery_person { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
    }
}
