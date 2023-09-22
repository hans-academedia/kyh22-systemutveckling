using Microsoft.Azure.Cosmos;

namespace AzureFunctions.Models;

public class DataMessage
{
	public string id { get; set; } = Guid.NewGuid().ToString();
	public double Temperature { get; set; }
	public double Humidity { get; set; }
	public int _ts { get; set; }
}
