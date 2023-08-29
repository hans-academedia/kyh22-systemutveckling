using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Contexts;
using Shared.Repositories;
using Shared.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(config => config.AddJsonFile("local.settings.json"))
    .ConfigureServices((builder, services) =>
    {
        services.AddDbContext<SqlContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
        services.AddScoped<CustomerRepository>();
        services.AddScoped<CustomerService>();
    })
    .Build();

host.Run();
