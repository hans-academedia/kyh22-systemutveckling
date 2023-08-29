using Dapper;
using Newtonsoft.Json;
using Shared.Contracts;
using Shared.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CustomerService : ICustomerContract
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\azure_localdb.mdf;Integrated Security=True;Connect Timeout=30";

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.Query<Customer>("SELECT * FROM Customers");
                return result;
            }
        }

        public string GetAllCustomersAsJson()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.Query<Customer>("SELECT * FROM Customers");
                return JsonConvert.SerializeObject(result);
            }
        }
    }
}
