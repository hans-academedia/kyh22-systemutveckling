namespace AzureFunctions.Models
{
    public class DeviceItemMessage
    {
        public string? DeviceId { get; set; }
        public string? Payload { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string PartitionKey { get; set; } = "Message";
    }
}
