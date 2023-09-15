namespace Iot_Shared.Models;

public class IotHubManagerOptions
{
    public string IotHubConnectionString { get; set; } = null!;
    public string EventHubEndpoint { get; set; } = null!;
    public string EventHubName { get; set; } = null!;
    public string ConsumerGroup { get; set; } = null!;
}
