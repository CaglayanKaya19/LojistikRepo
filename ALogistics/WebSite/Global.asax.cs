using ALogistics.Services.OrderDeliveryServices;
using System;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using Unity;
using ALogistics.Services.ExternalOrderServices;

namespace WebSite
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = this.AddUnity();
            container.RegisterType<IOrderDeliveryServices, OrderDeliveryServices>();
            container.RegisterType<IExternalOrderServices, ExternalOrderServices>();
        }
    }
}