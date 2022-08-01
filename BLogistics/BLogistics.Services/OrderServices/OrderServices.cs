using BLogistics.Core.DTO;
using BLogistics.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using static BLogistics.Core.Enum.EnumList;

namespace BLogistics.Services.OrderServices
{
    public class OrderServices : IOrderServices
    {
        public List<Order> OrderList(DateTime date)
        {
            List<Order> result = new List<Order>();
            DateTime min = DateTime.Parse(date.ToString("yyyy-MM-dd"));
            DateTime max = DateTime.Parse(date.ToString("yyyy-MM-dd"));
            max = max.AddHours(23).AddMinutes(59).AddSeconds(59);

            try
            {
                using (var db = new BLogisticsEntities())
                {
                    result = db.tbl_order.Where(q => q.order_transfer_status == (short)OrderDeliveryStatus.Wait && (q.create_date >= min || q.create_date <= max) ).Select(q => new Order
                    {
                        contact_phone = q.contact_phone,
                        create_date = q.create_date,
                        order_transfer_status = q.order_transfer_status,
                        order_count = q.order_count,
                        order_no = q.order_no,
                        PRODUCT_ID = q.PRODUCT_ID,
                        receiver = q.receiver,
                        shipment_poit = q.shipment_poit,
                        order_transfer_status_update_date = q.order_transfer_status_update_date,
                        product = new Product
                        {
                            product_name = q.tbl_product.product_name,
                            product_barcode = q.tbl_product.product_barcode,
                            stock_count = q.tbl_product.stock_count,
                            create_date = q.tbl_product.create_date,
                            id = q.tbl_product.id
                        }
                    }).ToList();
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
