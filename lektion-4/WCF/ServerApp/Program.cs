using ServerApp.Contracts;
using ServerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerContract customerService = new CustomerService();
            var uris = new Uri[]
            {
                new Uri("net.tcp://localhost:9999/customers/")
            };

            ServiceHost host = new ServiceHost(customerService, uris);
            host.AddServiceEndpoint(typeof(ICustomerContract), new NetTcpBinding(SecurityMode.None), "");
            host.Opened += OnServiceHostOpened;
            host.Open();

        }

        private static void OnServiceHostOpened(object sender, EventArgs e)
        {
            Console.WriteLine("WCF Server has been started and is in running mode...");
            Console.WriteLine("Press any key to close the WCF Server Connection.");
            Console.ReadKey();
        }
    }
}
