using System.Net;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctions.Actions
{
    public class GetDevices
    {
        private readonly IConfiguration _configuration;
        private RegistryManager _registryManager;

        public GetDevices(IConfiguration configuration)
        {
            _configuration = configuration;
            _registryManager = RegistryManager.CreateFromConnectionString(_configuration.GetConnectionString("IotHub"));
        }

        [Function("GetDevices")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "devices")] HttpRequestData req)
        {
            var devices = new List<Twin>();

            var result = _registryManager.CreateQuery("select * from devices");
            foreach(var device in await result.GetNextAsTwinAsync())
                devices.Add(device);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            response.WriteString(JsonConvert.SerializeObject(devices));
            return response;
        }
    }
}
