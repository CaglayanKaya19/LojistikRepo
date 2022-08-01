using ALogistics.Services.OrderDeliveryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class Delivery : System.Web.UI.Page
    {
        public string order_no { get; set; }
        IOrderDeliveryServices _orderDeliveryServices;
        public Delivery(IOrderDeliveryServices orderDeliveryServices)
        {
            _orderDeliveryServices = orderDeliveryServices;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            order_no = Request.QueryString["order_no"].ToString();
        }

         protected void btSave_Click(object sender, EventArgs e)
        {
            ALogistics.Core.Enum.EnumList.OrderDeliveryStatus deliveryStatus = ALogistics.Core.Enum.EnumList.OrderDeliveryStatus.CouldNotBeReached;
            string plate = drpPlate.SelectedItem.Value;
            int status = Convert.ToInt32(drpDeliveryStatus.SelectedItem.Value);
            if (status == 0)
                return;
            else if (status == 1)
            {
                deliveryStatus = ALogistics.Core.Enum.EnumList.OrderDeliveryStatus.WasDelivered;
            }
             
            if (_orderDeliveryServices.OrderDeliveryUpdate(plate, order_no, deliveryStatus))
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}