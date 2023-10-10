using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services;
using Microsoft.EntityFrameworkCore;

using var context = new DataContext();
if (!await context.Configurations.AnyAsync())
{
    context.Configurations.Add(new DeviceConfiguration() { DeviceId = "consoledevice" });
    await context.SaveChangesAsync();
}

var deviceManager = new DeviceManager(context);
await deviceManager.InitializeAsync("https://kyh-demo-fa.azurewebsites.net/api/RegisterDevice?code=WTnAt941_ZJToaKNGNT3KKdHYuRNoItz489FCj_Fddi4AzFu5OcvKw==");

