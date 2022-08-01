using BLogistics.Core.DTO;
using System;
using System.Collections.Generic;

namespace BLogistics.Services.OrderServices
{
    public interface IOrderServices
    {
        List<Order> OrderList(DateTime date);
    }
}
