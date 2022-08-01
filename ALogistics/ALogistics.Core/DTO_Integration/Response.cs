using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ALogistics.Core.Enum.EnumList;

namespace ALogistics.Core.DTO_Integration
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
