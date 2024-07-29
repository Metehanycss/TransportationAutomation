using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaşımacılıkOtomasyonu.Models;
using Microsoft.Extensions.DependencyInjection;
using TaşımacılıkOtomasyonu;

namespace TaşımacılıkOtomasyonu
{
    public partial class VehicleWindow : Window
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public VehicleWindow(AppDbContext context, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = context;
            _serviceProvider = serviceProvider;
            LoadData();
        }

        private void LoadData()
        {
            var vehicles = _context.Vehicles.ToList();
            dataGrid.ItemsSource = vehicles;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var vehicle = new Vehicle
            {
                LicensePlate = licensePlateTextBox.Text,
                Model = modelTextBox.Text,
                Capacity = int.Parse(capacityTextBox.Text),
                Status = statusTextBox.Text
            };
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            LoadData();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Vehicle selectedVehicle)
            {
                selectedVehicle.LicensePlate = licensePlateTextBox.Text;
                selectedVehicle.Model = modelTextBox.Text;
                selectedVehicle.Capacity = int.Parse(capacityTextBox.Text);
                selectedVehicle.Status = statusTextBox.Text;
                _context.SaveChanges();
                LoadData();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Vehicle selectedVehicle)
            {
                _context.Vehicles.Remove(selectedVehicle);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            licensePlateTextBox.Clear();
            modelTextBox.Clear();
            capacityTextBox.Clear();
            statusTextBox.Clear();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Vehicle selectedVehicle)
            {
                licensePlateTextBox.Text = selectedVehicle.LicensePlate;
                modelTextBox.Text = selectedVehicle.Model;
                capacityTextBox.Text = selectedVehicle.Capacity.ToString();
                statusTextBox.Text = selectedVehicle.Status;
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
