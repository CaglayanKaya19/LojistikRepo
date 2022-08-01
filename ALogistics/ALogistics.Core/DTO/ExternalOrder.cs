using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALogistics.Core.DTO
{
    public class ExternalOrder
    {
        public int id { get; set; }
        public string order_no { get; set; }
        public DateTime? create_date { get; set; }
        public string shipment_poit { get; set; }
        public string receiver { get; set; }
        public string contact_phone { get; set; }
        public int order_count { get; set; }
        public string product_name { get; set; }
        public string product_barcode { get; set; }
        public int stock_count { get; set; }
        public string plate { get; set; }

    }
}
