using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLogistics.Core.Enum.EnumList;

namespace BLogistics.Core.Helper
{
    public class Response
    {
        public WCFResponseMessageType ResponseStatus { get; set; }
    }

    public class Response<T> : Response
    {
        public T Result { get; set; }
    }
}
