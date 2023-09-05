using System;
using System.Text;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctions
{
    public class ViewMessages
    {
        private readonly ILogger<ViewMessages> _logger;

        public ViewMessages(ILogger<ViewMessages> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ViewMessages))]
        public void Run([EventHubTrigger("iothub-ehub-kyh-iothub-25230144-fa41a83a62", Connection = "IotHubEndpoint")] EventData[] events)
        {
            foreach (EventData @event in events)
            {
                var data = Encoding.UTF8.GetString(@event.Body.ToArray());

                _logger.LogInformation("Event Body: {data}", data);
            }
        }
    }
}
