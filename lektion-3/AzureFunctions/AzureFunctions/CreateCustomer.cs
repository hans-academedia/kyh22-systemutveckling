using System.Net;
using Azure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.Models.Schemas;
using Shared.Services;

namespace AzureFunctions
{
    public class CreateCustomer
    {
        private readonly ILogger _logger;
        private readonly CustomerService _customerService;

        public CreateCustomer(ILoggerFactory loggerFactory, CustomerService customerService)
        {
            _logger = loggerFactory.CreateLogger<CreateCustomer>();
            _customerService = customerService;
        }

        [Function("CreateCustomer")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            var response = req.CreateResponse();

            var data = new StreamReader(req.Body).ReadToEnd();
            if (!string.IsNullOrEmpty(data)) 
            {
                var schema = JsonConvert.DeserializeObject<CustomerSchema>(data);
                if (schema != null)
                {
                    var customer = await _customerService.CreateCustomerAsync(schema);
                    if (customer != null)
                    {
                        response = req.CreateResponse(HttpStatusCode.OK);
                        await response.WriteAsJsonAsync(customer);
                        return response;
                    }
                    response = req.CreateResponse(HttpStatusCode.Conflict);
                    return response;
                }
            }

            response = req.CreateResponse(HttpStatusCode.BadRequest);
            return response;
        }
    }
}
