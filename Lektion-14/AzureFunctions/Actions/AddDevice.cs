using System.Net;
using AzureFunctions.Models;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctions.Actions
{
    public class AddDevice
    {
        private readonly string _connectionString = string.Empty;
        private readonly IConfiguration _configuration;
        private RegistryManager _registryManager;

        public AddDevice(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("IotHub");

            _registryManager = RegistryManager.CreateFromConnectionString(_connectionString);
        }

        [Function("AddDevice")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "devices")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);

            string data = new StreamReader(req.Body).ReadToEnd();
            var result = JsonConvert.DeserializeObject<DeviceItem>(data);
            if (result != null)
            {
                if (!string.IsNullOrEmpty(result.DeviceId))
                {
                    var device = await _registryManager.GetDeviceAsync(result.DeviceId);
                    if (device == null)
                    {
                        device = await _registryManager.AddDeviceAsync(new Device(result.DeviceId));
                        response = req.CreateResponse(HttpStatusCode.Created);
                    }

                    var connectionString = $"{_connectionString.Split(";")[0]};DeviceId={device.Id};SharedAccessKey={device.Authentication.SymmetricKey.PrimaryKey}";
                    response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
                    response.WriteString(connectionString);
                    return response;
                }
            }

            response = req.CreateResponse(HttpStatusCode.BadRequest);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            return response;
        }
    }
}