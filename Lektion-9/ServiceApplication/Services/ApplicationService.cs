using System;

namespace ServiceApplication.Services;

public class ApplicationService
{
	public static void CloseApplication()
	{
		Environment.Exit(0);
	}
}
