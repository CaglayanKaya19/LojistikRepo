using BLogistics.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogistics.Services.DeliveryServices
{
    public interface IDeliveryServices
    {
        bool UpdateOrderStatus(List<Delivery> deliveries);
    }
}
