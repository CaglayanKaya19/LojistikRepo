using BLogistics.Core.DTO;
using BLogistics.Core.Helper;
using BLogistics.Services.DeliveryServices;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace BLogistics.WebApi.Controllers
{
    public class DeliveryController : ApiController
    {
        private readonly IDeliveryServices _deliveryServices;
        public DeliveryController(IDeliveryServices deliveryServices)
        {
            _deliveryServices = deliveryServices;
        }

        [HttpPut]
        public Response<bool> OrderDeliveryUpdate([FromBody] List<Delivery> deliveries)
        {
            Response<bool> result = new Response<bool>();
            result.ResponseStatus = Core.Enum.EnumList.WCFResponseMessageType.Error;
            result.Result = false;
            if (_deliveryServices.UpdateOrderStatus(deliveries))
            {
                result.ResponseStatus = Core.Enum.EnumList.WCFResponseMessageType.Success;
                result.Result = true;
            }

            return result;
        }
    }
}