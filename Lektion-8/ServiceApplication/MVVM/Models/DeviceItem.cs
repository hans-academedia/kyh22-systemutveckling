namespace ServiceApplication.MVVM.Models;

public class DeviceItem
{
    public string? DeviceId { get; set; }
    public string? DeviceType { get; set; }
    public string? Placement { get; set; }
    public bool IsActive { get; set; } = false;
    public string? Icon { get; set; } = "\uf2db";
}
