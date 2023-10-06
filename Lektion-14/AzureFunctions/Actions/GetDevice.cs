using System.Net;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctions.Actions
{
    public class GetDevice
    {
        private readonly IConfiguration _configuration;
        private RegistryManager _registryManager;

        public GetDevice(IConfiguration configuration)
        {
            _configuration = configuration;
            _registryManager = RegistryManager.CreateFromConnectionString(_configuration.GetConnectionString("IotHub"));
        }

        [Function("GetDevice")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "devices/device")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);

            string deviceId = req.Query["deviceId"]!;
            if (!string.IsNullOrEmpty(deviceId)) 
            { 
                var device = await _registryManager.GetTwinAsync(deviceId);
                if (device != null)
                {
                    response.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    response.WriteString(JsonConvert.SerializeObject(device));
                    return response;
                }
            }

            response = req.CreateResponse(HttpStatusCode.BadRequest);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            return response;








        }
    }
}
