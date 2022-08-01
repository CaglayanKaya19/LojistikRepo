using ALogistics.Core.DTO;
using ALogistics.Core.DTO_Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALogistics.Services.ExternalOrderServices
{
    public interface IExternalOrderServices
    {
        bool ApiDataTransfer(List<Delivery> delivery);
        bool WCFDataTransder(List<ExternalOrder> orders);
    }
}
