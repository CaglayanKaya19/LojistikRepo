using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogistics.Core.Enum
{
    public partial class EnumList
    {
        public enum WCFResponseMessageType
        {
            Success = 1,
            Error = 2
        }

        public enum OrderDeliveryStatus
        {
            Wait = 0,
            WasDelivered = 1,
            Completed = 2
        }
    }
}
