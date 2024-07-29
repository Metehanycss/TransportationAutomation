using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaşımacılıkOtomasyonu.Models;
using Microsoft.Extensions.DependencyInjection;
using TaşımacılıkOtomasyonu.Models;
using TaşımacılıkOtomasyonu;

namespace TaşımacılıkOtomasyonu
{
    public partial class DriverWindow : Window
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public DriverWindow(AppDbContext context, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = context;
            _serviceProvider = serviceProvider;
            LoadData();
        }

        private void LoadData()
        {
            var drivers = _context.Drivers.ToList();
            dataGrid.ItemsSource = drivers;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var driver = new Driver
            {
                Name = nameTextBox.Text,
                LicenseNumber = licenseTextBox.Text,
                BirthDate = DateTime.Parse(birthDateTextBox.Text),
                PhoneNumber = phoneTextBox.Text
            };
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            LoadData();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Driver selectedDriver)
            {
                selectedDriver.Name = nameTextBox.Text;
                selectedDriver.LicenseNumber = licenseTextBox.Text;
                selectedDriver.BirthDate = DateTime.Parse(birthDateTextBox.Text);
                selectedDriver.PhoneNumber = phoneTextBox.Text;
                _context.SaveChanges();
                LoadData();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Driver selectedDriver)
            {
                _context.Drivers.Remove(selectedDriver);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Clear();
            licenseTextBox.Clear();
            birthDateTextBox.Clear();
            phoneTextBox.Clear();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Driver selectedDriver)
            {
                nameTextBox.Text = selectedDriver.Name;
                licenseTextBox.Text = selectedDriver.LicenseNumber;
                birthDateTextBox.Text = selectedDriver.BirthDate.ToString("yyyy-MM-dd");
                phoneTextBox.Text = selectedDriver.PhoneNumber;
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
