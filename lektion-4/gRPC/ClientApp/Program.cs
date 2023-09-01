using ClientApp;
using Grpc.Net.Client;

Console.WriteLine("Press any key to continue...");
Console.ReadKey();


using var channel = GrpcChannel.ForAddress("https://localhost:7199");

await CreateCustomerAsync(channel);
await GetCustomerAsync(channel);
await GetCustomersAsync(channel);

Console.ReadKey();



static async Task CreateCustomerAsync(GrpcChannel channel)
{
    var request = new CreateCustomerRequest();
    
    Console.WriteLine("\nCreate Customer\n-----------------");
    Console.Write("Name: ");
    request.Name = Console.ReadLine();
    Console.Write("E-mail: ");
    request.Email = Console.ReadLine();
    Console.Write("Phone number: ");
    request.PhoneNumber = Console.ReadLine();

    var client = new Customers.CustomersClient(channel);
    var response = await client.CreateCustomerAsync(request);
    
    Console.WriteLine($"\n{response.Id}");
    Console.ReadKey();
}

static async Task GetCustomerAsync(GrpcChannel channel)
{
    var request = new GetCustomerRequest();

    Console.WriteLine("\nGet Customer\n-----------------");
    Console.Write("E-mail: ");
    request.Email = Console.ReadLine();

    var client = new Customers.CustomersClient(channel);
    var response = await client.GetCustomerAsync(request);

    Console.WriteLine($"\n{response.Name} - {response.Email}");
    Console.ReadKey();
}

static async Task GetCustomersAsync(GrpcChannel channel)
{
    var request = new GetCustomersRequest();

    Console.WriteLine("\nGet Customers\n-----------------");

    var client = new Customers.CustomersClient(channel);
    var response = await client.GetCustomersAsync(request);

    foreach(var customer in response.Customers)
        Console.WriteLine($"{customer.Name} - {customer.Email}");

    Console.ReadKey();
}