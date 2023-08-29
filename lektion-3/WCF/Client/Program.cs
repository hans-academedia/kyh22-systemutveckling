using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var binding = new NetTcpBinding(SecurityMode.None);
            var channel = new ChannelFactory<ICustomerContract>(binding);
            var proxy = channel.CreateChannel(new EndpointAddress("net.tcp://localhost:5555/customers"));

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            GetCustomersAsJson(proxy);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            GetCustomers(proxy);

        }

        private static void GetCustomers(ICustomerContract proxy)
        {
            var response = proxy?.GetAllCustomers();
            if (response != null)
            {
                Console.WriteLine();
                Console.WriteLine("All Customers");
                foreach(var customer in response)
                    Console.WriteLine($"{customer.Name} - {customer.Email}");

                Console.ReadKey();
            }
        }

        private static void GetCustomersAsJson(ICustomerContract proxy)
        {
            var response = proxy?.GetAllCustomersAsJson();
            if (!string.IsNullOrEmpty(response))
            {
                Console.WriteLine();
                Console.WriteLine("All Customers as Json");
                Console.WriteLine(response);

                Console.ReadKey();
            }
        }
    }
}
