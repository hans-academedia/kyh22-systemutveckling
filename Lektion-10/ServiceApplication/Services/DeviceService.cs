using Microsoft.Azure.Devices;
using System.Threading.Tasks;

namespace ServiceApplication.Services;

public class DeviceService
{
	private readonly string _connectionString = "";
	private readonly ServiceClient _serviceClient;

	public DeviceService()
	{
		_serviceClient = ServiceClient.CreateFromConnectionString(_connectionString);
	}

	private async Task GetMessageAsync()
	{

	}
}
