using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApi.Models;

namespace WebApi.Controllers
{
    public interface ICustomersController
    {
        Task<IActionResult> CreateCustomer(Customer customer);
        Task<IActionResult> GetCustomer(string email);
        Task<IActionResult> GetCustomers();
    }


    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase, ICustomersController
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hans\Desktop\kyh\kyh22-systemutveckling\lektion-4\RESTWebApi\WebApi\Data\webapi_database.mdf;Integrated Security=True;Connect Timeout=30";

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using var conn = new SqlConnection(connectionString);
            var result = await conn.ExecuteScalarAsync<int>("INSERT INTO Customers OUTPUT Inserted.Id VALUES (@Name, @Email, @PhoneNumber)", customer);

            return Ok(result);
        }


        [HttpGet("{email}")]
        public async Task<IActionResult> GetCustomer(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            using var conn = new SqlConnection(connectionString);
            var customer = await conn.QueryFirstOrDefaultAsync<Customer>("SELECT * FROM Customers WHERE Email = @Email", new { Email = email });
            if (customer != null)
                return Ok(customer);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            using var conn = new SqlConnection(connectionString);
            var customers = await conn.QueryAsync<Customer>("SELECT * FROM Customers ");

            return Ok(customers);
        }

    }
}
