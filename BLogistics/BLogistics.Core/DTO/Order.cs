using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLogistics.Core.Enum.EnumList;

namespace BLogistics.Core.DTO
{
    public class Order
    {
        public string order_no { get; set; }
        public DateTime create_date { get; set; }
        public string shipment_poit { get; set; }
        public string receiver { get; set; }
        public string contact_phone { get; set; }
        public int PRODUCT_ID { get; set; }
        public int order_count { get; set; }
        public short order_transfer_status { get; set; }
        public DateTime? order_transfer_status_update_date { get; set; }
        public Product product{ get; set; }
    }
}
