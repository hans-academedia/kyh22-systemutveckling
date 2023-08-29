using Shared.Contracts;
using Shared.Services;
using System;
using System.ServiceModel;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerContract customerService = new CustomerService();
            var uris = new Uri[]
            {
                new Uri("net.tcp://localhost:5555/customers/")
            };

            ServiceHost host = new ServiceHost(customerService, uris);
            host.AddServiceEndpoint(typeof(ICustomerContract), new NetTcpBinding(SecurityMode.None), "");
            host.Opened += OnServiceHostOpened;
            host.Open();
        }

        private static void OnServiceHostOpened(object sender, EventArgs e)
        {
            Console.WriteLine("WCF Server has been started and is running...");
            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }
}
