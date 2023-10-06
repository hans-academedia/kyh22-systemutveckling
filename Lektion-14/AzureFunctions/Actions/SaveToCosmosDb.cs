using System;
using System.Text;
using Azure.Messaging.EventHubs;
using AzureFunctions.Contexts;
using Microsoft.Azure.Cosmos.Core;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctions.Actions
{
    public class SaveToCosmosDb
    {
        private readonly CosmosContext _context;

        public SaveToCosmosDb(CosmosContext context)
        {
            _context = context;
        }

        [Function(nameof(SaveToCosmosDb))]
        public async Task Run([EventHubTrigger("iothub-ehub-kyh-iothub-25235613-13f1cd2256", Connection = "IotHubEndpoint")] EventData[] events)
        {
            foreach (EventData @event in events)
            {
                var deviceMessage = new Models.DeviceItemMessage
                {
                    DeviceId = @event.SystemProperties["iothub-connection-device-id"].ToString(),
                    Payload = Encoding.UTF8.GetString(@event.Body.ToArray())
                };
                _context.Messages.Add(deviceMessage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
