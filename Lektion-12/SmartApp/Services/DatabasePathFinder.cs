using System.ComponentModel.Design;

namespace SmartApp.Services;

public static class DatabasePathFinder
{
	public static string GetPath(string databaseName = "Database.sqlite.db")
	{
		var path = "";

		if (DeviceInfo.Platform == DevicePlatform.Android)
		{
			path = Path.Combine(FileSystem.AppDataDirectory, databaseName);
		
		} 
		else if (DeviceInfo.Platform == DevicePlatform.iOS)
		{
			SQLitePCL.Batteries_V2.Init();
			path = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
				"..", 
				"Library", 
				databaseName);
		} 
		else
		{
			path = databaseName;
		}
		
		return path;
	}
}
