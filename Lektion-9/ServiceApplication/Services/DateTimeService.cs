﻿using System;
using System.Timers;

namespace ServiceApplication.Services;

public class DateTimeService
{
	private readonly Timer _timer;

	public string? CurrentTime { get; private set; }
	public string? CurrentDate { get; private set; }

	public DateTimeService(int interval = 1000)
	{
		SetDateTime();

		_timer = new Timer(interval);
		_timer.Elapsed += (s, e) => SetDateTime();
		_timer.Start();
	}

	private void SetDateTime()
	{
		CurrentTime = DateTime.Now.ToString("HH:mm");
		CurrentDate = DateTime.Now.ToString("dddd, d MMMM yyyy");
	}
}
