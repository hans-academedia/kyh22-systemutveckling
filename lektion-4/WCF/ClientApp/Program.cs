using ClientApp.Contracts;
using ClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var binding = new NetTcpBinding(SecurityMode.None);
            var channel = new ChannelFactory<ICustomerContract>(binding);
            var proxy = channel.CreateChannel(new EndpointAddress("net.tcp://localhost:9999/customers"));

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            CreateCustomer(proxy);
            GetCustomer(proxy);
            GetCustomers(proxy);
        }


        private static void CreateCustomer(ICustomerContract proxy)
        {
            var customer = new Customer();

            Console.WriteLine("\n\nNew Customer\n-------------");
            Console.Write("Name: ");
            customer.Name = Console.ReadLine();
            Console.Write("E-mail: ");
            customer.Email = Console.ReadLine();
            Console.Write("Phone number: ");
            customer.PhoneNumber = Console.ReadLine();

            var json = JsonConvert.SerializeObject(customer);
            var id = proxy?.Create(json);
            Console.WriteLine($"New Customer has id: {id}");
            Console.ReadKey();
        }

        private static void GetCustomer(ICustomerContract proxy)
        {
            Console.WriteLine("\n\nGet Customer\n-------------");
            Console.Write("Enter e-mail: ");
            var email = Console.ReadLine();

            var json = proxy?.Get(email);
            if (!string.IsNullOrEmpty(json))
            {
                var customer = JsonConvert.DeserializeObject<Customer>(json);
                Console.WriteLine($"\n{customer.Name} - {customer.Email}");
            }
            Console.ReadKey();
        }


        private static void GetCustomers(ICustomerContract proxy)
        {
            var json = proxy?.GetAll();
            if (!string.IsNullOrEmpty(json))
            {
                var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(json);

                Console.WriteLine("\n\nAll Customers\n-------------");
                foreach(var customer in customers) 
                    Console.WriteLine($"{customer.Name} - {customer.Email}");
            }
            Console.ReadKey();
        }




    }
}
