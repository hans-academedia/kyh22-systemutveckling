using System.Net.NetworkInformation;

namespace AdvancedDevice.Services;

internal class NetworkManager
{
    private static readonly Ping ping = new();
    private static bool isConnected = false;
    private static int heartbeatInterval = 10000; 

    public static async Task CheckConnectivityAsync()
    {
        while (true)
        {
            isConnected = await SendPingAsync("8.8.8.8");
            Console.WriteLine(isConnected ? "Connected" : "Disconnected");
            await Task.Delay(heartbeatInterval);
        }
    }

    public static async Task<bool> CheckConnectedStateAsync()
    {
        return await SendPingAsync("8.8.8.8");
    }


    private static async Task<bool> SendPingAsync(string ipAddress)
    {
        try
        {
            var reply = await ping.SendPingAsync(ipAddress, 1000, new byte[32], new());
            return reply.Status == IPStatus.Success;

        } catch (Exception ex) { return false; }
    }
}
