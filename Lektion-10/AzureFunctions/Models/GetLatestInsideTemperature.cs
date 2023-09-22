using System.Net;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctions.Models
{
    public class GetLatestInsideTemperature
    {
        private readonly ILogger _logger;
		private readonly CosmosClient _cosmosClient;
		private readonly Container _container;

		public GetLatestInsideTemperature(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetLatestInsideTemperature>();

			_cosmosClient = new CosmosClient("AccountEndpoint=https://kyh-cosmosdb.documents.azure.com:443/;AccountKey=YeQ4BkqrBCs7Qggp7CmuVr4QFZMsmjqMwPzjHYOZ8jZXRn5Ve5Gz7WeUaV7kFhf9lurB9U2osjh8ACDbGlJlrA==;");
			var database = _cosmosClient.GetDatabase("kyh");
			_container = database.GetContainer("messages");
		}

        [Function("GetLatestInsideTemperature")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
			var result = _container.GetItemLinqQueryable<DataMessage>(true).OrderByDescending(x => x._ts).Take(1).ToList().FirstOrDefault();

			var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString(result.ToString());

            return response;
        }
    }
}
