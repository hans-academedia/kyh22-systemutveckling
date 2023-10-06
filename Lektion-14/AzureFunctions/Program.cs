using AzureFunctions.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((config, services) =>
    {
        services.AddDbContext<CosmosContext>(x => x.UseCosmos(config.Configuration.GetConnectionString("CosmosDb")!, "KYH"));
    })
    .Build();

host.Run();
