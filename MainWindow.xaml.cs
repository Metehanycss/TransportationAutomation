using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TaşımacılıkOtomasyonu;
using TaşımacılıkOtomasyonu.Models;

namespace TaşımacılıkOtomasyonu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(AppDbContext context, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = context;
            _serviceProvider = serviceProvider;
        }

        private void vehicleButton_Click(object sender, RoutedEventArgs e)
        {
            var vehicleWindow = _serviceProvider.GetRequiredService<VehicleWindow>();
            vehicleWindow.Show();
            this.Close();
        }

        private void driverButton_Click(object sender, RoutedEventArgs e)
        {
            var driverWindow = _serviceProvider.GetRequiredService<DriverWindow>();
            driverWindow.Show();
            this.Close();
        }

        private void routeButton_Click(object sender, RoutedEventArgs e)
        {
            var routeWindow = _serviceProvider.GetRequiredService<RouteWindow>();
            routeWindow.Show();
            this.Close();
        }

        private void shipmentButton_Click(object sender, RoutedEventArgs e)
        {
            var shipmentWindow = _serviceProvider.GetRequiredService<ShipmentWindow>();
            shipmentWindow.Show();
            this.Close();
        }
    }
}
