namespace Iot_Shared.Models;

public class MethodDataRequest
{
    public string DeviceId { get; set; } = null!;
    public string MethodName { get; set;} = null!;
    public object? Payload { get; set; }
    public int ResponseTimeout { get; set; } = 30;
}
