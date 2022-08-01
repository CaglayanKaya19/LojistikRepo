using Autofac;
using Autofac.Integration.Wcf;
using BLogistics.Services.OrderServices;
using BLogistics.WCFService.Service;
using BLogistics.WCFService.Service.Contracts;
using System;

namespace BLogistics.WCFService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<OrderServices>().As<IOrderServices>();
            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}