using ALogistics.Core.DTO_Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using ALogistics.Core.DTO;
using ALogistics.Data;
using static ALogistics.Core.Enum.EnumList;

namespace ALogistics.Services.ExternalOrderServices
{
    public class ExternalOrderServices : IExternalOrderServices
    {
        public bool ApiDataTransfer(List<Delivery> delivery)
        {
            bool result = false;
            var url = "http://localhost:51353/api/Delivery/OrderDeliveryUpdate";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";
            httpRequest.ContentType = "application/json";
            string serializedData = JsonConvert.SerializeObject(delivery);
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(serializedData);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            var requestResponseString = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                requestResponseString = streamReader.ReadToEnd();
            }

            var response = JsonConvert.DeserializeObject<Response<bool>>(requestResponseString);
            if (response.ResponseStatus == Core.Enum.EnumList.WCFResponseMessageType.Success)
                result = true;
            else
                result = false;

            return result;
        }

        public bool WCFDataTransder(List<ExternalOrder> orders)
        {
            bool result = false;

            try
            {
                using (var db = new ALogisticsEntities())
                {

                    foreach (var item in orders)
                    {
                        tbl_external_order order = new tbl_external_order
                        {
                            order_no = item.order_no,
                            create_date = item.create_date,
                            shipment_poit = item.shipment_poit,
                            receiver = item.receiver,
                            contact_phone = item.contact_phone,
                            order_count = item.order_count,
                            product_name = item.product_name,
                            product_barcode = item.product_barcode,
                            stock_count = item.stock_count
                        };
                        db.tbl_external_order.Add(order);
                        db.SaveChanges();

                        tbl_order_delivey delivey = new tbl_order_delivey
                        {
                            ORDER_ID = order.id,
                            delivery_status = (short)OrderDeliveryStatus.Wait,
                            delivery_person = item.receiver,
                            create_date = DateTime.Now,
                        };
                        db.tbl_order_delivey.Add(delivey);
                        db.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message; // Loglama yapılabilir.
                result = false;
            }

            return result;
        }
    }
}
