using ALogistics.Services.OrderDeliveryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class Default : System.Web.UI.Page
    {
        IOrderDeliveryServices _orderDeliveryServices;
        public Default(IOrderDeliveryServices orderDeliveryServices)
        {
            _orderDeliveryServices = orderDeliveryServices;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = _orderDeliveryServices.DeliveryOrderList();
                if (data.Count > 0)
                {
                    grdOrderList.DataSource = data;
                    grdOrderList.DataBind();
                }
            }

        }
        protected void grdOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string order_no = grdOrderList.SelectedRow.Cells[0].Text;
            Response.Redirect("Delivery.aspx?order_no=" + order_no);
        }
    }
}