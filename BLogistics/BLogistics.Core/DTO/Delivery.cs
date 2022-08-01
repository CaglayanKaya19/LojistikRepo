using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLogistics.Core.Enum.EnumList;

namespace BLogistics.Core.DTO
{
    public class Delivery
    {
        public string order_no { get; set; }
        public short delivery_status{ get; set; }
    }
}
