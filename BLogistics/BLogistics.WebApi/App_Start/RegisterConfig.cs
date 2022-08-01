using Autofac;
using Autofac.Integration.WebApi;
using BLogistics.Services.DeliveryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace BLogistics.WebApi.App_Start
{
    public class RegisterConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DeliveryServices>().As<IDeliveryServices>();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}