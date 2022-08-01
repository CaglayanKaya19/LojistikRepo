using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogistics.Core.DTO
{
    public class Product
    {
        public int id { get; set; }
        public string product_name { get; set; }
        public string product_barcode { get; set; }
        public int stock_count { get; set; }
        public DateTime create_date { get; set; }
    }
}
