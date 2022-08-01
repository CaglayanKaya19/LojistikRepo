using ALogistics.Console.WCFDataTransfer.OrderService;
using ALogistics.Core.DTO;
using ALogistics.Core.DTO_Integration;
using ALogistics.Services.ExternalOrderServices;
using ALogistics.Services.OrderDeliveryServices;
using Autofac;
using System;
using System.Collections.Generic;

namespace ALogistics.Console.WCFDataTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("WCF Data Transfer Start: " + DateTime.Now.ToString());
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
            System.Console.WriteLine("WCF Data Transfer End: " + DateTime.Now.ToString());
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
        private readonly IExternalOrderServices _externalOrderServices;
        public Application(IExternalOrderServices externalOrderServices)
        {
            _externalOrderServices = externalOrderServices;
        }

        public void Run()
        {
            OrderServiceClient client = new OrderServiceClient();
            var listData = client.OrderList(DateTime.Now.AddDays(-1));
            List<ExternalOrder> list = new List<ExternalOrder>();
            foreach (var item in listData.Result)
            {
                ExternalOrder data = new ExternalOrder
                {
                    order_no = item.order_no,
                    create_date = item.create_date,
                    shipment_poit = item.shipment_poit,
                    receiver = item.receiver,
                    contact_phone = item.contact_phone,
                    order_count = item.order_count,
                    product_name = item.product.product_name,
                    product_barcode = item.product.product_barcode,
                    stock_count = item.product.stock_count
                };
                list.Add(data);
            }
            if (_externalOrderServices.WCFDataTransder(list))
                System.Console.WriteLine("WCF Data Transfer Success: " + DateTime.Now.ToString());
            else
                System.Console.WriteLine("WCF Data Transfer Error: " + DateTime.Now.ToString());
        }
    }
}
