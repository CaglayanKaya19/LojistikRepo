using ALogistics.Core.DTO;
using ALogistics.Core.DTO_Integration;
using System.Collections.Generic;
using static ALogistics.Core.Enum.EnumList;

namespace ALogistics.Services.OrderDeliveryServices
{
    public interface IOrderDeliveryServices
    {
        List<Delivery> ExternalOrderList();
        List<ExternalOrder> DeliveryOrderList();
        bool ExternalOrderDeliveryStatusUpdate(Delivery delivery);
        bool OrderDeliveryUpdate(string plate, string order_no, OrderDeliveryStatus orderDeliveryStatus);
    }
}
