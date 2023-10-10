using ConsoleDevice.Contexts;
using ConsoleDevice.Services;
using Microsoft.EntityFrameworkCore;

using var context = new DataContext();
if (!await context.Configuration.AnyAsync())
{
    context.Configuration.Add(new ConfigurationEntity());
    await context.SaveChangesAsync();
}

var deviceManager = new DeviceManager(context);
await deviceManager.InitializeAsync();

