using BLogistics.WCFService.Service.Contracts;
using BLogistics.Core.Enum;
using BLogistics.Services.OrderServices;
using System.Collections.Generic;
using BLogistics.Core.DTO;
using BLogistics.Core.Helper;
using System;

namespace BLogistics.WCFService.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderServices _orderServices;
        public OrderService(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public Response<List<Order>> OrderList(DateTime date)
        {
            Response<List<Order>> result = new Response<List<Order>>();
            result.Result = new List<Order>();
            var dataList = _orderServices.OrderList(date);
            if (dataList.Count > 0)
            {
                result.ResponseStatus = EnumList.WCFResponseMessageType.Success;
                result.Result = dataList;
            }

            return result;
        }
    }
}
