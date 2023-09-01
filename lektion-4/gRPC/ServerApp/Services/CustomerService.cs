using Dapper;
using Grpc.Core;
using Microsoft.Data.SqlClient;

namespace ServerApp.Services;

public class CustomerService : Customers.CustomersBase
{
    private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hans\Desktop\kyh\kyh22-systemutveckling\lektion-4\gRPC\ServerApp\Data\grpc_database.mdf;Integrated Security=True;Connect Timeout=30";

    public override async Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request, ServerCallContext context)
    {
        if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Email))
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid values. Name and Email must be provided."));

        using var conn = new SqlConnection(connectionString);
        var result = await conn.ExecuteScalarAsync<int>("INSERT INTO Customers OUTPUT Inserted.Id VALUES (@Name, @Email, @PhoneNumber)", request);

        return await Task.FromResult(new CreateCustomerResponse
        {
            Id = result
        });
    }




    public override async Task<GetCustomerResponse> GetCustomer(GetCustomerRequest request, ServerCallContext context)
    {
        if (string.IsNullOrEmpty(request.Email))
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid value. Email must be provided."));

        using var conn = new SqlConnection(connectionString);
        var customer = await conn.QueryFirstOrDefaultAsync<GetCustomerResponse>("SELECT * FROM Customers WHERE Email = @Email", new { Email = request.Email });

        if (customer != null)
            return await Task.FromResult(customer);

        throw new RpcException(new Status(StatusCode.NotFound, "The customer was not found."));
    }






    public override async Task<GetCustomersResponse> GetCustomers(GetCustomersRequest request, ServerCallContext context)
    {
        using var conn = new SqlConnection(connectionString);
        var customers = await conn.QueryAsync<GetCustomerResponse>("SELECT * FROM Customers");

        var result = new GetCustomersResponse();
        foreach (var customer in customers)
            result.Customers.Add(customer);

        return await Task.FromResult(result);
    }
}
