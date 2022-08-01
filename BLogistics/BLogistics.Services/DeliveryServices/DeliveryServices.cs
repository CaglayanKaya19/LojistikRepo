using BLogistics.Core.DTO;
using BLogistics.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogistics.Services.DeliveryServices
{
    public class DeliveryServices : IDeliveryServices
    {
        public bool UpdateOrderStatus(List<Delivery> deliveries)
        {
            bool result = false;
            try
            {
                using (var db = new BLogisticsEntities())
                {
                    foreach (var item in deliveries)
                    {
                        var data = db.tbl_order.Where(q => q.order_no == item.order_no).FirstOrDefault();

                        if (data != null)
                        {
                            data.order_transfer_status = (short)item.delivery_status;
                            data.order_transfer_status_update_date = DateTime.Now;
                            db.SaveChanges();
                            result = true;
                        }
                        else
                            result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                result = false;
            }
            return result;
        }
    }
}
