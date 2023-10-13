using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDevice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataContext _context;

        public MainWindow(DataContext context)
        {
            InitializeComponent();
            _context = context;

            if (!string.IsNullOrEmpty(_context.Configurations.FirstOrDefault()!.DeviceConnectionString))
                ConnectionState.Text = "Device Connected";
            else
                ConnectionState.Text = "Not Connected";
        }


    }
}
