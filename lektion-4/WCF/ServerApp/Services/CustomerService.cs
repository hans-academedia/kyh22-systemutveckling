using Dapper;
using Newtonsoft.Json;
using ServerApp.Contracts;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

// ExecuteNonQuery = bara utför ger inget svar tillbaka
// ExecuteScalar = utför något och skickar tillbaka ett värde men bara ett värde
// ExecuteReader = utför något och skickar tillbaka ett eller flera värden eller rader

namespace ServerApp.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class CustomerService : ICustomerContract
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hans\Desktop\kyh\kyh22-systemutveckling\lektion-4\WCF\ServerApp\Data\wcf_database.mdf;Integrated Security=True;Connect Timeout=30";

        public int Create(string json)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var customer = JsonConvert.DeserializeObject<Customer>(json);

                var result = conn.ExecuteScalar<int>("INSERT INTO Customers OUTPUT Inserted.Id VALUES (@Name, @Email, @PhoneNumber)", customer);
                return result;
            }
        }

        public string Get(string email)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.QueryFirstOrDefault<Customer>("SELECT * FROM Customers WHERE Email = @Email", new { Email = email });
                var json = JsonConvert.SerializeObject(result);
                return json;
            }
        }

        public string GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.Query<Customer>("SELECT * FROM Customers");
                var json = JsonConvert.SerializeObject(result);
                return json;
            }
        }
    }
}
