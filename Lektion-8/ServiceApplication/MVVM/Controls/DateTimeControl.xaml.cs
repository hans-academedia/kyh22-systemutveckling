﻿using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ServiceApplication.MVVM.Controls;

public partial class DateTimeControl : UserControl, INotifyPropertyChanged
{
    private string? _currentTime;
    private string? _currentDate;

    public string? CurrentTime { get => _currentTime; set { _currentTime = value; OnPropertyChanged(nameof(CurrentTime));}}
    public string? CurrentDate { get => _currentDate; set { _currentDate = value; OnPropertyChanged(nameof(CurrentDate)); } }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }








    public DateTimeControl()
    {
        InitializeComponent();
        DataContext = this;
        SetDateTime();

        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1),
        };
        timer.Tick += (s, e) => SetDateTime();
        timer.Start();
    }



    private void SetDateTime()
    {
        CurrentTime = DateTime.Now.ToString("HH:mm");
        CurrentDate = DateTime.Now.ToString("dddd, d MMMM yyyy");
    }
}
