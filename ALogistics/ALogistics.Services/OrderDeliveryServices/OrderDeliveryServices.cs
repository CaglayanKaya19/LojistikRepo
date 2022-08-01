using ALogistics.Core.DTO;
using ALogistics.Core.DTO_Integration;
using ALogistics.Core.Enum;
using ALogistics.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using static ALogistics.Core.Enum.EnumList;

namespace ALogistics.Services.OrderDeliveryServices
{
    public class OrderDeliveryServices : IOrderDeliveryServices
    {
        public List<Delivery> ExternalOrderList()
        {
            List<Delivery> result = new List<Delivery>();

            try
            {
                using (var db = new ALogisticsEntities())
                {
                    result = db.tbl_order_delivey.Where(q => q.delivery_status == (short)OrderDeliveryStatus.WasDelivered).Select(q=> new Delivery
                    { 
                        delivery_status = (short)OrderDeliveryStatus.Completed,
                        order_no = q.tbl_external_order.order_no
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message; // Loglama yapılabilir.
            }

            return result;
        }
        public List<ExternalOrder> DeliveryOrderList()
        {
            List<ExternalOrder> result = new List<ExternalOrder>();

            try
            {
                using (var db = new ALogisticsEntities())
                {
                    result = db.tbl_order_delivey.Where(q => q.delivery_status == (short)OrderDeliveryStatus.Wait).Select(q => new ExternalOrder
                    {
                        order_no = q.tbl_external_order.order_no,
                        product_name = q.tbl_external_order.product_name,
                        contact_phone = q.tbl_external_order.contact_phone,
                        order_count = q.tbl_external_order.order_count.Value,
                        plate = ""
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message; // Loglama yapılabilir.
            }

            return result;
        }
        public bool ExternalOrderDeliveryStatusUpdate(Delivery delivery)
        {
            bool result = false;

            try
            {
                using (var db = new ALogisticsEntities())
                {
                    var data = db.tbl_order_delivey.Where(q => q.tbl_external_order.order_no == delivery.order_no).FirstOrDefault();
                    if (data != null)
                    {
                        data.update_date = DateTime.Now;
                        data.delivery_status = (short)OrderDeliveryStatus.Completed;
                        db.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message; // Loglama yapılabilir.
            }

            return result;
        }
        public bool OrderDeliveryUpdate(string plate, string order_no, OrderDeliveryStatus orderDeliveryStatus)
        {
            bool result = false;

            try
            {
                using (var db = new ALogisticsEntities())
                {
                    var data = db.tbl_order_delivey.Where(q => q.tbl_external_order.order_no == order_no).FirstOrDefault();
                    if (data != null)
                    {
                        data.update_date = DateTime.Now;
                        data.delivery_plate = plate;
                        data.delivery_status = (short)orderDeliveryStatus;
                        db.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message; // Loglama yapılabilir.
            }

            return result;
        }
    }
}
