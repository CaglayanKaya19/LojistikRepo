using ALogistics.Core.DTO_Integration;
using ALogistics.Services.ExternalOrderServices;
using ALogistics.Services.OrderDeliveryServices;
using Autofac;
using System;
using System.Collections.Generic;

namespace ALogistics.Console.ApiDataTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Api Data Transfer Start: " + DateTime.Now.ToString());
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
            System.Console.WriteLine("Api Data Transfer End: " + DateTime.Now.ToString());
        }
    }

    public interface IApplication
    {
        void Run();
    }

    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<OrderDeliveryServices>().As<IOrderDeliveryServices>();
            builder.RegisterType<ExternalOrderServices>().As<IExternalOrderServices>();

            return builder.Build();
        }
    }

    public class Application : IApplication
    {
        private readonly IOrderDeliveryServices _orderDeliveryServices;
        private readonly IExternalOrderServices _externalOrderServices;
        public Application(IOrderDeliveryServices orderDeliveryServices, IExternalOrderServices externalOrderServices)
        {
            _orderDeliveryServices = orderDeliveryServices;
            _externalOrderServices = externalOrderServices;
        }

        public void Run()
        {
            var dataList = _orderDeliveryServices.ExternalOrderList();
            if (dataList.Count > 0)
            {
                foreach (var item in dataList)
                {
                    List<Delivery> sendData = new List<Delivery>();
                    sendData.Add(item);
                    if (_externalOrderServices.ApiDataTransfer(sendData))
                    {
                        _orderDeliveryServices.ExternalOrderDeliveryStatusUpdate(item);
                    }
                }
            }
        }
    }
}
