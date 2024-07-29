using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaşımacılıkOtomasyonu.Models;
using Microsoft.Extensions.DependencyInjection;
using TaşımacılıkOtomasyonu.Models;
using TaşımacılıkOtomasyonu;

namespace TaşımacılıkOtomasyonu
{
    public partial class ShipmentWindow : Window
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public ShipmentWindow(AppDbContext context, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = context;
            _serviceProvider = serviceProvider;
            LoadData();
        }

        private void LoadData()
        {
            var shipments = _context.Shipments.ToList();
            dataGrid.ItemsSource = shipments;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var shipment = new Shipment
            {
                VehicleID = int.Parse(vehicleIdTextBox.Text),
                DriverID = int.Parse(driverIdTextBox.Text),
                RouteID = int.Parse(routeIdTextBox.Text),
                ShipmentDate = DateTime.Parse(shipmentDateTextBox.Text)
            };
            _context.Shipments.Add(shipment);
            _context.SaveChanges();
            LoadData();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Shipment selectedShipment)
            {
                selectedShipment.VehicleID = int.Parse(vehicleIdTextBox.Text);
                selectedShipment.DriverID = int.Parse(driverIdTextBox.Text);
                selectedShipment.RouteID = int.Parse(routeIdTextBox.Text);
                selectedShipment.ShipmentDate = DateTime.Parse(shipmentDateTextBox.Text);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Shipment selectedShipment)
            {
                _context.Shipments.Remove(selectedShipment);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            vehicleIdTextBox.Clear();
            driverIdTextBox.Clear();
            routeIdTextBox.Clear();
            shipmentDateTextBox.Clear();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Shipment selectedShipment)
            {
                vehicleIdTextBox.Text = selectedShipment.VehicleID.ToString();
                driverIdTextBox.Text = selectedShipment.DriverID.ToString();
                routeIdTextBox.Text = selectedShipment.RouteID.ToString();
                shipmentDateTextBox.Text = selectedShipment.ShipmentDate.ToString("yyyy-MM-dd");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            this.Close();
        }
    }
}
