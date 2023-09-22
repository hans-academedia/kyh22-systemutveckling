using System;

using System.Text;
using Azure.Messaging.EventHubs;
using AzureFunctions.Models;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctions
{
    public class SaveDataToCosmosDB
    {
        private readonly ILogger<SaveDataToCosmosDB> _logger;
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public SaveDataToCosmosDB(ILogger<SaveDataToCosmosDB> logger)
        {
            _logger = logger;

            _cosmosClient = new CosmosClient("AccountEndpoint=https://kyh-cosmosdb.documents.azure.com:443/;AccountKey=YeQ4BkqrBCs7Qggp7CmuVr4QFZMsmjqMwPzjHYOZ8jZXRn5Ve5Gz7WeUaV7kFhf9lurB9U2osjh8ACDbGlJlrA==;");
            var database = _cosmosClient.GetDatabase("kyh");
            _container = database.GetContainer("messages");

        }

        [Function(nameof(SaveDataToCosmosDB))]
        public async Task Run([EventHubTrigger("iothub-ehub-kyh-iothub-25235613-13f1cd2256", Connection = "IotHubEndpoint")] EventData[] events)
        {
            foreach (EventData @event in events)
            {
                try
                {
					var json = Encoding.UTF8.GetString(@event.Body.ToArray());
					var data = JsonConvert.DeserializeObject<DataMessage>(json);
                    await _container.CreateItemAsync(data, new PartitionKey(data.id));

					_logger.LogInformation($"sparade meddelandet: {data}");
				}
				catch (Exception ex)
				{
					_logger.LogError($"Could not save: {ex.Message}");
				}
			}
        }
    }
}