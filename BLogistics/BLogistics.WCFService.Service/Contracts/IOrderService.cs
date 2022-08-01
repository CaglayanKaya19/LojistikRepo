using BLogistics.Core.DTO;
using BLogistics.Core.Helper;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace BLogistics.WCFService.Service.Contracts
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        Response<List<Order>> OrderList(DateTime date);
    }
}
