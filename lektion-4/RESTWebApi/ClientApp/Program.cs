using ClientApp.Models;
using System.Net.Http.Json;

Console.WriteLine("Press any key to continue...");
Console.ReadKey();

await CreateAsync();
await GetAsync();
await GetAllAsync();


static async Task CreateAsync()
{
    var customer = new Customer();
    
    Console.WriteLine("\n\nNew Customer\n---------------\n");
    Console.Write("Enter Name: ");
    customer.Name = Console.ReadLine() ?? "";
    Console.Write("Enter Email: ");
    customer.Email = Console.ReadLine() ?? "";
    Console.Write("Enter Phone number: ");
    customer.PhoneNumber = Console.ReadLine();

    using var http = new HttpClient();
    var result = await http.PostAsJsonAsync($"https://localhost:7212/api/customers/", customer);

    if (result.IsSuccessStatusCode)
        Console.WriteLine($"{await result.Content.ReadAsStringAsync()}");

    Console.ReadKey();
}


static async Task GetAsync()
{
    Console.WriteLine("\n\nGet Customer\n---------------\n");
    Console.Write("Enter Email: ");
    var email = Console.ReadLine();

    using var http = new HttpClient();
    var customer = await http.GetFromJsonAsync<Customer>($"https://localhost:7212/api/customers/{email}");

    if (customer != null)
        Console.WriteLine($"{customer.Name} - {customer.Email}");

    Console.ReadKey();
}



static async Task GetAllAsync()
{
    Console.WriteLine("\n\nGet All Customers\n---------------\n");

    using var http = new HttpClient();
    var result = await http.GetFromJsonAsync<IEnumerable<Customer>>("https://localhost:7212/api/customers");

    if (result != null)
        foreach (var customer in result)
            Console.WriteLine($"{customer.Name} - {customer.Email}");

    Console.ReadKey();
}